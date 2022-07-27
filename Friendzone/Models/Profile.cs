namespace Friendzone.Models
{
  public class Profile
  {
    public string Name { get; set; }
    public string Bio { get; set; }
    public string Interests { get; set; }
    public string CreatorId { get; set; }
    public Account Creator { get; set; }
  }
}