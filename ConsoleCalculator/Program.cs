using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleCalculator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input your query:");
            try
            {
                var query = Console.ReadLine();
                Console.WriteLine(Calculate(query));
            }
            catch(Exception ex)
            {
                Console.WriteLine("Error: {0}", ex.Message);
            }
            Console.ReadLine();
        }

        static double Calculate(string query)
        {
            Regex validationRegex = new Regex(@"([\s]*[-]?[\d]+[\s]*[+-\/*][\s]*[\d]+[\s]*)");
            if (!validationRegex.IsMatch(query))
            {
                throw new Exception("Unsupportable query");
            }

            var seporater = new Regex(@"(([-]?[\d]+)|[+-\/*])");
            var match = seporater.Matches(query).Cast<Match>().Select(x => x.Value).ToArray();
            
            double result = 0;

            switch (match.Length)
            {
                case 2:
                    result = double.Parse(match[0]) + double.Parse(match[1]);
                    break;
                case 3:
                    result = Operation(match[1])(double.Parse(match[0]), double.Parse(match[2]));
                    break;
                default:
                    throw new Exception("Unsupportable query");
            }

            return result;
        }

        static Func<double,double,double> Operation(string operation)
        {
            switch (operation)
            {
                case "+":
                    return (x, y) => x + y;
                case "-":
                    return (x, y) => x - y;
                case "/":
                    return (x, y) => x / y;
                case "*":
                    return (x, y) => x * y;
            }
            throw new Exception("Unsupportable operation");
        }
    }
}
