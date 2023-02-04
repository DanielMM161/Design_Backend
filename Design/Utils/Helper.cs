namespace Design.Utils
{
  public static class Helper
  {
    public static bool CheckEmptyFields(params string[] data)
    {
      bool value = false;

      for(int i = 0; i < data.Length; i++) {
        if(data[i].Trim().Equals("")) {
          value = true;
          break;
        }
      }

      return value;
    }
  }
}