using System;
using System.Collections.Generic;
using System.Text;

namespace ElpMaster.Common.Utils
{
    public class BCConverter
    {
        /// 转全角的函数(SBC case) 
        /// 
        /// 任意字符串 
        /// 全角字符串 
        /// 
        /// 全角空格为12288，半角空格为32 
        /// 其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248 
        /// 
        public static string ToSBC(string input)
        {
            //半角转全角： 
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 32)
                {
                    c[i] = (char)12288;
                    continue;
                }
            
                if (c[i] < 127)
                    c[i] = (char)(c[i] + 65248);
            }

            return new string(c);
        }

        public static char ToSBC(char input)
        {
            //半角转全角： 
            if (input == 32)
            {
                input = (char)12288;
            }

            if (input < 127)
                input = (char)(input + 65248);

            return input;
        }

        /// 
        /// 转半角的函数(DBC case) 
        /// 
        /// 任意字符串
        /// 半角字符串 
        /// 
        /// 全角空格为12288，半角空格为32 
        /// 其他字符半角(33-126)与全角(65281-65374)的对应关系是：均相差65248 
        /// 
        public static string ToDBC(string input)
        {
            char[] c = input.ToCharArray();
            for (int i = 0; i < c.Length; i++)
            {
                if (c[i] == 12288)
                {
                    c[i] = (char)32;
                    continue;
                }

                if (c[i] > 65280 && c[i] < 65375)
                    c[i] = (char)(c[i] - 65248);
            }

            return new string(c);
        }

        public static char ToDBC(char input)
        {
            if (input == 12288)
            {
                input = (char)32;
            }

            if (input > 65280 && input < 65375)
                input = (char)(input - 65248);

            return input;
        }
    }
}
