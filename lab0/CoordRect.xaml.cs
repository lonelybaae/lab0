using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using static System.Formats.Asn1.AsnWriter;

namespace lab0
{
    
    public partial class CoordRect : Window
    {
        MainWindow mw;
        Rectangle rt;
        int width;
        int height;

        public CoordRect(MainWindow mainWindow)
        {
            InitializeComponent();
            mw = mainWindow;
        }

        public void CreateRectangle(object sender, RoutedEventArgs e)
        {
            width = Convert.ToInt32(Width.Text);
            height = Convert.ToInt32(Height.Text);
            Point2D p1 = new Point2D(Convert.ToInt32(X1.Text), Convert.ToInt32(Y1.Text));
            Point2D p2 = new Point2D(p1.X + width, p1.Y);
            Point2D p3 = new Point2D((p1.X + width), (p1.Y - height));
            Point2D p4 = new Point2D((p1.X), (p1.Y - height));
            rt = new Rectangle(p1, p2, p3, p4);
            mw.DrawRectangle(rt);
            Close();
        }
    }
}
