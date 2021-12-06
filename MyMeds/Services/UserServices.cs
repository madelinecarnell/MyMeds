using System.Data;

using Dapper;

using Microsoft.Data.SqlClient;

using MyMeds.Models;

namespace MyMeds.Services
{
    public class UserServices : IUserServices
    {
        private readonly SqlConnection _connection = new("Server=.;Database=MyMeds;Trusted_Connection=True;");

        private LogonModel LogonUser { get; set; }

        public Task<bool> PasswordSignIn(string user, string password)
        {
            if (user == null || password == null) return Task.FromResult(false);

            const string procedure = "[SelectUser]";
            var values = new { UserId = user, password };
            _connection.Open();
            var results = _connection.Query<LogonModel>(procedure, values, commandType: CommandType.StoredProcedure).ToList();
            _connection.Close();

            LogonUser = new LogonModel();

            foreach (var result in results)
            {
                LogonUser.LoginId = result.LoginId;
                LogonUser.UserId = result.UserId;
                LogonUser.Pharmacy = result.Pharmacy;
                LogonUser.PharmacyPhone = result.PharmacyPhone;
                LogonUser.Prescriber = result.Prescriber;
                LogonUser.PrescriberPhone = result.PrescriberPhone;
            }

            if (LogonUser.LoginId is 0) return Task.FromResult(false);

            const string procedure2 = "[SelectMedicine]";
            var value = new { LogonsId = LogonUser.LoginId };
            _connection.Open();
            var results2 = _connection.Query<MedicationModel>(procedure2, value, commandType: CommandType.StoredProcedure).ToList();
            _connection.Close();

            foreach (var record in results2)
            {
                var medsModel = new MedicationModel
                {
                    LogonsId = record.LogonsId,
                    MedicationName = record.MedicationName,
                    Directions = record.Directions,
                    Prescriber = record.Prescriber,
                    Refills = record.Refills,
                    Pharmacy = record.Pharmacy,
                    TimeTaken = record.TimeTaken,
                };

                LogonUser.Medications.Add(medsModel);
            }

            return Task.FromResult(true);
        }

        public LogonModel GrabDataForUser(string user)
        {
            if (user == null) return null;

            const string procedure = "[SelectLoggedInUser]";
            var values = new { UserId = user };
            _connection.Open();
            var results = _connection.Query<LogonModel>(procedure, values, commandType: CommandType.StoredProcedure).ToList();
            _connection.Close();

            LogonUser = new LogonModel();

            foreach (var result in results)
            {
                LogonUser.LoginId = result.LoginId;
                LogonUser.UserId = result.UserId;
                LogonUser.Pharmacy = result.Pharmacy;
                LogonUser.PharmacyPhone = result.PharmacyPhone;
                LogonUser.Prescriber = result.Prescriber;
                LogonUser.PrescriberPhone = result.PrescriberPhone;
            }

            if (LogonUser.Id == null) return null;

            const string procedure2 = "[SelectMedicine]";
            var value = new { LogonsId = LogonUser.LoginId };
            _connection.Open();
            var results2 = _connection.Query<MedicationModel>(procedure2, value, commandType: CommandType.StoredProcedure).ToList();
            _connection.Close();

            foreach (var record in results2)
            {
                var medsModel = new MedicationModel
                {
                    LogonsId = record.LogonsId,
                    MedicationName = record.MedicationName,
                    Directions = record.Directions,
                    Prescriber = record.Prescriber,
                    Refills = record.Refills,
                    Pharmacy = record.Pharmacy,
                    TimeTaken = record.TimeTaken,
                };

                LogonUser.Medications.Add(medsModel);
            }

            return LogonUser;
        }

        public IList<MedicationModel> GrabMedicationsOnlyToList(string user)
        {
            if (user == null) return null;

            const string procedure = "[SelectLoggedInUser]";
            var values = new { UserId = user };
            _connection.Open();
            var results = _connection.Query<LogonModel>(procedure, values, commandType: CommandType.StoredProcedure).ToList();
            _connection.Close();

            LogonUser = new LogonModel();

            foreach (var result in results)
            {
                LogonUser.LoginId = result.LoginId;
                LogonUser.UserId = result.UserId;
                LogonUser.Pharmacy = result.Pharmacy;
                LogonUser.PharmacyPhone = result.PharmacyPhone;
                LogonUser.Prescriber = result.Prescriber;
                LogonUser.PrescriberPhone = result.PrescriberPhone;
            }

            if (LogonUser.Id == null) return null;

            const string procedure2 = "[SelectMedicine]";
            var value = new { LogonsId = LogonUser.LoginId };
            _connection.Open();
            var results2 = _connection.Query<MedicationModel>(procedure2, value, commandType: CommandType.StoredProcedure).ToList();
            _connection.Close();

            foreach (var record in results2)
            {
                var medsModel = new MedicationModel
                {
                    Id = record.Id,
                    LogonsId = record.LogonsId,
                    MedicationName = record.MedicationName,
                    Directions = record.Directions,
                    Prescriber = record.Prescriber,
                    Refills = record.Refills,
                    Pharmacy = record.Pharmacy,
                    TimeTaken = record.TimeTaken,
                };

                LogonUser.Medications.Add(medsModel);
            }

            return LogonUser.Medications.ToList();
        }

        public Task CreateMedicationTask(MedicationModel model, int logonId)
        {
            var adapter = new SqlDataAdapter();

            try
            {
                _connection.Open();
                var medication =
                    "INSERT INTO MyMeds.dbo.Medications (Id, LogonsId, MedicationName, Directions, Prescriber, Refills, Pharmacy, TimeTaken) VALUES " +
                    $"('{Random.Shared.Next()}','{logonId}','{model.MedicationName}','{model.Directions}','{model.Prescriber}','{model.Refills}','{model.Pharmacy}','{model.TimeTaken}')";

                var cmd = new SqlCommand(medication, _connection);
                adapter.InsertCommand = cmd;
                adapter.InsertCommand.ExecuteNonQuery();
                _connection.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return Task.CompletedTask;
        }

        public Task DeleteMedicationTask(MedicationModel model, int logonId)
        {
            try
            {
                _connection.Open();
                const string medication = $"DELETE FROM MyMeds.dbo.Medications WHERE Id = @Id";
                _connection.Execute(medication, new { model.Id });
                _connection.Close();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return Task.CompletedTask;
        }

        public Task UpdateMedicationTask(MedicationModel model, int logonId)
        {
            var dataTable = new DataTable();
            dataTable = MappedDataTableMedication(dataTable, model);
            var tableNumber = Random.Shared.Next();
            var table = $"TmpTable{tableNumber}";

            try
            {
                using var cmd = new SqlCommand("", _connection);
                _connection.Open();
                cmd.CommandText = $"CREATE TABLE {table}([Id] INT,[LogonsId] INT,[MedicationName] VARCHAR(30),[Directions] VARCHAR(140),[Prescriber] VARCHAR(30),[Refills] INT,[Pharmacy] VARCHAR(30),[TimeTaken] DATETIME)";
                cmd.ExecuteNonQuery();

                using var bulkCopy = new SqlBulkCopy(_connection);
                bulkCopy.BulkCopyTimeout = 2;
                bulkCopy.DestinationTableName = table;
                bulkCopy.WriteToServer(dataTable);
                bulkCopy.Close();

                cmd.CommandTimeout = 2;
                cmd.CommandText = "BEGIN TRAN; " +
                                  "UPDATE P WITH (ROWLOCK, SERIALIZABLE) SET P.[Id] = T.[Id], P.[LogonsId] = T.[LogonsId], P.[MedicationName] = T.[MedicationName], P.[Directions] = T.[Directions], P.[Prescriber] = T.[Prescriber], " +
                                  "P.[Refills] = T.[Refills], P.[Pharmacy] = T.[Pharmacy], P.[TimeTaken] = T.[TimeTaken] " +
                                  $"FROM MyMeds.dbo.Medications AS P INNER JOIN {table} AS T ON P.[Id] = T.[Id]; DROP TABLE {table}; " +
                                  "COMMIT;";
                cmd.ExecuteNonQuery();
            }
            catch (SqlException e)
            {
                Console.WriteLine(e);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return Task.CompletedTask;
        }

        private static DataTable MappedDataTableMedication(DataTable dataTable, MedicationModel obj)
        {
            dataTable.Clear();
            var row = dataTable.NewRow();

            dataTable.Columns.Add("Id");
            row["Id"] = obj.Id;
            dataTable.Columns.Add("LogonsId");
            row["LogonsId"] = obj.LogonsId;
            dataTable.Columns.Add("MedicationName");
            row["MedicationName"] = obj.MedicationName;
            dataTable.Columns.Add("Directions");
            row["Directions"] = obj.Directions;
            dataTable.Columns.Add("Prescriber");
            row["Prescriber"] = obj.Prescriber;
            dataTable.Columns.Add("Refills");
            row["Refills"] = obj.Refills;
            dataTable.Columns.Add("Pharmacy");
            row["Pharmacy"] = obj.Pharmacy;
            dataTable.Columns.Add("TimeTaken");
            row["TimeTaken"] = obj.TimeTaken;

            dataTable.Rows.Add(row);
            return dataTable;
        }
    }
}
