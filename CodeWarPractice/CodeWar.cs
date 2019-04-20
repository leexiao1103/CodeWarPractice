using System;
using System.Linq;
using System.Collections.Generic;

namespace CodeWarPractice
{
    public class CodeWar : ICodeWar
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Code War Practice!");
        }

        /// <summary>
        /// 找出陣列內第一個由k個字串組成的最長字串
        /// </summary>
        /// <param name="strarr">Input</param>
        /// <param name="k">幾個組成</param>
        /// <returns></returns>
        public string LongestConsec(string[] strarr, int k)
        {
            string result = "";

            if (strarr.Length == 0 || strarr.Length < k || k <= 0)
            {
                return result;
            }

            for (int i = 0; i <= strarr.Length - k; i++)
            {
                string str = String.Join("", strarr.Skip(i).Take(k).ToArray());

                if (str.Length > result.Length)
                    result = str;
            }
            return result;
        }

        public bool IsValidWalk(string[] walk)
        {
            int n = walk.Where(x => x.Equals("n")).ToArray().Length;
            int s = walk.Where(x => x.Equals("s")).ToArray().Length;
            int w = walk.Where(x => x.Equals("w")).ToArray().Length;
            int e = walk.Where(x => x.Equals("e")).ToArray().Length;

            if (n + s + w + e == 10 && n == s && w == e)
            {
                return true;
            }
            return false;
        }
    }
}
