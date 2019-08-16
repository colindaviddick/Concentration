using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

using MessageBox = System.Windows.MessageBox;
using Button = System.Windows.Controls.Button;

namespace Concentration
{

    // Things to look at for next time:

        // Separate out into different class files?
                     


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
        /// I will describe my refactoring mental process:
        /// 1) Regions - when I see them, it usually means the whole block can be extracted to a separate method with name similar to region description
        /// 2) The same for comments - as an example - I see a comment // Assign values to cards, this to me is an instruction: extract this to private void AssignValuesToCards(...) {}
        /// 8) Organize the Assets (images) to folders, say Assets/Images/Cards?
        /// 9) Use arrays where possible - you can do something like this: boxes[7] = box8.Text; then later... if (box[7]==xyz)...

        int selection = 0;
        int selection2 = 0;
        int clicks = 0;
        int pairs = 0;
        int numberOfDecks = 27;
        string currentThemeName = "basic";

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

        Image[] cardImages = new Image[16];
        Button[] backImages = new Button[16];

        enum ThemesEnum
        {
            animal,
            animal2,
            basic,
            bigcats,
            bigcats2,
            birds,
            birds2,
            bokeh,
            dolphin,
            flowers,
            icecream,
            minerals,
            mushrooms,
            mushrooms2,
            mushrooms3,
            rockformation,
            rockformation2,
            sealife,
            space,
            space2,
            sweets,
            sweets2,
            sweets3,
            water,
            water2,
            water3
        };


        Random r = new Random();

        int anonymousNamesLength;
        string[] anonymousNames = System.IO.File.ReadAllLines(@"C:\Users\User\source\repos\Concentration\Concentration\NameList.txt");

        int waitTime = 1500;



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
            RandomizeTheme();
            UpdateClicks();
            UpdateDebug();
            SetWaitTime.SelectedIndex = 2;
        }

        private void RandomizeTheme()
        {
            ThemeSelector.SelectedIndex = r.Next(0, numberOfDecks);
        }

        void AnonymizeNames()
        {
            anonymousNamesLength = anonymousNames.Length;


            if (Properties.Settings.Default.Name1 == "Anonymous")
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
            if (Properties.Settings.Default.Name4 == "Anonymous")
            {
                int rInt = r.Next(1, anonymousNamesLength);
                Properties.Settings.Default.Name4 = anonymousNames[rInt];
            }
            if (Properties.Settings.Default.Name5 == "Anonymous")
            {
                int rInt = r.Next(1, anonymousNamesLength);
                Properties.Settings.Default.Name5 = anonymousNames[rInt];
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

            cardImages[0] = image1;
            cardImages[1] = image2;
            cardImages[2] = image3;
            cardImages[3] = image4;
            cardImages[4] = image5;
            cardImages[5] = image6;
            cardImages[6] = image7;
            cardImages[7] = image8;
            cardImages[8] = image9;
            cardImages[9] = image10;
            cardImages[10] = image11;
            cardImages[11] = image12;
            cardImages[12] = image13;
            cardImages[13] = image14;
            cardImages[14] = image15;
            cardImages[15] = image16;

            backImages[0] = back1;
            backImages[1] = back2;
            backImages[2] = back3;
            backImages[3] = back4;
            backImages[4] = back5;
            backImages[5] = back6;
            backImages[6] = back7;
            backImages[7] = back8;
            backImages[8] = back9;
            backImages[9] = back10;
            backImages[10] = back11;
            backImages[11] = back12;
            backImages[12] = back13;
            backImages[13] = back14;
            backImages[14] = back15;
            backImages[15] = back16;

            for (int i = 0; i < 16; i++)
            {
                cardImages[i].Source = new BitmapImage(new Uri((@"/images/cards/" + currentThemeName + "/" + shuffledCards[i] + ".jpg"), UriKind.RelativeOrAbsolute));
            }

            #region
            image1.Source = new BitmapImage(new Uri((@"/images/cards/" + currentThemeName + "/" + shuffledCards[0] + ".jpg"), UriKind.RelativeOrAbsolute));
            image2.Source = new BitmapImage(new Uri((@"/images/cards/" + currentThemeName + "/" + shuffledCards[1] + ".jpg"), UriKind.RelativeOrAbsolute));
            image3.Source = new BitmapImage(new Uri((@"/images/cards/" + currentThemeName + "/" + shuffledCards[2] + ".jpg"), UriKind.RelativeOrAbsolute));
            image4.Source = new BitmapImage(new Uri((@"/images/cards/" + currentThemeName + "/" + shuffledCards[3] + ".jpg"), UriKind.RelativeOrAbsolute));
            image5.Source = new BitmapImage(new Uri((@"/images/cards/" + currentThemeName + "/" + shuffledCards[4] + ".jpg"), UriKind.RelativeOrAbsolute));
            image6.Source = new BitmapImage(new Uri((@"/images/cards/" + currentThemeName + "/" + shuffledCards[5] + ".jpg"), UriKind.RelativeOrAbsolute));
            image7.Source = new BitmapImage(new Uri((@"/images/cards/" + currentThemeName + "/" + shuffledCards[6] + ".jpg"), UriKind.RelativeOrAbsolute));
            image8.Source = new BitmapImage(new Uri((@"/images/cards/" + currentThemeName + "/" + shuffledCards[7] + ".jpg"), UriKind.RelativeOrAbsolute));
            image9.Source = new BitmapImage(new Uri((@"/images/cards/" + currentThemeName + "/" + shuffledCards[8] + ".jpg"), UriKind.RelativeOrAbsolute));
            image10.Source = new BitmapImage(new Uri((@"/images/cards/" + currentThemeName + "/" + shuffledCards[9] + ".jpg"), UriKind.RelativeOrAbsolute));
            image11.Source = new BitmapImage(new Uri((@"/images/cards/" + currentThemeName + "/" + shuffledCards[10] + ".jpg"), UriKind.RelativeOrAbsolute));
            image12.Source = new BitmapImage(new Uri((@"/images/cards/" + currentThemeName + "/" + shuffledCards[11] + ".jpg"), UriKind.RelativeOrAbsolute));
            image13.Source = new BitmapImage(new Uri((@"/images/cards/" + currentThemeName + "/" + shuffledCards[12] + ".jpg"), UriKind.RelativeOrAbsolute));
            image14.Source = new BitmapImage(new Uri((@"/images/cards/" + currentThemeName + "/" + shuffledCards[13] + ".jpg"), UriKind.RelativeOrAbsolute));
            image15.Source = new BitmapImage(new Uri((@"/images/cards/" + currentThemeName + "/" + shuffledCards[14] + ".jpg"), UriKind.RelativeOrAbsolute));
            image16.Source = new BitmapImage(new Uri((@"/images/cards/" + currentThemeName + "/" + shuffledCards[15] + ".jpg"), UriKind.RelativeOrAbsolute));
            #endregion

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

        void UpdateClicks()
        {
            Clicks.Text = ("Clicks : " + clicks.ToString());
            Pairs.Text = ("Pairs found : " + pairs.ToString());
            HighScore1.Text = Properties.Settings.Default.Score1.ToString();
            HighScore2.Text = Properties.Settings.Default.Score2.ToString();
            HighScore3.Text = Properties.Settings.Default.Score3.ToString();
            HighScore4.Text = Properties.Settings.Default.Score4.ToString();
            HighScore5.Text = Properties.Settings.Default.Score5.ToString();
            HighScoreName1.Text = Properties.Settings.Default.Name1;
            HighScoreName2.Text = Properties.Settings.Default.Name2;
            HighScoreName3.Text = Properties.Settings.Default.Name3;
            HighScoreName4.Text = Properties.Settings.Default.Name4;
            HighScoreName5.Text = Properties.Settings.Default.Name5;
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
                if (clicks <= Properties.Settings.Default.Score5)
                {
                    if (clicks < Properties.Settings.Default.Score1)
                    {
                        HighScoreExplanation.Text = "You are the new top scorer! You've beaten everyone from " + Properties.Settings.Default.Name1
                            + " to " + Properties.Settings.Default.Name5 + ". Well done!";
                    }
                    else if (clicks < Properties.Settings.Default.Score2)
                    {
                        HighScoreExplanation.Text = ("Not quite number 1, but you still managed a better score than " + Properties.Settings.Default.Name2
                            + ", " + Properties.Settings.Default.Name3 + ", " + Properties.Settings.Default.Name4 + " and " + Properties.Settings.Default.Name5
                            + ". Congratulations!");
                    }
                    else if (clicks < Properties.Settings.Default.Score3)
                    {
                        HighScoreExplanation.Text = ("You managed a better score than " + Properties.Settings.Default.Name4 + " & " + Properties.Settings.Default.Name5 + "! Amazing job. Save your score now!");

                    }
                    else if (clicks < Properties.Settings.Default.Score4)
                    {
                        HighScoreExplanation.Text = (Properties.Settings.Default.Name4 + "'s position is looking shaky now. One more loss and they're gone. Congratulations to you though, you've taken their spot at number 4!");
                    }

                    else
                    {
                        HighScoreExplanation.Text = "You've scraped your way onto the leaderboard and you're knocking " + Properties.Settings.Default.Name5 + " off into obscurity. Save your score now!";
                    }

                    HighestScoresPanel.Visibility = Visibility.Visible;
                    HighScorePanel.Visibility = Visibility.Visible;
                    HighScoreName.Focus();
                    Options.Visibility = Visibility.Collapsed;
                    Debug.Visibility = Visibility.Collapsed;
                    About.Visibility = Visibility.Collapsed;
                    Rules.Visibility = Visibility.Collapsed;
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
            string result = (MessageBox.Show("Are you sure you want to clear the Highscore board?\nAll scores will be lost and cannot be retrieved.", "Confirm clearing high scores?", MessageBoxButton.YesNo)).ToString();
            if (result == "Yes")
            {
                Properties.Settings.Default.Score1 = 100;
                Properties.Settings.Default.Name1 = "Anonymous";
                Properties.Settings.Default.Score2 = 100;
                Properties.Settings.Default.Name2 = "Anonymous";
                Properties.Settings.Default.Score3 = 100;
                Properties.Settings.Default.Name3 = "Anonymous";
                Properties.Settings.Default.Score4 = 100;
                Properties.Settings.Default.Name4 = "Anonymous";
                Properties.Settings.Default.Score5 = 100;
                Properties.Settings.Default.Name5 = "Anonymous";
                Properties.Settings.Default.Save();
                AnonymizeNames();
                UpdateClicks();
                HighScoreClearConfirmation.Visibility = Visibility.Visible;
            }
            else if (result == "No")
            {

            }



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
                HighScoreClearConfirmation.Visibility = Visibility.Collapsed;
            }
            else
            {
                Options.Visibility = Visibility.Visible;
                Debug.Visibility = Visibility.Collapsed;
                Rules.Visibility = Visibility.Collapsed;
                About.Visibility = Visibility.Collapsed;
                HighestScoresPanel.Visibility = Visibility.Collapsed;
                HighScoreClearConfirmation.Visibility = Visibility.Collapsed;
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

        private void HighScoreSaveButton_Click(object sender, RoutedEventArgs e)
        {
            if (HighScoreName.Text == "" || HighScoreName.Text == null)
            {
                NoNameWarning.Visibility = Visibility.Visible;
            }

            else
            {
                HighScoreSaveRoutine();
            }
        }

        private void HighScoreSaveRoutine()
        {
            if (clicks < Properties.Settings.Default.Score1)
            {
                Properties.Settings.Default.Name5 = Properties.Settings.Default.Name4;
                Properties.Settings.Default.Score5 = Properties.Settings.Default.Score4;
                Properties.Settings.Default.Name4 = Properties.Settings.Default.Name3;
                Properties.Settings.Default.Score4 = Properties.Settings.Default.Score3;
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
                Properties.Settings.Default.Name5 = Properties.Settings.Default.Name4;
                Properties.Settings.Default.Score5 = Properties.Settings.Default.Score4;
                Properties.Settings.Default.Name4 = Properties.Settings.Default.Name3;
                Properties.Settings.Default.Score4 = Properties.Settings.Default.Score3;
                Properties.Settings.Default.Name3 = Properties.Settings.Default.Name2;
                Properties.Settings.Default.Score3 = Properties.Settings.Default.Score2;
                Properties.Settings.Default.Name2 = HighScoreName.Text;
                Properties.Settings.Default.Score2 = clicks;
                Properties.Settings.Default.Save();
            }
            else if (clicks < Properties.Settings.Default.Score3)
            {
                Properties.Settings.Default.Name5 = Properties.Settings.Default.Name4;
                Properties.Settings.Default.Score5 = Properties.Settings.Default.Score4;
                Properties.Settings.Default.Name4 = Properties.Settings.Default.Name3;
                Properties.Settings.Default.Score4 = Properties.Settings.Default.Score3;
                Properties.Settings.Default.Name3 = HighScoreName.Text;
                Properties.Settings.Default.Score3 = clicks;
                Properties.Settings.Default.Save();
            }
            else if (clicks < Properties.Settings.Default.Score4)
            {
                Properties.Settings.Default.Name5 = Properties.Settings.Default.Name4;
                Properties.Settings.Default.Score5 = Properties.Settings.Default.Score4;
                Properties.Settings.Default.Name4 = HighScoreName.Text;
                Properties.Settings.Default.Score4 = clicks;
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.Name5 = HighScoreName.Text;
                Properties.Settings.Default.Score5 = clicks;
                Properties.Settings.Default.Save();
            }

            UpdateClicks();
            Properties.Settings.Default.Save();
            NoNameWarning.Visibility = Visibility.Hidden;
            HighScorePanel.Visibility = Visibility.Collapsed;
        }

        #region Themes
        private void Animals_Selected(object sender, RoutedEventArgs e)
        {
            ThemeChanged(ThemesEnum.animal);
        }
        private void Animals2_Selected(object sender, RoutedEventArgs e)
        {
            ThemeChanged(ThemesEnum.animal2);
        }
        private void BigCats_Selected(object sender, RoutedEventArgs e)
        {
            ThemeChanged(ThemesEnum.bigcats);
        }
        private void BigCats2_Selected(object sender, RoutedEventArgs e)
        {
            ThemeChanged(ThemesEnum.bigcats2);
        }
        private void Birds_Selected(object sender, RoutedEventArgs e)
        {
            ThemeChanged(ThemesEnum.birds);
        }
        private void Birds2_Selected(object sender, RoutedEventArgs e)
        {
            ThemeChanged(ThemesEnum.birds2);
        }
        private void Bokeh_Selected(object sender, RoutedEventArgs e)
        {
            ThemeChanged(ThemesEnum.bokeh);
        }
        private void Default_Selected(object sender, RoutedEventArgs e)
        {
            ThemeChanged(ThemesEnum.basic);
        }
        private void Dolphins_Selected(object sender, RoutedEventArgs e)
        {
            ThemeChanged(ThemesEnum.dolphin);
        }
        private void Flowers_Selected(object sender, RoutedEventArgs e)
        {
            ThemeChanged(ThemesEnum.flowers);
        }
        private void IceCream_Selected(object sender, RoutedEventArgs e)
        {
            ThemeChanged(ThemesEnum.icecream);
        }
        private void Minerals_Selected(object sender, RoutedEventArgs e)
        {
            ThemeChanged(ThemesEnum.minerals);
        }
        private void Mushrooms_Selected(object sender, RoutedEventArgs e)
        {
            ThemeChanged(ThemesEnum.mushrooms);
        }
        private void Mushrooms2_Selected(object sender, RoutedEventArgs e)
        {
            ThemeChanged(ThemesEnum.mushrooms2);
        }
        private void Mushrooms3_Selected(object sender, RoutedEventArgs e)
        {
            ThemeChanged(ThemesEnum.mushrooms3);
        }
        private void RockFormation_Selected(object sender, RoutedEventArgs e)
        {
            ThemeChanged(ThemesEnum.rockformation);
        }
        private void RockFormation2_Selected(object sender, RoutedEventArgs e)
        {
            ThemeChanged(ThemesEnum.rockformation2);
        }
        private void Sealife_Selected(object sender, RoutedEventArgs e)
        {
            ThemeChanged(ThemesEnum.sealife);
        }
        private void Space_Selected(object sender, RoutedEventArgs e)
        {
            ThemeChanged(ThemesEnum.space);
        }
        private void Space2_Selected(object sender, RoutedEventArgs e)
        {
            ThemeChanged(ThemesEnum.space2);
        }
        private void Sweets_Selected(object sender, RoutedEventArgs e)
        {
            ThemeChanged(ThemesEnum.sweets);
        }
        private void Sweets2_Selected(object sender, RoutedEventArgs e)
        {
            ThemeChanged(ThemesEnum.sweets2);
        }
        private void Sweets3_Selected(object sender, RoutedEventArgs e)
        {
            ThemeChanged(ThemesEnum.sweets3);
        }
        private void Water_Selected(object sender, RoutedEventArgs e)
        {
            ThemeChanged(ThemesEnum.water);
        }
        private void Water2_Selected(object sender, RoutedEventArgs e)
        {
            ThemeChanged(ThemesEnum.water2);
        }
        private void Water3_Selected(object sender, RoutedEventArgs e)
        {
            ThemeChanged(ThemesEnum.water3);
        }

        #endregion
        private void RandomTheme_Click(object sender, RoutedEventArgs e)
        {
            RandomizeTheme();
        }

        private void ThemeChanged(ThemesEnum selectedTheme)
        {
            string styleRef;

            switch (selectedTheme)
            {
                case ThemesEnum.animal:
                    styleRef = "AnimalCardBackMouseover";
                    currentThemeName = "animal";
                    break;
                case ThemesEnum.animal2:
                    styleRef = "Animal2CardBackMouseover";
                    currentThemeName = "animal2";
                    break;
                case ThemesEnum.basic:
                    styleRef = "DefaultCardBackMouseover";
                    currentThemeName = "basic";
                    break;
                case ThemesEnum.bigcats:
                    styleRef = "BigCatsCardBackMouseover";
                    currentThemeName = "bigcats";
                    break;
                case ThemesEnum.bigcats2:
                    styleRef = "BigCats2CardBackMouseover";
                    currentThemeName = "bigcats2";
                    break;
                case ThemesEnum.birds:
                    styleRef = "BirdsCardBackMouseover";
                    currentThemeName = "birds";
                    break;
                case ThemesEnum.birds2:
                    styleRef = "Birds2CardBackMouseover";
                    currentThemeName = "birds2";
                    break;                                                          
                case ThemesEnum.bokeh:                                              
                    styleRef = "BokehCardBackMouseover";
                    currentThemeName = "bokeh";
                    break;                                                          
                case ThemesEnum.dolphin:                                            
                    styleRef = "DolphinCardBackMouseover";
                    currentThemeName = "dolphin";
                    break;                                                          
                case ThemesEnum.flowers:                                            
                    styleRef = "FlowersCardBackMouseover";
                    currentThemeName = "flowers";
                    break;                                                          
                case ThemesEnum.icecream:                                           
                    styleRef = "IceCreamCardBackMouseover";
                    currentThemeName = "icecream";
                    break;                                                          
                case ThemesEnum.minerals:                                           
                    styleRef = "MineralsCardBackMouseover";
                    currentThemeName = "minerals";
                    break;                                                          
                case ThemesEnum.mushrooms:                                          
                    styleRef = "MushroomsCardBackMouseover";
                    currentThemeName = "mushrooms";
                    break;                                                          
                case ThemesEnum.mushrooms2:                                         
                    styleRef = "Mushrooms2CardBackMouseover";
                    currentThemeName = "mushrooms2";
                    break;                                                          
                case ThemesEnum.mushrooms3:                                         
                    styleRef = "Mushrooms3CardBackMouseover";
                    currentThemeName = "mushrooms3";
                    break;                                                          
                case ThemesEnum.rockformation:                                      
                    styleRef = "RockFormationCardBackMouseover";
                    currentThemeName = "rockformation";
                    break;                                                          
                case ThemesEnum.rockformation2:                                     
                    styleRef = "RockFormation2CardBackMouseover";
                    currentThemeName = "rockformation2";
                    break;                                                          
                case ThemesEnum.sealife:                                            
                    styleRef = "SealifeCardBackMouseover";
                    currentThemeName = "sealife";
                    break;                                                          
                case ThemesEnum.space:                                              
                    styleRef = "SpaceCardBackMouseover";
                    currentThemeName = "space";
                    break;                                                          
                case ThemesEnum.space2:                                             
                    styleRef = "Space2CardBackMouseover";
                    currentThemeName = "space2";
                    break;                                                          
                case ThemesEnum.sweets:                                             
                    styleRef = "SweetsCardBackMouseover";
                    currentThemeName = "sweets";
                    break;                                                          
                case ThemesEnum.sweets2:                                            
                    styleRef = "Sweets2CardBackMouseover";
                    currentThemeName = "sweets2";
                    break;                                                          
                case ThemesEnum.sweets3:                                            
                    styleRef = "Sweets3CardBackMouseover";
                    currentThemeName = "sweets3";
                    break;                                                          
                case ThemesEnum.water:                                              
                    styleRef = "WaterCardBackMouseover";
                    currentThemeName = "water";
                    break;                                                          
                case ThemesEnum.water2:                                             
                    styleRef = "Water2CardBackMouseover";
                    currentThemeName = "water2";
                    break;                                                          
                case ThemesEnum.water3:                                             
                    styleRef = "Water3CardBackMouseover";
                    currentThemeName = "water3";
                    break;                                                          
                default:                                                            
                    styleRef = "DefaultCardBackMouseover";
                    currentThemeName = "basic";
                    break;                                                          
            }

            for (int i = 0; i < 16; i++)
            {
                backImages[i].Style = (Style)FindResource(styleRef);
            }

            for (int i = 0; i < 16; i++)
            {

                if (i <= 8)
                {
                    cardImages[i].Source = new BitmapImage(new Uri((@"/images/cards/" + currentThemeName + "/" + (i + 1) + ".jpg"), UriKind.RelativeOrAbsolute));
                }
                else
                {
                    cardImages[i].Source = new BitmapImage(new Uri((@"/images/cards/" + currentThemeName + "/" + (i - 8) + ".jpg"), UriKind.RelativeOrAbsolute));
                }
            }

            NewGameSequence();
        }
                
        private void HighScoreName_KeyDown(object sender, System.Windows.Input.KeyEventArgs e)
        {
            if (e.Key == Key.Enter || e.Key == Key.Return)
            {
                if (HighScoreName.Text == "" || HighScoreName.Text == null)
                {
                    NoNameWarning.Visibility = Visibility.Visible;
                } 
                else
                {
                    HighScoreSaveRoutine();
                }
            }
        }

        private void SetWaitTime_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            int i = SetWaitTime.SelectedIndex;
            switch (i)
            {
                case 0:
                    waitTime = 500;
                    break;

                case 1:
                    waitTime = 1000;
                    break;

                case 2:
                    waitTime = 1500;
                    break;

                case 3:
                    waitTime = 2000;
                    break;

                case 4:
                    waitTime = 2500;
                    break;

                case 5:
                    waitTime = 3000;
                    break;

                default:
                    waitTime = 1500;
                    break;
            }
        }
    }
}