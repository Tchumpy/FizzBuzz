using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Configuration;

namespace WCFFizzBuzz
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "FizzBuzzService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select FizzBuzzService.svc or FizzBuzzService.svc.cs at the Solution Explorer and start debugging.
    public class FizzBuzzService : IFizzBuzzService
    {
        public string getFizzBuzz(int x)
        {
            string result = "";

            int configNumberLimit = Int32.Parse(ConfigurationManager.AppSettings["NumberLimit"]);
            for (int i = x; i < x + configNumberLimit; ++i)
            {
                result += calculateDivisible(i);
            }

            System.IO.File.AppendAllText(@"H://fizzbuzzseries.txt", result + DateTime.Now.ToString() + Environment.NewLine);

            return result;

        }

        private string calculateDivisible(int i)
        {
            int div = 1;
            string result = "";

            if (i % 3 == 0) div *= 2;
            if (i % 5 == 0) div *= 3;

            switch(div)
            {
                case 2:
                    result = "fizz,";
                    break;
                case 3:
                    result = "buzz,";
                    break;
                case 6:
                    result = "fizzbuzz,";
                    break;
                default:
                    result = i.ToString() + ",";
                    break;
            }


            return result;
        }
    }

    
}
