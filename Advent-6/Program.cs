using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Advent_6 {
    class Program {
        static void Main(string[] args) {
            StreamReader reader = new StreamReader("input.txt");
            String line;
            int count = 0;
            // Initialize Zeh Grid
            Light[,] grid = new Light[1000, 1000];

            for(int x = 0; x < 1000; x++) {
                for(int y = 0; y < 1000; y++) {
                    grid[x, y] = new Light();
                }
            }

            while(( line = reader.ReadLine()) != null) {
                string[] arr = line.Split(' ');
                
                int[] p1 = new int[2];
                int[] p2 = new int[2];

                if(line.Contains("toggle")) {
                    p1[0] = int.Parse(arr[1].Split(',')[0]);
                    p1[1] = int.Parse(arr[1].Split(',')[1]);

                    p2[0] = int.Parse(arr[3].Split(',')[0]);
                    p2[1] = int.Parse(arr[3].Split(',')[1]);

                } else if(line.Contains("turn")) {
                    p1[0] = int.Parse(arr[2].Split(',')[0]);
                    p1[1] = int.Parse(arr[2].Split(',')[1]);

                    p2[0] = int.Parse(arr[4].Split(',')[0]);
                    p2[1] = int.Parse(arr[4].Split(',')[1]);
                }

                for(int x = p1[0]; x <= p2[0]; x++) {
                    for(int y = p1[1]; y <= p2[1]; y++) {
                        if(line.Contains("toggle")) {
                            grid[x, y].Toggle();
                            grid[x, y].doubleUp();
                        } else if(line.Contains("turn off")) {
                            grid[x, y].TurnOff();
                            grid[x, y].down();
                        } else if(line.Contains("turn on")) {
                            grid[x, y].TurnOn();
                            grid[x, y].up();
                        }
                    }
                } 
            }
            int totalLevel = 0;
            foreach(Light l in grid) {
                if(l.GetState()) {
                    count++;
                }
                totalLevel += l.GetLevel();
            }
            Console.WriteLine("Part.1: " + count);
            Console.WriteLine("Part.2: " + totalLevel);
            Console.ReadLine();

        }
    }

    class Light {
        bool state = false;
        int level = 0;
        public Light() {}

        public bool GetState() {
            return this.state;
        }

        public bool Toggle() {
            return this.state = !state;
        }

        public void TurnOn() {
            this.state = true;
        }

        public void TurnOff() {
            this.state = false;
        }

        public int GetLevel() {
            return level;
        }

        public void doubleUp() {
            level += 2;
        }

        public void up() {
            level++;
        }

        public void down() {
            if(level > 0) {
                level--;
            }
        }
    }
}
