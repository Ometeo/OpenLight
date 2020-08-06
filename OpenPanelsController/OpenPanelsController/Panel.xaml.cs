using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;

namespace OpenPanelsController
{
    /// <summary>
    /// Interaction logic for Panel.xaml
    /// </summary>
    public partial class Panel : UserControl
    {
        public Panel()
        {
            InitializeComponent();
            DrawShape();
        }

        public void DrawShape()
        {
            int numberOfFaces = 3;

            Point center = new Point(150, 150);
            int radius = 150;
            double angle = 360.0f / numberOfFaces;
            double orientation = -90;

            Polygon polygon = new Polygon();
            polygon.Stroke = new SolidColorBrush(Colors.White);
            polygon.Fill = new SolidColorBrush(Colors.LightGray);

            for (int i = 0; i < numberOfFaces; i++)
            {
                Point p = new Point();
                p.X = center.X + Math.Cos((i * angle + orientation).ToRadians()) * radius;
                p.Y = center.Y + Math.Sin((i * angle + orientation).ToRadians()) * radius;
                polygon.Points.Add(p);
            }

            for (int i = 1; i < numberOfFaces; i++)
            {
                Button button = new Button();
                button.Content = "+";

                Canvas.SetLeft(button, center.X + Math.Cos((i * angle + orientation + angle / 2 + angle).ToRadians()) * radius);
                Canvas.SetTop(button, center.Y + Math.Sin((i * angle + orientation + angle / 2 + angle).ToRadians()) * radius);
                PanelShape.Children.Add(button);
            }

            PanelShape.Children.Add(polygon);
        }
    }

    public static class NumericExtensions
    {
        public static double ToRadians(this double val)
        {
            return (Math.PI / 180) * val;
        }
    }
}