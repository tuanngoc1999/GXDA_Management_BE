namespace DA_Management_Endpoint.Dtos
{
    public class CatechistProfileDto
    {
        public int Id { get; set; }
        public int CatechistId { get; set; }
        public int ProfileId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime UpdatedDate { get; set; }
        public int UpdatedBy { get; set; }

        public virtual CoreDto? Catechist { get; set; }
        public virtual CoreDto? Profile { get; set; }
    }
}

