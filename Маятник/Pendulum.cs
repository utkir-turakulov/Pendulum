using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Маятник
{
    /// <summary>
    /// Объект маятника реализуемый по паттерну синглтон
    /// </summary>
    class Pendulum
    {
        private static Pendulum _instance;
        private static object _locker = new object();

        /// <summary>
        /// Переменная направления маятника
        /// </summary>
        private static int _actiualDirection = (int)Direction.Clockwise;

        /// <summary>
        /// Определяет направление двичение маятника
        /// CounterClockwise - против часовой стрелки
        /// Clockwise - по часовой стрелке
        /// </summary>
        private enum Direction 
        {
            CounterClockwise = 0,
            Clockwise = 1
        }


        private Pendulum()
        {
        }

        /// <summary>
        /// Возвращает инстанс класса
        /// </summary>
        /// <returns></returns>
        public static Pendulum GetInstance()
        {
            if (_instance == null)
            {
                lock (_locker)
                {
                    if (_instance == null)
                    {
                        _instance = new Pendulum();
                    }
                }
            }
            return _instance;
        }

        /// <summary>
        /// Запускает задачу на отрисовку маятника
        /// </summary>
        /// <param name="form">Форма на которой отрисовать маятник</param>
        /// <param name="token">Токен для прерываия задачи</param>
        /// <returns>Task</returns>
        public Task Draw(Form form, CancellationToken token)
        {
            return new Task(() =>
            {
                Pen pen = new Pen(Color.Black, 2);
                double radius = 100;
                Graphics graphics = form.CreateGraphics();

                int y0 = form.Size.Height / 2;
                int x0 = form.Size.Width / 2;

                int counter = 100;
                double x = -1;
                double y = y0;
                double leftBorderX = -1 ;

                double angle = 10;
                double speed = 6;

                while (!token.IsCancellationRequested)
                {
                    if (_actiualDirection == (int)Direction.Clockwise)
                    {
                        if (x < 0)
                        {
                            x = x0 + radius * Math.Cos(DegreeToRadian(angle * speed));
                            leftBorderX =x -( 2 *radius);
                        }
                        else
                        {
                            x = x0 + radius * Math.Cos(DegreeToRadian(angle * speed));
                            y = y0 + radius * Math.Sin(DegreeToRadian(angle * speed));
                        }

                        if (x == leftBorderX)
                        {
                            _actiualDirection = (int)Direction.CounterClockwise;
                        }
                        
                    }
                    else
                    {
                        
                    }
                    
                    graphics.DrawLine(pen, new Point(x0, y0), new Point((int)x, (int)y));
                    angle++;
                    counter--;
                    Task.Delay(100).Wait();
                    graphics.Clear(Color.White);
                }
            });
        }


        private double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }
    }
}
