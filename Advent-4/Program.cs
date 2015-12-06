using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Windows.Input;
using System.Threading;

namespace Advent_4 {
    class Program {
        static void Main(string[] args) {
            List<Thread> tList = new List<Thread>();
            List<ComputeHash> chList = new List<ComputeHash>();
            List<int> matches = new List<int>();

            String source = "bgvyzdsv";
            string match = "00000";

            int threads = 4;
            int scope = 500000;

            for(int i = 0; i < threads; i++) {
                Thread t;
                ComputeHash h = new ComputeHash((i+1), source, i*scope, (i+1)*scope);
                chList.Add(h);
            }

            bool run = false;
            while(!run) {
                foreach(ComputeHash ch in chList) {
                    if(ch.match) {
                        run = true;
                        matches.Add(ch.current);
                        ch.thread.Abort();

                        foreach(ComputeHash c in chList) {
                            if(ch.id < c.id && ch.id != c.id) {
                                Console.WriteLine("Thread ID: " + c.id + " aborted");
                                c.thread.Abort();
                            }
                        }
                        
                    }
                }
            }

            if(!run) {
                Console.WriteLine("No match :<");
            } else {
                Console.WriteLine("This should be the lowest values: " + matches.Min());
            }



            Console.ReadLine();
        }
    }

    public class ComputeHash {
        public Thread thread;
        private string source;
        private int start, stop;
        public int id, current;
        public bool match = false;
        public ComputeHash(int id, string source, int start, int stop) {
            this.id = id;
            this.source = source;
            this.start = start;
            this.stop = stop;

            this.thread = new Thread(this.Compute);
            this.thread.Start();
        }

        public void Compute() {
            MD5 m = MD5.Create();
            string hash = GetMD5Hash(m, source + start);

            current = start;

            while(!match && !current.Equals(stop)) {
                hash = GetMD5Hash(m, source + current);
                String five = hash.Substring(0, 6);
                Console.WriteLine(id + " - " + hash + " - " + current + " - " + five);

                // Change this 
                if(five.Equals("000000")) {
                    Console.WriteLine("We have a match: " + hash + " - " + current + " - " + five);
                    match = !match;
                    break;
                }

                current++;
            }
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
        static bool VerifyMD5Hash(MD5 md5, string input, string hash) {
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
