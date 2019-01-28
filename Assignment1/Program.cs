using System;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Input starting number: ");
            int x = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input ending number: ");
            int y = Convert.ToInt32(Console.ReadLine());
            PrintPrimeNumbers(x, y);


            Console.WriteLine("\nEnter number of terms of the series");
            int n = int.Parse(Console.ReadLine());
            double s = GetSeriesResult(n);
            Console.WriteLine(s);

            Console.WriteLine("non-negative number to be converted to binary");
            int n2 = int.Parse(Console.ReadLine());
            long r2 = DecimalToBinary(n2);
            Console.WriteLine(r2);

            Console.WriteLine("non-negative number to be converted to decimal");
            int n3 = int.Parse(Console.ReadLine());
            long r3 = BinaryToDecimal(n3);
            Console.WriteLine(r3);

            Console.WriteLine("enter number of lines for the pattern");
            int n4 = int.Parse(Console.ReadLine());
            PrintTriangle(n4);

            Console.WriteLine("enter number of elements in the array");
            int k = int.Parse(Console.ReadLine());
            int[] arr = new int[k];
            Console.WriteLine("Enter the values:");
            for(int i=0;i<arr.Length;i++)
            {
                arr[i] = int.Parse(Console.ReadLine());
            }
            ComputeFrequency(arr);

            Console.ReadKey(true);
        }

        public static void PrintPrimeNumbers(int x, int y)
        {
            for (int i = x; i <= y; i++)
            {
                IsPrime(i);
            }
        }
        public static void IsPrime(int n)
        {
            int f = 0;
            for (int i = 1; i <= n; i++)
            {
                if (n % i == 0)
                {
                    f++;
                }
            }
            if (f == 2)
            {
                Console.Write(n + " ");
            }
        }

        public static double GetSeriesResult(int n)
        {
            double s = 0;
            for (int i = 1; i <= n; i++)
            {
                s = s + Math.Pow(-1, i + 1) * (Fact(i) / (i + 1)); //As per given series formula
            }
            return Math.Round(s, 3);
        }

        public static double Fact(double n)
        {
            double i = 1;
            // Iterating a multiplication fron n -> 1 decreasing value of n by 1 in each iteration   
            while (n != 0)
            {
                i *= n;
                n--;
            }
            return i;
        }

        public static long DecimalToBinary(int D2B)
        {
            int D = D2B;
            int r;
            long i = 1;
            //string s = "";
            long s = 0; ;
            //while loop runs continuously until the number becomes 0
            while (D != 0)
            {
                r = D % 2;
                D = D / 2;

                s += i * r;
                i *= 10;
            }
            return s;
        }

        public static long BinaryToDecimal(long n)
        {
            long q = n, mul = 1, value = 0, r;

            while (q != 0)
            {
                r = q % 10;
                q = q / 10;
                // each binary remainder multiplied with powers of 2 is added to value variable and finally returned
                value = value + (mul * r);
                mul = mul*2;
            }

            return value;
        }
        public static void PrintTriangle(int n)
        {
            for (int i = 0; i <= n; i++)
            {
                for (int j = 1; j <= n - i; j++)
                    Console.Write(" ");
                for (int j = 1; j <= 2 * i - 1; j++)
                    Console.Write("*");
                Console.Write("\n");
            }
        }

        public static void ComputeFrequency(int[] a)
        {
            int n = a.Length;

            // Decalring and intializing an array freq to store frequeny of each element of the original array a
            int[] freq = new int[n];

            //Iteratively intialzing every element of the array freq to -1
            for (int i = 0; i < n; i++)
            {
                freq[i] = -1;
            }

            // Iteratively looping the array in-order to get the frequency of each element
            for (int i = 0; i < n; i++)
            {
                int count = 1;
                for (int j = i + 1; j < n; j++)
                {
                    /* If match is found */
                    if (a[i] == a[j])
                    {
                        // Increasing the count!!
                        count++;

                        /* Making sure not to count same element again */
                        freq[j] = 0;
                    }
                }

                // If frequency of current element is not taken 
                if (freq[i] != 0)
                {
                    freq[i] = count;
                }
            }
            Console.WriteLine("Number Frequency");
            for (int i = 0; i < n; i++)
            {
                if (freq[i] != 0)
                {
                    Console.WriteLine(+a[i] + "      " + freq[i]);
                }
            }
        }
    }
}
  

