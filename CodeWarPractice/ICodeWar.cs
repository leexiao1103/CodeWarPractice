using System;
using System.Collections.Generic;
using System.Text;

namespace CodeWarPractice
{
    public interface ICodeWar
    {
        string LongestConsec(string[] strarr, int k);
        bool IsValidWalk(string[] walk);
        long NextBiggerNumber(long n);
        string High(string s);
    }
}
