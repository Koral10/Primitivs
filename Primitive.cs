using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test4
{
    public abstract class Primitive
    {

        protected Point position;
        protected int size;
        protected Brush brush = Brushes.Yellow;
        protected Pen outlinePen = new Pen(Color.Black, 2);
        public Primitive(int initialSize)
        {
            size = initialSize;
            position = new Point(0, 0);
        }
        public Point Position
        {
            get { return position; }
            set { position = value; }
        }

        public void SetPosition(Point newPosition)
        {
            position = newPosition;
        }

        public void SetSize(int newSize)
        {
            if (newSize < 300)
                size = Math.Max(10, newSize);
        }

        public abstract void Draw(Graphics graphics);
    }
}
