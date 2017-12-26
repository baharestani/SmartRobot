using System;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Shapes;

namespace SmartRobot.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private const int Scale = 15;
        private Robot r;
        private Point goal;
        private Timer timer = new Timer(200);

        public MainWindow()
        {
            InitializeComponent();

            var s = new MapReader();
            r = new Robot(s);

            DrawObstacles(s.Map);
            timer.AutoReset = true;
            timer.Elapsed += Timer_Elapsed;
            timer.Start();
        }

        private void DrawObstacles(Map s)
        {
            foreach (var p in s.Obstacles)
            {
                var e = new Rectangle()
                {
                    Fill = new SolidColorBrush(Colors.Maroon),
                    Width = Scale,
                    Height = Scale
                };
                Canvas.Children.Add(e);
                Canvas.SetTop(e, p.Y * Scale);
                Canvas.SetLeft(e, p.X * Scale);
            }
        }

        private void Timer_Elapsed(object sender, ElapsedEventArgs e)
        {
            try
            {
                Dispatcher.Invoke(() =>
                    {
                        r.StepTwards(goal);
                        Title = r.Position.ToString();
                        Canvas.SetTop(Elipse, r.Position.Y * Scale);
                        Canvas.SetLeft(Elipse, r.Position.X * Scale);
                    });
            }
            catch { }
        }

        private void Canvas_MouseDown(object sender, MouseButtonEventArgs e)
        {
            Canvas_MouseMove(sender, e);
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            var p = e.GetPosition(Canvas);
            this.goal = new Point((int)p.X / Scale, (int)p.Y / Scale);
            TextBox.Text=$"Goal: {goal}{Environment.NewLine}";
        }
    }
}
