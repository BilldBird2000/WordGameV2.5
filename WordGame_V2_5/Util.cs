using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordGame_V2_5
{
    //工具类
    //封装操作,便于跨平台移植

    class Util
    {
        public static void Input ( )
        {
            Console.WriteLine ( );
        }

        public static void Input ( string str )
        {
            Console.WriteLine (str);
        }

        //多字符串重载...嗯...
        public static void Input ( string format , params object [ ] arg )
        {
            Console.WriteLine (format , arg);
        }

        //public static string Reading ( string str )
        //{
        //    Console.ReadLine (str);
        //}



        public static void Key()
        {
            Console.ReadKey ( );
        }
    }
}
