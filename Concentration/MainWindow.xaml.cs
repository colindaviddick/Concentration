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

    // Themes
    /// Space
    // Mythical Creatures
    // Black and White
    // Coloursplash
    // Sports
    // Jewels
    /// Currency
    // Countries
    // Pirates
    // Mermaids
    // Unicorns
    // Movies
    // Candy
    /// Casino
    // British
    // Dinosaurs
    // Things beginning with...
    // 90s

    public partial class MainWindow : Window
    {
        /// <summary>
        
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

        string[] anonymousNames = System.IO.File.ReadAllLines(@"C:\Users\User\source\repos\Concentration\Concentration\NameList.txt");
        int anonymousNamesLength;
        // bool shieldTurn = true;

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
            AnonymizeNames();
            UpdateClicks();
            UpdateDebug();
        }

        void AnonymizeNames()
        {
            anonymousNamesLength = anonymousNames.Length;
            Random r = new Random();

            if(Properties.Settings.Default.Name1 == "Anonymous")
            {
                int rInt = r.Next(1, anonymousNamesLength);
                Properties.Settings.Default.Name1 = anonymousNames[rInt];
            }
            if (Properties.Settings.Default.Name2 == "Anonymous")
            {
                int rInt = r.Next(1, anonymousNamesLength);
                Properties.Settings.Default.Name2 = anonymousNames[rInt];
            }

            if (Properties.Settings.Default.Name3 == "Anonymous")
            {
                int rInt = r.Next(1, anonymousNamesLength);
                Properties.Settings.Default.Name3 = anonymousNames[rInt];
            }
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

        //public async Task SpinningShield()
        //{
        //    while (shieldTurn == true)
        //    {
        //        await Wait(5);
        //        ShieldTurn.Angle++;
        //    }
        //}

        void UpdateClicks()
        {
            Clicks.Text = ("Clicks : " + clicks.ToString());
            Pairs.Text = ("Pairs found : " + pairs.ToString());
            HighScore1.Text = (Properties.Settings.Default.Name1 + " - " + Properties.Settings.Default.Score1);
            HighScore2.Text = (Properties.Settings.Default.Name2 + " - " + Properties.Settings.Default.Score2);
            HighScore3.Text = (Properties.Settings.Default.Name3 + " - " + Properties.Settings.Default.Score3);
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
                if (clicks <= Properties.Settings.Default.Score3)
                {
                    HighestScoresPanel.Visibility = Visibility.Visible;
                    HighScorePanel.Visibility = Visibility.Visible;
                    Options.Visibility = Visibility.Collapsed;
                    Debug.Visibility = Visibility.Collapsed;
                    About.Visibility = Visibility.Collapsed;
                    Rules.Visibility = Visibility.Collapsed;
                    HighscoresPanel.Height = 300;
                }
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

            Shield.Visibility = Visibility.Hidden;
        }

        public async Task Wait(int milliseconds)
        {
            System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
            if (milliseconds == 0 || milliseconds < 0) return;
            timer1.Interval = milliseconds;
            timer1.Enabled = true;
            timer1.Start();
            timer1.Tick += (s, e) =>
            {
                timer1.Enabled = false;
                timer1.Stop();
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
                Shield.Visibility = Visibility.Visible;
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
                Shield.Visibility = Visibility.Visible;
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
                Shield.Visibility = Visibility.Visible;
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
                Shield.Visibility = Visibility.Visible;
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
                Shield.Visibility = Visibility.Visible;
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
                Shield.Visibility = Visibility.Visible;
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
                Shield.Visibility = Visibility.Visible;
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
                Shield.Visibility = Visibility.Visible;
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
                Shield.Visibility = Visibility.Visible;
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
                Shield.Visibility = Visibility.Visible;
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
                Shield.Visibility = Visibility.Visible;
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
                Shield.Visibility = Visibility.Visible;
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
                Shield.Visibility = Visibility.Visible;
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
                Shield.Visibility = Visibility.Visible;
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
                Shield.Visibility = Visibility.Visible;
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
                Shield.Visibility = Visibility.Visible;
                CheckIfPair(selection, selection2);
                await Wait(waitTime);
                await ReCoverCards();
                UpdateDebug();
                selection = 0;
                selection2 = 0;
            }
        }

        private void ClearHighScores_Click(object sender, RoutedEventArgs e)
        {
            Properties.Settings.Default.Score1 = 100;
            Properties.Settings.Default.Name1 = "Anonymous";
            Properties.Settings.Default.Score2 = 100;
            Properties.Settings.Default.Name2 = "Anonymous";
            Properties.Settings.Default.Score3 = 100;
            Properties.Settings.Default.Name3 = "Anonymous";
            Properties.Settings.Default.Save();
            AnonymizeNames();
            HighScore1.Text = (Properties.Settings.Default.Name1 + " - " + Properties.Settings.Default.Score1);
            HighScore2.Text = (Properties.Settings.Default.Name2 + " - " + Properties.Settings.Default.Score2);
            HighScore3.Text = (Properties.Settings.Default.Name3 + " - " + Properties.Settings.Default.Score3);
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

            back1.Style = (Style)FindResource("DefaultCardBackMouseover");
            back2.Style = (Style)FindResource("DefaultCardBackMouseover");
            back3.Style = (Style)FindResource("DefaultCardBackMouseover");
            back4.Style = (Style)FindResource("DefaultCardBackMouseover");
            back5.Style = (Style)FindResource("DefaultCardBackMouseover");
            back6.Style = (Style)FindResource("DefaultCardBackMouseover");
            back7.Style = (Style)FindResource("DefaultCardBackMouseover");
            back8.Style = (Style)FindResource("DefaultCardBackMouseover");
            back9.Style = (Style)FindResource("DefaultCardBackMouseover");
            back10.Style = (Style)FindResource("DefaultCardBackMouseover");
            back11.Style = (Style)FindResource("DefaultCardBackMouseover");
            back12.Style = (Style)FindResource("DefaultCardBackMouseover");
            back13.Style = (Style)FindResource("DefaultCardBackMouseover");
            back14.Style = (Style)FindResource("DefaultCardBackMouseover");
            back15.Style = (Style)FindResource("DefaultCardBackMouseover");
            back16.Style = (Style)FindResource("DefaultCardBackMouseover");
            NewGameSequence();
        }

        private void Dolphins_Selected(object sender, RoutedEventArgs e)
        {
            defaultTheme = "dolphin";

            back1.Style = (Style)FindResource("DolphinCardBackMouseover");
            back2.Style = (Style)FindResource("DolphinCardBackMouseover");
            back3.Style = (Style)FindResource("DolphinCardBackMouseover");
            back4.Style = (Style)FindResource("DolphinCardBackMouseover");
            back5.Style = (Style)FindResource("DolphinCardBackMouseover");
            back6.Style = (Style)FindResource("DolphinCardBackMouseover");
            back7.Style = (Style)FindResource("DolphinCardBackMouseover");
            back8.Style = (Style)FindResource("DolphinCardBackMouseover");
            back9.Style = (Style)FindResource("DolphinCardBackMouseover");
            back10.Style = (Style)FindResource("DolphinCardBackMouseover");
            back11.Style = (Style)FindResource("DolphinCardBackMouseover");
            back12.Style = (Style)FindResource("DolphinCardBackMouseover");
            back13.Style = (Style)FindResource("DolphinCardBackMouseover");
            back14.Style = (Style)FindResource("DolphinCardBackMouseover");
            back15.Style = (Style)FindResource("DolphinCardBackMouseover");
            back16.Style = (Style)FindResource("DolphinCardBackMouseover");
            NewGameSequence();
        }

        private void NewGameSequence()
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
            HighScorePanel.Visibility = Visibility.Collapsed;
            SortAndRandomiseCards();
            _ = ReCoverCards();
            pairs = 0;
            clicks = 0;
        }

        private void NewGame_Click(object sender, RoutedEventArgs e)
        {
            NewGameSequence();
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
            if (Options.Visibility == Visibility.Visible)
            {
                Options.Visibility = Visibility.Collapsed;
            }
            else
            {
                Options.Visibility = Visibility.Visible;
                Debug.Visibility = Visibility.Collapsed;
                Rules.Visibility = Visibility.Collapsed;
                About.Visibility = Visibility.Collapsed;
                HighestScoresPanel.Visibility = Visibility.Collapsed;
            }
        }

        private void DebugButton_Click(object sender, RoutedEventArgs e)
        {
            if (Debug.Visibility == Visibility.Visible)
            {
                Debug.Visibility = Visibility.Collapsed;
            }
            else
            {
                Options.Visibility = Visibility.Collapsed;
                Debug.Visibility = Visibility.Visible;
                Rules.Visibility = Visibility.Collapsed;
                About.Visibility = Visibility.Collapsed;
                HighestScoresPanel.Visibility = Visibility.Collapsed;
            }
        }

        private void RulesButton_Click(object sender, RoutedEventArgs e)
        {
            if (Rules.Visibility == Visibility.Visible)
            {
                Rules.Visibility = Visibility.Collapsed;
            }
            else
            {
                Options.Visibility = Visibility.Collapsed;
                Debug.Visibility = Visibility.Collapsed;
                Rules.Visibility = Visibility.Visible;
                About.Visibility = Visibility.Collapsed;
                HighestScoresPanel.Visibility = Visibility.Collapsed;
            }
        }
        private void AboutButton_Click(object sender, RoutedEventArgs e)
        {
            if (About.Visibility == Visibility.Visible)
            {
                About.Visibility = Visibility.Collapsed;
            }
            else
            {
                Options.Visibility = Visibility.Collapsed;
                Debug.Visibility = Visibility.Collapsed;
                Rules.Visibility = Visibility.Collapsed;
                About.Visibility = Visibility.Visible;
                HighestScoresPanel.Visibility = Visibility.Collapsed;
            }
        }

        private void HScoresButton_Click(object sender, RoutedEventArgs e)
        {
            if (HighestScoresPanel.Visibility == Visibility.Visible)
            {
                HighestScoresPanel.Visibility = Visibility.Collapsed;
            }
            else
            {
                Options.Visibility = Visibility.Collapsed;
                Debug.Visibility = Visibility.Collapsed;
                Rules.Visibility = Visibility.Collapsed;
                About.Visibility = Visibility.Collapsed;
                HighestScoresPanel.Visibility = Visibility.Visible;
            }
        }


        private void ActivateDebugMode_Click(object sender, RoutedEventArgs e)
        {
            DebugButton.Visibility = Visibility.Visible;
        }

        private void HalfSecond_Selected(object sender, RoutedEventArgs e)
        {
            waitTime = 500;
        }

        private void OneSecond_Selected(object sender, RoutedEventArgs e)
        {
            waitTime = 1000;
        }

        private void OneHalfSecond_Selected(object sender, RoutedEventArgs e)
        {
            waitTime = 1500;
        }

        private void TwoSecond_Selected(object sender, RoutedEventArgs e)
        {
            waitTime = 2000;
        }

        private void TwoHalfSecond_Selected(object sender, RoutedEventArgs e)
        {
            waitTime = 2500;
        }

        private void ThreeSecond_Selected(object sender, RoutedEventArgs e)
        {
            waitTime = 3000;
        }

        private void Animals_Selected(object sender, RoutedEventArgs e)
        {
            defaultTheme = "animal";

            back1.Style = (Style)FindResource("AnimalCardBackMouseover");
            back2.Style = (Style)FindResource("AnimalCardBackMouseover");
            back3.Style = (Style)FindResource("AnimalCardBackMouseover");
            back4.Style = (Style)FindResource("AnimalCardBackMouseover");
            back5.Style = (Style)FindResource("AnimalCardBackMouseover");
            back6.Style = (Style)FindResource("AnimalCardBackMouseover");
            back7.Style = (Style)FindResource("AnimalCardBackMouseover");
            back8.Style = (Style)FindResource("AnimalCardBackMouseover");
            back9.Style = (Style)FindResource("AnimalCardBackMouseover");
            back10.Style = (Style)FindResource("AnimalCardBackMouseover");
            back11.Style = (Style)FindResource("AnimalCardBackMouseover");
            back12.Style = (Style)FindResource("AnimalCardBackMouseover");
            back13.Style = (Style)FindResource("AnimalCardBackMouseover");
            back14.Style = (Style)FindResource("AnimalCardBackMouseover");
            back15.Style = (Style)FindResource("AnimalCardBackMouseover");
            back16.Style = (Style)FindResource("AnimalCardBackMouseover");
            NewGameSequence();
        }

        private void Animals2_Selected(object sender, RoutedEventArgs e)
        {
            defaultTheme = "animal2";

            back1.Style = (Style)FindResource("Animal2CardBackMouseover");
            back2.Style = (Style)FindResource("Animal2CardBackMouseover");
            back3.Style = (Style)FindResource("Animal2CardBackMouseover");
            back4.Style = (Style)FindResource("Animal2CardBackMouseover");
            back5.Style = (Style)FindResource("Animal2CardBackMouseover");
            back6.Style = (Style)FindResource("Animal2CardBackMouseover");
            back7.Style = (Style)FindResource("Animal2CardBackMouseover");
            back8.Style = (Style)FindResource("Animal2CardBackMouseover");
            back9.Style = (Style)FindResource("Animal2CardBackMouseover");
            back10.Style = (Style)FindResource("Animal2CardBackMouseover");
            back11.Style = (Style)FindResource("Animal2CardBackMouseover");
            back12.Style = (Style)FindResource("Animal2CardBackMouseover");
            back13.Style = (Style)FindResource("Animal2CardBackMouseover");
            back14.Style = (Style)FindResource("Animal2CardBackMouseover");
            back15.Style = (Style)FindResource("Animal2CardBackMouseover");
            back16.Style = (Style)FindResource("Animal2CardBackMouseover");
            NewGameSequence();
        }

        private void Flowers_Selected(object sender, RoutedEventArgs e)
        {
            defaultTheme = "flowers";

            back1.Style = (Style)FindResource("FlowersCardBackMouseover");
            back2.Style = (Style)FindResource("FlowersCardBackMouseover");
            back3.Style = (Style)FindResource("FlowersCardBackMouseover");
            back4.Style = (Style)FindResource("FlowersCardBackMouseover");
            back5.Style = (Style)FindResource("FlowersCardBackMouseover");
            back6.Style = (Style)FindResource("FlowersCardBackMouseover");
            back7.Style = (Style)FindResource("FlowersCardBackMouseover");
            back8.Style = (Style)FindResource("FlowersCardBackMouseover");
            back9.Style = (Style)FindResource("FlowersCardBackMouseover");
            back10.Style = (Style)FindResource("FlowersCardBackMouseover");
            back11.Style = (Style)FindResource("FlowersCardBackMouseover");
            back12.Style = (Style)FindResource("FlowersCardBackMouseover");
            back13.Style = (Style)FindResource("FlowersCardBackMouseover");
            back14.Style = (Style)FindResource("FlowersCardBackMouseover");
            back15.Style = (Style)FindResource("FlowersCardBackMouseover");
            back16.Style = (Style)FindResource("FlowersCardBackMouseover");
            NewGameSequence();
        }

        private void Sealife_Selected(object sender, RoutedEventArgs e)
        {
            defaultTheme = "sealife";

            back1.Style = (Style)FindResource("SealifeCardBackMouseover");
            back2.Style = (Style)FindResource("SealifeCardBackMouseover");
            back3.Style = (Style)FindResource("SealifeCardBackMouseover");
            back4.Style = (Style)FindResource("SealifeCardBackMouseover");
            back5.Style = (Style)FindResource("SealifeCardBackMouseover");
            back6.Style = (Style)FindResource("SealifeCardBackMouseover");
            back7.Style = (Style)FindResource("SealifeCardBackMouseover");
            back8.Style = (Style)FindResource("SealifeCardBackMouseover");
            back9.Style = (Style)FindResource("SealifeCardBackMouseover");
            back10.Style = (Style)FindResource("SealifeCardBackMouseover");
            back11.Style = (Style)FindResource("SealifeCardBackMouseover");
            back12.Style = (Style)FindResource("SealifeCardBackMouseover");
            back13.Style = (Style)FindResource("SealifeCardBackMouseover");
            back14.Style = (Style)FindResource("SealifeCardBackMouseover");
            back15.Style = (Style)FindResource("SealifeCardBackMouseover");
            back16.Style = (Style)FindResource("SealifeCardBackMouseover");
            NewGameSequence();
        }

        private void HighScoreSaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (clicks < Properties.Settings.Default.Score1)
            {
                Properties.Settings.Default.Name3 = Properties.Settings.Default.Name2;
                Properties.Settings.Default.Score3 = Properties.Settings.Default.Score2;
                Properties.Settings.Default.Name2 = Properties.Settings.Default.Name1;
                Properties.Settings.Default.Score2 = Properties.Settings.Default.Score1;
                Properties.Settings.Default.Name1 = HighScoreName.Text;
                Properties.Settings.Default.Score1 = clicks;
                Properties.Settings.Default.Save();
            }
            else if (clicks < Properties.Settings.Default.Score2)
            {
                Properties.Settings.Default.Name3 = Properties.Settings.Default.Name2;
                Properties.Settings.Default.Score3 = Properties.Settings.Default.Score2;
                Properties.Settings.Default.Name2 = HighScoreName.Text;
                Properties.Settings.Default.Score2 = clicks;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.Name3 = HighScoreName.Text;
                Properties.Settings.Default.Score3 = clicks;
                Properties.Settings.Default.Save();
            }

            HighScore1.Text = (Properties.Settings.Default.Name1 + " - " + Properties.Settings.Default.Score1);
            HighScore2.Text = (Properties.Settings.Default.Name2 + " - " + Properties.Settings.Default.Score2);
            HighScore3.Text = (Properties.Settings.Default.Name3 + " - " + Properties.Settings.Default.Score3);
            Properties.Settings.Default.Save();
            HighscoresPanel.Height = 145;
            HighScorePanel.Visibility = Visibility.Hidden;
        }

        private void BigCats_Selected(object sender, RoutedEventArgs e)
        {
            defaultTheme = "bigcats";

            back1.Style = (Style)FindResource("BigCats1CardBackMouseover");
            back2.Style = (Style)FindResource("BigCats1CardBackMouseover");
            back3.Style = (Style)FindResource("BigCats1CardBackMouseover");
            back4.Style = (Style)FindResource("BigCats1CardBackMouseover");
            back5.Style = (Style)FindResource("BigCats1CardBackMouseover");
            back6.Style = (Style)FindResource("BigCats1CardBackMouseover");
            back7.Style = (Style)FindResource("BigCats1CardBackMouseover");
            back8.Style = (Style)FindResource("BigCats1CardBackMouseover");
            back9.Style = (Style)FindResource("BigCats1CardBackMouseover");
            back10.Style = (Style)FindResource("BigCats1CardBackMouseover");
            back11.Style = (Style)FindResource("BigCats1CardBackMouseover");
            back12.Style = (Style)FindResource("BigCats1CardBackMouseover");
            back13.Style = (Style)FindResource("BigCats1CardBackMouseover");
            back14.Style = (Style)FindResource("BigCats1CardBackMouseover");
            back15.Style = (Style)FindResource("BigCats1CardBackMouseover");
            back16.Style = (Style)FindResource("BigCats1CardBackMouseover");
            NewGameSequence();
        }

        private void BigCats2_Selected(object sender, RoutedEventArgs e)
        {
            defaultTheme = "bigcats2";

            back1.Style = (Style)FindResource("BigCats2CardBackMouseover");
            back2.Style = (Style)FindResource("BigCats2CardBackMouseover");
            back3.Style = (Style)FindResource("BigCats2CardBackMouseover");
            back4.Style = (Style)FindResource("BigCats2CardBackMouseover");
            back5.Style = (Style)FindResource("BigCats2CardBackMouseover");
            back6.Style = (Style)FindResource("BigCats2CardBackMouseover");
            back7.Style = (Style)FindResource("BigCats2CardBackMouseover");
            back8.Style = (Style)FindResource("BigCats2CardBackMouseover");
            back9.Style = (Style)FindResource("BigCats2CardBackMouseover");
            back10.Style = (Style)FindResource("BigCats2CardBackMouseover");
            back11.Style = (Style)FindResource("BigCats2CardBackMouseover");
            back12.Style = (Style)FindResource("BigCats2CardBackMouseover");
            back13.Style = (Style)FindResource("BigCats2CardBackMouseover");
            back14.Style = (Style)FindResource("BigCats2CardBackMouseover");
            back15.Style = (Style)FindResource("BigCats2CardBackMouseover");
            back16.Style = (Style)FindResource("BigCats2CardBackMouseover");
            NewGameSequence();
        }

        private void Birds_Selected(object sender, RoutedEventArgs e)
        {
            defaultTheme = "birds";

            back1.Style = (Style)FindResource("BirdsCardBackMouseover");
            back2.Style = (Style)FindResource("BirdsCardBackMouseover");
            back3.Style = (Style)FindResource("BirdsCardBackMouseover");
            back4.Style = (Style)FindResource("BirdsCardBackMouseover");
            back5.Style = (Style)FindResource("BirdsCardBackMouseover");
            back6.Style = (Style)FindResource("BirdsCardBackMouseover");
            back7.Style = (Style)FindResource("BirdsCardBackMouseover");
            back8.Style = (Style)FindResource("BirdsCardBackMouseover");
            back9.Style = (Style)FindResource("BirdsCardBackMouseover");
            back10.Style = (Style)FindResource("BirdsCardBackMouseover");
            back11.Style = (Style)FindResource("BirdsCardBackMouseover");
            back12.Style = (Style)FindResource("BirdsCardBackMouseover");
            back13.Style = (Style)FindResource("BirdsCardBackMouseover");
            back14.Style = (Style)FindResource("BirdsCardBackMouseover");
            back15.Style = (Style)FindResource("BirdsCardBackMouseover");
            back16.Style = (Style)FindResource("BirdsCardBackMouseover");
            NewGameSequence();
        }

        private void Birds2_Selected(object sender, RoutedEventArgs e)
        {
            defaultTheme = "birds2";

            back1.Style = (Style)FindResource("Birds2CardBackMouseover");
            back2.Style = (Style)FindResource("Birds2CardBackMouseover");
            back3.Style = (Style)FindResource("Birds2CardBackMouseover");
            back4.Style = (Style)FindResource("Birds2CardBackMouseover");
            back5.Style = (Style)FindResource("Birds2CardBackMouseover");
            back6.Style = (Style)FindResource("Birds2CardBackMouseover");
            back7.Style = (Style)FindResource("Birds2CardBackMouseover");
            back8.Style = (Style)FindResource("Birds2CardBackMouseover");
            back9.Style = (Style)FindResource("Birds2CardBackMouseover");
            back10.Style = (Style)FindResource("Birds2CardBackMouseover");
            back11.Style = (Style)FindResource("Birds2CardBackMouseover");
            back12.Style = (Style)FindResource("Birds2CardBackMouseover");
            back13.Style = (Style)FindResource("Birds2CardBackMouseover");
            back14.Style = (Style)FindResource("Birds2CardBackMouseover");
            back15.Style = (Style)FindResource("Birds2CardBackMouseover");
            back16.Style = (Style)FindResource("Birds2CardBackMouseover");
            NewGameSequence();
        }

        private void Bokeh_Selected(object sender, RoutedEventArgs e)
        {
            defaultTheme = "bokeh";

            back1.Style = (Style)FindResource("BokehCardBackMouseover");
            back2.Style = (Style)FindResource("BokehCardBackMouseover");
            back3.Style = (Style)FindResource("BokehCardBackMouseover");
            back4.Style = (Style)FindResource("BokehCardBackMouseover");
            back5.Style = (Style)FindResource("BokehCardBackMouseover");
            back6.Style = (Style)FindResource("BokehCardBackMouseover");
            back7.Style = (Style)FindResource("BokehCardBackMouseover");
            back8.Style = (Style)FindResource("BokehCardBackMouseover");
            back9.Style = (Style)FindResource("BokehCardBackMouseover");
            back10.Style = (Style)FindResource("BokehCardBackMouseover");
            back11.Style = (Style)FindResource("BokehCardBackMouseover");
            back12.Style = (Style)FindResource("BokehCardBackMouseover");
            back13.Style = (Style)FindResource("BokehCardBackMouseover");
            back14.Style = (Style)FindResource("BokehCardBackMouseover");
            back15.Style = (Style)FindResource("BokehCardBackMouseover");
            back16.Style = (Style)FindResource("BokehCardBackMouseover");
            NewGameSequence();
        }

        private void RockFormation_Selected(object sender, RoutedEventArgs e)
        {
            defaultTheme = "rockformation";

            back1.Style = (Style)FindResource("RockFormationCardBackMouseover");
            back2.Style = (Style)FindResource("RockFormationCardBackMouseover");
            back3.Style = (Style)FindResource("RockFormationCardBackMouseover");
            back4.Style = (Style)FindResource("RockFormationCardBackMouseover");
            back5.Style = (Style)FindResource("RockFormationCardBackMouseover");
            back6.Style = (Style)FindResource("RockFormationCardBackMouseover");
            back7.Style = (Style)FindResource("RockFormationCardBackMouseover");
            back8.Style = (Style)FindResource("RockFormationCardBackMouseover");
            back9.Style = (Style)FindResource("RockFormationCardBackMouseover");
            back10.Style = (Style)FindResource("RockFormationCardBackMouseover");
            back11.Style = (Style)FindResource("RockFormationCardBackMouseover");
            back12.Style = (Style)FindResource("RockFormationCardBackMouseover");
            back13.Style = (Style)FindResource("RockFormationCardBackMouseover");
            back14.Style = (Style)FindResource("RockFormationCardBackMouseover");
            back15.Style = (Style)FindResource("RockFormationCardBackMouseover");
            back16.Style = (Style)FindResource("RockFormationCardBackMouseover");
            NewGameSequence();
        }

        private void RockFormation2_Selected(object sender, RoutedEventArgs e)
        {
            defaultTheme = "rockformation2";

            back1.Style = (Style)FindResource("RockFormation2CardBackMouseover");
            back2.Style = (Style)FindResource("RockFormation2CardBackMouseover");
            back3.Style = (Style)FindResource("RockFormation2CardBackMouseover");
            back4.Style = (Style)FindResource("RockFormation2CardBackMouseover");
            back5.Style = (Style)FindResource("RockFormation2CardBackMouseover");
            back6.Style = (Style)FindResource("RockFormation2CardBackMouseover");
            back7.Style = (Style)FindResource("RockFormation2CardBackMouseover");
            back8.Style = (Style)FindResource("RockFormation2CardBackMouseover");
            back9.Style = (Style)FindResource("RockFormation2CardBackMouseover");
            back10.Style = (Style)FindResource("RockFormation2CardBackMouseover");
            back11.Style = (Style)FindResource("RockFormation2CardBackMouseover");
            back12.Style = (Style)FindResource("RockFormation2CardBackMouseover");
            back13.Style = (Style)FindResource("RockFormation2CardBackMouseover");
            back14.Style = (Style)FindResource("RockFormation2CardBackMouseover");
            back15.Style = (Style)FindResource("RockFormation2CardBackMouseover");
            back16.Style = (Style)FindResource("RockFormation2CardBackMouseover");
            NewGameSequence();
        }

        private void Mushrooms_Selected(object sender, RoutedEventArgs e)
        {
            defaultTheme = "mushrooms";

            back1.Style = (Style)FindResource("MushroomsCardBackMouseover");
            back2.Style = (Style)FindResource("MushroomsCardBackMouseover");
            back3.Style = (Style)FindResource("MushroomsCardBackMouseover");
            back4.Style = (Style)FindResource("MushroomsCardBackMouseover");
            back5.Style = (Style)FindResource("MushroomsCardBackMouseover");
            back6.Style = (Style)FindResource("MushroomsCardBackMouseover");
            back7.Style = (Style)FindResource("MushroomsCardBackMouseover");
            back8.Style = (Style)FindResource("MushroomsCardBackMouseover");
            back9.Style = (Style)FindResource("MushroomsCardBackMouseover");
            back10.Style = (Style)FindResource("MushroomsCardBackMouseover");
            back11.Style = (Style)FindResource("MushroomsCardBackMouseover");
            back12.Style = (Style)FindResource("MushroomsCardBackMouseover");
            back13.Style = (Style)FindResource("MushroomsCardBackMouseover");
            back14.Style = (Style)FindResource("MushroomsCardBackMouseover");
            back15.Style = (Style)FindResource("MushroomsCardBackMouseover");
            back16.Style = (Style)FindResource("MushroomsCardBackMouseover");
            NewGameSequence();
        }

        private void Mushrooms2_Selected(object sender, RoutedEventArgs e)
        {
            defaultTheme = "mushrooms2";

            back1.Style = (Style)FindResource("Mushrooms2CardBackMouseover");
            back2.Style = (Style)FindResource("Mushrooms2CardBackMouseover");
            back3.Style = (Style)FindResource("Mushrooms2CardBackMouseover");
            back4.Style = (Style)FindResource("Mushrooms2CardBackMouseover");
            back5.Style = (Style)FindResource("Mushrooms2CardBackMouseover");
            back6.Style = (Style)FindResource("Mushrooms2CardBackMouseover");
            back7.Style = (Style)FindResource("Mushrooms2CardBackMouseover");
            back8.Style = (Style)FindResource("Mushrooms2CardBackMouseover");
            back9.Style = (Style)FindResource("Mushrooms2CardBackMouseover");
            back10.Style = (Style)FindResource("Mushrooms2CardBackMouseover");
            back11.Style = (Style)FindResource("Mushrooms2CardBackMouseover");
            back12.Style = (Style)FindResource("Mushrooms2CardBackMouseover");
            back13.Style = (Style)FindResource("Mushrooms2CardBackMouseover");
            back14.Style = (Style)FindResource("Mushrooms2CardBackMouseover");
            back15.Style = (Style)FindResource("Mushrooms2CardBackMouseover");
            back16.Style = (Style)FindResource("Mushrooms2CardBackMouseover");
            NewGameSequence();
        }

        private void Mushrooms3_Selected(object sender, RoutedEventArgs e)
        {
            defaultTheme = "mushrooms3";

            back1.Style = (Style)FindResource("Mushrooms3CardBackMouseover");
            back2.Style = (Style)FindResource("Mushrooms3CardBackMouseover");
            back3.Style = (Style)FindResource("Mushrooms3CardBackMouseover");
            back4.Style = (Style)FindResource("Mushrooms3CardBackMouseover");
            back5.Style = (Style)FindResource("Mushrooms3CardBackMouseover");
            back6.Style = (Style)FindResource("Mushrooms3CardBackMouseover");
            back7.Style = (Style)FindResource("Mushrooms3CardBackMouseover");
            back8.Style = (Style)FindResource("Mushrooms3CardBackMouseover");
            back9.Style = (Style)FindResource("Mushrooms3CardBackMouseover");
            back10.Style = (Style)FindResource("Mushrooms3CardBackMouseover");
            back11.Style = (Style)FindResource("Mushrooms3CardBackMouseover");
            back12.Style = (Style)FindResource("Mushrooms3CardBackMouseover");
            back13.Style = (Style)FindResource("Mushrooms3CardBackMouseover");
            back14.Style = (Style)FindResource("Mushrooms3CardBackMouseover");
            back15.Style = (Style)FindResource("Mushrooms3CardBackMouseover");
            back16.Style = (Style)FindResource("Mushrooms3CardBackMouseover");
            NewGameSequence();
        }

        private void Space_Selected(object sender, RoutedEventArgs e)
        {
            defaultTheme = "space";

            back1.Style = (Style)FindResource("SpaceCardBackMouseover");
            back2.Style = (Style)FindResource("SpaceCardBackMouseover");
            back3.Style = (Style)FindResource("SpaceCardBackMouseover");
            back4.Style = (Style)FindResource("SpaceCardBackMouseover");
            back5.Style = (Style)FindResource("SpaceCardBackMouseover");
            back6.Style = (Style)FindResource("SpaceCardBackMouseover");
            back7.Style = (Style)FindResource("SpaceCardBackMouseover");
            back8.Style = (Style)FindResource("SpaceCardBackMouseover");
            back9.Style = (Style)FindResource("SpaceCardBackMouseover");
            back10.Style = (Style)FindResource("SpaceCardBackMouseover");
            back11.Style = (Style)FindResource("SpaceCardBackMouseover");
            back12.Style = (Style)FindResource("SpaceCardBackMouseover");
            back13.Style = (Style)FindResource("SpaceCardBackMouseover");
            back14.Style = (Style)FindResource("SpaceCardBackMouseover");
            back15.Style = (Style)FindResource("SpaceCardBackMouseover");
            back16.Style = (Style)FindResource("SpaceCardBackMouseover");
            NewGameSequence();
        }

        private void Space2_Selected(object sender, RoutedEventArgs e)
        {
            defaultTheme = "space2";

            back1.Style = (Style)FindResource("Space2CardBackMouseover");
            back2.Style = (Style)FindResource("Space2CardBackMouseover");
            back3.Style = (Style)FindResource("Space2CardBackMouseover");
            back4.Style = (Style)FindResource("Space2CardBackMouseover");
            back5.Style = (Style)FindResource("Space2CardBackMouseover");
            back6.Style = (Style)FindResource("Space2CardBackMouseover");
            back7.Style = (Style)FindResource("Space2CardBackMouseover");
            back8.Style = (Style)FindResource("Space2CardBackMouseover");
            back9.Style = (Style)FindResource("Space2CardBackMouseover");
            back10.Style = (Style)FindResource("Space2CardBackMouseover");
            back11.Style = (Style)FindResource("Space2CardBackMouseover");
            back12.Style = (Style)FindResource("Space2CardBackMouseover");
            back13.Style = (Style)FindResource("Space2CardBackMouseover");
            back14.Style = (Style)FindResource("Space2CardBackMouseover");
            back15.Style = (Style)FindResource("Space2CardBackMouseover");
            back16.Style = (Style)FindResource("Space2CardBackMouseover");
            NewGameSequence();
        }
    }
}

// TODO
//
// Change the shield to something more attractive. I'd like a small spinning icon and maybe a slight darkening of all of the cards?
// Also add the Sunset images that were created tonight.
// Maybe rejig the layout as the High Score thing messes with the size of the page.
// Add a small splash screen?