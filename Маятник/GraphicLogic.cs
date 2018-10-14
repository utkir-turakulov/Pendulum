using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Маятник
{
    /// <summary>
    /// Заключаетс в себе логику объектов
    /// </summary>
    class GraphicLogic
    {
        private static int STEPS = 18;
        private static int ELLIPS_RADIUS = 40;
        private static int SPEED = 10;
        private static int ANGLE = 1;
        private static int CIRCLE_ANGLE = 10;
        private static float STEP_INCREMENT = 1;
        private static float CIRCLE_STEP_INCREMENT = 1;
        private static float PENDULUM_RADIUS = 150;
        private static float CIRCLE_RADIUS = 150;
        private static float CIRCLE_SPEED = 20;



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
            Panel pendulumPanel = form.Controls["PendulumPanel"] as Panel;
            Graphics pendulumPanelGraphics = pendulumPanel.CreateGraphics();

            Panel circlePanel = form.Controls["CirclePanel"] as Panel;
            Graphics circleGraphics = circlePanel.CreateGraphics();

            Panel sinusoidPanel = form.Controls["SinusoidPanel"] as Panel;
            Graphics sinusoidGraphics = sinusoidPanel?.CreateGraphics();

            Pendulum pendulum = new Pendulum();
            Circle circle = new Circle();
            Sinusoid sinusoid = new Sinusoid();

            return new Task(() =>
            {
                float FORM_BASE_Y = form.Size.Height / 2;
                float FORM_BASE_X = form.Size.Width / 2;

                float PENDULUM_BASE_X = pendulumPanel.Size.Width /2 ;//FORM_BASE_X;
                float PENDULUM_BASE_Y = (pendulumPanel.Size.Height / 2) -100 ;//(form.Size.Height / 2);

                float CIRCLE_BASE_X = circlePanel.Size.Width /2;
                float CIRCLE_BASE_Y = circlePanel.Size.Height /2;

                float CIRCLE_X = -1;
                float CIRCLE_Y = CIRCLE_BASE_Y;

                int counter = 0;
                float PENDULUM_X = -1;
                float PENDULUM_Y = PENDULUM_BASE_Y;//FORM_BASE_Y;
                int iterator = 0;
                int circle_iterator = 0;

                

                float SINUSOID_BASE_X = sinusoidPanel.Size.Width /2 -100;//PENDULUM_BASE_X + 100;
                float SINUSOID_BASE_Y = sinusoidPanel.Size.Height/2 -20;//PENDULUM_BASE_Y+150;


                while (!token.IsCancellationRequested)//пока не получена команда на прерывание потока
                {
                    if (_actiualDirection == (int)Direction.Clockwise)//определяем направление движения маятника
                    {
                        if (PENDULUM_X < 0 && CIRCLE_X < 0)
                        {
                          //  PENDULUM_X =(float) GetNextMove(FORM_BASE_X, FORM_BASE_Y, PENDULUM_RADIUS, iterator)["x"];
                            PENDULUM_X =(float) GetNextMove(PENDULUM_BASE_X, PENDULUM_BASE_Y, PENDULUM_RADIUS, iterator)["x"];
                            CIRCLE_X = CIRCLE_BASE_X - CIRCLE_RADIUS;
                        }
                        else
                        {
                            // PENDULUM_X =(float) GetNextMove(FORM_BASE_X, PENDULUM_BASE_Y, PENDULUM_RADIUS, iterator)["x"];
                            // PENDULUM_Y =(float) GetNextMove(FORM_BASE_X, PENDULUM_BASE_Y, PENDULUM_RADIUS, iterator)["y"];

                            PENDULUM_X = (float)GetNextMove(PENDULUM_BASE_X, PENDULUM_BASE_Y, PENDULUM_RADIUS, iterator)["x"];
                            PENDULUM_Y =(float) GetNextMove(PENDULUM_BASE_X, PENDULUM_BASE_Y, PENDULUM_RADIUS, iterator)["y"];

                            CIRCLE_X =(float) GetCircleNextMove(CIRCLE_BASE_X, CIRCLE_BASE_Y, CIRCLE_RADIUS / 2, circle_iterator)["x"];
                            CIRCLE_Y =(float) GetCircleNextMove(CIRCLE_BASE_X, CIRCLE_BASE_Y, CIRCLE_RADIUS / 2, circle_iterator)["y"];
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

                            // PENDULUM_X = (float) GetNextMove(FORM_BASE_X, PENDULUM_BASE_Y, PENDULUM_RADIUS, iterator)["x"];
                            // PENDULUM_Y =(float) GetNextMove(FORM_BASE_X, PENDULUM_BASE_Y, PENDULUM_RADIUS, iterator)["y"];

                            PENDULUM_X = (float)GetNextMove(PENDULUM_BASE_X, PENDULUM_BASE_Y, PENDULUM_RADIUS, iterator)["x"];
                            PENDULUM_Y = (float)GetNextMove(PENDULUM_BASE_X, PENDULUM_BASE_Y, PENDULUM_RADIUS, iterator)["y"];

                            CIRCLE_X = (float)GetCircleNextMove(CIRCLE_BASE_X, CIRCLE_BASE_Y, CIRCLE_RADIUS / 2, circle_iterator)["x"];
                            CIRCLE_Y = (float)GetCircleNextMove(CIRCLE_BASE_X, CIRCLE_BASE_Y, CIRCLE_RADIUS / 2, circle_iterator)["y"];
                        }
                        else
                        {
                            _actiualDirection = (int)Direction.Clockwise;
                        }
                    }

                    pendulum.Draw(pendulumPanelGraphics, new Point((int)PENDULUM_BASE_X, (int)PENDULUM_BASE_Y ), new Point((int)PENDULUM_X, (int)PENDULUM_Y));

                    circle.Draw(circleGraphics, new Point((int)CIRCLE_BASE_X , (int)CIRCLE_BASE_Y ), new Point((int)CIRCLE_X, (int)CIRCLE_Y), (int)CIRCLE_RADIUS);

                    sinusoid.Animation(sinusoidGraphics, Color.DodgerBlue, (int)SINUSOID_BASE_X, (int)SINUSOID_BASE_X +200 , (int)SINUSOID_BASE_Y);
                    sinusoid.MoveCircle(sinusoidGraphics, Color.Violet, (int)(SINUSOID_BASE_X), (int)SINUSOID_BASE_Y+ 200, 5, iterator);
                    
                    Task.Delay(150).Wait();
                    circleGraphics.Clear(Color.White);
                    pendulumPanelGraphics.Clear(Color.White);
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
        private Dictionary<string, double> GetNextMove(float x0, float y0, float radius, int iterator)
        {
            double result_x = x0 + radius * Math.Cos(DegreeToRadian((ANGLE + iterator) * SPEED));
            double result_y = y0 + radius * Math.Sin(DegreeToRadian((ANGLE + iterator) * SPEED));

            return new Dictionary<string, double>() {
                {"x", result_x},
                {"y", result_y}
            };
        }

        private Dictionary<string, double> GetCircleNextMove(float x0, float y0, float radius, int iterator)
        {

            double result_x = x0 + radius * Math.Cos(DegreeToRadian((CIRCLE_ANGLE + iterator) * CIRCLE_SPEED));
            double result_y = y0 + radius * Math.Sin(DegreeToRadian((CIRCLE_ANGLE + iterator) * CIRCLE_SPEED));

            return new Dictionary<string, double>() {
                {"x", result_x},
                {"y", result_y}
            };
        }
    }
}
