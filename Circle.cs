using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test4
{
    public class CirclePrimitive : Primitive
    {
        public CirclePrimitive(int initialSize) : base(initialSize) { }

        public override void Draw(Graphics graphics)
        {
            graphics.FillEllipse(brush, position.X, position.Y, size, size);
            graphics.DrawEllipse(outlinePen, position.X, position.Y, size, size); 
        }
    }
}
