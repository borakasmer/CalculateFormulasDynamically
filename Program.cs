using AngouriMath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Text.RegularExpressions;

namespace AngouriMathExample
{
    internal class Program
    {
        static void Main(string[] args)
        {           
            String source = "CMIW*CCL*(FG+CG)/10^6+1+sqrt(3)";           

            FormuleModel model = new FormuleModel() { CMIW = 4.5, CCL = 1, FG = 4, CG = 3 };
            var result = source.CalculateFormulas(model);
            Console.WriteLine(result);         
        }
    }
}