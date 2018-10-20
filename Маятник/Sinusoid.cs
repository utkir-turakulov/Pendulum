using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace Маятник
{
    class Sinusoid
    {
        public Pen Pen { get; set; } = new Pen(Color.Black, 3);

        /// <summary>
        /// Амплитуда графика
        /// </summary>
        public float Amplitude { get; set; } = 80.0f;
        /// <summary>
        /// Частота графика
        /// </summary>
        public float Frequency { get; set; } = 2.0f;
        /// <summary>
        /// Фаза графика
        /// </summary>
        public float Phase { get; set; } = 0.0f;
        /// <summary>
        /// Отступ сверху
        /// </summary>
        public float PaddingTop { get; set; } = 120;


        /// <summary>
        /// Отрисовка графика
        /// </summary>
        /// <param name="grfx">Объект рисования</param>
        /// <param name="clr">Цвет</param>
        /// <param name="start_x">Начало отрисовки</param>
        /// <param name="end_x">Конец отрисовки</param>
        /// <param name="width">Ширина графика</param>
        public void Animation(Graphics grfx, Color clr, int start_x, int end_x, int width)
        {
            List<PointF> points = new List<PointF>();

            for (int i = start_x; i <= end_x; i++)
            {
                float y = (float)(Amplitude * Math.Sin((2.0f * Math.PI * Frequency * i / (end_x)) + Phase)) + PaddingTop;

                points.Add(new PointF()
                {
                    X = i,
                    Y = y
                });
            }

            Dictionary<string, float> extremums = GetGraphicsCenter(points.ToArray());
            float center = (extremums["max"] + extremums["min"]) / 2;
            float center_x = points.Where(x => x.Y == center).First().X;

            List<PointF> new_points = points.Skip(Convert.ToInt32(center_x - start_x)).ToList();

            //Синусоида
            grfx.DrawLines(
                new Pen(clr),
                new_points.ToArray());

            //Ось Х
            grfx.DrawLine(
                   new Pen(Color.Black),
                   new PointF()
                   {
                       X = center_x,
                       Y = center
                   },
                   new PointF()
                   {
                       X = points[points.Count - 1].X,
                       Y = center

                   });

            // Ось Y 
            grfx.DrawLine(
                new Pen(Color.Black),
                new PointF()
                {
                    X = center_x,
                    Y = extremums["max"]
                },
                new PointF()
                {
                    X = center_x,
                    Y = extremums["min"]
                });


        }


        public void MoveCircle(Graphics graphics, Color color, int start_x, int end_x, int radius, int step)
        {
            float y = (float)(Amplitude * Math.Sin((2.0f * Math.PI * Frequency * step + start_x / (end_x)) + Phase)) + PaddingTop;

            graphics.DrawEllipse(new Pen(color), start_x - radius / 2, y - radius / 2, radius, radius);

        }


        private Dictionary<string, float> GetGraphicsCenter(PointF[] points)
        {
            float min = points[0].Y;
            float max = points[0].Y;

            int top_point = 0;
            bool min_achived = false;

            for (int i = 1; i < points.Length; i++)
            {
                if (max >= points[i].Y)
                {
                    max = points[i].Y;
                }
                else
                {
                    top_point = i;
                    break;
                }

            }
            min = points[top_point].Y;
            for (int i = top_point; i < points.Length; i++)
            {
                if (min <= points[i].Y && !min_achived)
                {
                    min = points[i].Y;
                }
                else
                {
                    min_achived = true;
                }
            }

            return new Dictionary<string, float>()
            {
                {"max", max },
                {"min",min }

            };
        }

        private Dictionary<string, float> GetGraphicsCenter(int start_x, int end_x)
        {
            List<PointF> points = new List<PointF>();

            for (int i = start_x; i <= end_x; i++)
            {
                float y = (float)(Amplitude * Math.Sin((2.0f * Math.PI * Frequency * i / (end_x)) + Phase)) + PaddingTop;

                points.Add(new PointF()
                {
                    X = i,
                    Y = y
                });
            }

            float min = points[0].Y;
            float max = points[0].Y;

            int top_point = 0;
            bool min_achived = false;

            for (int i = 1; i < points.Count; i++)
            {
                if (max >= points[i].Y)
                {
                    max = points[i].Y;
                }
                else
                {
                    top_point = i;
                    break;
                }

            }
            min = points[top_point].Y;
            for (int i = top_point; i < points.Count; i++)
            {
                if (min <= points[i].Y && !min_achived)
                {
                    min = points[i].Y;
                }
                else
                {
                    min_achived = true;
                }
            }

            return new Dictionary<string, float>()
            {
                {"max", max },
                {"min",min }

            };
        }
    }
}
