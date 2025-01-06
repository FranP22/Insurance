using Dapper;
using Insurance.Model;
using Microsoft.Data.SqlClient;

namespace Insurance.Service
{
    public class PolicyService : IPolicyService
    {
        private readonly IConfiguration _configuration;

        public PolicyService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }

        public async Task<List<Policy>> GetAllPolicies()
        {
            using var connection = GetConnection();
            var policies = await connection.QueryAsync<Policy>("SELECT * FROM Policies");
            return policies.ToList();
        }

        public async Task<Policy> GetPolicyByNumber(string number)
        {
            using var connection = GetConnection();
            var policy = await connection.QueryFirstOrDefaultAsync<Policy>("SELECT * FROM Policies WHERE PolicyNumber=@PolicyNumber", new { PolicyNumber = number });
            return policy;
        }

        public async Task<string> AddPolicy(Policy policy)
        {
            using var connection = GetConnection();
            var resultId = await connection.ExecuteScalarAsync<string>(
                "INSERT INTO Policies(PolicyNumber, PartnerNumber, PolicyAmount) " +
                "VALUES (LEFT(REPLACE(NEWID(), '-', ''), 15), @PartnerNumber, @PolicyAmount)"
                , new { PartnerNumber = policy.PartnerNumber, PolicyAmount = policy.PolicyAmount });

            return resultId;
        }
    }
}
