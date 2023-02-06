namespace Design.Models
{
  public class User 
  {
    public int Id { get; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public string Created { get; }
    public bool IsAdmin { get; set; }

    public User(int id, string name, string email, string password, bool isAdmin) 
    {
      Id = id;
      Created = DateTime.Now.ToString();
      Name = name;
      Email = email;
      Password = password;
      IsAdmin = isAdmin;
    }
  }
}