using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;

namespace Маятник
{
    class GraphicLogic
    {
        private static int STEPS = 18;
        private static int ELLIPS_RADIUS = 40;
        private static int SPEED = 10;
        private static int ANGLE = 1;
        private static double STEP_INCREMENT = 1;
        private static double CIRCLE_STEP_INCREMENT = 2;
        private static double PENDULUM_RADIUS = 150;
        private static double CIRCLE_RADIUS = 80;



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

        /// <summary>
        /// Переменная направления маятника
        /// </summary>
        private static int _actiualDirection = (int)Direction.Clockwise;

        public GraphicLogic()
        {

        }

        /// <summary>
        /// Выполняет отрисовку графических объектов
        /// </summary>
        /// <param name="form">Форма для отображения объектов</param>
        /// <param name="token">Токен для прерывания работы потока</param>
        /// <returns></returns>
        public Task Draw(Form1 form, CancellationToken token)
        {
            Graphics graphics = form.CreateGraphics();
            Pendulum pendulum = new Pendulum();
            Circle circle = new Circle();

            return new Task(() =>
            {
                int FORM_BASE_Y = form.Size.Height / 2;
                int FORM_BASE_X = form.Size.Width / 2;
                double CIRCLE_BASE_X = FORM_BASE_X - 300;
                double CIRCLE_BASE_Y = FORM_BASE_Y - 50;

                double CIRCLE_X = -1;
                double CIRCLE_Y = CIRCLE_BASE_Y;

                int counter = 0;
                double PENDULUM_X = -1;
                double PENDULUM_Y = FORM_BASE_Y;
                int iterator = 0;
                int circle_iterator = 0;


                while (!token.IsCancellationRequested)//пока не получена команда на прерывание потока
                {
                    if (_actiualDirection == (int)Direction.Clockwise)//определяем направление движения маятника
                    {
                        if (PENDULUM_X < 0 && CIRCLE_X < 0)
                        {
                            PENDULUM_X = GetNextMove(FORM_BASE_X, FORM_BASE_Y, PENDULUM_RADIUS, iterator)["x"];
                            CIRCLE_X = CIRCLE_BASE_X - CIRCLE_RADIUS;
                        }
                        else
                        {
                            PENDULUM_X = GetNextMove(FORM_BASE_X, FORM_BASE_Y, PENDULUM_RADIUS, iterator)["x"];
                            PENDULUM_Y = GetNextMove(FORM_BASE_X, FORM_BASE_Y, PENDULUM_RADIUS, iterator)["y"];

                            CIRCLE_X = GetNextMove(CIRCLE_BASE_X, CIRCLE_BASE_Y, CIRCLE_RADIUS / 2, circle_iterator)["x"];
                            CIRCLE_Y = GetNextMove(CIRCLE_BASE_X, CIRCLE_BASE_Y, CIRCLE_RADIUS / 2, circle_iterator)["y"];
                        }

                        if (counter == STEPS)
                        {
                            _actiualDirection = (int)Direction.CounterClockwise;
                        }
                        else
                        {
                            counter++;
                            iterator += (int)STEP_INCREMENT;
                            circle_iterator += (int)CIRCLE_STEP_INCREMENT;
                        }
                    }
                    else
                    {
                        if (counter >= 0)
                        {
                            counter--;
                            iterator -= (int)STEP_INCREMENT;
                            circle_iterator -= (int)CIRCLE_STEP_INCREMENT;
                            PENDULUM_X = GetNextMove(FORM_BASE_X, FORM_BASE_Y, PENDULUM_RADIUS, iterator)["x"];
                            PENDULUM_Y = GetNextMove(FORM_BASE_X, FORM_BASE_Y, PENDULUM_RADIUS, iterator)["y"];

                            CIRCLE_X = GetNextMove(CIRCLE_BASE_X, CIRCLE_BASE_Y, CIRCLE_RADIUS / 2, circle_iterator)["x"];
                            CIRCLE_Y = GetNextMove(CIRCLE_BASE_X, CIRCLE_BASE_Y, CIRCLE_RADIUS / 2, circle_iterator)["y"];
                        }
                        else
                        {
                            _actiualDirection = (int)Direction.Clockwise;
                        }
                    }
                    pendulum.Draw(graphics, new Point(FORM_BASE_X, FORM_BASE_Y), new Point((int)PENDULUM_X, (int)PENDULUM_Y));
                    circle.Draw(graphics, new Point((int)FORM_BASE_X - 300, (int)FORM_BASE_Y - 50), new Point((int)CIRCLE_X, (int)CIRCLE_Y), (int)CIRCLE_RADIUS);

                    Task.Delay(300).Wait();
                    graphics.Clear(Color.White);
                }
            });
        }

        /// <summary>
        /// Переводит градусы в радианы
        /// </summary>
        /// <param name="angle">Угол в градусах</param>
        /// <returns>Радиан</returns>
        private double DegreeToRadian(double angle)
        {
            return Math.PI * angle / 180.0;
        }

        /// <summary>
        /// Находит координаты следующей точки 
        /// </summary>
        /// <param name="x0">X - координата цента</param>
        /// <param name="y0">Y - координата центра</param>
        /// <param name="radius">Радиус окружности</param>
        /// <param name="iterator">Параметр сдвига угла по окружности</param>
        /// <returns></returns>
        private Dictionary<string, double> GetNextMove(double x0, double y0, double radius, int iterator)
        {
            double result_x = x0 + radius * Math.Cos(DegreeToRadian((ANGLE + iterator) * SPEED));
            double result_y = y0 + radius * Math.Sin(DegreeToRadian((ANGLE + iterator) * SPEED));

            return new Dictionary<string, double>() {
                {"x", result_x},
                {"y", result_y}
            };
        }

        private Dictionary<string, double> GetCircleNextMove(double x0, double y0, double radius, int iterator)
        {
            double result_x = x0 + radius * Math.Cos(DegreeToRadian((ANGLE + iterator) * SPEED));
            double result_y = y0 + radius * Math.Sin(DegreeToRadian((ANGLE + iterator) * SPEED));

            return new Dictionary<string, double>() {
                {"x", result_x},
                {"y", result_y}
            };
        }


    }
}
