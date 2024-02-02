namespace DatingAppAPI.Entities
{
    public class UserLike
    {
        public AppUser SourceUser { get; set; }
        public Guid SourceUserId { get; set; }
        public AppUser TargetUser { get; set; }
        public Guid TargetUserId { get; set; }
    }
}
