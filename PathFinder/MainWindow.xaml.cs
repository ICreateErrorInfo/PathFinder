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
        private Point EndPoint;
        private Point StartPoint;

        private void Canvas_LeftMouseDown(object sender, MouseButtonEventArgs e) {

            var pt = e.GetPosition(Canvas);
            const double diameter = 10;


            var c = new Ellipse {
                Width  = diameter,
                Height = diameter,
                Fill   = Brushes.Black,
            };


            c.MouseLeftButtonDown += (o, buttonEventArgs) => {
                var me = (Ellipse) o;
                buttonEventArgs.Handled = true;
                var myPos = new Point(Canvas.GetLeft(me) - diameter / 2, Canvas.GetTop(me) - diameter / 2);
                _points.Remove(myPos);
                Canvas.Children.Remove(me);
            };

            Canvas.SetLeft(c, pt.X - diameter / 2);
            Canvas.SetTop(c, pt.Y  - diameter / 2);
            Panel.SetZIndex(c, 10);

            _points.Add(pt);

            Canvas.Children.Add(c);

            c.MouseRightButtonDown += (o, buttonEventArgs) => {

                var me = (Ellipse) o;

                if (_e1 == null) {

                    _e1      = me;
                    _e1.Fill = Brushes.Blue;

                } else if (me == _e1) {
                    _e1.Fill = Brushes.Black;
                    _e1      = null;
                } else {

                    var p1 = new Point(Canvas.GetLeft(_e1) + diameter / 2, Canvas.GetTop(_e1) + diameter / 2);
                    var p2 = new Point(Canvas.GetLeft(me)  + diameter / 2, Canvas.GetTop(me)  + diameter / 2);

                    Line l = new Line {
                        StrokeThickness = 2,
                        Stroke          = Brushes.Red,
                        X1              = p1.X,
                        X2              = p2.X,
                        Y1              = p1.Y,
                        Y2              = p2.Y
                    };
                    Canvas.Children.Add(l);

                    _e1.Fill = Brushes.Black;
                    _e1      = null;
                }

            };

        }

        Ellipse _e1;

        private void EndPoint_Click(object sender, RoutedEventArgs e)
        {

        }

        private void StartPoint_Click(object sender, RoutedEventArgs e)
        {

        }
    }

}