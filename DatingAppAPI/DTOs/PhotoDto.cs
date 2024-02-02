namespace DatingAppAPI.DTOs
{
    public class PhotoDto
    {
        public Guid Id { get; set; }
        public string PhotoUrl { get; set; }
        public bool IsMain { get; set; }
    }
}
