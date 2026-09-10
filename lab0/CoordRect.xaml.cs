using System;
using System.Windows;

namespace lab0
{
    public partial class CoordRect : Window
    {
        private MainWindow mw;

        public CoordRect(MainWindow mainWindow)
        {
            InitializeComponent();
            mw = mainWindow;
        }

        public void CreateRectangle(object sender, RoutedEventArgs e)
        {
            int x = Convert.ToInt32(X1.Text);
            int y = Convert.ToInt32(Y1.Text);

            int width = Convert.ToInt32(Width.Text);
            int height = Convert.ToInt32(Height.Text);

            mw.CreateRectangleByCoordinates(
                x, y,
                width, height
            );

            Close();
        }
    }
}