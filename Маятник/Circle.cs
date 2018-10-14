using System.Drawing;

namespace Маятник
{
    internal class Circle
    {
        public Pen Pen { get; set; } = new Pen(Color.Black, 1);

        public void Draw(Graphics graphics, Point center_point, Point end_point, float radius)
        {
            graphics.DrawEllipse(Pen, center_point.X-radius/2 , center_point.Y-radius/2, radius, radius);//круг
            graphics.DrawLine(Pen, center_point, end_point);
        }
    }
}
