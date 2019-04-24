using System;
using CodeWarPractice;
using NUnit.Framework;

namespace Tests
{
    public class CodeWarTest
    {
        private ICodeWar _codeWar;

        [SetUp]
        public void Setup()
        {
            _codeWar = new CodeWar();
        }
        
        [Test]
        public void LongestConsecTest()
        {
            Assert.AreEqual(_codeWar.LongestConsec(new String[] { "zone", "abigail", "theta", "form", "libe", "zas", "theta", "abigail" }, 2), "abigailtheta");
            Assert.AreEqual(_codeWar.LongestConsec(new String[] { "ejjjjmmtthh", "zxxuueeg", "aanlljrrrxx", "dqqqaaabbb", "oocccffuucccjjjkkkjyyyeehh" }, 1), "oocccffuucccjjjkkkjyyyeehh");
            Assert.AreEqual(_codeWar.LongestConsec(new String[] { }, 3), "");
            Assert.AreEqual(_codeWar.LongestConsec(new String[] { "itvayloxrp", "wkppqsztdkmvcuwvereiupccauycnjutlv", "vweqilsfytihvrzlaodfixoyxvyuyvgpck" }, 2), "wkppqsztdkmvcuwvereiupccauycnjutlvvweqilsfytihvrzlaodfixoyxvyuyvgpck");
            Assert.AreEqual(_codeWar.LongestConsec(new String[] { "wlwsasphmxx", "owiaxujylentrklctozmymu", "wpgozvxxiu" }, 2), "wlwsasphmxxowiaxujylentrklctozmymu");
            Assert.AreEqual(_codeWar.LongestConsec(new String[] { "zone", "abigail", "theta", "form", "libe", "zas" }, -2), "");
            Assert.AreEqual(_codeWar.LongestConsec(new String[] { "it", "wkppv", "ixoyx", "3452", "zzzzzzzzzzzz" }, 3), "ixoyx3452zzzzzzzzzzzz");
            Assert.AreEqual(_codeWar.LongestConsec(new String[] { "it", "wkppv", "ixoyx", "3452", "zzzzzzzzzzzz" }, 15), "");
            Assert.AreEqual(_codeWar.LongestConsec(new String[] { "it", "wkppv", "ixoyx", "3452", "zzzzzzzzzzzz" }, 0), "");
        }

        [Test]
        public void IsValidWalk()
        {
            Assert.AreEqual(true, _codeWar.IsValidWalk(new string[] { "n", "s", "n", "s", "n", "s", "n", "s", "n", "s" }), "should return true");
            Assert.AreEqual(false, _codeWar.IsValidWalk(new string[] { "w", "e", "w", "e", "w", "e", "w", "e", "w", "e", "w", "e" }), "should return false");
            Assert.AreEqual(false, _codeWar.IsValidWalk(new string[] { "w" }), "should return false");
            Assert.AreEqual(false, _codeWar.IsValidWalk(new string[] { "n", "n", "n", "s", "n", "s", "n", "s", "n", "s" }), "should return false");
        }

        [Test]
        public void NextBiggerNumber()
        {
            Assert.AreEqual(59884848483559, _codeWar.NextBiggerNumber(59884848459853));
            Assert.AreEqual(21, _codeWar.NextBiggerNumber(12));
            Assert.AreEqual(1234567908, _codeWar.NextBiggerNumber(1234567890));
            Assert.AreEqual(531, _codeWar.NextBiggerNumber(513));
            Assert.AreEqual(2071, _codeWar.NextBiggerNumber(2017));
            Assert.AreEqual(441, _codeWar.NextBiggerNumber(414));
            Assert.AreEqual(414, _codeWar.NextBiggerNumber(144));
        }
    }
}