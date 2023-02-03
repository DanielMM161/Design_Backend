namespace Design.Models
{
  public class User 
  {
    public int id { get; set;}
    public string Name { get; set; }
    public string Email { get; set; }

    public User(string name, string email) 
    {
      Name = name;
      Email = email;
    }
  }
}