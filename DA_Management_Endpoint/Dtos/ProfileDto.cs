namespace DA_Management_Endpoint.Dtos
{
    public partial class ProfileDto
    {

        public int Id { get; set; }
        public required string Name { get; set; }
        public bool P1 { get; set; }
        public bool P2 { get; set; }
        public bool P3 { get; set; }
        public bool P4 { get; set; }
        public bool P5 { get; set; }
        public bool P6 { get; set; }
        public bool P7 { get; set; }
        public bool P8 { get; set; }
        public bool P9 { get; set; }
        public bool P10 { get; set; }
        public bool P11 { get; set; }
        public bool P12 { get; set; }
        public bool P13 { get; set; }
        public bool P14 { get; set; }
        public bool P15 { get; set; }
        public bool P16 { get; set; }
        public bool P17 { get; set; }
        public bool P18 { get; set; }
        public bool P19 { get; set; }
        public bool P20 { get; set; }
        public bool P21 { get; set; }
        public bool P22 { get; set; }
        public bool P23 { get; set; }
        public bool P24 { get; set; }
        public int QuantityUsed { get; set; }

        public virtual CoreDto? CreatedByCatechist { get; set; }
        public virtual CoreDto? UpdatedByCatechist { get; set; }
    }
}

