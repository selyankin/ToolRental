using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Linq;
using System.Data.SqlClient;
using System.Linq;
using ToolsRental;

namespace ToolRental
{
    class MSSQLClient
    {
        public static SqlConnection GetDBConnection()
        {
            var datasource = "RASPBERRY";
            var database = "toolrental";

            var connString = @"Data Source=" + datasource + ";Initial Catalog=" + database + ";Integrated Security=True";

            return new SqlConnection(connString);
        }


        /// <summary>
        /// Add client to database.
        /// </summary>
        /// <param name="client"></param>
        public void AddData(Client client)
        {
            var sqlExpression = @"INSERT INTO Clients (Id, Name, Surname, Patronymic, Sex, City, Street,
Building, Apartment, HomePhone, OfficePhone, CellPhone, Email, Deposit, Balance, Discount, Note, Passport, 
IssueDate, WhoIssuedPassport, ResidenceAddress) 
VALUES (@Id, @Name, @Surname, @Patronymic, @Sex, @City, @Street,
@Building, @Apartment, @HomePhone, @OfficePhone, @CellPhone, @Email, @Deposit, @Balance, @Discount, @Note, @Passport, 
@IssueDate, @WhoIssuedPassport, @ResidenceAddress)";


            using (var conn = GetDBConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlExpression, conn);

                var idParam = new SqlParameter("@Id", client.Id);
                var nameParam = new SqlParameter("@Name", client.Name);
                var surnameParam = new SqlParameter("@Surname", client.Surname);
                var patronymicParam = new SqlParameter("@Patronymic", client.Patronymic ?? (object)DBNull.Value);

                var sexParam = new SqlParameter("@Sex", client.Sex);
                var cityParam = new SqlParameter("@City", client.City);
                var streetParam = new SqlParameter("@Street", client.Street ?? (object)DBNull.Value);

                var buildingParam = new SqlParameter("@Building", client.Building ?? (object)DBNull.Value);
                var apartmentParam = new SqlParameter("@Apartment", client.Apartment ?? (object)DBNull.Value);
                var homePhoneParam = new SqlParameter("@HomePhone", client.HomePhone ?? (object)DBNull.Value);
                var officePhoneParam = new SqlParameter("@OfficePhone", client.OfficePhone ?? (object)DBNull.Value);
                var cellPhoneParam = new SqlParameter("@CellPhone", client.CellPhone ?? (object)DBNull.Value);
                var emailParam = new SqlParameter("@Email", client.Email ?? (object)DBNull.Value);

                var depositParam = new SqlParameter("@Deposit", client.Deposit);
                var balanceParam = new SqlParameter("@Balance", client.Balance);
                var discountParam = new SqlParameter("@Discount", client.Discount);
                var noteParam = new SqlParameter("@Note", client.Note ?? (object)DBNull.Value);
                var passPortParam = new SqlParameter("@Passport", client.Passport);

                var issueDateParam = new SqlParameter("@IssueDate", client.IssueDate);
                var whoIssuedPassportParam = new SqlParameter("@WhoIssuedPassport", client.WhoIssuedPassport ?? (object)DBNull.Value);
                var residenceAddressParam = new SqlParameter("@ResidenceAddress", client.ResidenceAddress ?? (object)DBNull.Value);

                cmd.Parameters.Add(idParam);
                cmd.Parameters.Add(nameParam);
                cmd.Parameters.Add(surnameParam);
                cmd.Parameters.Add(patronymicParam);

                cmd.Parameters.Add(sexParam);
                cmd.Parameters.Add(cityParam);
                cmd.Parameters.Add(streetParam);

                cmd.Parameters.Add(buildingParam);
                cmd.Parameters.Add(apartmentParam);
                cmd.Parameters.Add(homePhoneParam);
                cmd.Parameters.Add(officePhoneParam);
                cmd.Parameters.Add(cellPhoneParam);
                cmd.Parameters.Add(emailParam);

                cmd.Parameters.Add(depositParam);
                cmd.Parameters.Add(balanceParam);
                cmd.Parameters.Add(discountParam);
                cmd.Parameters.Add(noteParam);
                cmd.Parameters.Add(passPortParam);

                cmd.Parameters.Add(issueDateParam);
                cmd.Parameters.Add(whoIssuedPassportParam);
                cmd.Parameters.Add(residenceAddressParam);

                cmd.ExecuteNonQuery();
            }
        }


        /// <summary>
        /// Add tool to database.
        /// </summary>
        /// <param name="tool"></param>
        public void AddData(Tool tool)
        {
            var sqlExpression = @"INSERT INTO Tools (Id, Name, Price, Note, PathToPicture) VALUES (@Id, @Name, @Price, @Note, @PathToPicture)";

            using (var conn = MSSQLClient.GetDBConnection())
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(sqlExpression, conn);

                var idParam = new SqlParameter("@Id", tool.Id);
                var nameParam = new SqlParameter("@Name", tool.Name);
                var priceParam = new SqlParameter("@Price", tool.Price);
                var noteParam = new SqlParameter("@Note", tool.Note ?? (object)DBNull.Value);
                var pathParam = new SqlParameter("@PathToPicture", DBNull.Value);

                cmd.Parameters.Add(idParam);
                cmd.Parameters.Add(nameParam);
                cmd.Parameters.Add(priceParam);
                cmd.Parameters.Add(noteParam);
                cmd.Parameters.Add(pathParam);

                cmd.ExecuteNonQuery();
            }
        }


        public DataTable GetDatabase(string dbName)
        {
            var sqlExpression = $"SELECT * FROM {dbName}";

            using (var conn = GetDBConnection())
            {
                conn.Open();
                var adapter = new SqlDataAdapter(sqlExpression, conn);

                var ds = new DataSet();
                adapter.Fill(ds);

                return ds.Tables[0];
            }
        }


        public IEnumerable<Client> FindNaturalPersons(List<int> indexes)
        {
            var datasource = "RASPBERRY";
            var database = "toolrental";

            var connString = @"Data Source=" + datasource + ";Initial Catalog=" + database + ";Integrated Security=SSPI";

            var db = new DataContext(connString);

            var clients = db.GetTable<Client>();

            return from c in clients
                where indexes.Contains(c.Id)
                select c;
        }
    }
}
