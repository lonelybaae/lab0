using System;
using System.Windows;

namespace lab0
{
    public partial class CoordTr : Window
    {
        private MainWindow mw;

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

            mw.CreateTriangleByCoordinates(
                x1, y1,
                x2, y2,
                x3, y3
            );

            Close();
        }
    }
}