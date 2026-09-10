using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab0
{
    public class Rectangle
    {
        //Свойства класса
        public Point2D P1 { get; private set; }
        public Point2D P2 { get; private set; }
        public Point2D P3 { get; private set; }
        public Point2D P4 { get; private set; }

        //Конструктор класса
        public Rectangle(Point2D p1, Point2D p2, Point2D p3, Point2D p4)
        {
            P1 = p1;
            P2 = p2;
            P3 = p3;
            P4 = p4;
        }

        public void AddX(int x)
        {
            P1.AddX(x);
            P2.AddX(x);
            P3.AddX(x);
            P4.AddX(x);
        }
        public void AddY(int y)
        {
            P1.AddY(y);
            P2.AddY(y);
            P3.AddY(y);
            P4.AddY(y);
        }
    }
}
