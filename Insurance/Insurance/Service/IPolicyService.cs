using Insurance.Model;

namespace Insurance.Service
{
    public interface IPolicyService : IDbConnection
    {
        Task<List<Policy>> GetAllPolicies();
        Task<Policy> GetPolicyByNumber(string number);
        Task<string> AddPolicy(Policy policy);
    }
}
