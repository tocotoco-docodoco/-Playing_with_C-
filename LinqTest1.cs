using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqTest1
{
    class Program
    {
        static void Main(string[] args)
        {

            int target = 5;
            var numbers = new[] { 5, 3, 9, 6, 7, 5, 8, 1, 0, 10, 4 };

            CountUtil countUtil = new CountUtil();

            // Count the number of target in the numbers
            int count0 = countUtil.Count0(numbers, target);

            // Delegate C#1.0
            // Count the number divided by 2 in the numbers
            CountUtil.Judgement judge = countUtil.IsEven;
            int count1 = countUtil.Count1(numbers, judge);

            // Delegate C#2.0
            // Count the number divided by 3 in the numbers
            int count2 = countUtil.Count2(numbers, delegate(int n) { return n % 3 == 0; });

            // Lambda expression C#3.0 step1
            int count3 = countUtil.Count2(numbers,
                    (int n) =>{
                        if (n % 2 == 0)
                        {
                            return true;
                        }
                        else
                        {
                            return false;
                        }

                    }
                );

            // Lambda expression C#3.0 step2
            // Write an expression on the right side of the return
            // "n % 2 == 0" is expression and has a bool type value
            int count4 = countUtil.Count2(numbers,(int n) => { return n % 2 == 0; });

            // Lambda expression C#3.0 step3
            // In the case of one sentence {} and return can be omitted
            int count5 = countUtil.Count2(numbers,(int n) => n % 2 == 0 );

            // Lambda expression C#3.0 step4
            // Argument types can be omitted
            int count6 = countUtil.Count2(numbers,(n) => n % 2 == 0);

            // Lambda expression C#3.0 step5
            // In the case of one argument () can be ommited
            int count7 = countUtil.Count2(numbers, n => n % 2 == 0);

            Console.WriteLine("C#1.0 > count0: " + count0 + "\ncount1: " + count1 );
            Console.WriteLine("C#2.0 > count2: " + count2);
            Console.WriteLine("C#3.0 > count3: " + count3 + "\ncount4: " + count4 + "\ncount5: " + count5 + "\ncount6: " + count6 + "\ncount7: " + count7);
            Console.ReadKey();
            
        }
    }

    public class CountUtil
    {

        public delegate bool Judgement(int value);

        public bool IsEven(int n)
        {
            return n % 2 == 0; 
        }

        public int Count0(int[] numbers, int num)
        {

            int count = 0;

            foreach (var n in numbers)
            {
                if (n == num)
                {
                    count++;
                }
            }

            return count;

        }

        public int Count1(int[] numbers, Judgement judge)
        {
            int count = 0;

            foreach (var n in numbers)
            {
                if (judge(n) == true)
                {
                    count++;
                }

            }

            return count;

        }

        public int Count2(int[] numbers, Predicate<int> judge)
        {
            int count = 0;

            foreach(var n in numbers)
            {
                if(judge(n) == true )
                {
                    count++;
                }
            }

            return count;
        }

    }

}
