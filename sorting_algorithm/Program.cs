using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace sorting_algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Double> numbers = new List<Double>();
            try
            {
                using (StreamReader sr = new StreamReader(args[0]))
                {
                    string line;
                    while ((line = sr.ReadLine()) != null)
                    {
                        numbers.Add(Double.Parse(line, System.Globalization.NumberStyles.Float));
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
            SortList(numbers, numbers.Count);

            using (System.IO.StreamWriter file = new System.IO.StreamWriter(args[1]))
            {
                foreach (double number in numbers)
                {
                    file.WriteLine(number.ToString());
                }
            }
            Console.ReadKey();
        }

        static void SortList(List<double> nbrs, int listSize)
        {

            int i, g, inc;
            double temp;
            inc = 3;
            while (inc > 0)
            {
                for (i = 0; i < listSize; i++)
                {
                    g = i;
                    temp = nbrs[i];
                    while ((g >= inc) && (nbrs[g - inc] > temp))
                    {
                        nbrs[g] = nbrs[g - inc];
                        g = g - inc;
                    }
                    nbrs[g] = temp;
                }
                if (inc / 2 != 0)
                    inc = inc / 2;
                else if (inc == 1)
                    inc = 0;
                else
                    inc = 1;
            }
        }
    }   
}
