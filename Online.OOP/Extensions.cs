using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Online.OOP;

internal static class Extensions
{
    public static void AddSugar(this CoffeeMachine coffeeMachine, int countSpoonOfSugar)
    {
        coffeeMachine.MakeCoffee();
        Console.WriteLine("With Sugar: " + countSpoonOfSugar);
    }
}
