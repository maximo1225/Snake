using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Position
    {
        private int x;
        private int y;

        public Position(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int Posx
        {
            get { return this.x; }
            set { this.x = value; }
        }

        public int Posy
        {
            get { return this.y; }
            set { this.y = value; }
        }
    }
}
