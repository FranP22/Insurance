namespace Insurance.Model
{
    public class Partner
    {
        //public int PartnerId { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Address { get; set; }
        public required string PartnerNumber { get; set; }
        public string? CroatianPin { get; set; }
        public int PartnerTypeId { get; set; }
        public required DateTime CreatedAtUtc { get; set; }
        public required string CreatedByUser { get; set; }
        public bool IsForeign { get; set; }
        public string? ExternalCode { get; set; }
        public char Gender { get; set; }

        public static bool PartnerIsValid(Partner partner)
        {
            string genders = "MFN";
            int[] validTypeIds = [1, 2];

            if (!genders.Contains(partner.Gender)) return false;

            /*if(partner.CroatianPin != null)
            {
                if (partner.CroatianPin.Length != 11) return false;
            }

            if (partner.ExternalCode != null)
            {
                if (partner.ExternalCode.Length > 0 && partner.ExternalCode.Length <= 10 && partner.ExternalCode.Length <= 20) return false;
            }*/

            if (!validTypeIds.Contains(partner.PartnerTypeId)) return false;
            
            return true;
        }
    }
}
