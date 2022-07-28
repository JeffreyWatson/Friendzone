namespace Friendzone.Models
{
  public class Profile
  {
    public string Id { get; set; }
    public string Name { get; set; }
    public string Bio { get; set; }
    public string Picture { get; set; }
  }

  public class Account : Profile
  {
    public string Email { get; set; }
  }

  public class FollowersViewModel : Profile
  {
    public string FollowId { get; set; }
  }

}