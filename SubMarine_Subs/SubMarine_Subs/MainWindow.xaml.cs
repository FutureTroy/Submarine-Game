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

namespace SubMarine_Subs
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            InstructionsWindow i = new InstructionsWindow();
            i.Show();
        }

        private void button_Click_1(object sender, RoutedEventArgs e)
        {
            /*Player N = new Player(textBox.Text, So on so on, ); Pass new SubMarine_(N)*/
            this.Hide();
            SubMarine_ m = new SubMarine_();
            m.Show();
        }


       /* public class Player
        {
            string
                Public Player( string Stuff)
            {
                this.operators for string stuff
            }



            pubic string getfirstName() { return getfirstName; }
            public void setFirstName(string arg) { firstName = arg; }
        }*/


       
    }
}
