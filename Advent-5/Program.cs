using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Advent_5
{
    class Program
    {
        static void Main(string[] args) {
            StreamReader reader = new StreamReader("input.txt");
            string line;
            int count = 0;
         
            List<string> niceList = new List<string>();

            while ((line = reader.ReadLine()) != null) {
                // Part.1
                if(!CheckNauthy(line) && CheckVowels(line) > 2 && CheckDoubles(line)) {
                    count++;
                }

                // Part.2


            }
            Console.WriteLine("Part.1: " + count);
            Console.ReadLine();
        }

        // Part.1
        public static bool CheckDoubles(string line) {
            bool result = false;
            
            for (int i = 0; i < line.Length - 1; i++) {
                char[] sub = line.Substring(i, 2).ToCharArray();
                if (sub[0].Equals(sub[1])) {
                    result = true;
                }
            }
            return result;
        }

        public static bool CheckNauthy(string line) {
            bool result = false;
            List<string> naugthyList = new List<string>();
            naugthyList.Add("ab");
            naugthyList.Add("cd");
            naugthyList.Add("pq");
            naugthyList.Add("xy");

            for (int i = 0; i < line.Length-1; i++) {
                string sub = line.Substring(i, 2);
                if(naugthyList.Contains(sub)) {
                    result = true;
                    break;
                }
            }
            return result;
        }

        public static int CheckVowels(string line) {
            List<char> vowelList = new List<char>();
            vowelList.Add('a');
            vowelList.Add('e');
            vowelList.Add('i');
            vowelList.Add('o');
            vowelList.Add('u');
            int count = 0;

            foreach (Char c in line) {
                if (vowelList.Contains(c)) {
                    count++;
                }
            }

            return count;
        }

        // Part.2

    }
}
