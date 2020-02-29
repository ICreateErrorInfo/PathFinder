using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace PathFinder {

    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow: Window {

        public MainWindow() {
            InitializeComponent();
        }

        readonly List<Point> _points = new List<Point>();

        private void Canvas_LeftMouseDown(object sender, MouseButtonEventArgs e) {

            var pt = e.GetPosition(Canvas);

            const double diameter = 10;
            var c = new Ellipse {
                Width  = diameter,
                Height = diameter,
                Fill   = Brushes.Black
            };

            c.MouseLeftButtonDown += (o, buttonEventArgs) => {
                var me = (Ellipse) o;
                buttonEventArgs.Handled = true;
                var myPos = new Point(Canvas.GetLeft(me) - diameter / 2, Canvas.GetTop(me) - diameter / 2);
                _points.Remove(myPos);
                Canvas.Children.Remove(me);
            };

            c.MouseRightButtonDown += (o, buttonEventArgs) => {

                var me = (Ellipse) o;

                if (_p1 == null) {

                    _p1 = new Point(Canvas.GetLeft(me) +diameter /2, Canvas.GetTop(me) +diameter /2);

                } else if (_p2 == null) {

                    _p2 = new Point(Canvas.GetLeft(me)+diameter /2, Canvas.GetTop(me) +diameter /2);

                    Line l = new Line {
                        StrokeThickness = 2,
                        Stroke          = Brushes.Red,
                        X1              = _p1.Value.X,
                        X2              = _p2.Value.X,
                        Y1              = _p1.Value.Y,
                        Y2              = _p2.Value.Y
                    };
                    Canvas.Children.Add(l);

                    _p1 = null;
                    _p2 = null;

                }

            };

            Canvas.SetLeft(c, pt.X - diameter / 2);
            Canvas.SetTop(c, pt.Y  - diameter / 2);

            _points.Add(pt);

            Canvas.Children.Add(c);
        }

        Point? _p1;
        Point? _p2;

        private void Canvas_MouseRightButtonDown(object sender, MouseButtonEventArgs e) {

        }

    }

}