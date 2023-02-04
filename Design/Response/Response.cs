namespace Design.Response
{
  public enum Status
  {
    success,
    error
  }
  public class Response<T> where T : class
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

    // public Response<T> Success(T data)
    // {
    //   return new Response<T>(data, "success", Status.success);
    // }

    // public Response<T> Error(T data)
    // {
    //   return new Response<T>(null, "error", Status.error);
    // }    
  }
}