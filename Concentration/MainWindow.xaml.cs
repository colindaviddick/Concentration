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

namespace Concentration
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        /// <summary>
        /// I should be able to pass the box information into a 
        /// method and search for it's pair that way, box 1 and box 2 = pair, box 3 and box 4 = pair, etc.
        /// This would make the code a lot cleaner but take longer for me to work out... :)
        /// 
        /// </summary>

        int selection = 0;
        int selection2 = 0;
        int clicks = 0;

        public MainWindow()
        {
            InitializeComponent();
            RandomizeTiles();
            UpdateClicks();
        }

        void RandomizeTiles()
        {

            #region Generate Random numbers for each tiles to assign cards
            Random r = new Random();
            int rInt = r.Next(1, 17);

            box1.Text = rInt.ToString();

            while (rInt.ToString() == box1.Text)
            {
                rInt = r.Next(1, 17);
            }

            box2.Text = rInt.ToString();

            while (rInt.ToString() == box1.Text || rInt.ToString() == box2.Text)
            {
                rInt = r.Next(1, 17);
            }

            box3.Text = rInt.ToString();

            while (rInt.ToString() == box1.Text || rInt.ToString() == box2.Text || rInt.ToString() == box3.Text)
            {
                rInt = r.Next(1, 17);
            }

            box4.Text = rInt.ToString();

            while (rInt.ToString() == box1.Text || rInt.ToString() == box2.Text || rInt.ToString() == box3.Text || rInt.ToString() == box4.Text)
            {
                rInt = r.Next(1, 17);
            }

            box5.Text = rInt.ToString();

            while (rInt.ToString() == box1.Text || rInt.ToString() == box2.Text || rInt.ToString() == box3.Text || rInt.ToString() == box4.Text
                || rInt.ToString() == box5.Text)
            {
                rInt = r.Next(1, 17);
            }

            box6.Text = rInt.ToString();

            while (rInt.ToString() == box1.Text || rInt.ToString() == box2.Text || rInt.ToString() == box3.Text || rInt.ToString() == box4.Text
                || rInt.ToString() == box5.Text || rInt.ToString() == box6.Text)
            {
                rInt = r.Next(1, 17);
            }

            box7.Text = rInt.ToString();

            while (rInt.ToString() == box1.Text || rInt.ToString() == box2.Text || rInt.ToString() == box3.Text || rInt.ToString() == box4.Text
                || rInt.ToString() == box5.Text || rInt.ToString() == box6.Text || rInt.ToString() == box7.Text)
            {
                rInt = r.Next(1, 17);
            }

            box8.Text = rInt.ToString();

            while (rInt.ToString() == box1.Text || rInt.ToString() == box2.Text || rInt.ToString() == box3.Text || rInt.ToString() == box4.Text
                || rInt.ToString() == box5.Text || rInt.ToString() == box6.Text || rInt.ToString() == box7.Text || rInt.ToString() == box8.Text)
            {
                rInt = r.Next(1, 17);
            }

            box9.Text = rInt.ToString();

            while (rInt.ToString() == box1.Text || rInt.ToString() == box2.Text || rInt.ToString() == box3.Text || rInt.ToString() == box4.Text
                || rInt.ToString() == box5.Text || rInt.ToString() == box6.Text || rInt.ToString() == box7.Text || rInt.ToString() == box8.Text
                || rInt.ToString() == box9.Text)
            {
                rInt = r.Next(1, 17);
            }

            box10.Text = rInt.ToString();

            while (rInt.ToString() == box1.Text || rInt.ToString() == box2.Text || rInt.ToString() == box3.Text || rInt.ToString() == box4.Text
                || rInt.ToString() == box5.Text || rInt.ToString() == box6.Text || rInt.ToString() == box7.Text || rInt.ToString() == box8.Text
                || rInt.ToString() == box9.Text || rInt.ToString() == box10.Text)
            {
                rInt = r.Next(1, 17);
            }

            box11.Text = rInt.ToString();

            while (rInt.ToString() == box1.Text || rInt.ToString() == box2.Text || rInt.ToString() == box3.Text || rInt.ToString() == box4.Text
                || rInt.ToString() == box5.Text || rInt.ToString() == box6.Text || rInt.ToString() == box7.Text || rInt.ToString() == box8.Text
                || rInt.ToString() == box9.Text || rInt.ToString() == box10.Text || rInt.ToString() == box11.Text)
            {
                rInt = r.Next(1, 17);
            }

            box12.Text = rInt.ToString();

            while (rInt.ToString() == box1.Text || rInt.ToString() == box2.Text || rInt.ToString() == box3.Text || rInt.ToString() == box4.Text
                || rInt.ToString() == box5.Text || rInt.ToString() == box6.Text || rInt.ToString() == box7.Text || rInt.ToString() == box8.Text
                || rInt.ToString() == box9.Text || rInt.ToString() == box10.Text || rInt.ToString() == box11.Text || rInt.ToString() == box12.Text)
            {
                rInt = r.Next(1, 17);
            }

            box13.Text = rInt.ToString();

            while (rInt.ToString() == box1.Text || rInt.ToString() == box2.Text || rInt.ToString() == box3.Text || rInt.ToString() == box4.Text
                || rInt.ToString() == box5.Text || rInt.ToString() == box6.Text || rInt.ToString() == box7.Text || rInt.ToString() == box8.Text
                || rInt.ToString() == box9.Text || rInt.ToString() == box10.Text || rInt.ToString() == box11.Text || rInt.ToString() == box12.Text
                || rInt.ToString() == box13.Text)
            {
                rInt = r.Next(1, 17);
            }

            box14.Text = rInt.ToString();

            while (rInt.ToString() == box1.Text || rInt.ToString() == box2.Text || rInt.ToString() == box3.Text || rInt.ToString() == box4.Text
                || rInt.ToString() == box5.Text || rInt.ToString() == box6.Text || rInt.ToString() == box7.Text || rInt.ToString() == box8.Text
                || rInt.ToString() == box9.Text || rInt.ToString() == box10.Text || rInt.ToString() == box11.Text || rInt.ToString() == box12.Text
                || rInt.ToString() == box13.Text || rInt.ToString() == box14.Text)
            {
                rInt = r.Next(1, 17);
            }

            box15.Text = rInt.ToString();

            while (rInt.ToString() == box1.Text || rInt.ToString() == box2.Text || rInt.ToString() == box3.Text || rInt.ToString() == box4.Text
                || rInt.ToString() == box5.Text || rInt.ToString() == box6.Text || rInt.ToString() == box7.Text || rInt.ToString() == box8.Text
                || rInt.ToString() == box9.Text || rInt.ToString() == box10.Text || rInt.ToString() == box11.Text || rInt.ToString() == box12.Text
                || rInt.ToString() == box13.Text || rInt.ToString() == box14.Text || rInt.ToString() == box15.Text)
            {
                rInt = r.Next(1, 17);
            }

            box16.Text = rInt.ToString();
            #endregion

            // Below is for testing only?

            #region Assign cards to tiles

            // box1
            if (box1.Text == "1" || box1.Text == "2")
            {
                image1.Source = new BitmapImage(new Uri(@"/1.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box1.Text == "3" || box1.Text == "4")
            {
                image1.Source = new BitmapImage(new Uri(@"/2.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box1.Text == "5" || box1.Text == "6")
            {
                image1.Source = new BitmapImage(new Uri(@"/3.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box1.Text == "7" || box1.Text == "8")
            {
                image1.Source = new BitmapImage(new Uri(@"/4.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box1.Text == "9" || box1.Text == "10")
            {
                image1.Source = new BitmapImage(new Uri(@"/5.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box1.Text == "11" || box1.Text == "12")
            {
                image1.Source = new BitmapImage(new Uri(@"/6.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box1.Text == "13" || box1.Text == "14")
            {
                image1.Source = new BitmapImage(new Uri(@"/7.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box1.Text == "15" || box1.Text == "16")
            {
                image1.Source = new BitmapImage(new Uri(@"/8.jpg", UriKind.RelativeOrAbsolute));
            }


            // box2
            if (box2.Text == "1" || box2.Text == "2")
            {
                image2.Source = new BitmapImage(new Uri(@"/1.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box2.Text == "3" || box2.Text == "4")
            {
                image2.Source = new BitmapImage(new Uri(@"/2.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box2.Text == "5" || box2.Text == "6")
            {
                image2.Source = new BitmapImage(new Uri(@"/3.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box2.Text == "7" || box2.Text == "8")
            {
                image2.Source = new BitmapImage(new Uri(@"/4.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box2.Text == "9" || box2.Text == "10")
            {
                image2.Source = new BitmapImage(new Uri(@"/5.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box2.Text == "11" || box2.Text == "12")
            {
                image2.Source = new BitmapImage(new Uri(@"/6.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box2.Text == "13" || box2.Text == "14")
            {
                image2.Source = new BitmapImage(new Uri(@"/7.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box2.Text == "15" || box2.Text == "16")
            {
                image2.Source = new BitmapImage(new Uri(@"/8.jpg", UriKind.RelativeOrAbsolute));
            }

            // box3
            if (box3.Text == "1" || box3.Text == "2")
            {
                image3.Source = new BitmapImage(new Uri(@"/1.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box3.Text == "3" || box3.Text == "4")
            {
                image3.Source = new BitmapImage(new Uri(@"/2.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box3.Text == "5" || box3.Text == "6")
            {
                image3.Source = new BitmapImage(new Uri(@"/3.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box3.Text == "7" || box3.Text == "8")
            {
                image3.Source = new BitmapImage(new Uri(@"/4.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box3.Text == "9" || box3.Text == "10")
            {
                image3.Source = new BitmapImage(new Uri(@"/5.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box3.Text == "11" || box3.Text == "12")
            {
                image3.Source = new BitmapImage(new Uri(@"/6.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box3.Text == "13" || box3.Text == "14")
            {
                image3.Source = new BitmapImage(new Uri(@"/7.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box3.Text == "15" || box3.Text == "16")
            {
                image3.Source = new BitmapImage(new Uri(@"/8.jpg", UriKind.RelativeOrAbsolute));
            }

            // box4
            if (box4.Text == "1" || box4.Text == "2")
            {
                image4.Source = new BitmapImage(new Uri(@"/1.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box4.Text == "3" || box4.Text == "4")
            {
                image4.Source = new BitmapImage(new Uri(@"/2.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box4.Text == "5" || box4.Text == "6")
            {
                image4.Source = new BitmapImage(new Uri(@"/3.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box4.Text == "7" || box4.Text == "8")
            {
                image4.Source = new BitmapImage(new Uri(@"/4.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box4.Text == "9" || box4.Text == "10")
            {
                image4.Source = new BitmapImage(new Uri(@"/5.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box4.Text == "11" || box4.Text == "12")
            {
                image4.Source = new BitmapImage(new Uri(@"/6.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box4.Text == "13" || box4.Text == "14")
            {
                image4.Source = new BitmapImage(new Uri(@"/7.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box4.Text == "15" || box4.Text == "16")
            {
                image4.Source = new BitmapImage(new Uri(@"/8.jpg", UriKind.RelativeOrAbsolute));
            }

            //box 5
            if (box5.Text == "1" || box5.Text == "2")
            {
                image5.Source = new BitmapImage(new Uri(@"/1.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box5.Text == "3" || box5.Text == "4")
            {
                image5.Source = new BitmapImage(new Uri(@"/2.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box5.Text == "5" || box5.Text == "6")
            {
                image5.Source = new BitmapImage(new Uri(@"/3.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box5.Text == "7" || box5.Text == "8")
            {
                image5.Source = new BitmapImage(new Uri(@"/4.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box5.Text == "9" || box5.Text == "10")
            {
                image5.Source = new BitmapImage(new Uri(@"/5.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box5.Text == "11" || box5.Text == "12")
            {
                image5.Source = new BitmapImage(new Uri(@"/6.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box5.Text == "13" || box5.Text == "14")
            {
                image5.Source = new BitmapImage(new Uri(@"/7.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box5.Text == "15" || box5.Text == "16")
            {
                image5.Source = new BitmapImage(new Uri(@"/8.jpg", UriKind.RelativeOrAbsolute));
            }
            //box 6
            if (box6.Text == "1" || box6.Text == "2")
            {
                image6.Source = new BitmapImage(new Uri(@"/1.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box6.Text == "3" || box6.Text == "4")
            {
                image6.Source = new BitmapImage(new Uri(@"/2.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box6.Text == "5" || box6.Text == "6")
            {
                image6.Source = new BitmapImage(new Uri(@"/3.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box6.Text == "7" || box6.Text == "8")
            {
                image6.Source = new BitmapImage(new Uri(@"/4.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box6.Text == "9" || box6.Text == "10")
            {
                image6.Source = new BitmapImage(new Uri(@"/5.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box6.Text == "11" || box6.Text == "12")
            {
                image6.Source = new BitmapImage(new Uri(@"/6.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box6.Text == "13" || box6.Text == "14")
            {
                image6.Source = new BitmapImage(new Uri(@"/7.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box6.Text == "15" || box6.Text == "16")
            {
                image6.Source = new BitmapImage(new Uri(@"/8.jpg", UriKind.RelativeOrAbsolute));
            }
            //box 7
            if (box7.Text == "1" || box7.Text == "2")
            {
                image7.Source = new BitmapImage(new Uri(@"/1.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box7.Text == "3" || box7.Text == "4")
            {
                image7.Source = new BitmapImage(new Uri(@"/2.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box7.Text == "5" || box7.Text == "6")
            {
                image7.Source = new BitmapImage(new Uri(@"/3.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box7.Text == "7" || box7.Text == "8")
            {
                image7.Source = new BitmapImage(new Uri(@"/4.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box7.Text == "9" || box7.Text == "10")
            {
                image7.Source = new BitmapImage(new Uri(@"/5.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box7.Text == "11" || box7.Text == "12")
            {
                image7.Source = new BitmapImage(new Uri(@"/6.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box7.Text == "13" || box7.Text == "14")
            {
                image7.Source = new BitmapImage(new Uri(@"/7.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box7.Text == "15" || box7.Text == "16")
            {
                image7.Source = new BitmapImage(new Uri(@"/8.jpg", UriKind.RelativeOrAbsolute));
            }

            //box 8
            if (box8.Text == "1" || box8.Text == "2")
            {
                image8.Source = new BitmapImage(new Uri(@"/1.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box8.Text == "3" || box8.Text == "4")
            {
                image8.Source = new BitmapImage(new Uri(@"/2.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box8.Text == "5" || box8.Text == "6")
            {
                image8.Source = new BitmapImage(new Uri(@"/3.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box8.Text == "7" || box8.Text == "8")
            {
                image8.Source = new BitmapImage(new Uri(@"/4.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box8.Text == "9" || box8.Text == "10")
            {
                image8.Source = new BitmapImage(new Uri(@"/5.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box8.Text == "11" || box8.Text == "12")
            {
                image8.Source = new BitmapImage(new Uri(@"/6.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box8.Text == "13" || box8.Text == "14")
            {
                image8.Source = new BitmapImage(new Uri(@"/7.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box8.Text == "15" || box8.Text == "16")
            {
                image8.Source = new BitmapImage(new Uri(@"/8.jpg", UriKind.RelativeOrAbsolute));
            }
            //box 9
            if (box9.Text == "1" || box9.Text == "2")
            {
                image9.Source = new BitmapImage(new Uri(@"/1.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box9.Text == "3" || box9.Text == "4")
            {
                image9.Source = new BitmapImage(new Uri(@"/2.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box9.Text == "5" || box9.Text == "6")
            {
                image9.Source = new BitmapImage(new Uri(@"/3.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box9.Text == "7" || box9.Text == "8")
            {
                image9.Source = new BitmapImage(new Uri(@"/4.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box9.Text == "9" || box9.Text == "10")
            {
                image9.Source = new BitmapImage(new Uri(@"/5.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box9.Text == "11" || box9.Text == "12")
            {
                image9.Source = new BitmapImage(new Uri(@"/6.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box9.Text == "13" || box9.Text == "14")
            {
                image9.Source = new BitmapImage(new Uri(@"/7.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box9.Text == "15" || box9.Text == "16")
            {
                image9.Source = new BitmapImage(new Uri(@"/8.jpg", UriKind.RelativeOrAbsolute));
            }
            //box 10
            if (box10.Text == "1" || box10.Text == "2")
            {
                image10.Source = new BitmapImage(new Uri(@"/1.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box10.Text == "3" || box10.Text == "4")
            {
                image10.Source = new BitmapImage(new Uri(@"/2.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box10.Text == "5" || box10.Text == "6")
            {
                image10.Source = new BitmapImage(new Uri(@"/3.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box10.Text == "7" || box10.Text == "8")
            {
                image10.Source = new BitmapImage(new Uri(@"/4.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box10.Text == "9" || box10.Text == "10")
            {
                image10.Source = new BitmapImage(new Uri(@"/5.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box10.Text == "11" || box10.Text == "12")
            {
                image10.Source = new BitmapImage(new Uri(@"/6.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box10.Text == "13" || box10.Text == "14")
            {
                image10.Source = new BitmapImage(new Uri(@"/7.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box10.Text == "15" || box10.Text == "16")
            {
                image10.Source = new BitmapImage(new Uri(@"/8.jpg", UriKind.RelativeOrAbsolute));
            }
            //box 11
            if (box11.Text == "1" || box11.Text == "2")
            {
                image11.Source = new BitmapImage(new Uri(@"/1.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box11.Text == "3" || box11.Text == "4")
            {
                image11.Source = new BitmapImage(new Uri(@"/2.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box11.Text == "5" || box11.Text == "6")
            {
                image11.Source = new BitmapImage(new Uri(@"/3.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box11.Text == "7" || box11.Text == "8")
            {
                image11.Source = new BitmapImage(new Uri(@"/4.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box11.Text == "9" || box11.Text == "10")
            {
                image11.Source = new BitmapImage(new Uri(@"/5.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box11.Text == "11" || box11.Text == "12")
            {
                image11.Source = new BitmapImage(new Uri(@"/6.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box11.Text == "13" || box11.Text == "14")
            {
                image11.Source = new BitmapImage(new Uri(@"/7.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box11.Text == "15" || box11.Text == "16")
            {
                image11.Source = new BitmapImage(new Uri(@"/8.jpg", UriKind.RelativeOrAbsolute));
            }
            //box 12
            if (box12.Text == "1" || box12.Text == "2")
            {
                image12.Source = new BitmapImage(new Uri(@"/1.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box12.Text == "3" || box12.Text == "4")
            {
                image12.Source = new BitmapImage(new Uri(@"/2.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box12.Text == "5" || box12.Text == "6")
            {
                image12.Source = new BitmapImage(new Uri(@"/3.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box12.Text == "7" || box12.Text == "8")
            {
                image12.Source = new BitmapImage(new Uri(@"/4.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box12.Text == "9" || box12.Text == "10")
            {
                image12.Source = new BitmapImage(new Uri(@"/5.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box12.Text == "11" || box12.Text == "12")
            {
                image12.Source = new BitmapImage(new Uri(@"/6.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box12.Text == "13" || box12.Text == "14")
            {
                image12.Source = new BitmapImage(new Uri(@"/7.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box12.Text == "15" || box12.Text == "16")
            {
                image12.Source = new BitmapImage(new Uri(@"/8.jpg", UriKind.RelativeOrAbsolute));
            }
            //box 13
            if (box13.Text == "1" || box13.Text == "2")
            {
                image13.Source = new BitmapImage(new Uri(@"/1.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box13.Text == "3" || box13.Text == "4")
            {
                image13.Source = new BitmapImage(new Uri(@"/2.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box13.Text == "5" || box13.Text == "6")
            {
                image13.Source = new BitmapImage(new Uri(@"/3.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box13.Text == "7" || box13.Text == "8")
            {
                image13.Source = new BitmapImage(new Uri(@"/4.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box13.Text == "9" || box13.Text == "10")
            {
                image13.Source = new BitmapImage(new Uri(@"/5.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box13.Text == "11" || box13.Text == "12")
            {
                image13.Source = new BitmapImage(new Uri(@"/6.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box13.Text == "13" || box13.Text == "14")
            {
                image13.Source = new BitmapImage(new Uri(@"/7.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box13.Text == "15" || box13.Text == "16")
            {
                image13.Source = new BitmapImage(new Uri(@"/8.jpg", UriKind.RelativeOrAbsolute));
            }
            //box 14
            if (box14.Text == "1" || box14.Text == "2")
            {
                image14.Source = new BitmapImage(new Uri(@"/1.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box14.Text == "3" || box14.Text == "4")
            {
                image14.Source = new BitmapImage(new Uri(@"/2.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box14.Text == "5" || box14.Text == "6")
            {
                image14.Source = new BitmapImage(new Uri(@"/3.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box14.Text == "7" || box14.Text == "8")
            {
                image14.Source = new BitmapImage(new Uri(@"/4.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box14.Text == "9" || box14.Text == "10")
            {
                image14.Source = new BitmapImage(new Uri(@"/5.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box14.Text == "11" || box14.Text == "12")
            {
                image14.Source = new BitmapImage(new Uri(@"/6.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box14.Text == "13" || box14.Text == "14")
            {
                image14.Source = new BitmapImage(new Uri(@"/7.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box14.Text == "15" || box14.Text == "16")
            {
                image14.Source = new BitmapImage(new Uri(@"/8.jpg", UriKind.RelativeOrAbsolute));
            }
            //box 15
            if (box15.Text == "1" || box15.Text == "2")
            {
                image15.Source = new BitmapImage(new Uri(@"/1.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box15.Text == "3" || box15.Text == "4")
            {
                image15.Source = new BitmapImage(new Uri(@"/2.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box15.Text == "5" || box15.Text == "6")
            {
                image15.Source = new BitmapImage(new Uri(@"/3.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box15.Text == "7" || box15.Text == "8")
            {
                image15.Source = new BitmapImage(new Uri(@"/4.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box15.Text == "9" || box15.Text == "10")
            {
                image15.Source = new BitmapImage(new Uri(@"/5.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box15.Text == "11" || box15.Text == "12")
            {
                image15.Source = new BitmapImage(new Uri(@"/6.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box15.Text == "13" || box15.Text == "14")
            {
                image15.Source = new BitmapImage(new Uri(@"/7.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box15.Text == "15" || box15.Text == "16")
            {
                image15.Source = new BitmapImage(new Uri(@"/8.jpg", UriKind.RelativeOrAbsolute));
            }
            //box 16
            if (box16.Text == "1" || box16.Text == "2")
            {
                image16.Source = new BitmapImage(new Uri(@"/1.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box16.Text == "3" || box16.Text == "4")
            {
                image16.Source = new BitmapImage(new Uri(@"/2.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box16.Text == "5" || box16.Text == "6")
            {
                image16.Source = new BitmapImage(new Uri(@"/3.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box16.Text == "7" || box16.Text == "8")
            {
                image16.Source = new BitmapImage(new Uri(@"/4.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box16.Text == "9" || box16.Text == "10")
            {
                image16.Source = new BitmapImage(new Uri(@"/5.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box16.Text == "11" || box16.Text == "12")
            {
                image16.Source = new BitmapImage(new Uri(@"/6.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box16.Text == "13" || box16.Text == "14")
            {
                image16.Source = new BitmapImage(new Uri(@"/7.jpg", UriKind.RelativeOrAbsolute));
            }
            else if (box16.Text == "15" || box16.Text == "16")
            {
                image16.Source = new BitmapImage(new Uri(@"/8.jpg", UriKind.RelativeOrAbsolute));
            }
            #endregion
        }

        void UpdateClicks()
        {
            Clicks.Text = ("Number of clicks : " + clicks.ToString());
        }

        private void Random_Click(object sender, RoutedEventArgs e)
        {
            RandomizeTiles();
            clicks = 0;
            UpdateClicks();
        }


        /// <summary>
        /// Clicking card backs.
        /// </summary>
        
        void CheckIfPair(int selection, int selection2)
        {

        }

        private void Back1_Click(object sender, RoutedEventArgs e)
        {
            clicks++;
            UpdateClicks();
            back1.Visibility = Visibility.Hidden;

            if(selection == 0)
            {
                selection = Int32.Parse(box1.Text);
                MessageBox.Show(selection.ToString());
            }

        }

        private void Back2_Click(object sender, RoutedEventArgs e)
        {
            clicks++;
            UpdateClicks();
            back2.Visibility = Visibility.Hidden;
        }

        private void Back3_Click(object sender, RoutedEventArgs e)
        {
            clicks++;
            UpdateClicks();
            back3.Visibility = Visibility.Hidden;
        }

        private void Back4_Click(object sender, RoutedEventArgs e)
        {
            clicks++;
            UpdateClicks();
            back4.Visibility = Visibility.Hidden;
        }

        private void Back5_Click(object sender, RoutedEventArgs e)
        {
            clicks++;
            UpdateClicks();
            back5.Visibility = Visibility.Hidden;
        }

        private void Back6_Click(object sender, RoutedEventArgs e)
        {
            clicks++;
            UpdateClicks();
            back6.Visibility = Visibility.Hidden;
        }

        private void Back7_Click(object sender, RoutedEventArgs e)
        {
            clicks++;
            UpdateClicks();
            back7.Visibility = Visibility.Hidden;
        }

        private void Back8_Click(object sender, RoutedEventArgs e)
        {
            clicks++;
            UpdateClicks();
            back8.Visibility = Visibility.Hidden;
        }

        private void Back9_Click(object sender, RoutedEventArgs e)
        {
            clicks++;
            UpdateClicks();
            back9.Visibility = Visibility.Hidden;
        }

        private void Back10_Click(object sender, RoutedEventArgs e)
        {
            clicks++;
            UpdateClicks();
            back10.Visibility = Visibility.Hidden;
        }

        private void Back11_Click(object sender, RoutedEventArgs e)
        {
            clicks++;
            UpdateClicks();
            back11.Visibility = Visibility.Hidden;
        }

        private void Back12_Click(object sender, RoutedEventArgs e)
        {
            clicks++;
            UpdateClicks();
            back12.Visibility = Visibility.Hidden;
        }

        private void Back13_Click(object sender, RoutedEventArgs e)
        {
            clicks++;
            UpdateClicks();
            back13.Visibility = Visibility.Hidden;
        }

        private void Back14_Click(object sender, RoutedEventArgs e)
        {
            clicks++;
            UpdateClicks();
            back14.Visibility = Visibility.Hidden;
        }

        private void Back15_Click(object sender, RoutedEventArgs e)
        {
            clicks++;
            UpdateClicks();
            back15.Visibility = Visibility.Hidden;
        }

        private void Back16_Click(object sender, RoutedEventArgs e)
        {
            clicks++;
            UpdateClicks();
            back16.Visibility = Visibility.Hidden;
        }
    }
}


// todo after two cards are uncovered, if not a pair, re-cover the cards.
// todo once a pair is found, they should remain shown. Can a button be deleted? Will it cause problems when they're being shown again?
// todo look at implementing delays in display

