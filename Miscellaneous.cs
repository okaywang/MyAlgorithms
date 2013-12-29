using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MyAlgorithms
{
    public static class Miscellaneous
    {
        #region Case01:不允许使用循环语句、条件语句，在控制台中打印出1-200这200个数
        public static void Case01_1()
        {
            Case01_1Print(1);
            Console.Read();
        }
        private static void Case01_1Print(int number)
        {
            try
            {
                Console.WriteLine(number);
                int i = 1 / (200 - number);
                number = number + 1;
                Case01_1Print(number);
            }
            catch (DivideByZeroException e)
            {
            }
        }

        public static void Case01_2()
        {
            Case01_2Print(1);
            Console.Read();
        }
        private static bool Case01_2Print(int number)
        {
            Console.WriteLine(number);
            return number >= 200 || Case01_2Print(number + 1);
        }
        #endregion

        #region Case02:给定一个整数num，判断这个整数是否是2的N次方。
        public static void Case02()
        {
            var flg = Case02GetFlag(3);
            Console.WriteLine(flg);
        }

        private static bool Case02GetFlag(int num)
        {
            if (num < 1) return false;
            return (num & num - 1) == 0;
        } 
        #endregion
    }
}
