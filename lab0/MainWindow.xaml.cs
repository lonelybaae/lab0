using System.Security.Cryptography.Xml;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace lab0
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Triangle tr;
        Rectangle rt;
        CoordTr coordTr;
        CoordRect coordRect;  
        Random rnd = new Random();

        int width;
        int height;

        public MainWindow()
        {
            InitializeComponent();
         
        }

        //функция в основном теле программы
        public void DrawLine(Point2D p1, Point2D p2)
        {
            //Создание новой линии
            Line line = new Line();
            //Цвет и толщина линии
            line.Stroke = Brushes.Red;
            line.StrokeThickness = 3;
            //Установка координат линии из координат точек Point2D
            line.X1 = p1.X;
            line.Y1 = p1.Y;
            line.X2 = p2.X;
            line.Y2 = p2.Y;
            //Добавление линии в Canvas
            Scene.Children.Add(line);
        }

        public void DrawTriangle(Triangle tr)
        {
            //Отрисовка треугольника с помощью функции отрисовки линии
            DrawLine(tr.P1, tr.P2);
            DrawLine(tr.P2, tr.P3);
            DrawLine(tr.P3, tr.P1);
        }
        public void DrawRectangle(Rectangle rt)
        {
             
            DrawLine(rt.P1, rt.P2);
            DrawLine(rt.P2, rt.P3); 
            DrawLine(rt.P3, rt.P4);
            DrawLine(rt.P4, rt.P1);
        }
        public void CreateTriangleByCoordinates(
    int x1, int y1,
    int x2, int y2,
    int x3, int y3)
        {
            Point2D p1 = new Point2D(x1, y1);
            Point2D p2 = new Point2D(x2, y2);
            Point2D p3 = new Point2D(x3, y3);
            tr = new Triangle(p1, p2, p3);
            previousX = SliderX.Value;
            previousY = SliderY.Value;
            ClearScene();
            DrawTriangle(tr);
        }

        public void CreateRectangleByCoordinates(
            int x,
            int y,
            int width,
            int height)
        {
            Point2D p1 = new Point2D(x, y);
            Point2D p2 = new Point2D(x + width,y);
            Point2D p3 = new Point2D(x + width,y - height);
            Point2D p4 = new Point2D(x,y - height);
            rt = new Rectangle(p1, p2, p3, p4);
            previousX = SliderX.Value;
            previousY = SliderY.Value;
            ClearScene();
            DrawRectangle(rt);
        }


        public void ClearScene()
        {
            Scene.Children.Clear();
        }

        private void createRect(object sender, RoutedEventArgs e)
        {
            ClearScene();
            width = rnd.Next(0, (int)Scene.Width);
            height = rnd.Next((int)Scene.Height);
            Point2D p1 = new Point2D(rnd.Next(0, (int)Scene.Width), rnd.Next(0, (int)Scene.Height));
            Point2D p2 = new Point2D(p1.X + width, p1.Y);
            Point2D p3 = new Point2D((p1.X + width), (p1.Y - height));
            Point2D p4 = new Point2D((p1.X), (p1.Y - height));
            rt = new Rectangle(p1, p2, p3, p4);
            tr = null;
            DrawRectangle(rt);
        }

        private void Clear(object sender, RoutedEventArgs e)
        {
            ClearScene();
        }

        private void createTr(object sender, RoutedEventArgs e)
        {
            //Создание треугольника со случайными координатами
            ClearScene();
            Point2D p1 = new Point2D(rnd.Next(0, (int)Scene.Width), rnd.Next(0, (int)Scene.Height));
            Point2D p2 = new Point2D(rnd.Next(0, (int)Scene.Width), rnd.Next(0, (int)Scene.Height));
            Point2D p3 = new Point2D(rnd.Next(0, (int)Scene.Width), rnd.Next(0, (int)Scene.Height));
            tr = new Triangle(p1, p2, p3);
            rt = null;
            DrawTriangle(tr);
        }

        private void createCoordTr(object sender, RoutedEventArgs e)
        {
            coordTr = new CoordTr(this);
            coordTr.Show();
        }

        private void createCoordRect(object sender, RoutedEventArgs e)
        {
            //вот тут this
            coordRect = new CoordRect(this);
            coordRect.Show();
        }

        private double previousX = 0;
        private double previousY = 0;

        private void SliderX_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int dx = (int)(e.NewValue - previousX);

            if (tr != null)
            {
                tr.AddX(dx);
                ClearScene();
                DrawTriangle(tr);
            } 
            else if (rt != null)
            {
                rt.AddX(dx);
                ClearScene();
                DrawRectangle(rt);
            }

            previousX = e.NewValue;
        }

        private void SliderY_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int dy = (int)(e.NewValue - previousY);

            if (tr != null)
            {
                tr.AddY(dy);
                ClearScene();
                DrawTriangle(tr);
            }
            else if (rt != null)
            {
                rt.AddY(dy);
                ClearScene();
                DrawRectangle(rt);
            }

            previousY = e.NewValue;


        }
    }
}