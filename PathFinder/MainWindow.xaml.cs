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

        // ReSharper disable once CollectionNeverQueried.Local
        readonly List<Point> _points = new List<Point>();
        private  Ellipse     _endPoint;
        private  Ellipse     _startPoint;

        private void Canvas_LeftMouseDown(object sender, MouseButtonEventArgs e) {

            var          pt       = e.GetPosition(Canvas);
            const double diameter = 10;

            var c = new Ellipse {
                Width  = diameter,
                Height = diameter,
            };

            ResetColor(c);

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
                    SetSelection(me);
                } else if (me == _e1) {
                    UnSelect();
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

                    UnSelect();
                }

            };

        }

        Ellipse _e1;

        private void EndPoint_Click(object sender, RoutedEventArgs e) {
            if (_e1 != null) {
                SetEndPoint(_e1);
                UnSelect();
            }
        }

        private void StartPoint_Click(object sender, RoutedEventArgs e) {
            if (_e1 != null) {
                SetStartPoint(_e1);
                UnSelect();
            }
        }

        void UnSelect() {
            SetSelection(null);
        }

        void SetStartPoint(Ellipse startPoint) {

            var prevStartPoint = _startPoint;
            _startPoint = startPoint;

            if (prevStartPoint != null) {
                ResetColor(prevStartPoint);
            }

            if (startPoint != null) {
                ResetColor(startPoint);
            }
        }

        void SetEndPoint(Ellipse endPoint) {

            var prevEndPoint = _endPoint;
            _endPoint = endPoint;

            if (prevEndPoint != null) {
                ResetColor(prevEndPoint);
            }

            if (endPoint != null) {
                ResetColor(endPoint);
            }
        }

        void ResetColor(Ellipse e) {
            if (e == _startPoint) {
                e.Fill = Brushes.Green;
            } else if (e == _endPoint) {
                e.Fill = Brushes.Orange;
            } else {
                e.Fill = Brushes.Black;
            }
        }

        void SetSelection(Ellipse e) {
            if (_e1 != null) {
                ResetColor(_e1);
                _e1 = null;
            }

            if (e != null) {
                e.Fill = Brushes.Blue;
                _e1    = e;
            }

        }

    }

}