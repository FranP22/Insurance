using Insurance.Model;

namespace Insurance.Service
{
    public interface IPartnerService : IDbConnection
    {
        Task<List<Partner>> GetAllPartners();
        Task<Partner> GetPartnerByNumber(string number);
        Task<List<Policy>> GetPartnerPolicies(string number);
        Task<Partner> AddPartner(Partner partner);
    }
}
