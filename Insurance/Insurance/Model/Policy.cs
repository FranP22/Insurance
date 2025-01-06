namespace Insurance.Model
{
    public class Policy
    {
        //public int PolicyId { get; set; }
        public required string PolicyNumber { get; set; }
        public required string PartnerNumber { get; set; }
        public float PolicyAmount { get; set; }
    }
}
