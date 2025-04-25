using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CalculatorApp;
using CalculatorApp.MemoryName;


class Program
{
    public static void Main(string[] args)
    {
        Toonii_mashin toonii_Mashin = new Toonii_mashin();
        

        Console.WriteLine(toonii_Mashin.result);
        while (true)
        {

            var uildel = Console.ReadLine()?.ToLower();

            if (uildel == "memory")
            {
               toonii_Mashin.memory.print();
            }
            else if (uildel == "+")
            {
                Console.Write("Nemeh too: ");
                int.TryParse(Console.ReadLine(), out int x);

                toonii_Mashin.Add(x);

            }
            else if (uildel == "reset")
            {
                toonii_Mashin.resetResult();
            }
            else if (uildel == "-")
            {
                Console.Write("Hasah too: ");
                int.TryParse(Console.ReadLine(), out int y);

                toonii_Mashin.Substract(y);
            }
            else if (uildel == "ms")
            {
                toonii_Mashin.memory.Store(toonii_Mashin.result);
            }
            else if (uildel == "m-")
            {
                int.TryParse(Console.ReadLine(), out int e);
                int.TryParse(Console.ReadLine(), out int i);

                if (toonii_Mashin.memory._memoryItems.Count > e && e >= 0)
                {
                    toonii_Mashin.memory._memoryItems[e].Substract(i);
                }
                else
                {
                    Console.WriteLine("baihguee tiim bairand");
                }
            }
            else if (uildel == "m+")
            {
                int.TryParse(Console.ReadLine(), out int e);
                int.TryParse(Console.ReadLine(), out int i);

                if (toonii_Mashin.memory._memoryItems.Count > e)
                {
                    toonii_Mashin.memory._memoryItems[e].Add(i);
                }
            }
            else if (uildel == "clear")
            {
                toonii_Mashin.memory.Clear();
            }

            else if (uildel == "exit")
            {
                break;
            }

        }
    }
}