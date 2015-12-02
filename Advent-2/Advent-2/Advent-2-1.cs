using System;
using System.IO;
using System.Linq;


namespace Advent_2 {
    class Program {
        
        static void Main(string[] args) {
            int totalFeet = 0;
            int totalRibbon = 0;

            StreamReader reader = new StreamReader("dims.txt");
            String line;
            while((line = reader.ReadLine()) != null) {
                int[] dims = Array.ConvertAll(line.Split('x'), s => int.Parse(s));
                int[] result = new int[3];
                int small;
                /*
                ** Cal total square feet of paper
                */

                result[0] = (dims[0] * dims[1]);
                result[1] = (dims[1] * dims[2]);
                result[2] = (dims[2] * dims[0]);
                small = result.Min();
                totalFeet += (small + (2 * result.Sum()));

                /*
                ** Cal total feet of ribbon
                */

                if(dims[0] < dims[1] || dims[0] < dims[2]) {
                    if(dims[1] < dims[2]) {
                        totalRibbon += 2 * dims[1];
                    } else {
                        totalRibbon += 2 * dims[2];
                    }
                    totalRibbon += 2 * dims[0];
                } else {
                    totalRibbon += 2 * dims[1];
                    totalRibbon += 2 * dims[2];
                }
                totalRibbon += (dims[0] * dims[1] * dims[2]);
            }

            Console.WriteLine("Total square feet: " + totalFeet);
            Console.WriteLine("Total ribbon: " + totalRibbon);
            Console.ReadLine();
        }
    }
}
