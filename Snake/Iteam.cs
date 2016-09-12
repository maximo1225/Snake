using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Snake
{
    class Iteam
    {
        private string itemType;
        private Position position = new Position(0, 0);
        private string figura = "*";

        public string ItemType {
            get { return this.itemType; }
            set { this.itemType = value; }
        }

        public string Figura {
            get { return this.figura; }
            set { this.figura = value; }
        }
    }
}
