using System.Drawing;

namespace Маятник
{
    internal class Pendulum
    {
        private static object _locker = new object();
        private static int STEPS = 18;
        private static int ELLIPS_RADIUS = 40;
        private static int SPEED = 10;
        private static int ANGLE = 1;
        private static double STEP_INCREMENT = 1;

        public Pen Pen { get; set; } = new Pen(Color.Black, 1);

        public Pendulum()
        {
        }

        public void Draw(Graphics graphics, Point center, Point line_end)
        {
            graphics.DrawEllipse(Pen, line_end.X - ELLIPS_RADIUS / 2, line_end.Y - ELLIPS_RADIUS / 2, ELLIPS_RADIUS, ELLIPS_RADIUS);//круг
            graphics.DrawLine(Pen, center, line_end);//Линия
        }
    }
}
