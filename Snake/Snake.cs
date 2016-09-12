using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    
    class Snake
    {

        public Position pos = new Position(Console.WindowWidth / 2, Console.WindowHeight / 2);
        private int velocidad = 90;
        private Direccion desplazamiento;
        private ConsoleKeyInfo cki;
        public List<Position> body = new List<Position>();
        
        public Snake() {
            for(int i = 0; i < 5; i++)
                this.body.Add(new Position(this.pos.Posx, this.pos.Posy + i));
        }

        public enum Direccion
        {
            Up,
            Down,
            Right,
            Left
        }
        

        public void mover(ref bool salir) {
            this.cki = Console.ReadKey(true);
            switch (this.cki.KeyChar)
            {
                case 'w':
                    this.desplazamiento = Direccion.Up;
                    break;

                case 's':
                    this.desplazamiento = Direccion.Down;
                    break;

                case 'a':
                    this.desplazamiento = Direccion.Left;
                    break;

                case 'd':
                    this.desplazamiento = Direccion.Right;
                    break;

                case 'q':
                    salir = true;
                    break;

            }
            
        }
        
        public void cleanCKI() { this.cki = default(ConsoleKeyInfo); }

        public int Velocidad {
            get { return this.velocidad; }
            set { this.velocidad = value; }
        }

        public Direccion Desplazamiento {
            get { return this.desplazamiento; }
            set { this.desplazamiento = value; }
        }
    }
}
