using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TooniiMashins1;
using Memorys;

class Program
{
    public static void Main(string[] args)
    {
        Toonii_mashin toonii_Mashin = new Toonii_mashin();
        Memory memory = new Memory();

        Console.WriteLine(toonii_Mashin.result);
        while (true)
        {
            Console.Write(":");
            var uildel = Console.ReadLine()?.ToLower();

            if (uildel == "memory")
            {
                memory.print();
            }
            else if (uildel == "+")
            {
                Console.Write("Enter number: ");
                int.TryParse(Console.ReadLine(), out int x);

                toonii_Mashin.Add(x);

            }
            else if (uildel == "-") 
            {
                Console.Write("Enter number: ");
                int.TryParse(Console.ReadLine(), out int y);

                toonii_Mashin.Substract(y);
            }
            else if (uildel == "ms")
            {
                memory.Store(toonii_Mashin.result);
            }
            else if(uildel == "m-")
            {
                int.TryParse(Console.ReadLine(), out int e);
                int.TryParse(Console.ReadLine(), out int i);

                if (memory._memoryItems.Count > e)
                {
                    memory._memoryItems[e].Substract(i);
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

                if (memory._memoryItems.Count > e)
                {
                    memory._memoryItems[e].Add(i);
                }
                else
                {
                    Console.WriteLine("baihguee tiim bairand");
                }
            }

            else if (uildel == "exit")
            {
                break;
            }
            
        }
    }
}
