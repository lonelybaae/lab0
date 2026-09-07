using System;
using System.Windows;

namespace lab0
{
    /// <summary>
    /// Логика взаимодействия для CoordTr.xaml
    /// </summary>
    public partial class CoordTr : Window
    {
        MainWindow mw;

        public CoordTr(MainWindow mainWindow)
        {
            InitializeComponent();
            mw = mainWindow;
        }

        public void CreateTriangle(object sender, RoutedEventArgs e)
        {
            int x1 = Convert.ToInt32(X1.Text);
            int y1 = Convert.ToInt32(Y1.Text);
            int x2 = Convert.ToInt32(X2.Text);
            int y2 = Convert.ToInt32(Y2.Text);
            int x3 = Convert.ToInt32(X3.Text);
            int y3 = Convert.ToInt32(Y3.Text);

            var p1 = new Point2D(x1, y1);
            var p2 = new Point2D(x2, y2);
            var p3 = new Point2D(x3, y3);

            var tr = new Triangle(p1, p2, p3);
            mw.DrawTriangle(tr);

            Close();
        }
    }
}
