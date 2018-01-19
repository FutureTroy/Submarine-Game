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

namespace SubMarine_Subs
{
    /// <summary>
    /// Interaction logic for GameOver.xaml
    /// </summary>
    public partial class GameOver : Window
    {
        string label;
        public GameOver(string label)
        {
            InitializeComponent();
            this.label = label;

            showSubsNum.Content = label;

            int numVal = Int32.Parse(label);

            if (numVal > 4)
            {
                medal.Source = new BitmapImage(new Uri("pack://application:,,,/SubMarine_Subs;component/Resources/gold.png"));
            }
            if (numVal == 3 || numVal == 2)
            {
                medal.Source = new BitmapImage(new Uri("pack://application:,,,/SubMarine_Subs;component/Resources/silver.png"));
            }
            if (numVal == 1|| numVal == 0)
            {
                medal.Source = new BitmapImage(new Uri("pack://application:,,,/SubMarine_Subs;component/Resources/bronze.png"));
            }
        }

        private void playBtn(object sender, RoutedEventArgs e)
        {
            /*Player N = new Player(textBox.Text, So on so on, ); Pass new SubMarine_(N)*/
            this.Close();
            SubMarine_ m = new SubMarine_();
            m.Show();
        }


        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            /*Player N = new Player(textBox.Text, So on so on, ); Pass new SubMarine_(N)*/
            this.Close();
            MainWindow s = new MainWindow();
            s.Show();
        }

        private void PlayBtn1_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
            SubMarine_ m = new SubMarine_();
            m.Show();
        }
    }
}
