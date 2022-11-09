using AngouriMath;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace AngouriMathExample
{
    public static class Extensions
    {
        public static decimal CalculateFormulas(this string formule, IFormuleModel model)
        {
            String pattern = @"([A-Z]|[a-z])+([A-z]|[a-z]|\d|_)*";
            
            String output = String.Join(",",
                Regex.Matches(formule, pattern)
                .OfType<Match>().Where(item => item.Value != "sqrt")
                .Select(item => item.Value));

            int i = 0;
            output.Split(',').ToList().ForEach(item =>
            {
                formule = formule.Replace(item, "{" + i.ToString() + "}");
                i++;
            });
            var varableArray = output.Split(',');
            Object[] prms = new Object[varableArray.Length];
            var index = 0;
            varableArray.ToList().ForEach(prm =>
            {
                prms[index] = model[prm];
                index++;
            });

            formule = String.Format(formule, prms);
            Entity expr = formule;
            return (decimal)expr.EvalNumerical();
        }
    }
}
