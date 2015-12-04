using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Input;

namespace Advent_4 {
    class Program {
        static void Main(string[] args) {
            MD5 m = MD5.Create();
            String source = "bgvyzdsv";
            String hash = GetMD5Hash(m, source);

            bool match = false;
            int i = 0;

            
            while(!match) {
                hash = GetMD5Hash(m, source + i);
                String five = hash.Substring(0, 6);
                Console.WriteLine(hash + " - " + i + " - " + five);

                // Change this 
                if(five.Equals("000000")) {
                    match = !match;
                    break;
                }
                
                i++;
            }


            if(VerifyMD5Hash(m, source+i, hash)) {
                Console.WriteLine("Match");
            } else {
                Console.WriteLine("No Match");
            }
            
            Console.ReadLine();
        }


        // Convert data to bytes and format as hexadecimal
        static string GetMD5Hash(MD5 md5, String input) {
            byte[] data = md5.ComputeHash(Encoding.UTF8.GetBytes(input));
            StringBuilder sb = new StringBuilder();

            foreach(byte b in data) {
                sb.Append(b.ToString("x2"));
            }

            return sb.ToString();
        }

        // Verify Hash against string
        static bool VerifyMD5Hash(MD5 md5,string input, string hash) {
            string inputHash = GetMD5Hash(md5, input);
            StringComparer comp = StringComparer.OrdinalIgnoreCase;

            if(0 == comp.Compare(inputHash, hash)) {
                return true;
            } else {
                return false;
            }

        }


    }
}
