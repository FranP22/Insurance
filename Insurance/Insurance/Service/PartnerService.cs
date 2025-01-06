using Dapper;
using Insurance.Model;
using Microsoft.Data.SqlClient;

namespace Insurance.Service
{
    public class PartnerService : IPartnerService
    {
        private readonly IConfiguration _configuration;

        public PartnerService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public SqlConnection GetConnection()
        {
            return new SqlConnection(_configuration.GetConnectionString("DefaultConnection"));
        }

        public async Task<List<Partner>> GetAllPartners()
        {
            using var connection = GetConnection();
            var partners = await connection.QueryAsync<Partner>("SELECT * FROM Partners ORDER BY CreatedAtUTC DESC");
            return partners.ToList();
        }

        public async Task<Partner> GetPartnerByNumber(string number)
        {
            using var connection = GetConnection();
            var partner = await connection.QueryFirstOrDefaultAsync<Partner>("SELECT * FROM Partners WHERE PartnerNumber=@PartnerNumber", new { PartnerNumber = number });
            return partner;
        }

        public async Task<List<Policy>> GetPartnerPolicies(string number)
        {
            using var connection = GetConnection();
            var policies = await connection.QueryAsync<Policy>("SELECT * FROM Policies WHERE PartnerNumber=@PartnerNumber", new { PartnerNumber = number });
            return policies.ToList();
        }

        public async Task<Partner> AddPartner(Partner partner)
        {
            if (!Partner.PartnerIsValid(partner)) return null;

            using var connection = GetConnection();
            var result = await connection.QuerySingleOrDefaultAsync<Partner>(
                "INSERT INTO Partners(FirstName, LastName, Address, CroatianPin, PartnerTypeId, CreatedByUser, IsForeign, ExternalCode, Gender) " +
                "VALUES (@FirstName,@LastName,@Address,@CroatianPin,@PartnerTypeId,@CreatedByUser,@IsForeign,@ExternalCode,@Gender);" +
                "SELECT * FROM Partners WHERE PartnerNumber = SCOPE_IDENTITY();"
                , new { FirstName = partner.FirstName,
                    LastName = partner.LastName,
                    Address = partner.Address,
                    CroatianPin = partner.CroatianPin,
                    PartnerTypeId = partner.PartnerTypeId,
                    CreatedByUser = partner.CreatedByUser,
                    IsForeign = partner.IsForeign,
                    ExternalCode = partner.ExternalCode,
                    Gender = partner.Gender });

            return result;
        }
    }
}
