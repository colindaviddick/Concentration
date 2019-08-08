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

namespace Concentration
{
    /// <summary>
    /// Interaction logic for SplashScreen.xaml
    /// </summary>
    public partial class SplashScreen : Window
    {
        Random randomNumber = new Random();


        public SplashScreen()
        {
            int rInt = randomNumber.Next(1, 6);
            InitializeComponent();

            //Just for trialling new images.
            //RandomImage.Source = new BitmapImage(new Uri((@"/images/ConcentrationLogo5.png"), UriKind.RelativeOrAbsolute));
            RandomImage.Source = new BitmapImage(new Uri((@"/images/ConcentrationLogo" + rInt + ".png"), UriKind.RelativeOrAbsolute));
        }




        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MainWindow game = new MainWindow();
            game.Show();
            this.Close();
        }
    }
}
