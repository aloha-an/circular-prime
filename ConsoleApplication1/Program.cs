using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
           List<int> simple=new List<int>();
           int count = 0;
            for(int i=2;i<1000000;i++)
                if (insprime(i))
                {
                    if (i > 9)
                    {
                        if (swing(i))
                        {
                           // Console.Write("{0} ", i);
                            count++;
                        }
                    }
                    else
                    {
                       // Console.Write("{0} ", i);
                        count++;
                    }
                }
            Console.WriteLine("\n\nВ диапазоне до 1млн. находится {0} чисел типа circular prime", count);
            Console.ReadKey();
        }
        static bool insprime(double n)      //проверяем простое ли число
        {
            if (n == 1) 
                return false;
            for (int d = 2; d * d <= n; d++)
                if (n % d == 0)
                    return false;
            return true;
        }

        static bool swing(int n)        //проверяем число nб яявляется ли оно circular prime
        {
            List<int> numb = new List<int>();
            double tempNumber=0;
            int count = 1;
        
            while(n % 10 != 0 && n>0)   //преобразовываем число в массив цифр для облегчения сдвига числа n                {
            {
                numb.Add(n % 10); 
                n -= n % 10; 
                if (n == 0)
                    break;
                else
                n = n / 10; 
            }

            numb.Reverse();
            for(int i=1;i<numb.Count;i++)
            {
                int k = numb[0];                            //сдвиг числа n
                for (int j= 0; j < numb.Count - 1; j++)
                    numb[j] = numb[j + 1];
                numb[numb.Count - 1] = k;

                for(int v=0, f=numb.Count-1; v<numb.Count; v++,f--) //"формирование" числа из свдинутого массива
                    tempNumber += numb[v] * Math.Pow(10, f);
                if (insprime(tempNumber))
                    count++;
                else
                    break;
            }

            if (count == numb.Count)
                return true;
            else
                return false;
        }
    }

}
 