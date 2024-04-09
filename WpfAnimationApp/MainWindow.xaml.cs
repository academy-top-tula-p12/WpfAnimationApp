using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfAnimationApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DoubleAnimation animWidth;
        DoubleAnimation animHeight;
        ColorAnimation animColorBg;

        public MainWindow()
        {
            InitializeComponent();

            animWidth = new();
            animWidth.Duration = TimeSpan.FromSeconds(3);
            animWidth.AutoReverse = true;

            animHeight = new();
            animHeight.Duration = TimeSpan.FromSeconds(3);
            animHeight.AutoReverse = true;

            animColorBg = new();
            animColorBg.Duration = TimeSpan.FromSeconds(3);
            animColorBg.AutoReverse = true;

        }

        private void btn_Click(object sender, RoutedEventArgs e)
        {
            animWidth.From = btn.Width;
            animWidth.To = btn.Width * 2;
            animWidth.Completed += DoubleAnimation_Completed;

            animHeight.From = btn.Height;
            animHeight.To = btn.Height * 0.5;

            animColorBg.From = Colors.Blue;
            animColorBg.To = Colors.Red;

            SolidColorBrush brush = new(Colors.Red);
            btn.Background = brush;

            btn.BeginAnimation(Button.WidthProperty, animWidth);
            btn.BeginAnimation(Button.HeightProperty, animHeight);
            //btn.BeginAnimation(Button.BackgroundProperty, animColorBg);
            brush.BeginAnimation(SolidColorBrush.ColorProperty, animColorBg);
        }

        private void DoubleAnimation_Completed(object sender, EventArgs e)
        {
            MessageBox.Show("Animation Stop");
        }
    }
}