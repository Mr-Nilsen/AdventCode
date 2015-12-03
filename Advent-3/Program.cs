using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace Advent_3 {
    class Program {
        

        static void Main(string[] args) {
            /*
            ** Part.1
            */ 

            List<Vector2> map = new List<Vector2>();
            Santa santa = new Santa();

            List<Vector2> map2 = new List<Vector2>();
            Santa santa2 = new Santa(map2);
            Santa robo = new Santa(map2);
            bool turn = true;

            map.Add(santa.WhereAreYou());

            StreamReader reader = new StreamReader("input.txt");
            String puzzle = reader.ReadToEnd();
            foreach(Char c in puzzle) {

                // Part.1
                santa.Move(c);
                Vector2 tmp = map.Find((loc => loc.Equal(santa.WhereAreYou())));
                if(tmp == null) {
                    map.Add(santa.WhereAreYou());
                }

                // Part.2
                Vector2 tmp2;
                if(turn) {
                    santa2.Move(c);
                    tmp2 = map2.Find((loc => loc.Equal(santa2.WhereAreYou())));
                    if(tmp2 == null) {
                        map2.Add(santa2.WhereAreYou());
                    }
                } else {
                    robo.Move(c);
                    tmp2 = map2.Find((loc => loc.Equal(robo.WhereAreYou())));
                    if(tmp2 == null) {
                        map2.Add(robo.WhereAreYou());
                    }
                }
                turn = !turn;

                
                
            }

            Console.WriteLine("Locations visited: " + map.Count());
            Console.WriteLine("Locations2 visited: " + map2.Count());
            Console.ReadLine();
        }
    }

    public class Santa {
        private Vector2 position;
        public List<Vector2> map;
        
        public Santa() {
            this.position = new Vector2(0, 0);
        }

        public Santa(List<Vector2> map) {
            this.position = new Vector2(0, 0);
            this.map = map;
        }

        public Vector2 WhereAreYou() {
            return new Vector2(this.position.GetX(), this.position.GetY());
        }

        public void Move(char c) {
            switch(c) {
                case '^':
                    this.position.SetY(this.position.GetY() + 1);
                    break;
                case '>':
                    this.position.SetX(this.position.GetX() + 1);
                    break;
                case '<':
                    this.position.SetX(this.position.GetX() - 1);
                    break;
                case 'v':
                    this.position.SetY(this.position.GetY() - 1);
                    break;
            }
        }


    }



    public class Vector2 {
        private int x, y;
        public Vector2(int x, int y) {
            this.x = x;
            this.y = y;
        }

        public int GetX() {
            return this.x;
        }

        public int GetY() {
            return this.y;
        }

        public void SetX(int x) {
            this.x = x;
        }

        public void SetY(int y) {
            this.y = y;
        }

        public Boolean Equal(Vector2 v) {
            return (this.x.Equals(v.GetX()) && (this.y.Equals(v.GetY())));
        }
    }
}
