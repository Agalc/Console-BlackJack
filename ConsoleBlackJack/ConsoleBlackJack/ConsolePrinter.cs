using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleBlackJack
{
  class ConsolePrinter:IPrinter
  {
    public void Print(string str)
    {
      Console.WriteLine(str);
    }

    public void Wait()
    {
      Console.ReadKey();
    }

    public string ReadLine()
    {
      return Console.ReadLine();
    }
  }
}
