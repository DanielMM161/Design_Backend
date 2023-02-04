namespace Design.Response
{
  public interface IResponse<T> where T : class
  {
    T data {get; set; }
    string Message { get; set;}
    int Status { get; set; }
  }
}