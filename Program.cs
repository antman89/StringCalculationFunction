using System;
using System.Data;

namespace IdeagenChallenge
{
    class Program
    {
        static void Main(string[] args)
        {
            CalculateBreakDown("10.5 - ( 2 + 3 * ( 7 - 5 ) )");
            Console.WriteLine("Calculate: " + Calculate("10.5 - ( 2 + 3 * ( 7 - 5 ) )"));
        }

        static int countChar(string str, char x)
        {
            int count = 0;
            int n = 10;
            for (int i = 0; i < str.Length; i++)
                if (str[i] == x)
                    count++;

            // atleast k repetition are required 
            int repititions = n / str.Length;
            count = count * repititions;

            // if n is not the multiple of the  
            // string size check for the remaining  
            // repeating character. 
            for (int i = 0;
                     i < n % str.Length; i++)
            {
                if (str[i] == x)
                    count++;
            }

            return count;
        }

        public static double caluculationOptions(string cal)
        {
            double ans = 0.0;

            if (cal.Contains("+"))
            {
                int index = cal.IndexOf("+");
                double a1 = Convert.ToInt64(cal.Substring(0, index));
                double a2 = Convert.ToInt64(cal.Substring(index + 1));

                Console.WriteLine(a1);
                Console.WriteLine(a2);

                ans = a1 + a2;

                //cal.Remove(0, index);

                Console.WriteLine(ans);
            }
            if (cal.Contains("-"))
            {
                int index = cal.IndexOf("-");
                double a1 = Convert.ToInt64(cal.Substring(0, index));
                double a2 = Convert.ToInt64(cal.Substring(index + 1));

                Console.WriteLine(a1);
                Console.WriteLine(a2);

                ans = a1 - a2;

                Console.WriteLine(ans);
            }
            if (cal.Contains("*"))
            {
                int index = cal.IndexOf("*");
                double a1 = Convert.ToInt64(cal.Substring(0, index));
                double a2 = Convert.ToInt64(cal.Substring(index + 1));

                Console.WriteLine(a1);
                Console.WriteLine(a2);

                ans = a1 * a2;

                Console.WriteLine(ans);
            }
            if (cal.Contains("/"))
            {
                int index = cal.IndexOf("/");
                double a1 = Convert.ToInt64(cal.Substring(0, index));
                double a2 = Convert.ToInt64(cal.Substring(index + 1));

                Console.WriteLine(a1);
                Console.WriteLine(a2);

                ans = a1 / a2;

                Console.WriteLine(ans);
            }

            return ans;
        }

        public static void CalculateBreakDown(string sum)
        {
            sum = sum.Replace(" ", "");

            string backupSum = sum;
            double ans = 0.0;

            int NumOfOpenBrac = countChar(sum, '(') + 1;
            Console.WriteLine("NumOfOpenBrac: " + NumOfOpenBrac + "\n");

            int i = 0;
            while (i < NumOfOpenBrac)
            {
                Console.WriteLine("count: " + i);
                int Startindex = sum.IndexOf("(");
                Console.WriteLine("sum: " + sum);

                Console.WriteLine("StartIndex: " + Startindex);

                string newString = sum.Substring(Startindex + 1);
                Console.WriteLine(newString + "\n");

                sum = newString;

                if (sum.Contains(')'))
                {
                    int EndBracket = sum.IndexOf(')');

                    sum = sum.Remove(EndBracket);

                    //sum = sum.Replace(")", "");
                }

                if (i == NumOfOpenBrac - 1)
                {
                    ans = caluculationOptions(sum);

                    int startBracket = backupSum.IndexOf(sum) - 1;
                    backupSum = backupSum.Remove(startBracket, 1);

                    //int endBracket = backupSum.IndexOf(sum)+1; 
                    //backupSum = backupSum.Remove(endBracket,1);

                    Console.WriteLine(sum);
                    int endBracket = backupSum.IndexOf(sum);
                    backupSum = backupSum.Replace(sum, ans.ToString());

                    backupSum = backupSum.Remove(endBracket+1, 1);

                    Console.WriteLine("formula= " + backupSum);

                    CalculateBreakDown(backupSum);
                }

                i++;
            }

            foreach (var a in sum)
            {
                //Console.WriteLine(a);



                //ans += ans;
            }
        }

        public static double Calculate(string sum)
        {
            sum = sum.Replace(" ", "");
            try
            {
                var result = new DataTable().Compute(sum, null);
                return Convert.ToDouble(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }

            return 0.0;
        }
    }
}
