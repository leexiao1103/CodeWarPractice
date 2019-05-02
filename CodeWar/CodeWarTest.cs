using System;
using System.Collections.Generic;
using System.Text;
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

        [Test]
        public void High()
        {
            Assert.AreEqual("taxi", _codeWar.High("man i need a taxi up to ubud"));
            Assert.AreEqual("volcano", _codeWar.High("what time are we climbing up to the volcano"));
            Assert.AreEqual("semynak", _codeWar.High("take me to semynak"));
        }

        [Test]
        public void ToWeirdCase()
        {
            Assert.AreEqual("ThIs", _codeWar.ToWeirdCase("This"));
            Assert.AreEqual("Is", _codeWar.ToWeirdCase("is"));
            Assert.AreEqual("ThIs Is A TeSt", _codeWar.ToWeirdCase("This is a test"));
        }

        [Test]
        public void Justify()
        {
            //Arrnge
            var input = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Vestibulum sagittis dolor mauris, at elementum ligula tempor eget. In quis rhoncus nunc, at aliquet orci. Fusce at dolor sit amet felis suscipit tristique. Nam a imperdiet tellus. Nulla eu vestibulum urna. Vivamus tincidunt suscipit enim, nec ultrices nisi volutpat ac. Maecenas sit amet lacinia arcu, non dictum justo. Donec sed quam vel risus faucibus euismod. Suspendisse rhoncus rhoncus felis at fermentum. Donec lorem magna, ultricies a nunc sit amet, blandit fringilla nunc. In vestibulum velit ac felis rhoncus pellentesque. Mauris at tellus enim. Aliquam eleifend tempus dapibus. Pellentesque commodo, nisi sit amet hendrerit fringilla, ante odio porta lacus, ut elementum justo nulla et dolor.";
            var lengths = new int[] { 15, 20, 25, 30, 50, 75, 100 };
            Func<string, int, string> Sol = (str, len) => {
                if (string.IsNullOrEmpty(str)) return "";
                var queue = new Queue<string>(str.Split(' '));
                var builder = new StringBuilder();
                while (queue.Count > 0)
                {
                    var temp = new List<string> { queue.Dequeue() };
                    while (queue.Count > 0 && string.Join(" ", temp).Length + queue.Peek().Length < len)
                        temp.Add(queue.Dequeue());
                    var missingspaces = len - string.Join(" ", temp).Length;
                    var i = 0;
                    while (missingspaces > 0 && queue.Count > 0 && temp.Count > 1)
                    {
                        temp[i % (temp.Count - 1)] += " ";
                        i++;
                        missingspaces--;
                    }
                    builder.Append(string.Join(" ", temp));
                    if (queue.Count > 0) builder.Append('\n');
                }
                return builder.ToString();
            };

            //Act
            foreach (var length in lengths)
            {
                var myresult = Sol(input, length);
                var result = _codeWar.Justify(input, length);
                Assert.AreEqual(myresult, result, "Expected different result:");
                Assert.AreEqual(myresult.Length, result.Length, "Expected different amount of characters");
            }

            //Assert
            Assert.AreEqual(_codeWar.Justify("", 2), "", "Expect empy string for empty string");
            Assert.AreEqual(_codeWar.Justify(null, 123), "", "Expect empy string for null");
        }
    }
}