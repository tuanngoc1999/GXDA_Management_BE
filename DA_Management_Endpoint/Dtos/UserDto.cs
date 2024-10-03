namespace DA_Management_Endpoint.Dtos
{
	public class UserDto
	{
        public int Id { get; set; }
        public required string UserName { get; set; }

        public virtual CoreDto? Catechist { get; set; }

    }
}

