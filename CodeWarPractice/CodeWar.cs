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
        /// CodeWar題目：Consecutive strings
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

        /// <summary>
        /// CodeWar題目：Take a Ten Minute Walk
        /// </summary>
        /// <param name="walk">Input</param>
        /// <returns></returns>
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

        /// <summary>
        /// CodeWar題目：Next bigger number with the same digits
        /// </summary>
        /// <param name="n">Input</param>
        /// <returns></returns>
        public long NextBiggerNumber(long n)
        {
            var digitArray = n.ToString().Select(x => x).ToArray();

            for (int i = digitArray.Length - 1; i > 0; i--)
            {
                if (digitArray[i] > digitArray[i - 1])
                {
                    var pivot = digitArray[i - 1];
                    var leftPart = String.Join("", digitArray.Take(i - 1).ToArray());
                    var rightPart = digitArray.Skip(i).ToList();
                    var changePoint = rightPart.Where(x => x > pivot).OrderBy(x => x).First();

                    rightPart.Remove(changePoint);
                    rightPart.Add(pivot);

                    return long.Parse(leftPart + changePoint.ToString() + String.Join("", rightPart.OrderBy(x => x).ToArray()));
                }
            }
            return -1;
        }

        /// <summary>
        /// CodeWar題目：Highest Scoring Word
        /// </summary>
        /// <param name="s">Input</param>
        /// <returns></returns>
        public string High(string s)
        {
            var charList = s.Split(" ");
            var pointList = charList.Select(x => x.Select(y => (int)y - 96).Sum()).ToList();

            return charList[pointList.IndexOf(pointList.Max())];
        }

        public static bool ValidParentheses(string input)
        {
            var pteList = input.Select(x => x).ToList();

            if (pteList.Count() >= 2 && pteList.First().Equals('('))
            {
                return pteList.Where(x => '('.Equals(x)).Count() - pteList.Where(x => ')'.Equals(x)).Count() == 0 ? true : false;
            }
            return false;
        }

        /// <summary>
        /// CodeWar題目：WeIrD StRiNg CaSe
        /// </summary>
        /// <param name="s">Input</param>
        /// <returns></returns>
        public string ToWeirdCase(string s)
        {
            return String.Join(" ", s.Split(" ").Select(x => String.Concat(x.Select((v, i) => i % 2 != 0 ? char.ToLower(v) : char.ToUpper(v)))));
        }
    }
}
