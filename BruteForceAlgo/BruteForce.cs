using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace BruteForceAlgo
{
    internal class BruteForce
    {
        private ProcessHandler processHandler;
        private List<char> lowerChars = ['a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k', 'l', 'm', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z'];
        private List<char> upperChars;
        private List<char> nums = ['1', '2', '3', '4', '5', '6', '7', '8', '9', '0'];
        private List<char> special = ['!', '"'];
        private int maxLength = 15;

        public BruteForce(ProcessHandler processHandler)
        {
            this.processHandler = processHandler;
            upperChars = lowerChars.Select(char.ToUpper).ToList();
        }

        public void StartBruteForce()
        {
            string argue = string.Empty;
            List<char> all = lowerChars;
            all.AddRange(upperChars);
            all.AddRange(nums);
            all.AddRange(special);
            int exitCode = 1;

            int tryCounter = 0;
            int doneAll = 0;
            int[] chars = new int[maxLength];

            do
            {
                chars[0]++;

                if (chars[0] % all.Count == 0 && chars[0] != 0)
                {
                }
            }
            while (exitCode == 1);
        }
    }
}
                //for (int i = 0; i < bruteLength; i++)
                //{
                //    foreach (char c in all)
                //    {
                //        chars[i] = c;
                //        string trying = new string(chars);
                //        exitCode = processHandler.StartProgram(trying);
                //        Console.Clear();
                //        Console.WriteLine(trying);
                //        if (exitCode == 0)
                //        {
                //            break;
                //        }
                //        // ["\"", ]
                //        //     ["\0","\""]
                //        //     ["\0","\0","\""]
                //    }
                //}
                //bruteLength++;
                //char[] actualChars = chars;
                //chars = new char[bruteLength];

                //for (int i = 0; i < actualChars.Length; i++)
                //{
                //    chars[i] = actualChars[i];
                //}