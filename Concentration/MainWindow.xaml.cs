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
        int pairs = 0;

        bool paired1 = false;
        bool paired2 = false;
        bool paired3 = false;
        bool paired4 = false;
        bool paired5 = false;
        bool paired6 = false;
        bool paired7 = false;
        bool paired8 = false;
        bool paired9 = false;
        bool paired10 = false;
        bool paired11 = false;
        bool paired12 = false;
        bool paired13 = false;
        bool paired14 = false;
        bool paired15 = false;
        bool paired16 = false;

        public MainWindow()
        {
            InitializeComponent();
            RandomizeTiles();
            UpdateClicks();
            UpdateDebug();
            HighScore.Text = (Properties.Settings.Default.Name + " -- " + Properties.Settings.Default.LowestScore);
        }

        void RandomizeTiles()
        {

            #region Generate Random numbers for each tiles to assign cards

            //Random r = new Random();
            //int rInt = r.Next(1, 17);

            //box1.Text = rInt.ToString();

            //while (rInt.ToString() == box1.Text)
            //{
            //    rInt = r.Next(1, 17);
            //}

            //box2.Text = rInt.ToString();

            //while (rInt.ToString() == box1.Text || rInt.ToString() == box2.Text)
            //{
            //    rInt = r.Next(1, 17);
            //}

            //box3.Text = rInt.ToString();

            //while (rInt.ToString() == box1.Text || rInt.ToString() == box2.Text || rInt.ToString() == box3.Text)
            //{
            //    rInt = r.Next(1, 17);
            //}

            //box4.Text = rInt.ToString();

            //while (rInt.ToString() == box1.Text || rInt.ToString() == box2.Text || rInt.ToString() == box3.Text || rInt.ToString() == box4.Text)
            //{
            //    rInt = r.Next(1, 17);
            //}

            //box5.Text = rInt.ToString();

            //while (rInt.ToString() == box1.Text || rInt.ToString() == box2.Text || rInt.ToString() == box3.Text || rInt.ToString() == box4.Text
            //    || rInt.ToString() == box5.Text)
            //{
            //    rInt = r.Next(1, 17);
            //}

            //box6.Text = rInt.ToString();

            //while (rInt.ToString() == box1.Text || rInt.ToString() == box2.Text || rInt.ToString() == box3.Text || rInt.ToString() == box4.Text
            //    || rInt.ToString() == box5.Text || rInt.ToString() == box6.Text)
            //{
            //    rInt = r.Next(1, 17);
            //}

            //box7.Text = rInt.ToString();

            //while (rInt.ToString() == box1.Text || rInt.ToString() == box2.Text || rInt.ToString() == box3.Text || rInt.ToString() == box4.Text
            //    || rInt.ToString() == box5.Text || rInt.ToString() == box6.Text || rInt.ToString() == box7.Text)
            //{
            //    rInt = r.Next(1, 17);
            //}

            //box8.Text = rInt.ToString();

            //while (rInt.ToString() == box1.Text || rInt.ToString() == box2.Text || rInt.ToString() == box3.Text || rInt.ToString() == box4.Text
            //    || rInt.ToString() == box5.Text || rInt.ToString() == box6.Text || rInt.ToString() == box7.Text || rInt.ToString() == box8.Text)
            //{
            //    rInt = r.Next(1, 17);
            //}

            //box9.Text = rInt.ToString();

            //while (rInt.ToString() == box1.Text || rInt.ToString() == box2.Text || rInt.ToString() == box3.Text || rInt.ToString() == box4.Text
            //    || rInt.ToString() == box5.Text || rInt.ToString() == box6.Text || rInt.ToString() == box7.Text || rInt.ToString() == box8.Text
            //    || rInt.ToString() == box9.Text)
            //{
            //    rInt = r.Next(1, 17);
            //}

            //box10.Text = rInt.ToString();

            //while (rInt.ToString() == box1.Text || rInt.ToString() == box2.Text || rInt.ToString() == box3.Text || rInt.ToString() == box4.Text
            //    || rInt.ToString() == box5.Text || rInt.ToString() == box6.Text || rInt.ToString() == box7.Text || rInt.ToString() == box8.Text
            //    || rInt.ToString() == box9.Text || rInt.ToString() == box10.Text)
            //{
            //    rInt = r.Next(1, 17);
            //}

            //box11.Text = rInt.ToString();

            //while (rInt.ToString() == box1.Text || rInt.ToString() == box2.Text || rInt.ToString() == box3.Text || rInt.ToString() == box4.Text
            //    || rInt.ToString() == box5.Text || rInt.ToString() == box6.Text || rInt.ToString() == box7.Text || rInt.ToString() == box8.Text
            //    || rInt.ToString() == box9.Text || rInt.ToString() == box10.Text || rInt.ToString() == box11.Text)
            //{
            //    rInt = r.Next(1, 17);
            //}

            //box12.Text = rInt.ToString();

            //while (rInt.ToString() == box1.Text || rInt.ToString() == box2.Text || rInt.ToString() == box3.Text || rInt.ToString() == box4.Text
            //    || rInt.ToString() == box5.Text || rInt.ToString() == box6.Text || rInt.ToString() == box7.Text || rInt.ToString() == box8.Text
            //    || rInt.ToString() == box9.Text || rInt.ToString() == box10.Text || rInt.ToString() == box11.Text || rInt.ToString() == box12.Text)
            //{
            //    rInt = r.Next(1, 17);
            //}

            //box13.Text = rInt.ToString();

            //while (rInt.ToString() == box1.Text || rInt.ToString() == box2.Text || rInt.ToString() == box3.Text || rInt.ToString() == box4.Text
            //    || rInt.ToString() == box5.Text || rInt.ToString() == box6.Text || rInt.ToString() == box7.Text || rInt.ToString() == box8.Text
            //    || rInt.ToString() == box9.Text || rInt.ToString() == box10.Text || rInt.ToString() == box11.Text || rInt.ToString() == box12.Text
            //    || rInt.ToString() == box13.Text)
            //{
            //    rInt = r.Next(1, 17);
            //}

            //box14.Text = rInt.ToString();

            //while (rInt.ToString() == box1.Text || rInt.ToString() == box2.Text || rInt.ToString() == box3.Text || rInt.ToString() == box4.Text
            //    || rInt.ToString() == box5.Text || rInt.ToString() == box6.Text || rInt.ToString() == box7.Text || rInt.ToString() == box8.Text
            //    || rInt.ToString() == box9.Text || rInt.ToString() == box10.Text || rInt.ToString() == box11.Text || rInt.ToString() == box12.Text
            //    || rInt.ToString() == box13.Text || rInt.ToString() == box14.Text)
            //{
            //    rInt = r.Next(1, 17);
            //}

            //box15.Text = rInt.ToString();

            //while (rInt.ToString() == box1.Text || rInt.ToString() == box2.Text || rInt.ToString() == box3.Text || rInt.ToString() == box4.Text
            //    || rInt.ToString() == box5.Text || rInt.ToString() == box6.Text || rInt.ToString() == box7.Text || rInt.ToString() == box8.Text
            //    || rInt.ToString() == box9.Text || rInt.ToString() == box10.Text || rInt.ToString() == box11.Text || rInt.ToString() == box12.Text
            //    || rInt.ToString() == box13.Text || rInt.ToString() == box14.Text || rInt.ToString() == box15.Text)
            //{
            //    rInt = r.Next(1, 17);
            //}

            //box16.Text = rInt.ToString();
            #endregion

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
            Pairs.Text = ("Number of Pairs found : " + pairs.ToString());
        }

        void UpdateDebug()
        {
            DebugCard1.Text = ("Card1 Number : " + selection.ToString());
            DebugCard2.Text = ("Card2 Number : " + selection2.ToString());
        }

        private void Random_Click(object sender, RoutedEventArgs e)
        {
            RandomizeTiles();
            clicks = 0;
            UpdateClicks();
        }

        void ReCoverCards(bool paired1, bool paired2, bool paired3, bool paired4, bool paired5, bool paired6,
                          bool paired7, bool paired8, bool paired9, bool paired10, bool paired11, bool paired12,
                          bool paired13, bool paired14, bool paired15, bool paired16)
        {
            //MessageBox.Show(paired1.ToString() + paired2.ToString() + paired3.ToString() + paired4.ToString() + paired5.ToString() + paired6.ToString() + paired7.ToString() + paired8.ToString() + paired9.ToString() + paired10.ToString() + paired11.ToString() + paired12.ToString() + paired13.ToString() + paired14.ToString() + paired15.ToString() + paired16.ToString());


            if (!paired1)
            {
                back1.Visibility = Visibility.Visible;
            }
            if (!paired2)
            {
                back2.Visibility = Visibility.Visible;
            }
            if (!paired3)
            {
                back3.Visibility = Visibility.Visible;
            }
            if (!paired4)
            {
                back4.Visibility = Visibility.Visible;
            }
            if (!paired5)
            {
                back5.Visibility = Visibility.Visible;
            }
            if (!paired6)
            {
                back6.Visibility = Visibility.Visible;
            }
            if (!paired7)
            {
                back7.Visibility = Visibility.Visible;
            }
            if (!paired8)
            {
                back8.Visibility = Visibility.Visible;
            }
            if (!paired9)
            {
                back9.Visibility = Visibility.Visible;
            }
            if (!paired10)
            {
                back10.Visibility = Visibility.Visible;
            }
            if (!paired11)
            {
                back11.Visibility = Visibility.Visible;
            }
            if (!paired12)
            {
                back12.Visibility = Visibility.Visible;
            }
            if (!paired13)
            {
                back13.Visibility = Visibility.Visible;
            }
            if (!paired14)
            {
                back14.Visibility = Visibility.Visible;
            }
            if (!paired15)
            {
                back15.Visibility = Visibility.Visible;
            }
            if (!paired16)
            {
                back16.Visibility = Visibility.Visible;
            }
            //MessageBox.Show(paired1.ToString() + paired2.ToString() + paired3.ToString() + paired4.ToString() + paired5.ToString() + paired6.ToString() + paired7.ToString() + paired8.ToString() + paired9.ToString() + paired10.ToString() + paired11.ToString() + paired12.ToString() + paired13.ToString() + paired14.ToString() + paired15.ToString() + paired16.ToString());
        }


        /// <summary>
        /// Clicking card backs.
        /// </summary>

        void CheckIfPair(int selection, int selection2)
        {
            if ((selection == 1 && selection2 == 2) || (selection == 2 && selection2 == 1))
            {
                //MessageBox.Show("You found a pair!");
                paired1 = true;
                paired2 = true;
                pairs++;
            }
            else if ((selection == 3 && selection2 == 4) || (selection == 4 && selection2 == 3))
            {
                //MessageBox.Show("You found a pair!");
                paired3 = true;
                paired4 = true;
                pairs++;
            }
            else if ((selection == 5 && selection2 == 6) || (selection == 6 && selection2 == 5))
            {
                //MessageBox.Show("You found a pair!");
                paired5 = true;
                paired6 = true;
                pairs++;
            }
            else if ((selection == 7 && selection2 == 8) || (selection == 8 && selection2 == 7))
            {
                //MessageBox.Show("You found a pair!");
                paired7 = true;
                paired8 = true;
                pairs++;
            }
            else if ((selection == 9 && selection2 == 10) || (selection == 10 && selection2 == 9))
            {
                //MessageBox.Show("You found a pair!");
                paired9 = true;
                paired10 = true;
                pairs++;
            }
            else if ((selection == 11 && selection2 == 12) || (selection == 12 && selection2 == 11))
            {
                //MessageBox.Show("You found a pair!");
                paired11 = true;
                paired12 = true;
                pairs++;
            }
            else if ((selection == 13 && selection2 == 14) || (selection == 14 && selection2 == 13))
            {
                //MessageBox.Show("You found a pair!");
                paired13 = true;
                paired14 = true;
                pairs++;
            }
            else if ((selection == 15 && selection2 == 16) || (selection == 16 && selection2 == 15))
            {
                //MessageBox.Show("You found a pair!");
                paired15 = true;
                paired16 = true;
                pairs++;
            }

            if (pairs == 8)
            {
                MessageBox.Show("Game was won in " + clicks + " clicks!");

                if (clicks < Properties.Settings.Default.LowestScore)
                {
                    HighScoreName.Visibility = Visibility.Visible;
                    HighScoreSaveName.Visibility = Visibility.Visible;
                    Keyboard.Focus(HighScoreName);
                }
            }

            UpdateClicks();


            ReCoverCards(paired1, paired2, paired3, paired4, paired5, paired6, paired7, paired8,
                paired9, paired10, paired11, paired12, paired13, paired14, paired15, paired16);
            //MessageBox.Show(paired1.ToString() + paired2.ToString() + paired3.ToString() + paired4.ToString() + paired5.ToString() + paired6.ToString() + paired7.ToString() + paired8.ToString() + paired9.ToString() + paired10.ToString() + paired11.ToString() + paired12.ToString() + paired13.ToString() + paired14.ToString() + paired15.ToString() + paired16.ToString());
            UpdateDebug();
        }

        private void Back1_Click(object sender, RoutedEventArgs e)
        {
            clicks++;
            UpdateClicks();
            back1.Visibility = Visibility.Hidden;

            if (selection == 0)
            {
                selection = Int32.Parse(box1.Text);
                UpdateDebug();
            }
            else
            {
                selection2 = Int32.Parse(box1.Text);
                CheckIfPair(selection, selection2);
                UpdateDebug();
                selection = 0;
                selection2 = 0;
            }

        }

        private void Back2_Click(object sender, RoutedEventArgs e)
        {
            clicks++;
            UpdateClicks();
            back2.Visibility = Visibility.Hidden;

            if (selection == 0)
            {
                selection = Int32.Parse(box2.Text);
                UpdateDebug();
            }
            else
            {
                selection2 = Int32.Parse(box2.Text);
                CheckIfPair(selection, selection2);
                UpdateDebug();
                selection = 0;
                selection2 = 0;
            }
        }

        private void Back3_Click(object sender, RoutedEventArgs e)
        {
            clicks++;
            UpdateClicks();
            back3.Visibility = Visibility.Hidden;

            if (selection == 0)
            {
                selection = Int32.Parse(box3.Text);
                UpdateDebug();
            }
            else
            {
                selection2 = Int32.Parse(box3.Text);
                CheckIfPair(selection, selection2);
                UpdateDebug();
                selection = 0;
                selection2 = 0;
            }
        }

        private void Back4_Click(object sender, RoutedEventArgs e)
        {
            clicks++;
            UpdateClicks();
            back4.Visibility = Visibility.Hidden;

            if (selection == 0)
            {
                selection = Int32.Parse(box4.Text);
                UpdateDebug();
            }
            else
            {
                selection2 = Int32.Parse(box4.Text);
                CheckIfPair(selection, selection2);
                UpdateDebug();
                selection = 0;
                selection2 = 0;
            }
        }

        private void Back5_Click(object sender, RoutedEventArgs e)
        {
            clicks++;
            UpdateClicks();
            back5.Visibility = Visibility.Hidden;

            if (selection == 0)
            {
                selection = Int32.Parse(box5.Text);
                UpdateDebug();
            }
            else
            {
                selection2 = Int32.Parse(box5.Text);
                CheckIfPair(selection, selection2);
                UpdateDebug();
                selection = 0;
                selection2 = 0;
            }
        }

        private void Back6_Click(object sender, RoutedEventArgs e)
        {
            clicks++;
            UpdateClicks();
            back6.Visibility = Visibility.Hidden;
            if (selection == 0)
            {
                selection = Int32.Parse(box6.Text);
                UpdateDebug();
            }
            else
            {
                selection2 = Int32.Parse(box6.Text);
                CheckIfPair(selection, selection2);
                UpdateDebug();
                selection = 0;
                selection2 = 0;
            }
        }

        private void Back7_Click(object sender, RoutedEventArgs e)
        {
            clicks++;
            UpdateClicks();
            back7.Visibility = Visibility.Hidden;
            if (selection == 0)
            {
                selection = Int32.Parse(box7.Text);
                UpdateDebug();
            }
            else
            {
                selection2 = Int32.Parse(box7.Text);
                CheckIfPair(selection, selection2);
                UpdateDebug();
                selection = 0;
                selection2 = 0;
            }
        }

        private void Back8_Click(object sender, RoutedEventArgs e)
        {
            clicks++;
            UpdateClicks();
            back8.Visibility = Visibility.Hidden;
            if (selection == 0)
            {
                selection = Int32.Parse(box8.Text);
                UpdateDebug();
            }
            else
            {
                selection2 = Int32.Parse(box8.Text);
                CheckIfPair(selection, selection2);
                UpdateDebug();
                selection = 0;
                selection2 = 0;
            }
        }

        private void Back9_Click(object sender, RoutedEventArgs e)
        {
            clicks++;
            UpdateClicks();
            back9.Visibility = Visibility.Hidden;
            if (selection == 0)
            {
                selection = Int32.Parse(box9.Text);
                UpdateDebug();
            }
            else
            {
                selection2 = Int32.Parse(box9.Text);
                CheckIfPair(selection, selection2);
                UpdateDebug();
                selection = 0;
                selection2 = 0;
            }
        }

        private void Back10_Click(object sender, RoutedEventArgs e)
        {
            clicks++;
            UpdateClicks();
            back10.Visibility = Visibility.Hidden;
            if (selection == 0)
            {
                selection = Int32.Parse(box10.Text);
                UpdateDebug();
            }
            else
            {
                selection2 = Int32.Parse(box10.Text);
                CheckIfPair(selection, selection2);
                UpdateDebug();
                selection = 0;
                selection2 = 0;
            }
        }

        private void Back11_Click(object sender, RoutedEventArgs e)
        {
            clicks++;
            UpdateClicks();
            back11.Visibility = Visibility.Hidden;
            if (selection == 0)
            {
                selection = Int32.Parse(box11.Text);
                UpdateDebug();
            }
            else
            {
                selection2 = Int32.Parse(box11.Text);
                CheckIfPair(selection, selection2);
                UpdateDebug();
                selection = 0;
                selection2 = 0;
            }
        }

        private void Back12_Click(object sender, RoutedEventArgs e)
        {
            clicks++;
            UpdateClicks();
            back12.Visibility = Visibility.Hidden;
            if (selection == 0)
            {
                selection = Int32.Parse(box12.Text);
                UpdateDebug();
            }
            else
            {
                selection2 = Int32.Parse(box12.Text);
                CheckIfPair(selection, selection2);
                UpdateDebug();
                selection = 0;
                selection2 = 0;
            }
        }

        private void Back13_Click(object sender, RoutedEventArgs e)
        {
            clicks++;
            UpdateClicks();
            back13.Visibility = Visibility.Hidden;
            if (selection == 0)
            {
                selection = Int32.Parse(box13.Text);
                UpdateDebug();
            }
            else
            {
                selection2 = Int32.Parse(box13.Text);
                CheckIfPair(selection, selection2);
                UpdateDebug();
                selection = 0;
                selection2 = 0;
            }
        }

        private void Back14_Click(object sender, RoutedEventArgs e)
        {
            clicks++;
            UpdateClicks();
            back14.Visibility = Visibility.Hidden;
            if (selection == 0)
            {
                selection = Int32.Parse(box14.Text);
                UpdateDebug();
            }
            else
            {
                selection2 = Int32.Parse(box14.Text);
                CheckIfPair(selection, selection2);
                UpdateDebug();
                selection = 0;
                selection2 = 0;
            }
        }

        private void Back15_Click(object sender, RoutedEventArgs e)
        {
            clicks++;
            UpdateClicks();
            back15.Visibility = Visibility.Hidden;
            if (selection == 0)
            {
                selection = Int32.Parse(box15.Text);
                UpdateDebug();
            }
            else
            {
                selection2 = Int32.Parse(box15.Text);
                CheckIfPair(selection, selection2);
                UpdateDebug();
                selection = 0;
                selection2 = 0;
            }
        }

        private void Back16_Click(object sender, RoutedEventArgs e)
        {
            clicks++;
            UpdateClicks();
            back16.Visibility = Visibility.Hidden;
            if (selection == 0)
            {
                selection = Int32.Parse(box16.Text);
                UpdateDebug();
            }
            else
            {
                selection2 = Int32.Parse(box16.Text);
                CheckIfPair(selection, selection2);
                UpdateDebug();
                selection = 0;
                selection2 = 0;
            }
        }

        private void HighScoreSaveName_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.LowestScore = clicks;
            Properties.Settings.Default.Name = HighScoreName.Text;
            HighScore.Text = (Properties.Settings.Default.Name + " -- " + Properties.Settings.Default.LowestScore);
            HighScoreName.Visibility = Visibility.Hidden;
            HighScoreSaveName.Visibility = Visibility.Hidden;
            Properties.Settings.Default.Save();
        }

        private void ClearHighScores_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.LowestScore = 100;
            Properties.Settings.Default.Name = "Anonymous";
            Properties.Settings.Default.Save();
            HighScore.Text = (Properties.Settings.Default.Name + " -- " + Properties.Settings.Default.LowestScore);
        }
    }
}


//// todo after two cards are uncovered, if not a pair, re-cover the cards.
// todo once a pair is found, they should remain shown. Can a button be deleted? Will it cause problems when they're being shown again?
// todo look at implementing delays in display

