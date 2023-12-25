using FirebirdSql.Data.FirebirdClient;
using System;
using System.Data;
using otdelkadrov.Models;
using System.Data.SqlClient;

namespace otdelkadrov
{
    class DataBase
    {
        public void Insert(string query, RequestType requestType)
        {
            string connectionString = @"User=SYSDBA;Password=masterkey;Database=D:\order1 2\order1\Database\humanResourcesDepartment.fdb;DataSource=localhost;Port=3050;";
            string insertQuery = "INSERT INTO AVTORIZACIYA (LOGIN, PAROL) VALUES (@log, @pass)";

            using (FbConnection connection = new FbConnection(connectionString))
            {
                connection.Open();

                using (FbCommand command = new FbCommand(insertQuery, connection))
                {
                    command.Parameters.AddWithValue("@log", "Suomenvoimat1999");
                    command.Parameters.AddWithValue("@pass", "sisu1111");

                    command.ExecuteNonQuery();
                }

                connection.Close();
            }
        }

        public Chapter Select(string query, RequestType requestType, out int lastId)
        {
            Chapter operation = new Chapter();
            lastId = 0;

            string connectionString = @"User=SYSDBA;Password=masterkey;Database=D:\order1 2\order1\Database\humanResourcesDepartment.fdb;DataSource=localhost;Port=3050;";

            using (FbConnection connection = new FbConnection(connectionString))
            {
                connection.Open();

                using (FbCommand command = new FbCommand(query, connection))
                {
                    using (var reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if(requestType == RequestType.GetLoginAndPassword)
                            {
                                
                            }
                        }
                    }

                    if (requestType == RequestType.None)
                    {
                        lastId = Convert.ToInt32(command.ExecuteScalar());
                    }
                }
            }

            return operation;
        }

     

        public void AddNewEmpoloyee(Employee employee)
        {


            string connectionString = @"User=SYSDBA;Password=masterkey;Database=D:\order1 2\order1\Database\humanResourcesDepartment.fdb;DataSource=localhost;Port=3050;";

            using (FbConnection connection = new FbConnection(connectionString))
            {
                connection.Open();

                string passport = @"INSERT INTO PASPORT (SERIYA, NOMER, KEMVIDAN, KOGDAVIDAN, NOMERPODRAZDELENIYA)
                  VALUES (@seria, @number, @byIssued, @dateIssue, @departmentNumber)";

                string propiska = @"INSERT INTO PROPISKA (STRANA, OBLAST, GOROD, ULICA, DOM, KVARTIRA)
                  VALUES (@country, @state, @city, @street, @house, @flat)";

                string position = @"INSERT INTO DOLJNOST (NAZVANIEDOLJNOSTI)
                  VALUES (@positionName)";

                string department = @"INSERT INTO OTDEL (NAZVANIEOTDELA)
                  VALUES (@departmentName)";

                string laborActivity = @"INSERT INTO TRUDOVAYADEYATELNOST (DATAPRIEMANARABOTU, ZARPLATA, ID_DOLJNOSTI, ID_OTDELA)
                  VALUES (@dateEmpl, @salary, @pos_id, @dep_id)";

                string newEmployeer = @"INSERT INTO SOTRUDNIKI (FAMILIYA, IMYA, OTCHESTVO, DATAROZHDENIYA, NOMERTELEPHONA, NOMERBANKOVSKOYKARTI, ID_TRUDOVOYDEYATELNOSTI, ID_PASPORTA, ID_PROPISKI, PHOTO)
                  VALUES (@surname, @name, @fathersName, @birthDay, @phoneNumber, @bankCardNumber, @empl_id, @pass_id, @address_id, @photo)";



                using (FbCommand command1 = new FbCommand(passport, connection))
                {
                    command1.Parameters.AddWithValue("@seria", employee.PassSerial);
                    command1.Parameters.AddWithValue("@number", employee.PassNumber);
                    command1.Parameters.AddWithValue("@byIssued", employee.IssuedBy);
                    command1.Parameters.AddWithValue("@dateIssue", employee.IssueDate);
                    command1.Parameters.AddWithValue("@departmentNumber", employee.DepartmentNumber);

                    command1.ExecuteNonQuery();
                }

                using (FbCommand command2 = new FbCommand(propiska, connection))
                {
                    command2.Parameters.AddWithValue("@country", employee.Country);
                    command2.Parameters.AddWithValue("@state", employee.State);
                    command2.Parameters.AddWithValue("@city", employee.City);
                    command2.Parameters.AddWithValue("@street", employee.Street);
                    command2.Parameters.AddWithValue("@house", employee.House);
                    command2.Parameters.AddWithValue("@flat", employee.Flat);

                    command2.ExecuteNonQuery();
                }

                using (FbCommand command3 = new FbCommand(position, connection))
                {
                    command3.Parameters.AddWithValue("@positionName", employee.Position);

                    command3.ExecuteNonQuery();
                }

                using (FbCommand command4 = new FbCommand(department, connection))
                {
                    command4.Parameters.AddWithValue("@departmentName", employee.Department);

                    command4.ExecuteNonQuery();
                }

                Select("SELECT MAX(ID_DOLJNOSTI) FROM DOLJNOST", RequestType.None, out int positionLastId);
                Select("SELECT MAX(ID_OTDELA) FROM OTDEL", RequestType.None, out int departmentLastId);

                using (FbCommand command5 = new FbCommand(laborActivity, connection))
                {
                    command5.Parameters.AddWithValue("@dateEmpl", employee.EmploymentDate);
                    command5.Parameters.AddWithValue("@salary", employee.Rate);
                    command5.Parameters.AddWithValue("@pos_id", positionLastId);
                    command5.Parameters.AddWithValue("@dep_id", departmentLastId);

                    command5.ExecuteNonQuery();
                }

                Select("SELECT MAX(ID_TRUDOVOYDEYATELNOSTI) FROM TRUDOVAYADEYATELNOST", RequestType.None, out int emlLastId);
                Select("SELECT MAX(ID_PASPORTA) FROM PASPORT", RequestType.None, out int passLastId);
                Select("SELECT MAX(ID_PROPISKI) FROM PROPISKA", RequestType.None, out int addressLastId);

                using (FbCommand command6 = new FbCommand(newEmployeer, connection))
                {
                    
                    command6.Parameters.AddWithValue("@surname", employee.Surname);
                    command6.Parameters.AddWithValue("@name", employee.Name);
                    command6.Parameters.AddWithValue("@fathersName", employee.FatherName);
                    command6.Parameters.AddWithValue("@birthDay", employee.BirthDay);
                    command6.Parameters.AddWithValue("@phoneNumber", employee.PhoneNumber);
                    command6.Parameters.AddWithValue("@bankCardNumber", employee.BankCardNumber);
                    command6.Parameters.AddWithValue("@empl_id", emlLastId);
                    command6.Parameters.AddWithValue("@pass_id", passLastId);
                    command6.Parameters.AddWithValue("@address_id", addressLastId);
                    command6.Parameters.AddWithValue("@photo", employee.Photo);


                    command6.ExecuteNonQuery();
                }
            }
        }
        public void DeleteEmployee(int employeeID)
        {
            string connectionString = @"User=SYSDBA;Password=masterkey;Database=D:\order1 2\order1\Database\humanResourcesDepartment.fdb;DataSource=localhost;Port=3050;";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string query = "DELETE FROM Employees WHERE ID = @empl_id";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@empl_id", employeeID);
                    command.ExecuteNonQuery();
                }
            }
        }
        internal Employee GetEmployeeById(string id)
        {
            throw new NotImplementedException();
        }
    }
}
