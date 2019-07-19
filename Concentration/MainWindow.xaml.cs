using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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
using System.Windows.Threading;
using System.Windows.Forms;
using MessageBox = System.Windows.MessageBox;

namespace Concentration
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        // ReCover Cards method:

            // The back number does not match the card number and so I'm not sure how to get it to reCover the card....


        /// <summary>
        /// I should be able to pass the box information into a 
        /// method and search for it's pair that way, box 1 and box 2 = pair, box 3 and box 4 = pair, etc.
        /// This would make the code a lot cleaner but take longer for me to work out... :)
        /// 
        /// Hi, let's do a small code review. 
        ///1) The class file is big, would you be able to extract some logic to standalone class and pass just the arguments needed using method parameters?
        ///2) Methods are too long. They should ideally be 20 lines max(soft limit). Try to break them to multiple smaller methods.
        ///3) Don't read from UI controls multiple times if it's not needed.Read once, assign the value to property, use the property
        ///4) Do not use shortcuts in variable names.People will be asking - what is rInt?
        ///5) Do not use magic constants - what is the number 17 in the random call? Replace it by constant with clear name.
        ///6) Do not convert int to steing multiple times if you can extract the result of conversion to variable and reuse it then.
        /// 7) it will also lead to better SOC - separation of concerns and
        /// 8) you will use SRP - single responsibility principle - its simplified version is: In class/method do one thing and do it well.
        /// 
        /// I will describe my refactoring mental process:
        /// 1) Regions - when I see them, it usually means the whole block can be extracted to a separate method with name similar to region description
        /// 2) The same for comments - as an example - I see a comment // Assign values to cards, this to me is an instruction: extract this to private void AssignValuesToCards(...) {}
        /// 8) Organize the Assets (images) to folders, say Assets/Images/Cards?
        /// 9) Use arrays where possible - you can do something like this: boxes[7] = box8.Text; then later... if (box[7]==xyz)...

        /// Create a CARD class, with a position (randomly generated, a number 1 of 2, 2 of 2, and image association?
        /// 
        /// Code needs totally revamped but I have the most important thing working, the timer.
        /// 
        /// 
        /// </summary>
        /// 


            //  Latest attempt... 3D Array of Integers
            //  Containing card no & randomized no.
            //  if 
            //
            //  Now I'm not sure why it'd need to be 3d... Randomize then do a foreach loop through it, if shuffledCards[1] == 4, card4 = hidden... etc.

        int selection = 0;
        int selection2 = 0;
        int clicks = 0;
        int pairs = 0;
        string theme = "basic";
        bool paired1 = false;
        bool paired2 = false;
        bool paired3 = false;
        bool paired4 = false;
        bool paired5 = false;
        bool paired6 = false;
        bool paired7 = false;
        bool paired8 = false;
        bool cardsHidden = true;
        bool showNumbers = true;
        bool pairFound = false;
        int[] shuffledCards = new int[16];

        // Use a 3d array to control randomizing and returning cards??

        //List shuffledcards;

        List<int> intList = new List<int>();

        public MainWindow()
        {
            InitializeComponent();

            _ = StartSequence();
        }

        async Task StartSequence()
        {
            SortAndRandomiseCards();
            await Wait(500);
            UpdateClicks();
            await Wait(500);
            UpdateDebug();
            await Wait(500);
            HighScore.Text = (Properties.Settings.Default.Name + " -- " + Properties.Settings.Default.LowestScore);
        }

        void SortAndRandomiseCards()
        {
            int numberOfCardsPlusOne = 17;
            List<int> cardNumberList = new List<int>();

            for (int i = 1; i < numberOfCardsPlusOne; i++)
            {
                cardNumberList.Add(i);
            }

            var shuffledCards = cardNumberList.OrderBy(a => Guid.NewGuid()).ToList();

            for (int i = 0; i < 16; i++)
            {
                if (shuffledCards[i] > 8)
                {
                    shuffledCards[i] -= 8;
                }
            }

            // Not sure if this is of any use....

            box1.Text = shuffledCards[0].ToString();
            box2.Text = shuffledCards[1].ToString();
            box3.Text = shuffledCards[2].ToString();
            box4.Text = shuffledCards[3].ToString();
            box5.Text = shuffledCards[4].ToString();
            box6.Text = shuffledCards[5].ToString();
            box7.Text = shuffledCards[6].ToString();
            box8.Text = shuffledCards[7].ToString();
            box9.Text = shuffledCards[8].ToString();
            box10.Text = shuffledCards[9].ToString();
            box11.Text = shuffledCards[10].ToString();
            box12.Text = shuffledCards[11].ToString();
            box13.Text = shuffledCards[12].ToString();
            box14.Text = shuffledCards[13].ToString();
            box15.Text = shuffledCards[14].ToString();
            box16.Text = shuffledCards[15].ToString();
            back1.Name = ("back00" + shuffledCards[0].ToString());
            back2.Name = ("back00" + shuffledCards[1].ToString());
            back3.Name = ("back00" + shuffledCards[2].ToString());
            back4.Name = ("back00" + shuffledCards[3].ToString());
            back5.Name = ("back00" + shuffledCards[4].ToString());
            back6.Name = ("back00" + shuffledCards[5].ToString());
            back7.Name = ("back00" + shuffledCards[6].ToString());
            back8.Name = ("back00" + shuffledCards[7].ToString());
            back9.Name = ("back00" + shuffledCards[8].ToString());
            back10.Name = ("back00" + shuffledCards[9].ToString());
            back11.Name = ("back00" + shuffledCards[10].ToString());
            back12.Name = ("back00" + shuffledCards[11].ToString());
            back13.Name = ("back00" + shuffledCards[12].ToString());
            back14.Name = ("back00" + shuffledCards[13].ToString());
            back15.Name = ("back00" + shuffledCards[14].ToString());
            back16.Name = ("back00" + shuffledCards[15].ToString());



            image1.Source  = new BitmapImage(new Uri((@"/images/cards/" + theme + "/" + shuffledCards[0] + ".jpg"), UriKind.RelativeOrAbsolute));
            image2.Source  = new BitmapImage(new Uri((@"/images/cards/" + theme + "/" + shuffledCards[1] + ".jpg"), UriKind.RelativeOrAbsolute));
            image3.Source  = new BitmapImage(new Uri((@"/images/cards/" + theme + "/" + shuffledCards[2] + ".jpg"), UriKind.RelativeOrAbsolute));
            image4.Source  = new BitmapImage(new Uri((@"/images/cards/" + theme + "/" + shuffledCards[3] + ".jpg"), UriKind.RelativeOrAbsolute));
            image5.Source  = new BitmapImage(new Uri((@"/images/cards/" + theme + "/" + shuffledCards[4] + ".jpg"), UriKind.RelativeOrAbsolute));
            image6.Source  = new BitmapImage(new Uri((@"/images/cards/" + theme + "/" + shuffledCards[5] + ".jpg"), UriKind.RelativeOrAbsolute));
            image7.Source  = new BitmapImage(new Uri((@"/images/cards/" + theme + "/" + shuffledCards[6] + ".jpg"), UriKind.RelativeOrAbsolute));
            image8.Source  = new BitmapImage(new Uri((@"/images/cards/" + theme + "/" + shuffledCards[7] + ".jpg"), UriKind.RelativeOrAbsolute));
            image9.Source  = new BitmapImage(new Uri((@"/images/cards/" + theme + "/" + shuffledCards[8] + ".jpg"), UriKind.RelativeOrAbsolute));
            image10.Source = new BitmapImage(new Uri((@"/images/cards/" + theme + "/" + shuffledCards[9] + ".jpg"), UriKind.RelativeOrAbsolute));
            image11.Source = new BitmapImage(new Uri((@"/images/cards/" + theme + "/" + shuffledCards[10] + ".jpg"), UriKind.RelativeOrAbsolute));
            image12.Source = new BitmapImage(new Uri((@"/images/cards/" + theme + "/" + shuffledCards[11] + ".jpg"), UriKind.RelativeOrAbsolute));
            image13.Source = new BitmapImage(new Uri((@"/images/cards/" + theme + "/" + shuffledCards[12] + ".jpg"), UriKind.RelativeOrAbsolute));
            image14.Source = new BitmapImage(new Uri((@"/images/cards/" + theme + "/" + shuffledCards[13] + ".jpg"), UriKind.RelativeOrAbsolute));
            image15.Source = new BitmapImage(new Uri((@"/images/cards/" + theme + "/" + shuffledCards[14] + ".jpg"), UriKind.RelativeOrAbsolute));
            image16.Source = new BitmapImage(new Uri((@"/images/cards/" + theme + "/" + shuffledCards[15] + ".jpg"), UriKind.RelativeOrAbsolute));
        }                      
                               
        // void AssignCardsToTiles()
        //{

            //AssignImagesToCards(Int32.Parse(box1.Text));
            //AssignImagesToCards(Int32.Parse(box2.Text));
            //AssignImagesToCards(Int32.Parse(box3.Text));
            //AssignImagesToCards(Int32.Parse(box4.Text));
            //AssignImagesToCards(Int32.Parse(box5.Text));
            //AssignImagesToCards(Int32.Parse(box6.Text));
            //AssignImagesToCards(Int32.Parse(box7.Text));
            //AssignImagesToCards(Int32.Parse(box8.Text));
            //AssignImagesToCards(Int32.Parse(box9.Text));
            //AssignImagesToCards(Int32.Parse(box10.Text));
            //AssignImagesToCards(Int32.Parse(box11.Text));
            //AssignImagesToCards(Int32.Parse(box12.Text));
            //AssignImagesToCards(Int32.Parse(box13.Text));
            //AssignImagesToCards(Int32.Parse(box14.Text));
            //AssignImagesToCards(Int32.Parse(box15.Text));
            //AssignImagesToCards(Int32.Parse(box16.Text));
            
            //void AssignImagesToCards(int cardNo)
            //{
            //    switch (cardNo)
            //    {
            //        case 1:
            //            image1.Source = new BitmapImage(new Uri((@"/images/cards/" + theme + "/1.jpg"), UriKind.RelativeOrAbsolute));
            //            break;
            //        case 2:
            //            image2.Source = new BitmapImage(new Uri((@"/images/cards/" + theme + "/1.jpg"), UriKind.RelativeOrAbsolute));
            //            break;
            //        case 3:
            //            image3.Source = new BitmapImage(new Uri((@"/images/cards/" + theme + "/2.jpg"), UriKind.RelativeOrAbsolute));
            //            break;
            //        case 4:
            //            image4.Source = new BitmapImage(new Uri((@"/images/cards/" + theme + "/2.jpg"), UriKind.RelativeOrAbsolute));
            //            break;
            //        case 5:
            //            image5.Source = new BitmapImage(new Uri((@"/images/cards/" + theme + "/3.jpg"), UriKind.RelativeOrAbsolute));
            //            break;
            //        case 6:
            //            image6.Source = new BitmapImage(new Uri((@"/images/cards/" + theme + "/3.jpg"), UriKind.RelativeOrAbsolute));
            //            break;
            //        case 7:
            //            image7.Source = new BitmapImage(new Uri((@"/images/cards/" + theme + "/4.jpg"), UriKind.RelativeOrAbsolute));
            //            break;
            //        case 8:
            //            image8.Source = new BitmapImage(new Uri((@"/images/cards/" + theme + "/4.jpg"), UriKind.RelativeOrAbsolute));
            //            break;
            //        case 9:
            //            image9.Source = new BitmapImage(new Uri((@"/images/cards/" + theme + "/5.jpg"), UriKind.RelativeOrAbsolute));
            //            break;
            //        case 10:
            //            image10.Source = new BitmapImage(new Uri((@"/images/cards/" + theme + "/5.jpg"), UriKind.RelativeOrAbsolute));
            //            break;
            //        case 11:
            //            image11.Source = new BitmapImage(new Uri((@"/images/cards/" + theme + "/6.jpg"), UriKind.RelativeOrAbsolute));
            //            break;
            //        case 12:
            //            image12.Source = new BitmapImage(new Uri((@"/images/cards/" + theme + "/6.jpg"), UriKind.RelativeOrAbsolute));
            //            break;
            //        case 13:
            //            image13.Source = new BitmapImage(new Uri((@"/images/cards/" + theme + "/7.jpg"), UriKind.RelativeOrAbsolute));
            //            break;
            //        case 14:
            //            image14.Source = new BitmapImage(new Uri((@"/images/cards/" + theme + "/7.jpg"), UriKind.RelativeOrAbsolute));
            //            break;
            //        case 15:
            //            image15.Source = new BitmapImage(new Uri((@"/images/cards/" + theme + "/8.jpg"), UriKind.RelativeOrAbsolute));
            //            break;
            //        case 16:
            //            image16.Source = new BitmapImage(new Uri((@"/images/cards/" + theme + "/8.jpg"), UriKind.RelativeOrAbsolute));
            //            break;
            //        default:
            //            break;
            //    }
            //}


            //// box1
            //if (box1.Text == "1" || box1.Text == "2")
            //{
            //    
            //}
            //else if (box1.Text == "3" || box1.Text == "4")
            //{
            //    image1.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/2.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box1.Text == "5" || box1.Text == "6")
            //{
            //    image1.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/3.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box1.Text == "7" || box1.Text == "8")
            //{
            //    image1.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/4.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box1.Text == "9" || box1.Text == "10")
            //{
            //    image1.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/5.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box1.Text == "11" || box1.Text == "12")
            //{
            //    image1.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/6.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box1.Text == "13" || box1.Text == "14")
            //{
            //    image1.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/7.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box1.Text == "15" || box1.Text == "16")
            //{
            //    image1.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/8.jpg", UriKind.RelativeOrAbsolute));
            //}


            //// box2
            //if (box2.Text == "1" || box2.Text == "2")
            //{
            //    image2.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/1.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box2.Text == "3" || box2.Text == "4")
            //{
            //    image2.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/2.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box2.Text == "5" || box2.Text == "6")
            //{
            //    image2.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/3.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box2.Text == "7" || box2.Text == "8")
            //{
            //    image2.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/4.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box2.Text == "9" || box2.Text == "10")
            //{
            //    image2.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/5.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box2.Text == "11" || box2.Text == "12")
            //{
            //    image2.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/6.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box2.Text == "13" || box2.Text == "14")
            //{
            //    image2.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/7.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box2.Text == "15" || box2.Text == "16")
            //{
            //    image2.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/8.jpg", UriKind.RelativeOrAbsolute));
            //}

            //// box3
            //if (box3.Text == "1" || box3.Text == "2")
            //{
            //    image3.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/1.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box3.Text == "3" || box3.Text == "4")
            //{
            //    image3.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/2.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box3.Text == "5" || box3.Text == "6")
            //{
            //    image3.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/3.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box3.Text == "7" || box3.Text == "8")
            //{
            //    image3.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/4.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box3.Text == "9" || box3.Text == "10")
            //{
            //    image3.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/5.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box3.Text == "11" || box3.Text == "12")
            //{
            //    image3.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/6.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box3.Text == "13" || box3.Text == "14")
            //{
            //    image3.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/7.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box3.Text == "15" || box3.Text == "16")
            //{
            //    image3.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/8.jpg", UriKind.RelativeOrAbsolute));
            //}

            //// box4
            //if (box4.Text == "1" || box4.Text == "2")
            //{
            //    image4.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/1.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box4.Text == "3" || box4.Text == "4")
            //{
            //    image4.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/2.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box4.Text == "5" || box4.Text == "6")
            //{
            //    image4.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/3.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box4.Text == "7" || box4.Text == "8")
            //{
            //    image4.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/4.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box4.Text == "9" || box4.Text == "10")
            //{
            //    image4.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/5.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box4.Text == "11" || box4.Text == "12")
            //{
            //    image4.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/6.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box4.Text == "13" || box4.Text == "14")
            //{
            //    image4.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/7.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box4.Text == "15" || box4.Text == "16")
            //{
            //    image4.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/8.jpg", UriKind.RelativeOrAbsolute));
            //}

            ////box 5
            //if (box5.Text == "1" || box5.Text == "2")
            //{
            //    image5.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/1.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box5.Text == "3" || box5.Text == "4")
            //{
            //    image5.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/2.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box5.Text == "5" || box5.Text == "6")
            //{
            //    image5.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/3.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box5.Text == "7" || box5.Text == "8")
            //{
            //    image5.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/4.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box5.Text == "9" || box5.Text == "10")
            //{
            //    image5.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/5.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box5.Text == "11" || box5.Text == "12")
            //{
            //    image5.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/6.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box5.Text == "13" || box5.Text == "14")
            //{
            //    image5.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/7.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box5.Text == "15" || box5.Text == "16")
            //{
            //    image5.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/8.jpg", UriKind.RelativeOrAbsolute));
            //}
            ////box 6
            //if (box6.Text == "1" || box6.Text == "2")
            //{
            //    image6.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/1.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box6.Text == "3" || box6.Text == "4")
            //{
            //    image6.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/2.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box6.Text == "5" || box6.Text == "6")
            //{
            //    image6.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/3.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box6.Text == "7" || box6.Text == "8")
            //{
            //    image6.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/4.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box6.Text == "9" || box6.Text == "10")
            //{
            //    image6.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/5.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box6.Text == "11" || box6.Text == "12")
            //{
            //    image6.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/6.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box6.Text == "13" || box6.Text == "14")
            //{
            //    image6.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/7.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box6.Text == "15" || box6.Text == "16")
            //{
            //    image6.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/8.jpg", UriKind.RelativeOrAbsolute));
            //}
            ////box 7
            //if (box7.Text == "1" || box7.Text == "2")
            //{
            //    image7.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/1.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box7.Text == "3" || box7.Text == "4")
            //{
            //    image7.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/2.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box7.Text == "5" || box7.Text == "6")
            //{
            //    image7.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/3.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box7.Text == "7" || box7.Text == "8")
            //{
            //    image7.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/4.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box7.Text == "9" || box7.Text == "10")
            //{
            //    image7.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/5.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box7.Text == "11" || box7.Text == "12")
            //{
            //    image7.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/6.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box7.Text == "13" || box7.Text == "14")
            //{
            //    image7.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/7.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box7.Text == "15" || box7.Text == "16")
            //{
            //    image7.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/8.jpg", UriKind.RelativeOrAbsolute));
            //}

            ////box 8
            //if (box8.Text == "1" || box8.Text == "2")
            //{
            //    image8.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/1.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box8.Text == "3" || box8.Text == "4")
            //{
            //    image8.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/2.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box8.Text == "5" || box8.Text == "6")
            //{
            //    image8.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/3.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box8.Text == "7" || box8.Text == "8")
            //{
            //    image8.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/4.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box8.Text == "9" || box8.Text == "10")
            //{
            //    image8.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/5.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box8.Text == "11" || box8.Text == "12")
            //{
            //    image8.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/6.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box8.Text == "13" || box8.Text == "14")
            //{
            //    image8.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/7.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box8.Text == "15" || box8.Text == "16")
            //{
            //    image8.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/8.jpg", UriKind.RelativeOrAbsolute));
            //}
            ////box 9
            //if (box9.Text == "1" || box9.Text == "2")
            //{
            //    image9.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/1.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box9.Text == "3" || box9.Text == "4")
            //{
            //    image9.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/2.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box9.Text == "5" || box9.Text == "6")
            //{
            //    image9.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/3.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box9.Text == "7" || box9.Text == "8")
            //{
            //    image9.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/4.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box9.Text == "9" || box9.Text == "10")
            //{
            //    image9.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/5.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box9.Text == "11" || box9.Text == "12")
            //{
            //    image9.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/6.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box9.Text == "13" || box9.Text == "14")
            //{
            //    image9.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/7.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box9.Text == "15" || box9.Text == "16")
            //{
            //    image9.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/8.jpg", UriKind.RelativeOrAbsolute));
            //}
            ////box 10
            //if (box10.Text == "1" || box10.Text == "2")
            //{
            //    image10.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/1.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box10.Text == "3" || box10.Text == "4")
            //{
            //    image10.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/2.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box10.Text == "5" || box10.Text == "6")
            //{
            //    image10.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/3.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box10.Text == "7" || box10.Text == "8")
            //{
            //    image10.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/4.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box10.Text == "9" || box10.Text == "10")
            //{
            //    image10.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/5.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box10.Text == "11" || box10.Text == "12")
            //{
            //    image10.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/6.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box10.Text == "13" || box10.Text == "14")
            //{
            //    image10.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/7.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box10.Text == "15" || box10.Text == "16")
            //{
            //    image10.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/8.jpg", UriKind.RelativeOrAbsolute));
            //}
            ////box 11
            //if (box11.Text == "1" || box11.Text == "2")
            //{
            //    image11.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/1.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box11.Text == "3" || box11.Text == "4")
            //{
            //    image11.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/2.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box11.Text == "5" || box11.Text == "6")
            //{
            //    image11.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/3.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box11.Text == "7" || box11.Text == "8")
            //{
            //    image11.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/4.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box11.Text == "9" || box11.Text == "10")
            //{
            //    image11.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/5.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box11.Text == "11" || box11.Text == "12")
            //{
            //    image11.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/6.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box11.Text == "13" || box11.Text == "14")
            //{
            //    image11.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/7.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box11.Text == "15" || box11.Text == "16")
            //{
            //    image11.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/8.jpg", UriKind.RelativeOrAbsolute));
            //}
            ////box 12
            //if (box12.Text == "1" || box12.Text == "2")
            //{
            //    image12.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/1.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box12.Text == "3" || box12.Text == "4")
            //{
            //    image12.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/2.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box12.Text == "5" || box12.Text == "6")
            //{
            //    image12.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/3.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box12.Text == "7" || box12.Text == "8")
            //{
            //    image12.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/4.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box12.Text == "9" || box12.Text == "10")
            //{
            //    image12.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/5.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box12.Text == "11" || box12.Text == "12")
            //{
            //    image12.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/6.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box12.Text == "13" || box12.Text == "14")
            //{
            //    image12.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/7.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box12.Text == "15" || box12.Text == "16")
            //{
            //    image12.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/8.jpg", UriKind.RelativeOrAbsolute));
            //}
            ////box 13
            //if (box13.Text == "1" || box13.Text == "2")
            //{
            //    image13.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/1.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box13.Text == "3" || box13.Text == "4")
            //{
            //    image13.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/2.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box13.Text == "5" || box13.Text == "6")
            //{
            //    image13.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/3.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box13.Text == "7" || box13.Text == "8")
            //{
            //    image13.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/4.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box13.Text == "9" || box13.Text == "10")
            //{
            //    image13.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/5.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box13.Text == "11" || box13.Text == "12")
            //{
            //    image13.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/6.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box13.Text == "13" || box13.Text == "14")
            //{
            //    image13.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/7.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box13.Text == "15" || box13.Text == "16")
            //{
            //    image13.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/8.jpg", UriKind.RelativeOrAbsolute));
            //}
            ////box 14
            //if (box14.Text == "1" || box14.Text == "2")
            //{
            //    image14.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/1.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box14.Text == "3" || box14.Text == "4")
            //{
            //    image14.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/2.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box14.Text == "5" || box14.Text == "6")
            //{
            //    image14.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/3.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box14.Text == "7" || box14.Text == "8")
            //{
            //    image14.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/4.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box14.Text == "9" || box14.Text == "10")
            //{
            //    image14.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/5.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box14.Text == "11" || box14.Text == "12")
            //{
            //    image14.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/6.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box14.Text == "13" || box14.Text == "14")
            //{
            //    image14.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/7.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box14.Text == "15" || box14.Text == "16")
            //{
            //    image14.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/8.jpg", UriKind.RelativeOrAbsolute));
            //}
            ////box 15
            //if (box15.Text == "1" || box15.Text == "2")
            //{
            //    image15.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/1.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box15.Text == "3" || box15.Text == "4")
            //{
            //    image15.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/2.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box15.Text == "5" || box15.Text == "6")
            //{
            //    image15.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/3.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box15.Text == "7" || box15.Text == "8")
            //{
            //    image15.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/4.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box15.Text == "9" || box15.Text == "10")
            //{
            //    image15.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/5.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box15.Text == "11" || box15.Text == "12")
            //{
            //    image15.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/6.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box15.Text == "13" || box15.Text == "14")
            //{
            //    image15.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/7.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box15.Text == "15" || box15.Text == "16")
            //{
            //    image15.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/8.jpg", UriKind.RelativeOrAbsolute));
            //}
            ////box 16
            //if (box16.Text == "1" || box16.Text == "2")
            //{
            //    image16.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/1.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box16.Text == "3" || box16.Text == "4")
            //{
            //    image16.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/2.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box16.Text == "5" || box16.Text == "6")
            //{
            //    image16.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/3.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box16.Text == "7" || box16.Text == "8")
            //{
            //    image16.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/4.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box16.Text == "9" || box16.Text == "10")
            //{
            //    image16.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/5.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box16.Text == "11" || box16.Text == "12")
            //{
            //    image16.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/6.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box16.Text == "13" || box16.Text == "14")
            //{
            //    image16.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/7.jpg", UriKind.RelativeOrAbsolute));
            //}
            //else if (box16.Text == "15" || box16.Text == "16")
            //{
            //    image16.Source = new BitmapImage(new Uri(@"/images/cards/" + theme + "/8.jpg", UriKind.RelativeOrAbsolute));
            //}
        //}

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
            SortAndRandomiseCards();
            clicks = 0;
            UpdateClicks();
        }

        bool CheckIfPair(int selection, int selection2)
        {
            if (selection == selection2)
            {
                pairs++;
                return pairFound = true;
            }
            else
            {
                return pairFound = false;
            }

            /// THE PROBLEM HERE IS THAT THE PAIR NUMBER IS NOT MATCHED UP TO THE BACK NUMBER....
            /// 
            ////
            ///
            ////
            ///
            ////
            // I think the above is all I need for this section....!
            // I just need to sort out the logic for keeping cards shown.
            
        }

        private void CheckIfWon()
        {
            if(pairs == 8)
            {
                MessageBox.Show("You have won!");
            }
        }

        async Task ReCoverCards(bool paired1, bool paired2, bool paired3, bool paired4, bool paired5, bool paired6,
                          bool paired7, bool paired8)
            //, bool paired9, bool paired10, bool paired11, bool paired12, bool paired13, bool paired14, bool paired15, bool paired16
        {
            //MessageBox.Show(paired1.ToString() + paired2.ToString() + paired3.ToString() + paired4.ToString() + paired5.ToString() + paired6.ToString() + paired7.ToString() + paired8.ToString() + paired9.ToString() + paired10.ToString() + paired11.ToString() + paired12.ToString() + paired13.ToString() + paired14.ToString() + paired15.ToString() + paired16.ToString());

            _ = Wait(2000);
            
            if (!paired1)
            {
                back1.Visibility = Visibility.Visible;
                back9.Visibility = Visibility.Visible;
            }
            if (!paired2)
            {
                back2.Visibility = Visibility.Visible;
                back10.Visibility = Visibility.Visible;
            }
            if (!paired3)
            {
                back3.Visibility = Visibility.Visible;
                back11.Visibility = Visibility.Visible;
            }
            if (!paired4)
            {
                back4.Visibility = Visibility.Visible;
                back12.Visibility = Visibility.Visible;
            }
            if (!paired5)
            {
                back5.Visibility = Visibility.Visible;
                back13.Visibility = Visibility.Visible;
            }
            if (!paired6)
            {
                back6.Visibility = Visibility.Visible;
                back14.Visibility = Visibility.Visible;
            }
            if (!paired7)
            {
                back7.Visibility = Visibility.Visible;
                back15.Visibility = Visibility.Visible;
            }
            if (!paired8)
            {
                back8.Visibility = Visibility.Visible;
                back16.Visibility = Visibility.Visible;
            }
         }

        public async Task Wait(int milliseconds)
        {
            System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
            if (milliseconds == 0 || milliseconds < 0) return;
            //Console.WriteLine("start wait timer");
            timer1.Interval = milliseconds;
            timer1.Enabled = true;
            timer1.Start();
            timer1.Tick += (s, e) =>
            {
                timer1.Enabled = false;
                timer1.Stop();
                //Console.WriteLine("stop wait timer");
            };
            while (timer1.Enabled)
            {
                System.Windows.Forms.Application.DoEvents();
            }
        }

        private void Back1_Click(object sender, RoutedEventArgs e)
        {
            clicks++;
            UpdateClicks();

            //("back00" + shuffledCards[0].ToString()).Visibility = Visibility.Hidden;

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

        private void UncoverCards_Click(object sender, RoutedEventArgs e)
        {
            if(cardsHidden)
            {
                back1.Visibility = Visibility.Hidden;
                back2.Visibility = Visibility.Hidden;
                back3.Visibility = Visibility.Hidden;
                back4.Visibility = Visibility.Hidden;
                back5.Visibility = Visibility.Hidden;
                back6.Visibility = Visibility.Hidden;
                back7.Visibility = Visibility.Hidden;
                back8.Visibility = Visibility.Hidden;
                back9.Visibility = Visibility.Hidden;
                back10.Visibility = Visibility.Hidden;
                back11.Visibility = Visibility.Hidden;
                back12.Visibility = Visibility.Hidden;
                back13.Visibility = Visibility.Hidden;
                back14.Visibility = Visibility.Hidden;
                back15.Visibility = Visibility.Hidden;
                back16.Visibility = Visibility.Hidden;
                cardsHidden = false;
            }
            else
            {
                back1.Visibility = Visibility.Visible;
                back2.Visibility = Visibility.Visible;
                back3.Visibility = Visibility.Visible;
                back4.Visibility = Visibility.Visible;
                back5.Visibility = Visibility.Visible;
                back6.Visibility = Visibility.Visible;
                back7.Visibility = Visibility.Visible;
                back8.Visibility = Visibility.Visible;
                back9.Visibility = Visibility.Visible;
                back10.Visibility = Visibility.Visible;
                back11.Visibility = Visibility.Visible;
                back12.Visibility = Visibility.Visible;
                back13.Visibility = Visibility.Visible;
                back14.Visibility = Visibility.Visible;
                back15.Visibility = Visibility.Visible;
                back16.Visibility = Visibility.Visible;
                cardsHidden = true;
            }

        }

        private void ShowNumbers_Click(object sender, RoutedEventArgs e)
        {
            if (showNumbers)
            {
                image1.Visibility = Visibility.Hidden;
                image2.Visibility = Visibility.Hidden;
                image3.Visibility = Visibility.Hidden;
                image4.Visibility = Visibility.Hidden;
                image5.Visibility = Visibility.Hidden;
                image6.Visibility = Visibility.Hidden;
                image7.Visibility = Visibility.Hidden;
                image8.Visibility = Visibility.Hidden;
                image9.Visibility = Visibility.Hidden;
                image10.Visibility = Visibility.Hidden;
                image11.Visibility = Visibility.Hidden;
                image12.Visibility = Visibility.Hidden;
                image13.Visibility = Visibility.Hidden;
                image14.Visibility = Visibility.Hidden;
                image15.Visibility = Visibility.Hidden;
                image16.Visibility = Visibility.Hidden;
                showNumbers = false;
            }
            else
            {
                image1.Visibility = Visibility.Visible;
                image2.Visibility = Visibility.Visible;
                image3.Visibility = Visibility.Visible;
                image4.Visibility = Visibility.Visible;
                image5.Visibility = Visibility.Visible;
                image6.Visibility = Visibility.Visible;
                image7.Visibility = Visibility.Visible;
                image8.Visibility = Visibility.Visible;
                image9.Visibility = Visibility.Visible;
                image10.Visibility = Visibility.Visible;
                image11.Visibility = Visibility.Visible;
                image12.Visibility = Visibility.Visible;
                image13.Visibility = Visibility.Visible;
                image14.Visibility = Visibility.Visible;
                image15.Visibility = Visibility.Visible;
                image16.Visibility = Visibility.Visible;
                showNumbers = true;
            }
        }
    }
}


//// todo after two cards are uncovered, if not a pair, re-cover the cards.
// todo once a pair is found, they should remain shown. Can a button be deleted? Will it cause problems when they're being shown again?
// todo look at implementing delays in display

