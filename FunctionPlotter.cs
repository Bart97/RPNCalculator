using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace RPNCalculator
{
    partial class FunctionPlotter : Form
    {
        public Dictionary<double, double> points;
        public CompiledExpression expression;

        public FunctionPlotter()
        {
            points = new Dictionary<double,double>();
            InitializeComponent();
            ClientSize = new Size(500, 500);
        }

        // FIXME: There's an issue with rounding. Reproduction: f(x) = 2 x ^ for x = 0,5 is for some reason rounded to 0,3
        // TODO: Deal with asimptotes
        // TODO: More exact plots
        private void FunctionPlotter_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawLine(Pens.Black, new Point(250, 0), new Point(250, 500));
            g.DrawLine(Pens.Black, new Point(0, 250), new Point(500, 250));

            DrawScale(g);
            Point[] pointArray = new Point[points.Count];
            byte[] types = new byte[points.Count];
            int i = 0;
            int lastx = -1;
            int lasty = -1;
            Stack<double> functionStack = new Stack<double>();

            foreach (KeyValuePair<double, double> point in points)
            {
                int x = (int)Math.Round(250 + (10 * point.Key));
                int y = (int)Math.Round(250 - (10 * point.Value));
                if (lastx != -1 && lasty != -1)
                {
                    int distanceSquare = (int)(Math.Pow(x - lastx, 2) + Math.Pow(y - lasty, 2));
                    double nextX = point.Key;
                    while (distanceSquare > 2)
                    {
                        nextX -= 0.025D;
                        RPNEvaluator.x.Value = nextX;
                        expression.Execute(functionStack);
                        double nextY = functionStack.Pop();
                        int drawX = (int)Math.Round(250 + (10 * nextX));
                        int drawY = (int)Math.Round(250 - (10 * nextY));
                        g.FillRectangle(Brushes.Blue, drawX, drawY, 1, 1);
                        distanceSquare = (int)(Math.Pow(drawX - lastx, 2) + Math.Pow(drawY - lasty, 2));

                    }
                }
                Point p = new Point(250 + (int)Math.Round((decimal)10 * (decimal)point.Key, MidpointRounding.AwayFromZero), 250 - (int)Math.Round((decimal)10 * (decimal)point.Value, MidpointRounding.AwayFromZero));
                //g.DrawLine(Pens.Black, p, p);
                g.FillRectangle(Brushes.Black, x, y, 1, 1);
                //pointArray[i] = new Point(x, y);
                //types[i] = i == 0 ? (byte)PathPointType.Start : (byte)PathPointType.Line;
                lastx = x;
                lasty = y;
                i++;
            }
            //GraphicsPath path = new GraphicsPath(pointArray,types);
            //g.DrawPath(Pens.Black, path);
        }

        private void DrawScale(Graphics g)
        {
            for (int i = 0; i < 500; i += 10)
            {
                g.DrawLine(Pens.Black, new Point(248, i), new Point(252, i));
                g.DrawLine(Pens.Black, new Point(i, 248), new Point(i, 252));
            }
        }
    }
}
