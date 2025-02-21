using System;
using TooniiMashins1;
using Memorys;
class Program
{
    public static void Main(string[] args)
    {
        Toonii_mashin toonii_Mashin = new Toonii_mashin(5);
        Memory memory = new Memory();

        toonii_Mashin.Add(6);
        Console.WriteLine(toonii_Mashin.result);
        memory.Store(toonii_Mashin.result);
        toonii_Mashin.Substract(8);
        Console.WriteLine(toonii_Mashin.result);
        memory.Store(toonii_Mashin.result);
        toonii_Mashin.Add(6);
        Console.WriteLine(toonii_Mashin.result);
        memory.Store(toonii_Mashin.result);

        memory.print();

        memory._memoryItems[0].Add(6);
        memory._memoryItems[2].Substract(-1);

        var item = memory.GetMemoryItem(4);
        
        if (item != null)
        {
            item.Add(5);
        }
                
        memory.print();
        memory.Clear();
        memory.print();

    }
}
