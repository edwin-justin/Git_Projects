using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

namespace MortgageCalculator.API.ServiceHost
{
    class Program
    {
        static HttpClient client = new HttpClient();
        static void Main(string[] args)
        {
            client.BaseAddress = new Uri("http://localhost:8080");
            Console.WriteLine("Press Enter to quit.");
            Console.ReadLine();
        }
    }
}
