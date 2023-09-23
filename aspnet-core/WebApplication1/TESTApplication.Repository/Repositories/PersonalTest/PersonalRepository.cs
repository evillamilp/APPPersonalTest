using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System.Data;

using TESTApplication.Repository;
using TSTApplitacionConstants = TESTApplication.Domain.TSTApplitacionConstants;
using TESTApplicationParamConstants = TESTApplication.Domain.TESTApplicationParamConstants;

namespace TESTApplication.PersonalTest
{
    public class PersonalRepository : IPersonalRepository
    {

        private readonly IConfiguration _configuration;
        private string _connectionString;

        public PersonalRepository(IConfiguration configuration)
        {
            _configuration = configuration;
            _connectionString = _configuration.GetConnectionString("DefaultConnection") ?? String.Empty;
        }

        public async Task<List<Personal>> GetPersonal() 
        {
            var result = new List<Personal>();

            try
            {
                using (SqlConnection connection = new SqlConnection(DbUtils.getConnectionBuilder(_connectionString).ConnectionString)) 
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(TSTApplitacionConstants.PERSONAL_GET_PERSONAL_LIST, connection)) 
                    {
                        command.CommandTimeout = connection.ConnectionTimeout;
                        command.CommandType = CommandType.StoredProcedure;

                        using (SqlDataReader datareader = await command.ExecuteReaderAsync(CommandBehavior.CloseConnection))
                        {
                            while (await datareader.ReadAsync())
                            {
                                result.Add(this.LoadPersonalFromReader(datareader));
                            }
                        }
                    }
                }
            }
            catch (Exception ex) 
            {
            }

            return result;
        }

        public async Task<Personal?> AddPersonal(Personal input) 
        {
            Personal? result = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(DbUtils.getConnectionBuilder(_connectionString).ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(TSTApplitacionConstants.PERSONAL_ADDPERSONAL, connection))
                    {
                        command.CommandTimeout = connection.ConnectionTimeout;
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue(TESTApplicationParamConstants.PERSONAL_ADD_FULLNAME, input.Name);
                        command.Parameters.AddWithValue(TESTApplicationParamConstants.PERSONAL_ADD_ADDRESS, input.FullAddress);
                        command.Parameters.AddWithValue(TESTApplicationParamConstants.PERSONAL_ADD_PHONE, input.Phone);
                        command.Parameters.AddWithValue(TESTApplicationParamConstants.PERSONAL_ADD_EMAIL, input.EmailAddress);

                        using (SqlDataReader datareader = await command.ExecuteReaderAsync(CommandBehavior.CloseConnection))
                        {
                            while (await datareader.ReadAsync())
                            {
                                result = this.LoadPersonalFromReader(datareader);
                            }
                        }
                    }
                }
            }
            catch 
            {
                result = null;
            }

            return result;
        }

        public async Task<Personal?> UpdatePersonal(Personal input) 
        {
            Personal? result = null;
            try
            {
                using (SqlConnection connection = new SqlConnection(DbUtils.getConnectionBuilder(_connectionString).ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(TSTApplitacionConstants.PERSONAL_UPDATEPERSONAL, connection))
                    {
                        command.CommandTimeout = connection.ConnectionTimeout;
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue(TESTApplicationParamConstants.PERSONAL_ID, input.PersonId);
                        command.Parameters.AddWithValue(TESTApplicationParamConstants.PERSONAL_ADD_PHONE, input.Phone);
                        command.Parameters.AddWithValue(TESTApplicationParamConstants.PERSONAL_ADD_EMAIL, input.EmailAddress);

                        using (SqlDataReader datareader = await command.ExecuteReaderAsync(CommandBehavior.CloseConnection))
                        {
                            while (await datareader.ReadAsync())
                            {
                                result = this.LoadPersonalFromReader(datareader);
                                result.PersonId = input.PersonId;
                            }
                        }
                    }
                }
            }
            catch
            {
                result = null;
            }

            return result;
        }

        public async Task<bool> DeletePersonal(int id) 
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DbUtils.getConnectionBuilder(_connectionString).ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand(TSTApplitacionConstants.PERSONAL_DELETEPERSONAL, connection))
                    {
                        command.CommandTimeout = connection.ConnectionTimeout;
                        command.CommandType = CommandType.StoredProcedure;

                        command.Parameters.AddWithValue(TESTApplicationParamConstants.PERSONAL_ID, id);

                        using (SqlDataReader datareader = await command.ExecuteReaderAsync(CommandBehavior.CloseConnection))
                        {
                            var result = 0;
                            while (await datareader.ReadAsync())
                            {
                                result = datareader.IsDBNull(0) ? 0 : datareader.GetInt32(0);
                            }

                            return result > 0 ? true : false;
                        }
                    }
                }
            }
            catch
            {
                return false;
            }
        }

        private Personal LoadPersonalFromReader(IDataReader reader) 
        {
            return new Personal
            {   
                PersonId = reader.FieldCount == 5  ? reader["PersonId"] == DBNull.Value  ? 0 : int.Parse(reader["PersonId"].ToString()??"0") : 0,
                Name = reader["Name"] == DBNull.Value ? string.Empty : reader["Name"].ToString(),
                FullAddress = reader["FullAddress"] == DBNull.Value ? string.Empty : reader["FullAddress"].ToString(),
                Phone = reader["Phone"] == DBNull.Value ? string.Empty : reader["Phone"].ToString(),
                EmailAddress = reader["EmailAddress"] == DBNull.Value ? string.Empty : reader["EmailAddress"].ToString(),
            };
        }
    }
}