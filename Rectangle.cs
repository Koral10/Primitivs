using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test4
{
    public class RectanglePrimitive : Primitive
    {
        public RectanglePrimitive(int initialSize) : base(initialSize) { }

        public override void Draw(Graphics graphics)
        {
            graphics.FillRectangle(brush, position.X, position.Y, size, size);
            graphics.DrawRectangle(outlinePen, position.X, position.Y, size, size);
        }
    }
}
