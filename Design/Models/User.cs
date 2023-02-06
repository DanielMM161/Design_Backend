namespace Design.Models
{
  public class User 
  {
    public int Id { get; set;}
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Created { get; set; }
    public bool IsAdmin { get; set; }

    public User(string name, string email, string password, bool isAdmin) 
    {
      Created = DateTime.Now.ToString();
      Name = name;
      Email = email;
      Password = password;
      IsAdmin = isAdmin;
    }
  }
}