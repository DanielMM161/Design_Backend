// See https://aka.ms/new-console-template for more information
using Design.Controllers;
using Design.Models;
using Design.Response;

UserController userController = new UserController();
ProjectController projectController = new ProjectController();
ToDoController toDoController = new ToDoController();
CommentController commentController = new CommentController();

Project? projectCreated = null;
ToDo? toDoCreated = null;
Comment? commentCreated = null;

string name = "Daniel Moreno";
string email = "daniel@test.com";
string password = "123456";

Response<User> userResponse = userController.SignUp(name, email, password);
ShowMessage(userResponse, "Sign Up User");

Response<User> loginUserResponse = userController.Login(email, password);
ShowMessage(loginUserResponse, "Login");

// If User it's logged you can do things
if(loginUserResponse.Data != null)
{
  User loginUser = loginUserResponse.Data;  
  Console.WriteLine($"Login User: {loginUser.Name}, Email: {loginUser.Email}");
  Console.WriteLine("");
    
  Response<Project> projectResponse = projectController.CreateProject("Project Test", loginUser.Id);
  projectCreated = projectResponse.Data;
  ShowMessage(projectResponse, " Create Project");
    
  Response<ToDo> toDoResponse = toDoController.CreateToDo(projectCreated.Id, "Title Test", "Description Test");
  toDoCreated = toDoResponse.Data;
  ShowMessage(toDoResponse, "Create ToDo");
  
  toDoResponse = toDoController.CreateToDo(projectCreated.Id, "Title Test 2", "Description Test 2");
  toDoCreated = toDoResponse.Data;
  ShowMessage(toDoResponse, "Create ToDo Same Project");
  
  toDoResponse = toDoController.CreateToDo(projectCreated.Id, "Title Test 2", "Description Test 2");
  ShowMessage(toDoResponse, "Create ToDo Same Project and Same Title");
  
  Response<bool> assignToDo = toDoController.AssignToDo(loginUser.Id, toDoCreated.Id);
  ShowMessage(assignToDo, "Assign ToDo");
  
  assignToDo = toDoController.AssignToDo(loginUser.Id, toDoCreated.Id);
  ShowMessage(assignToDo, "Assign ToDo Same User");
  
  toDoCreated.Status = Design.Models.Status.inProgress;
  Response<ToDo> todoUpdated = toDoController.UpdateTodo(toDoCreated);
  ShowMessage(todoUpdated, "Update Todo Status");
  
  Response<Comment> commentResponse = commentController.CreateComment("Comment Description", loginUser.Id, toDoCreated.Id);
  commentCreated = commentResponse.Data;
  ShowMessage(commentResponse, "Create Comment");

  commentResponse = commentController.UpdateComment("Comment Description Updated", commentCreated.Id);
  ShowMessage(commentResponse, "Update Comment");

  // Delete Comment
  // Response<bool> commentDeleteResponse = commentController.DeleteComment(commentCreated.Id);
  // ShowMessage(commentDeleteResponse, "Delete Comment");

  // Delete ToDo
  // Response<bool> toDoDeleteResponse = toDoController.DeleteToDo(toDoCreated.Id);
  // ShowMessage(toDoDeleteResponse, "Delete ToDo");

  // Delete User
  // Response<bool> userDeleteResponse = userController.DeleteUser(loginUser.Id);
  // ShowMessage(userDeleteResponse, "Delete User");

  // Delete Project
  // Response<bool> projectDeleteResponse = projectController.DeleteProject(projectCreated.Id);
  // ShowMessage(projectDeleteResponse, "Delete Project");
}

void ShowMessage<T>(Response<T> response, string message)
{
  Console.WriteLine($"----------- {message} -----------");
  Console.WriteLine($"----------- Status: {response.Status}, Message: {response.Message} -----------");
  Console.WriteLine("");
}








