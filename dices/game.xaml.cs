using System;
using System.Collections.Generic;
using System.IO;
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

namespace dices
{
    /// <summary>
    /// Interaction logic for game.xaml
    /// </summary>
    public partial class game : Window
    {
        Random random = new Random();
        Image image;
        Border border;
        int p1ms= 0;
        int p2ms= 0;
        int Player = 1;
        int count = 6;
        int[] array;
        int Scoreones;
        int ScoreTwos;
        int Scorethrees;
        int Scorefours;
        int Scorefives;
        int Scoresixs;
        int FinalScore;
        int meziscoreint;
        bool picked;
        public List<int> list = new List<int>();
        List<int> ones;
        List<int> twos;
        List<int> threes;
        List<int> fourths;
        List<int> fives;
        List<int> sixs;
        public game()
        {
            array = new int[6];
            InitializeComponent();
            showDices();
            saveopon.Visibility= Visibility.Collapsed;
            contiopon.Visibility= Visibility.Collapsed;
        }

        private ImageSource GetImage(byte[] resource)
        {
            MemoryStream memoryStream = new MemoryStream(resource);
            BitmapFrame bitmapFrame = BitmapFrame.Create(memoryStream);
            Image image = new Image();
            image.Source = bitmapFrame;
            return image.Source;
        }
        public void clear()
        {
            ones = new List<int>();
            twos = new List<int>();
            threes = new List<int>();
            fourths = new List<int>();
            fives = new List<int>();
            sixs = new List<int>();
        }
        public void addTolist(List<int> l)
        {
            clear();
            foreach (int i in l)
            {
                switch (i)
                {
                        case 1:
                            ones.Add(i);
                            break;
                        case 2:
                        twos.Add(i);
                            break;                         
                        case 3:
                        threes.Add(i);
                            break;
                        case 4:
                        fourths.Add(i);
                            break;
                        case 5:
                        fives.Add(i);
                            break;
                        case 6:
                        sixs.Add(i);
                            break;                    
                }
            }
            Scoreones = scoreCount(ones);
            ScoreTwos = scoreCount(twos);
            Scorethrees = scoreCount(threes);
            Scorefours = scoreCount(fourths);
            Scorefives = scoreCount(fives);
            Scoresixs = scoreCount(sixs);
            FinalScore = Scoreones + ScoreTwos + Scorethrees+ Scorefours+ Scorefives + Scoresixs;
            if (Player == 1)
            {
                score.Text = FinalScore.ToString();
            }
            else
            {
                scoreopon.Text = FinalScore.ToString();
            }
        }
        public int scoreCount(List<int> l)
        {
            if (l.Count <= 0)
            {
                return 0;
            }
            else
            {
                int num;               
                num = l.First();
                if (l.Count == 1)
                {
                    switch (num)
                    {
                        case 1:
                            return 100;
                        case 2:
                            return 0;
                        case 3:
                            return 0;
                        case 4:
                            return 0;
                        case 5:
                            return 50;
                        case 6:
                            return 0;
                    }
                }
                else if (l.Count == 2)
                {
                    switch (num)
                    {
                        case 1:
                            return 200;
                        case 2:
                            return 0;
                        case 3:
                            return 0;
                        case 4:
                            return 0;
                        case 5:
                            return 100;
                        case 6:
                            return 0;
                    }
                }
                else if (l.Count == 3)
                {
                    switch (num)
                    {
                        case 1:
                        return 1000;
                        case 2:
                        return 200;
                        case 3:
                        return 300;
                        case 4:
                        return 400;
                        case 5:
                        return 500;
                        case 6:
                        return 600;
                    }
                }
                else if (l.Count == 4)
                {
                    switch (num)
                    {
                        case 1:
                            return 2000;
                        case 2:
                            return 400;
                        case 3:
                            return 600;
                        case 4:
                            return 800;
                        case 5:
                            return 1000;
                        case 6:
                            return 1200;
                    }
                }
                else if (l.Count == 5)
                {
                    switch (num)
                    {
                        case 1:
                            return 4000;
                        case 2:
                            return 800;
                        case 3:
                            return 1200;
                        case 4:
                            return 1600;
                        case 5:
                            return 2000;
                        case 6:
                            return 2400;
                    }
                }
                else if (l.Count == 6)
                {
                    switch (num)
                    {
                        case 1:
                            return 8000;
                        case 2:
                            return 1600;
                        case 3:
                            return 2400;
                        case 4:
                            return 3200;
                        case 5:
                            return 4000;
                        case 6:
                            return 4800;
                    }
                }

            }
            return 0;
        }
        public void showDices()
        {
            if (Player == 1)
            {
                for (int i = 0; i < count; i++)
                {
                    int x = random.Next(1, 7);
                    image = new Image();
                    image.Source = new BitmapImage(new Uri($@"/pictures/dice{x}.png", UriKind.Relative));
                    array[i] = x;
                    image.Tag = i;
                    image.MouseDown += GridMouse;
                    PlayerGrid.Children.Add(image);
                    Grid.SetRow(image, 2);
                    Grid.SetColumn(image, i);

                }
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    int x = random.Next(1, 7);
                    image = new Image();
                    image.Source = new BitmapImage(new Uri($@"/pictures/dice{x}.png", UriKind.Relative));
                    array[i] = x;
                    image.Tag = i;
                    image.MouseDown += GridMouse;
                    oponGrid.Children.Add(image);
                    Grid.SetRow(image, 2);
                    Grid.SetColumn(image, i);

                }
            }
            
        }
        public void GridMouse(object sender, MouseButtonEventArgs e)
        {
            if (Player == 1)
            {
                try
                {
                    Image image = sender as Image;
                    int exos = int.Parse(image.Tag.ToString());
                    int x = exos;
                    image.Tag = image.Tag += "picked";
                    border = new Border();
                    border.BorderThickness = new Thickness(2);
                    border.BorderBrush = Brushes.White;
                    border.CornerRadius = new CornerRadius(200);
                    PlayerGrid.Children.Add(border);
                    Grid.SetRowSpan(border, 3);
                    Grid.SetColumnSpan(border, 1);
                    Grid.SetRow(border, 1);
                    Grid.SetColumn(border, x);
                    switch (array[x])
                    {
                        case 1:
                            list.Add(1);
                            break;
                        case 2:
                            list.Add(2);
                            break;
                        case 3:
                            list.Add(3);
                            break;
                        case 4:
                            list.Add(4);
                            break;
                        case 5:
                            list.Add(5);
                            break;
                        case 6:
                            list.Add(6);
                            break;
                        default:
                            break;
                    }
                    addTolist(list);
                }
                catch
                {
                    MessageBox.Show("To uz jsem nestihl");
                }
            }        
            else
            {
                try
                {
                    Image image = sender as Image;
                    int exos = int.Parse(image.Tag.ToString());
                    int x = exos;
                    image.Tag = image.Tag += "picked";
                    border = new Border();
                    border.BorderThickness = new Thickness(2);
                    border.BorderBrush = Brushes.White;
                    border.CornerRadius = new CornerRadius(200);
                    oponGrid.Children.Add(border);
                    Grid.SetRowSpan(border, 3);
                    Grid.SetColumnSpan(border, 1);
                    Grid.SetRow(border, 1);
                    Grid.SetColumn(border, x);
                    switch (array[x])
                    {
                        case 1:
                            list.Add(1);
                            break;
                        case 2:
                            list.Add(2);
                            break;
                        case 3:
                            list.Add(3);
                            break;
                        case 4:
                            list.Add(4);
                            break;
                        case 5:
                            list.Add(5);
                            break;
                        case 6:
                            list.Add(6);
                            break;
                        default:
                            break;
                    }
                    addTolist(list);
                }
                catch
                {
                    MessageBox.Show("To uz jsem nestihl");
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {                        
            if (Player == 1)
            {                
                meziscoreint += FinalScore;
                FinalScore = 0;
                score.Text = FinalScore.ToString();                
                save.Visibility = Visibility.Collapsed;
                conti.Visibility = Visibility.Collapsed;
                PlayerGrid.Children.Clear();
                saveopon.Visibility = Visibility.Visible;
                contiopon.Visibility = Visibility.Visible;
                p1ms += meziscoreint;
                Meziscore.Text= p1ms.ToString();
                Player = 2;
            }
            else
            {                
                meziscoreint += FinalScore;
                FinalScore = 0;
                scoreopon.Text = FinalScore.ToString();
                meziscoreopon.Text = meziscoreint.ToString();
                save.Visibility = Visibility.Visible;
                conti.Visibility = Visibility.Visible;
                oponGrid.Children.Clear();
                saveopon.Visibility = Visibility.Collapsed;
                contiopon.Visibility = Visibility.Collapsed;
                p2ms+= meziscoreint;
                meziscoreopon.Text = p2ms.ToString();
                Player = 1;
            }
            count = 6;
            meziscoreint = 0;
            FinalScore= 0;
            list.Clear();
            checkwin();
            showDices();
        }
        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            if (Player == 1)
            {
                
                meziscoreint += FinalScore;
                FinalScore = 0;
                score.Text = FinalScore.ToString();                
                count -= list.Count;
                if (count == 0)
                {
                    count = 6;
                }
                PlayerGrid.Children.Clear();
                showDices();
                list.Clear();
                p1ms += meziscoreint;
                Meziscore.Text = p1ms.ToString();                
            }
            else
            {
                
                meziscoreint += FinalScore;
                FinalScore = 0;
                score.Text = FinalScore.ToString();                
                count -= list.Count;
                if (count == 0)
                {
                    count = 6;
                }
                oponGrid.Children.Clear();
                showDices();
                list.Clear();
                p2ms += meziscoreint;
                meziscoreopon.Text = p2ms.ToString();
            }
            
        }
        public void checkwin()
        {
            if (p2ms >=2000)
            {
                MessageBox.Show("P2 win");
                Application.Current.Shutdown();
            }
            else if (p1ms >=2000)
            {
                MessageBox.Show("P1 win");
                Application.Current.Shutdown();
            }
        }
    }
}