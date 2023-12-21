using EmployeeTaskTrackerDB.ClassesWithTableFields;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;



namespace EmployeeTaskTrackerDB
{
    internal class RequestSQL
    {
        private readonly string connectionString = "Server=localhost;Port=5432;User Id=postgres; Password=0000;Database=EmployeeTaskTracker";

        /// <summary>
        /// Вход в систему
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <param name="accessLevel"></param>
        /// <returns></returns>
        public bool AuthenticateUser(string login, string password, out bool userFound)
        {
            bool accessLevel = false; // false может быть использовано для обозначения неудачной аутентификации
            userFound = false; // Переменная, которая будет указывать, найден ли пользователь в базе данных

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                string sqlQuery = "SELECT access_level FROM public.users WHERE username = @username AND password_hash = @password";

                using (var cmd = new NpgsqlCommand(sqlQuery, conn))
                {
                    cmd.Parameters.AddWithValue("@username", login);
                    cmd.Parameters.AddWithValue("@password", password);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Если запись найдена, устанавливаем уровень доступа, устанавливаем userFound в true и возвращаем true
                            accessLevel = reader.GetBoolean(reader.GetOrdinal("access_level"));
                            userFound = true;
                            return accessLevel;
                        }
                    }
                }
            }

            return false; // Возвращаем false, если аутентификация неудачна
        }

        /// <summary>
        /// Сделать сотрудника не активным
        /// </summary>
        /// <param name="employeeId"></param>
        public void DeactivateEmployee(int employeeId)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                string sqlQuery = "UPDATE public.employees SET is_active = @isActive WHERE employee_id = @employeeId";

                using (var cmd = new NpgsqlCommand(sqlQuery, conn))
                {
                    // Параметры запроса
                    cmd.Parameters.AddWithValue("@isActive", false);
                    cmd.Parameters.AddWithValue("@employeeId", employeeId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Добавить ID сотрудника к ID задаче
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="employeeId"></param>
        public void AssignTaskToEmployee(int taskId, int employeeId)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                // Вставляем новую запись в taskuser без проверки на существование, 
                // так как одна задача может быть назначена многим сотрудникам
                using (var cmd = new NpgsqlCommand("INSERT INTO taskuser (task_id, employee_id) VALUES (@TaskId, @EmployeeId)", conn))
                {
                    cmd.Parameters.AddWithValue("@TaskId", taskId);
                    cmd.Parameters.AddWithValue("@EmployeeId", employeeId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Получить дополнительную информацию о сотруднике
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public EmployeeDetails GetEmployeeDetailsById(int employeeId)
        {
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                // SQL-запрос для получения дополнительной информации о сотруднике
                string sql = @"
                    SELECT 
                        p.passport_number, 
                        p.passport_issue_date, 
                        p.passport_issue_code, 
                        s.base_salary, 
                        s.over_salary_amount, 
                        s.over_salary_period, 
                        COUNT(b.bonuses_id) AS amount_of_bonuses, 
                        MAX(b.date) AS date_of_bonuses, 
                        e.date_joined
                    FROM employees e
                    LEFT JOIN passport p ON e.employee_id = p.employee_id
                    LEFT JOIN salary s ON e.employee_id = s.employee_id
                    LEFT JOIN bonuses b ON e.employee_id = b.employee_id
                    WHERE e.employee_id = @EmployeeId
                    GROUP BY e.employee_id, p.passport_number, p.passport_issue_date, 
                        p.passport_issue_code, s.base_salary, s.over_salary_amount, 
                        s.over_salary_period, e.date_joined";

                using (var command = new NpgsqlCommand(sql, connection))
                {
                    command.Parameters.AddWithValue("@EmployeeId", employeeId);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            return new EmployeeDetails
                            {
                                PassportNumber = reader["passport_number"].ToString(),
                                PassportIssueDate = reader["passport_issue_date"].ToString(),
                                PassportIssueCode = reader["passport_issue_code"].ToString(),
                                BaseSalary = Convert.IsDBNull(reader["base_salary"]) ? 0 : Convert.ToInt32(reader["base_salary"]),
                                OverSalaryAmount = Convert.IsDBNull(reader["over_salary_amount"]) ? 0 : Convert.ToInt32(reader["over_salary_amount"]),
                                OverSalaryPeriod = reader["over_salary_period"].ToString(),
                                AmountOfBonuses = Convert.IsDBNull(reader["amount_of_bonuses"]) ? 0 : Convert.ToInt32(reader["amount_of_bonuses"]),
                                DateOfBonuses = reader["date_of_bonuses"].ToString(),
                                DateJoined = reader["date_joined"].ToString()
                            };
                        }
                    }

                    // В случае, если сотрудник не найден, возвращаем null
                    return null;

                }
            }
        }

        /// <summary>
        /// Выбрать все задачи у определенного проекта
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public List<Value> GetTasksByProjectId(int projectId)
        {
            List<Value> tasksList = new List<Value>();

            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand("SELECT * FROM tasks WHERE project_id = @ProjectId", conn))
                {
                    cmd.Parameters.AddWithValue("@ProjectId", projectId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var task = new Value
                            {
                                Id = reader.GetInt32(reader.GetOrdinal("task_id")),
                                Name = reader.IsDBNull(reader.GetOrdinal("task_name")) ? null : reader.GetString(reader.GetOrdinal("task_name")),
                            };
                            tasksList.Add(task);
                        }
                    }
                }
            }

            return tasksList;
        }

        /// <summary>
        /// Узнать имя проекта по Id
        /// </summary>
        /// <param name="projectId"></param>
        /// <returns></returns>
        public string GetProjectNameById(int projectId)
        {
            string projectName = string.Empty;
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();
                using (var cmd = new NpgsqlCommand("SELECT project_name FROM projects WHERE project_id = @ProjectId", conn))
                {
                    cmd.Parameters.AddWithValue("@ProjectId", projectId);

                    var result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        projectName = result.ToString();
                    }
                }
            }
            return projectName;
        }

        /// <summary>
        /// Считать все задачи у определенного сотрудника
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public List<Tasks> GetTasksByEmployeeId(int employeeId)
        {
            var tasks = new List<Tasks>();
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "SELECT t.task_id, t.task_name, t.description, t.project_id FROM tasks t INNER JOIN taskuser tu ON t.task_id = tu.task_id WHERE tu.employee_id = @EmployeeId;";
                    cmd.Parameters.AddWithValue("@EmployeeId", employeeId);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            var task = new Tasks
                            {
                                TaskId = reader.GetInt32(reader.GetOrdinal("task_id")),
                                TaskName = reader.IsDBNull(reader.GetOrdinal("task_name")) ? null : reader.GetString(reader.GetOrdinal("task_name")),
                                Description = reader.IsDBNull(reader.GetOrdinal("description")) ? null : reader.GetString(reader.GetOrdinal("description")),
                                ProjectId = reader.IsDBNull(reader.GetOrdinal("project_id")) ? 0 : reader.GetInt32(reader.GetOrdinal("project_id"))
                            };
                            tasks.Add(task);
                        }
                    }
                }
            }
            return tasks;
        }

        /// <summary>
        /// Добавить задачу
        /// </summary>
        /// <param name="task"></param>
        public void AddTask(Tasks task)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO tasks (task_name, description, project_id) VALUES (@TaskName, @Description, @ProjectId) RETURNING task_id;";
                    cmd.Parameters.AddWithValue("@TaskName", task.TaskName);
                    cmd.Parameters.AddWithValue("@Description", task.Description);
                    cmd.Parameters.AddWithValue("@ProjectId", task.ProjectId);

                    // Выполнение команды и получение сгенерированного ID
                    int generatedId = (int)cmd.ExecuteScalar();
                    task.TaskId = generatedId; // Предполагается, что у вас есть свойство TaskId в классе Tasks

                    // Добавление связи задачи и сотрудника, если Id сотрудника задан
                    if (task.EmployeeId > 0)
                    {
                        AddTaskUser(task.TaskId, task.EmployeeId);
                    }
                }
            }
        }

        /// <summary>
        /// Добавить связь задача и сотрудник
        /// </summary>
        /// <param name="taskId"></param>
        /// <param name="employeeId"></param>
        private void AddTaskUser(int taskId, int employeeId)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO taskuser (task_id, employee_id) VALUES (@TaskId, @EmployeeId);";
                    cmd.Parameters.AddWithValue("@TaskId", taskId);
                    cmd.Parameters.AddWithValue("@EmployeeId", employeeId);

                    cmd.ExecuteNonQuery();
                }
            }
        }

        /// <summary>
        /// Добавить бонусы
        /// </summary>
        /// <param name="bonus"></param>
        /// <param name="employeeId"></param>
        public void AddBonuses(ref Bonuses bonus, int employeeId)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO bonuses (employee_id, amount, date) VALUES (@EmployeeId, @Amount, @Date) RETURNING bonuses_id;";
                    cmd.Parameters.AddWithValue("@EmployeeId", employeeId);
                    cmd.Parameters.AddWithValue("@Amount", bonus.Amount);
                    cmd.Parameters.AddWithValue("@Date", bonus.Date); // Убедитесь, что дата в правильном формате

                    // Выполнение команды и получение сгенерированного ID
                    int generatedId = (int)cmd.ExecuteScalar();
                    bonus.BonusesId = generatedId; // Предполагается наличие свойства BonusesId
                }
            }
        }

        /// <summary>
        /// Добавить зарплату
        /// </summary>
        /// <param name="salary"></param>
        /// <param name="employeeId"></param>
        public void AddSalary(ref Salarys salary, int employeeId)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO salary (employee_id, base_salary, over_salary_amount, over_salary_period) VALUES (@EmployeeId, @BaseSalary, @OverSalaryAmount, @OverSalaryPeriod) RETURNING salary_id;";
                    cmd.Parameters.AddWithValue("@EmployeeId", employeeId);
                    cmd.Parameters.AddWithValue("@BaseSalary", salary.BaseSalary);
                    cmd.Parameters.AddWithValue("@OverSalaryAmount", salary.OverSalaryAmount);
                    cmd.Parameters.AddWithValue("@OverSalaryPeriod", salary.OverSalaryPeriod); // Убедитесь, что дата в правильном формате

                    // Выполнение команды и получение сгенерированного ID
                    int generatedId = (int)cmd.ExecuteScalar();
                    salary.SalaryId = generatedId; // Предполагается наличие свойства SalaryId
                }
            }
        }

        /// <summary>
        /// Добавить паспорт
        /// </summary>
        /// <param name="passport"></param>
        /// <param name="employeeId"></param>
        public void AddPassport(ref Passports passport, int employeeId)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO passport (employee_id, passport_number, passport_issue_date, passport_issue_code) VALUES (@EmployeeId, @PassportNumber, @PassportIssueDate, @PassportIssueCode) RETURNING passport_id;";
                    cmd.Parameters.AddWithValue("@EmployeeId", employeeId);
                    cmd.Parameters.AddWithValue("@PassportNumber", passport.PassportNumber);
                    cmd.Parameters.AddWithValue("@PassportIssueDate", passport.PassportIssueDate);
                    cmd.Parameters.AddWithValue("@PassportIssueCode", passport.PassportIssueCode);

                    // Выполнение команды и получение сгенерированного ID
                    int generatedId = (int)cmd.ExecuteScalar();
                    passport.PassportId = generatedId; // Предполагаем, что есть свойство PassportId
                }
            }
        }

        /// <summary>
        /// Добавление сотрудника
        /// </summary>
        /// <param name="employee"></param>
        public void AddEmployee(ref Employees employee)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO employees (last_name, first_name, middle_name, email, phone_number, date_joined, department_id, position_id, address_id, date_of_birth) VALUES (@LastName, @FirstName, @MiddleName, @Email, @PhoneNumber, @DateJoined, @DepartmentId, @PositionId, @AddressId, @DateOfBirth) RETURNING employee_id;";
                    cmd.Parameters.AddWithValue("@LastName", employee.LastName);
                    cmd.Parameters.AddWithValue("@FirstName", employee.FirstName);
                    cmd.Parameters.AddWithValue("@MiddleName", employee.MiddleName);
                    cmd.Parameters.AddWithValue("@Email", employee.Email);
                    cmd.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
                    cmd.Parameters.AddWithValue("@DateJoined", employee.DataJoined);
                    cmd.Parameters.AddWithValue("@DepartmentId", employee.DepartmentId);
                    cmd.Parameters.AddWithValue("@PositionId", employee.PositionId);
                    cmd.Parameters.AddWithValue("@AddressId", employee.AddressId);
                    cmd.Parameters.AddWithValue("@DateOfBirth", employee.DateOfBirth);

                    // Выполнение команды и получение сгенерированного ID
                    int generatedId = (int)cmd.ExecuteScalar();
                    employee.EmployeeID = generatedId;
                }
            }
        }

        /// <summary>
        /// Добавить адрес
        /// </summary>
        /// <param name="address"></param>
        public void AddAddress(ref Addresses address)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO addresses (city_id, street, house_number, apartment_number, postal_code) VALUES (@CityId, @Street, @HouseNumber, @ApartmentNumber, @PostalCode) RETURNING address_id;";
                    cmd.Parameters.AddWithValue("@CityId", address.CityId);
                    cmd.Parameters.AddWithValue("@Street", address.Street);
                    cmd.Parameters.AddWithValue("@HouseNumber", address.HouseNumber);
                    cmd.Parameters.AddWithValue("@ApartmentNumber", address.ApartmentNumber);
                    cmd.Parameters.AddWithValue("@PostalCode", address.PostalCode);

                    // Выполнение команды и получение сгенерированного ID
                    int generatedId = (int)cmd.ExecuteScalar();
                    address.AddressId = generatedId; // Предполагаем, что есть свойство AddressId
                }
            }
        }

        /// <summary>
        /// Выбрать всю информацию о сотруднике, зная его Id
        /// </summary>
        /// <param name="employeeId"></param>
        /// <returns></returns>
        public EmployeeInfo GetEmployee(int employeeId)
        {
            var employee = new EmployeeInfo();

            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                var query = @"
                    SELECT 
                        e.first_name, e.last_name, e.middle_name, 
                        p.passport_number, p.passport_issue_date, p.passport_issue_code, 
                        e.date_of_birth, e.email, e.phone_number, e.date_joined, 
                        d.department_name, pos.position_name, 
                        c.city_name, r.region_name, co.country_name, 
                        a.street, a.house_number, a.apartment_number, a.postal_code
                    FROM employees e
                    LEFT JOIN passport p ON e.employee_id = p.employee_id
                    LEFT JOIN addresses a ON e.address_id = a.address_id
                    LEFT JOIN cities c ON a.city_id = c.city_id
                    LEFT JOIN regions r ON c.region_id = r.region_id
                    LEFT JOIN countries co ON r.country_id = co.country_id
                    LEFT JOIN departments d ON e.department_id = d.department_id
                    LEFT JOIN positions pos ON e.position_id = pos.position_id
                    WHERE e.employee_id = @employeeId";

                using (var command = new NpgsqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@employeeId", employeeId);

                    using (var reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            employee.FirstName = reader["first_name"].ToString();
                            employee.LastName = reader["last_name"].ToString();
                            employee.MiddleName = reader["middle_name"].ToString();
                            employee.PassportNumber = reader["passport_number"].ToString();
                            employee.PassportIsueDate = reader["passport_issue_date"].ToString();
                            employee.PassportIsueCode = reader["passport_issue_code"].ToString();
                            employee.DateOfBirth = reader["date_of_birth"].ToString();
                            employee.Email = reader["email"].ToString();
                            employee.PhoneNumber = reader["phone_number"].ToString();
                            employee.DataJoined = reader["date_joined"].ToString();
                            employee.Department = reader["department_name"].ToString();
                            employee.Position = reader["position_name"].ToString();
                            employee.Country = reader["country_name"].ToString();
                            employee.Region = reader["region_name"].ToString();
                            employee.City = reader["city_name"].ToString();
                            employee.Street = reader["street"].ToString();
                            employee.HouseNumber = reader["house_number"].ToString();
                            employee.ApartmentNumber = reader["apartment_number"].ToString();
                            employee.PostalCode = reader["postal_code"].ToString();
                        }
                    }
                }
            }

            return employee;
        }

        /// <summary>
        /// Выбрать всех активных сотрудников из БД
        /// </summary>
        /// <param name="employees"></param>
        /// <returns></returns>
        public List<FullNameEmployee> SelectEmployees()
        {
            List<FullNameEmployee> employees = new List<FullNameEmployee>();
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();

                // Добавлено условие WHERE is_active = true OR is_active IS NULL
                var command = new NpgsqlCommand("SELECT employee_id, first_name, last_name, middle_name FROM employees WHERE is_active = true OR is_active IS NULL", connection);

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        employees.Add(new FullNameEmployee
                        (
                            (int)reader["employee_id"],
                            reader["first_name"].ToString(),
                            reader["last_name"].ToString(),
                            reader["middle_name"].ToString()
                        ));
                    }
                }
            }
            return employees;
        }

        /// <summary>
        /// Выбрать всех сотрудников у которых ФИО начинается на определенные символы
        /// </summary>
        /// <param name="startWith"></param>
        /// <param name="employees"></param>
        /// <returns></returns>
        public void SelectEmployees(string startWith, ref List<FullNameEmployee> employees)
        {
            //employees = new List<FullNameEmployee>();
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                // Добавляем параметры поиска с помощью оператора LIKE
                var command = new NpgsqlCommand("SELECT employee_id, first_name, last_name, middle_name FROM employees WHERE first_name LIKE @startWithPattern OR last_name LIKE @startWithPattern OR middle_name LIKE @startWithPattern", connection);
                // Устанавливаем значение параметра с символом подстановки
                command.Parameters.AddWithValue("@startWithPattern", startWith + "%");

                using (var reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        employees.Add(new FullNameEmployee
                        (
                            (int)reader["employee_id"],
                            reader["first_name"].ToString(),
                            reader["last_name"].ToString(),
                            reader["middle_name"].ToString()
                        ));
                    }
                }
            }
        }

        /// <summary>
        /// Добавить проект
        /// </summary>
        /// <param name="project"></param>
        public void AddProject(Value project)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO projects (project_name) VALUES (@projectName) RETURNING project_id;";
                    cmd.Parameters.AddWithValue("@projectName", project.Name ?? string.Empty);

                    // Выполнение команды и получение сгенерированного ID
                    int generatedId = (int)cmd.ExecuteScalar();
                    project.Id = generatedId;
                }
            }
        }

        /// <summary>
        /// Создать отдел
        /// </summary>
        /// <param name="value"></param>
        public void AddDepartment(Value value)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO departments (department_name) VALUES (@departmentName) RETURNING department_id;";
                    cmd.Parameters.AddWithValue("@departmentName", value.Name ?? string.Empty);

                    // Выполнение команды и получение сгенерированного ID
                    int generatedId = (int)cmd.ExecuteScalar();
                    value.Id = generatedId;
                }
            }
        }

        /// <summary>
        /// Создать должность
        /// </summary>
        /// <param name="value"></param>
        public void AddPosition(Value value)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO positions (position_name) VALUES (@positionName) RETURNING position_id;";
                    cmd.Parameters.AddWithValue("@positionName", value.Name ?? string.Empty);

                    // Выполнение команды и получение сгенерированного ID
                    int generatedId = (int)cmd.ExecuteScalar();
                    value.Id = generatedId;
                }
            }
        }

        /// <summary>
        /// Создать страну
        /// </summary>
        /// <param name="department"></param>
        public void AddCountry(Value department)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO countries (country_name) VALUES (@countryName) RETURNING country_id;";
                    cmd.Parameters.AddWithValue("@countryName", department.Name ?? string.Empty);

                    // Выполнение команды и получение сгенерированного ID
                    int generatedId = (int)cmd.ExecuteScalar();
                    department.Id = generatedId;
                }
            }
        }

        /// <summary>
        /// Добавить область зная к какой стране она относится
        /// </summary>
        /// <param name="region"></param>
        /// <param name="countryId"></param>
        public void AddRegion(Value region, int countryId)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO regions (region_name, country_id) VALUES (@regionName, @countryId) RETURNING region_id;";
                    cmd.Parameters.AddWithValue("@regionName", region.Name ?? string.Empty);
                    cmd.Parameters.AddWithValue("@countryId", countryId);

                    // Выполнение команды и получение сгенерированного ID
                    int generatedId = (int)cmd.ExecuteScalar();
                    region.Id = generatedId;
                }
            }
        }

        /// <summary>
        /// добавить город зная к какому регионы он относится
        /// </summary>
        /// <param name="city"></param>
        /// <param name="regionId"></param>
        public void AddCity(Value city, int regionId)
        {
            using (var conn = new NpgsqlConnection(connectionString))
            {
                conn.Open();

                using (var cmd = new NpgsqlCommand())
                {
                    cmd.Connection = conn;
                    cmd.CommandText = "INSERT INTO cities (city_name, region_id) VALUES (@cityName, @regionId) RETURNING city_id;";
                    cmd.Parameters.AddWithValue("@cityName", city.Name ?? string.Empty);
                    cmd.Parameters.AddWithValue("@regionId", regionId);

                    // Выполнение команды и получение сгенерированного ID
                    int generatedId = (int)cmd.ExecuteScalar();
                    city.Id = generatedId;
                }
            }
        }

        /// <summary>
        /// Выбрать все отделы
        /// </summary>
        /// <returns></returns>
        public List<Value> SelectDepartment()
        {
            var department = new List<Value>();
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand("SELECT department_id, department_name FROM departments", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader["department_id"] as int? ?? 0;
                            string name = reader["department_name"].ToString();
                            department.Add(new Value(id, name));
                        }
                    }
                }
            }
            return department;
        }

        /// <summary>
        /// Выбрать все проекты
        /// </summary>
        /// <returns></returns>
        public List<Value> SelectProjects()
        {
            var projects = new List<Value>();
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand("SELECT project_id, project_name FROM projects", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader["project_id"] as int? ?? 0;
                            string name = reader["project_name"].ToString();
                            projects.Add(new Value(id, name));
                        }
                    }
                }
            }
            return projects;
        }

        /// <summary>
        /// Выбрать все должности 
        /// </summary>
        /// <returns></returns>
        public List<Value> SelectPosition()
        {
            var position = new List<Value>();
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand("SELECT position_id, position_name FROM positions", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader["position_id"] as int? ?? 0;
                            string name = reader["position_name"].ToString();
                            position.Add(new Value(id, name));
                        }
                    }
                }
            }
            return position;
        }

        /// <summary>
        /// Выбрать все страны
        /// </summary>
        /// <returns></returns>
        public List<Value> SelectCountry()
        {
            var countries = new List<Value>();
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand("SELECT country_id, country_name FROM countries", connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader["country_id"] as int? ?? 0;
                            string name = reader["country_name"].ToString();
                            countries.Add(new Value(id, name));
                        }
                    }
                }
            }
            return countries;
        }

        /// <summary>
        /// Выбрать все области зная страну
        /// </summary>
        /// <param name="countryId"></param>
        /// <returns></returns>
        public List<Value> SelectRegionsByCountryId(int countryId)
        {
            var regions = new List<Value>();
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand("SELECT region_id, region_name FROM regions WHERE country_id = @CountryId", connection))
                {
                    command.Parameters.AddWithValue("@CountryId", countryId);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader["region_id"] as int? ?? 0;
                            string name = reader["region_name"].ToString();
                            regions.Add(new Value(id, name));
                        }
                    }
                }
            }
            return regions;
        }

        /// <summary>
        /// Выбрать все города зная регион
        /// </summary>
        /// <param name="regionId"></param>
        /// <returns></returns>
        public List<Value> SelectCitiesByRegionId(int regionId)
        {
            var cities = new List<Value>();
            using (var connection = new NpgsqlConnection(connectionString))
            {
                connection.Open();
                using (var command = new NpgsqlCommand("SELECT city_id, city_name FROM cities WHERE region_id = @RegionId", connection))
                {
                    command.Parameters.AddWithValue("@RegionId", regionId);

                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            int id = reader["city_id"] as int? ?? 0;
                            string name = reader["city_name"].ToString();
                            cities.Add(new Value(id, name));
                        }
                    }
                }
            }
            return cities;
        }
    }
}
