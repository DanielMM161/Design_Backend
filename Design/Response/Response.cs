namespace Design.Response
{
  public enum Status
  {
    success,
    error
  }
  public class Response<T>
  {
    public T Data { get; set; }
    
    public string Message { get; set; }

    public Status Status { get; set; }
    
    public Response(T data, string message, Status status)
    {
      Data = data;
      Message = message;
      Status = status;
    } 
  }
}