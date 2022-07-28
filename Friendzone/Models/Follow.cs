namespace Friendzone.Models
{
  public class Follow
  {
    public int Id { get; set; }
    public string FollowerId { get; set; }
    public string FollowingId { get; set; }
  }
}