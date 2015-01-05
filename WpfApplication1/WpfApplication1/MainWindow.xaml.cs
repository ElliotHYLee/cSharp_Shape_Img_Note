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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApplication1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double canvasWidth, canvasHeight;
        string folderAdd;
        Line line;
        public MainWindow()
        {
            InitializeComponent();
        }

        private Line getLine(double x)
        {
            double angle = x - 90;
            double origin = this.canvasWidth / 2;
            this.line.Visibility = System.Windows.Visibility.Visible;
            this.line.Stroke = System.Windows.Media.Brushes.Black;

            double lineLength = this.canvasWidth / 4;

            this.line.X1 = origin - Math.Cos(angle*Math.PI/180)*lineLength;
            this.line.Y1 = origin - Math.Sin(angle * Math.PI / 180) * lineLength;

            this.line.X2 = origin + Math.Cos(angle * Math.PI / 180) * lineLength;
            this.line.Y2 = origin + Math.Sin(angle * Math.PI / 180) * lineLength;
            
            
            this.line.StrokeThickness = 5; 
            return line;
        }


        private void btnLine_Click(object sender, RoutedEventArgs e)
        {

        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {

            this.line = new Line();
            this.txtAng.Text = "90";
            this.canvasWidth = this.canvas.Width;
            this.canvasHeight = this.canvas.Height;
            this.folderAdd = AbsAddress.getFolderAddr("Pictures");
            Image coord = new Image();
            coord.Source = new BitmapImage(new Uri(this.folderAdd + "coord.jpg"));
            coord.Height = this.canvasHeight;
            coord.Width = this.canvasWidth;
            
            ImageBrush imgb = new ImageBrush();
            imgb.ImageSource = coord.Source;

            this.canvas.Background = imgb;
        }

        private void btnShowImg_Click(object sender, RoutedEventArgs e)
        {
            this.canvas.Children.Clear();
            double angle = Double.Parse(this.txtAng.Text);
            this.canvas.Children.Add(this.getLine(angle));
        }



    }
}
