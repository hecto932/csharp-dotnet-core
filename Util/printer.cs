using static System.Console;

namespace CodeSchool.Util
{
  // A static class does not create new instances 
  public static class Printer
  {
    public static void DrawLine(int size = 10)
    {
      var line = "".PadLeft(size, '=');
      WriteLine(line);
    }

    public static void DrawTitle(string title)
    {
      DrawLine(title.Length + 4);
      WriteLine($"| {title} |");
      DrawLine(title.Length + 4);
      WriteLine();
    }

    public static void Beep(int hz = 2000, int tiempo = 500, int cantidad = 1)
    {
      while (cantidad-- > 0)
      {
        System.Console.Beep(hz, tiempo);
      }
    }
  }
}