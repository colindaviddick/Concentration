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

    // A better way of doing this would be to create a class of Box, and add the boxes using an array
    // boxes[i] = new Box()


    public partial class MainWindow : Window
    {
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

        int selection = 0;
        int selection2 = 0;
        int clicks = 0;
        int pairs = 0;
        string defaultTheme = "basic";
        //StringBuilder backPath = new StringBuilder(@"images\cards\" + theme + @"\backse.jpg");
        bool cardsHidden = true;
        bool showNumbers = true;
        bool card1found = false;
        bool card2found = false;
        bool card3found = false;
        bool card4found = false;
        bool card5found = false;
        bool card6found = false;
        bool card7found = false;
        bool card8found = false;
        bool card9found = false;
        bool card10found = false;
        bool card11found = false;
        bool card12found = false;
        bool card13found = false;
        bool card14found = false;
        bool card15found = false;
        bool card16found = false;
        int waitTime = 1500;

        int[] shuffledCards = new int[16];

        int[,] cardArray = new int[,]
        {   { 1, 0 },
            { 2, 0 },
            { 3, 0 },
            { 4, 0 },
            { 5, 0 },
            { 6, 0 },
            { 7, 0 },
            { 8, 0 },
            { 9, 0 },
            { 10, 0 },
            { 11, 0 },
            { 12, 0 },
            { 13, 0 },
            { 14, 0 },
            { 15, 0 },
            { 16, 0 }
        };

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
            //await Wait(500);
            UpdateDebug();
            //await Wait(500);
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

            image1.Source = new BitmapImage(new Uri((@"/images/cards/" + defaultTheme + "/" + shuffledCards[0] + ".jpg"), UriKind.RelativeOrAbsolute));
            image2.Source = new BitmapImage(new Uri((@"/images/cards/" + defaultTheme + "/" + shuffledCards[1] + ".jpg"), UriKind.RelativeOrAbsolute));
            image3.Source = new BitmapImage(new Uri((@"/images/cards/" + defaultTheme + "/" + shuffledCards[2] + ".jpg"), UriKind.RelativeOrAbsolute));
            image4.Source = new BitmapImage(new Uri((@"/images/cards/" + defaultTheme + "/" + shuffledCards[3] + ".jpg"), UriKind.RelativeOrAbsolute));
            image5.Source = new BitmapImage(new Uri((@"/images/cards/" + defaultTheme + "/" + shuffledCards[4] + ".jpg"), UriKind.RelativeOrAbsolute));
            image6.Source = new BitmapImage(new Uri((@"/images/cards/" + defaultTheme + "/" + shuffledCards[5] + ".jpg"), UriKind.RelativeOrAbsolute));
            image7.Source = new BitmapImage(new Uri((@"/images/cards/" + defaultTheme + "/" + shuffledCards[6] + ".jpg"), UriKind.RelativeOrAbsolute));
            image8.Source = new BitmapImage(new Uri((@"/images/cards/" + defaultTheme + "/" + shuffledCards[7] + ".jpg"), UriKind.RelativeOrAbsolute));
            image9.Source = new BitmapImage(new Uri((@"/images/cards/" + defaultTheme + "/" + shuffledCards[8] + ".jpg"), UriKind.RelativeOrAbsolute));
            image10.Source = new BitmapImage(new Uri((@"/images/cards/" + defaultTheme + "/" + shuffledCards[9] + ".jpg"), UriKind.RelativeOrAbsolute));
            image11.Source = new BitmapImage(new Uri((@"/images/cards/" + defaultTheme + "/" + shuffledCards[10] + ".jpg"), UriKind.RelativeOrAbsolute));
            image12.Source = new BitmapImage(new Uri((@"/images/cards/" + defaultTheme + "/" + shuffledCards[11] + ".jpg"), UriKind.RelativeOrAbsolute));
            image13.Source = new BitmapImage(new Uri((@"/images/cards/" + defaultTheme + "/" + shuffledCards[12] + ".jpg"), UriKind.RelativeOrAbsolute));
            image14.Source = new BitmapImage(new Uri((@"/images/cards/" + defaultTheme + "/" + shuffledCards[13] + ".jpg"), UriKind.RelativeOrAbsolute));
            image15.Source = new BitmapImage(new Uri((@"/images/cards/" + defaultTheme + "/" + shuffledCards[14] + ".jpg"), UriKind.RelativeOrAbsolute));
            image16.Source = new BitmapImage(new Uri((@"/images/cards/" + defaultTheme + "/" + shuffledCards[15] + ".jpg"), UriKind.RelativeOrAbsolute));

            cardArray[0, 1] = shuffledCards[0];
            cardArray[1, 1] = shuffledCards[1];
            cardArray[2, 1] = shuffledCards[2];
            cardArray[3, 1] = shuffledCards[3];
            cardArray[4, 1] = shuffledCards[4];
            cardArray[5, 1] = shuffledCards[5];
            cardArray[6, 1] = shuffledCards[6];
            cardArray[7, 1] = shuffledCards[7];
            cardArray[8, 1] = shuffledCards[8];
            cardArray[9, 1] = shuffledCards[9];
            cardArray[10, 1] = shuffledCards[10];
            cardArray[11, 1] = shuffledCards[11];
            cardArray[12, 1] = shuffledCards[12];
            cardArray[13, 1] = shuffledCards[13];
            cardArray[14, 1] = shuffledCards[14];
            cardArray[15, 1] = shuffledCards[15];

            tb1.Text = shuffledCards[0].ToString();
            tb2.Text = shuffledCards[1].ToString();
            tb3.Text = shuffledCards[2].ToString();
            tb4.Text = shuffledCards[3].ToString();
            tb5.Text = shuffledCards[4].ToString();
            tb6.Text = shuffledCards[5].ToString();
            tb7.Text = shuffledCards[6].ToString();
            tb8.Text = shuffledCards[7].ToString();
            tb9.Text = shuffledCards[8].ToString();
            tb10.Text = shuffledCards[9].ToString();
            tb11.Text = shuffledCards[10].ToString();
            tb12.Text = shuffledCards[11].ToString();
            tb13.Text = shuffledCards[12].ToString();
            tb14.Text = shuffledCards[13].ToString();
            tb15.Text = shuffledCards[14].ToString();
            tb16.Text = shuffledCards[15].ToString();

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

        private void CheckIfPair(int selection, int selection2)
        {
            if (selection == selection2)
            {

                if (cardArray[0, 1] == selection)
                {
                    card1found = true;
                }
                if (cardArray[1, 1] == selection)
                {
                    card2found = true;
                }
                if (cardArray[2, 1] == selection)
                {
                    card3found = true;
                }
                if (cardArray[3, 1] == selection)
                {
                    card4found = true;
                }
                if (cardArray[4, 1] == selection)
                {
                    card5found = true;
                }
                if (cardArray[5, 1] == selection)
                {
                    card6found = true;
                }
                if (cardArray[6, 1] == selection)
                {
                    card7found = true;
                }
                if (cardArray[7, 1] == selection)
                {
                    card8found = true;
                }
                if (cardArray[8, 1] == selection)
                {
                    card9found = true;
                }
                if (cardArray[9, 1] == selection)
                {
                    card10found = true;
                }
                if (cardArray[10, 1] == selection)
                {
                    card11found = true;
                }
                if (cardArray[11, 1] == selection)
                {
                    card12found = true;
                }
                if (cardArray[12, 1] == selection)
                {
                    card13found = true;
                }
                if (cardArray[13, 1] == selection)
                {
                    card14found = true;
                }
                if (cardArray[14, 1] == selection)
                {
                    card15found = true;
                }
                if (cardArray[15, 1] == selection)
                {
                    card16found = true;
                }
                pairs++;
                UpdateClicks();
                CheckIfWon();
            }
            else
            {
                UpdateClicks();
            }
        }

        private void CheckIfWon()
        {
            if (pairs == 8)
            {
                MessageBox.Show("You have won!");
            }
        }

        async Task ReCoverCards()
        //, bool paired9, bool paired10, bool paired11, bool paired12, bool paired13, bool paired14, bool paired15, bool paired16
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

            if (card1found)
            {
                back1.Visibility = Visibility.Hidden;
            }
            if (card2found)
            {
                back2.Visibility = Visibility.Hidden;
            }
            if (card3found)
            {
                back3.Visibility = Visibility.Hidden;
            }
            if (card4found)
            {
                back4.Visibility = Visibility.Hidden;
            }
            if (card5found)
            {
                back5.Visibility = Visibility.Hidden;
            }
            if (card6found)
            {
                back6.Visibility = Visibility.Hidden;
            }
            if (card7found)
            {
                back7.Visibility = Visibility.Hidden;
            }
            if (card8found)
            {
                back8.Visibility = Visibility.Hidden;
            }
            if (card9found)
            {
                back9.Visibility = Visibility.Hidden;
            }
            if (card10found)
            {
                back10.Visibility = Visibility.Hidden;
            }
            if (card11found)
            {
                back11.Visibility = Visibility.Hidden;
            }
            if (card12found)
            {
                back12.Visibility = Visibility.Hidden;
            }
            if (card13found)
            {
                back13.Visibility = Visibility.Hidden;
            }
            if (card14found)
            {
                back14.Visibility = Visibility.Hidden;
            }
            if (card15found)
            {
                back15.Visibility = Visibility.Hidden;
            }
            if (card16found)
            {
                back16.Visibility = Visibility.Hidden;
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

        private async void Back1_Click(object sender, RoutedEventArgs e)
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
                await Wait(waitTime);
                await ReCoverCards();
            }
        }

        private async void Back2_Click(object sender, RoutedEventArgs e)
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
                await Wait(waitTime);
                await ReCoverCards();
            }
        }

        private async void Back3_Click(object sender, RoutedEventArgs e)
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
                await Wait(waitTime);
                await ReCoverCards();

            }
        }

        private async void Back4_Click(object sender, RoutedEventArgs e)
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
                await Wait(waitTime);
                await ReCoverCards();

            }
        }

        private async void Back5_Click(object sender, RoutedEventArgs e)
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
                await Wait(waitTime);
                await ReCoverCards();

            }
        }

        private async void Back6_Click(object sender, RoutedEventArgs e)
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
                await Wait(waitTime);
                await ReCoverCards();

            }
        }

        private async void Back7_Click(object sender, RoutedEventArgs e)
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
                await Wait(waitTime);
                await ReCoverCards();
            }
        }

        private async void Back8_Click(object sender, RoutedEventArgs e)
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
                await Wait(waitTime);
                await ReCoverCards();

            }
        }

        private async void Back9_Click(object sender, RoutedEventArgs e)
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
                await Wait(waitTime);
                await ReCoverCards();

            }
        }

        private async void Back10_Click(object sender, RoutedEventArgs e)
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
                await Wait(waitTime);
                await ReCoverCards();

            }
        }

        private async void Back11_Click(object sender, RoutedEventArgs e)
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
                await Wait(waitTime);
                await ReCoverCards();

            }
        }

        private async void Back12_Click(object sender, RoutedEventArgs e)
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
                await Wait(waitTime);
                await ReCoverCards();

            }
        }

        private async void Back13_Click(object sender, RoutedEventArgs e)
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
                await Wait(waitTime);
                await ReCoverCards();

            }
        }

        private async void Back14_Click(object sender, RoutedEventArgs e)
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
                await Wait(waitTime);
                await ReCoverCards();

            }
        }

        private async void Back15_Click(object sender, RoutedEventArgs e)
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
                selection = 0;
                selection2 = 0;
                UpdateDebug();
                await Wait(waitTime);
                await ReCoverCards();

            }
        }

        private async void Back16_Click(object sender, RoutedEventArgs e)
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
                await Wait(waitTime);
                await ReCoverCards();
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
            if (cardsHidden)
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

        private void Default_Selected(object sender, RoutedEventArgs e)
        {
            defaultTheme = "basic";
            SortAndRandomiseCards();
        }

        private void Dolphins_Selected(object sender, RoutedEventArgs e)
        {
            defaultTheme = "dolphin";
            SortAndRandomiseCards();
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            card1found = false;
            card2found = false;
            card3found = false;
            card4found = false;
            card5found = false;
            card6found = false;
            card7found = false;
            card8found = false;
            card9found = false;
            card10found = false;
            card11found = false;
            card12found = false;
            card13found = false;
            card14found = false;
            card15found = false;
            card16found = false;
            SortAndRandomiseCards();
            ReCoverCards();
            pairs = 0;
            clicks = 0;
        }

        private void QuitGame_Click(object sender, RoutedEventArgs e)
        {
            string result = (MessageBox.Show("Do you want to quit?", "Confirm quit", MessageBoxButton.YesNo)).ToString();
            if (result == "Yes")
            {
                this.Close();
            }
            else if (result == "No")
            {

            }
        }

        private void OptionsButton_Click(object sender, RoutedEventArgs e)
        {
            Options.Visibility = Visibility.Visible;
            Debug.Visibility = Visibility.Collapsed;
            Rules.Visibility = Visibility.Collapsed;
        }

        private void DebugButton_Click(object sender, RoutedEventArgs e)
        {
            Options.Visibility = Visibility.Collapsed;
            Debug.Visibility = Visibility.Visible;
            Rules.Visibility = Visibility.Collapsed;
        }

        private void RulesButton_Click(object sender, RoutedEventArgs e)
        {
            Options.Visibility = Visibility.Collapsed;
            Debug.Visibility = Visibility.Collapsed;
            Rules.Visibility = Visibility.Visible;
        }
    }
}


//// todo after two cards are uncovered, if not a pair, re-cover the cards.
// todo once a pair is found, they should remain shown. Can a button be deleted? Will it cause problems when they're being shown again?
// todo look at implementing delays in display

