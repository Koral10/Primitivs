using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test4
{
    public class TrianglePrimitive : Primitive
    {
        public TrianglePrimitive(int initialSize) : base(initialSize) { }

        public override void Draw(Graphics graphics)
        {
            Point[] trianglePoints = {
                new Point(position.X + size / 2, position.Y),
                new Point(position.X, position.Y + size),
                new Point(position.X + size, position.Y + size)
            };
            graphics.FillPolygon(brush, trianglePoints);
            graphics.DrawPolygon(outlinePen, trianglePoints);
        }
    }
}
