using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class food
    {
        private static Random r = new Random();
        
        public Position pos = new Position(r.Next(3, Console.WindowWidth-3), r.Next(3, Console.WindowHeight-3));
        private string type;
        private string figura = "@";
        
        public void cambiarTipo(string type)
        {
            this.type = type;
            if (this.type == "comida")
            {
                this.figura = "@";
            }
            else if (this.type == "trampa")
            {
                this.figura = "#";
            }
            else if (this.type == "powerUp")
            {
                this.figura = "^";
            }
        }

        public string Figura {
            get { return this.figura; }
            set { this.figura = value; }
        }

        public void cambiarPosicion() {
            this.pos.Posx = r.Next(3, Console.WindowWidth - 3);
            this.pos.Posy = r.Next(3, Console.WindowHeight - 3);
        }

    }
}
