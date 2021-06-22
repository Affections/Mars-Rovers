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

namespace Mars_Rovers
{
    /// <summary>
    /// Interaction logic for TwoRovers.xaml
    /// </summary>
    /// 

    public partial class TwoRovers : Window
    {
        public int X;
        public int Y;
        public int DirectionR;
        public Image TempImage;
        public Image Nimage;
        public Image SImage;
        public Image Wimage;
        public Image Eimage;

        public TwoRovers()
        {
            InitializeComponent();
        }
        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            char[] input = commandsInput.Text.ToCharArray();
            for (int i = 0; i < input.Length; i++)
            {
                switch (input[i])
                {
                    case 'L':
                        {
                            if (DirectionR == 0)
                            {
                                DirectionR = 3;
                            }
                            else
                            {
                                DirectionR -= 1;
                            }
                        }
                        break;
                    case 'R':
                        {
                            if (DirectionR == 3)
                            {
                                DirectionR = 0;
                            }
                            else
                            {
                                DirectionR += 1;
                            }
                        }
                        break;
                    case 'M':
                        {
                            switch (DirectionR)
                            {
                                case 0:
                                    {
                                        if ((Y - 1) < 0)
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            Y -= 1;
                                        }
                                    }
                                    break;
                                case 1:
                                    {
                                        if ((X - 1) < 0)
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            X -= 1;
                                        }
                                    }
                                    break;
                                case 2:
                                    {
                                        if ((Y + 1) > TheGrid.RowDefinitions.Count)
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            Y += 1;
                                        }
                                    }
                                    break;
                                case 3:
                                    {
                                        if ((X + 1) > TheGrid.ColumnDefinitions.Count)
                                        {
                                            break;
                                        }
                                        else
                                        {
                                            X += 1;
                                        }
                                    }
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;
                    default:
                        break;
                }
            }
            Dictionary<int[], char> outPut = new Dictionary<int[], char>();
            switch (DirectionR)
            {
                case 0:
                    {
                        outPut.Add(new int[] { X, Y }, 'S');
                    }
                    break;
                case 1:
                    {
                        outPut.Add(new int[] { X, Y }, 'W');
                    }
                    break;
                case 2:
                    {
                        outPut.Add(new int[] { X, Y }, 'N');
                    }
                    break;
                case 3:
                    {
                        outPut.Add(new int[] { X, Y }, 'E');
                    }
                    break;
                default:
                    break;
            }
            foreach (var item in outPut)
            {
               outPutBox.Text = $"{String.Join("", item.Key)}{item.Value}";
                TheGrid.Children.Remove(TempImage);
                int xItem = item.Key[0];
                int yItem = item.Key[1];
                switch (item.Value)
                {
                    case 'N':
                        {
                            TheGrid.Children.Add(Nimage);
                            System.Windows.Controls.Grid.SetRow(Nimage, TheGrid.RowDefinitions.Count - yItem);
                            System.Windows.Controls.Grid.SetColumn(Nimage, xItem - 1);
                        }
                        break;
                    case 'S':
                        {
                            TheGrid.Children.Add(SImage);
                            System.Windows.Controls.Grid.SetRow(SImage, TheGrid.RowDefinitions.Count - yItem);
                            System.Windows.Controls.Grid.SetColumn(SImage, xItem - 1);
                        }
                        break;
                    case 'W':
                        {
                            TheGrid.Children.Add(Wimage);
                            System.Windows.Controls.Grid.SetRow(Wimage, TheGrid.RowDefinitions.Count - yItem);
                            System.Windows.Controls.Grid.SetColumn(Wimage, xItem - 1);
                        }
                        break;
                    case 'E':
                        {
                            TheGrid.Children.Add(Eimage);
                            System.Windows.Controls.Grid.SetRow(Eimage, TheGrid.RowDefinitions.Count - yItem);
                            System.Windows.Controls.Grid.SetColumn(Eimage, xItem - 1);
                        }
                        break;
                    default:
                        break;
                } 
            }
        }
        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            TheGrid.Children.Remove(TempImage);
            X = 0;
            Y = 0;
            char[] input = spawnPositionInput.Text.ToCharArray();
            int xTry = Convert.ToInt32($"{input[0]}");
            int yTry = Convert.ToInt32($"{input[1]}");
            X = (int)xTry;
            Y = (int)yTry;

            var imageN = new System.Windows.Media.Imaging.BitmapImage();
            imageN.BeginInit();
            imageN.UriSource = new Uri(@"E:\Internship\Mars_Rovers\Mars_Rovers\Images\N.png");
            imageN.DecodePixelWidth = 40;
            imageN.EndInit();
            var imageE = new System.Windows.Media.Imaging.BitmapImage();
            imageE.BeginInit();
            imageE.UriSource = new Uri(@"E:\Internship\Mars_Rovers\Mars_Rovers\Images\E.png");
            imageE.DecodePixelWidth = 40;
            imageE.EndInit();
            var imageS = new System.Windows.Media.Imaging.BitmapImage();
            imageS.BeginInit();
            imageS.UriSource = new Uri(@"E:\Internship\Mars_Rovers\Mars_Rovers\Images\S.png");
            imageS.DecodePixelWidth = 40;
            imageS.EndInit();
            var imageW = new System.Windows.Media.Imaging.BitmapImage();
            imageW.BeginInit();
            imageW.UriSource = new Uri(@"E:\Internship\Mars_Rovers\Mars_Rovers\Images\W.png");
            imageW.DecodePixelWidth = 40;
            imageW.EndInit();
            Image N = new Image();
            N.Source = imageN;
            N.Height = 40;
            N.Width = 40;
            Image E = new Image();
            E.Source = imageE;
            E.Height = 40;
            E.Width = 40;
            Image S = new Image();
            S.Source = imageS;
            S.Height = 40;
            S.Width = 40;
            Image W = new Image();
            W.Source = imageW;
            W.Height = 40;
            W.Width = 40; 
            Wimage = W;
            SImage = S;
            Eimage = E;
            Nimage = N;
            DirectionR = 0;
            switch (input[2])
            {
                case 'N':
                    {
                        DirectionR = (int)Direction.N;

                        TheGrid.Children.Add(N);
                        System.Windows.Controls.Grid.SetRow(N, TheGrid.RowDefinitions.Count - Y);
                        System.Windows.Controls.Grid.SetColumn(N, X - 1);
                        TempImage = N;
                    }
                    break;
                case 'W':
                    {
                        DirectionR = (int)Direction.W;
                        TheGrid.Children.Add(W);
                        System.Windows.Controls.Grid.SetRow(W, TheGrid.RowDefinitions.Count - Y);
                        System.Windows.Controls.Grid.SetColumn(W, X - 1);
                        TempImage = W;
                    }
                    break;
                case 'S':
                    {
                        DirectionR = (int)Direction.S;
                        TheGrid.Children.Add(S);
                        System.Windows.Controls.Grid.SetRow(S, TheGrid.RowDefinitions.Count - Y);
                        System.Windows.Controls.Grid.SetColumn(S, X - 1);
                        TempImage = S;
                    }
                    break;
                case 'E':
                    {
                        DirectionR = (int)Direction.E;
                        TheGrid.Children.Add(E);
                        System.Windows.Controls.Grid.SetRow(E, TheGrid.RowDefinitions.Count - Y);
                        System.Windows.Controls.Grid.SetColumn(E, X - 1);
                        TempImage = E;
                    }
                    break;
                default:
                    break;
            }

            TheGrid.UpdateLayout();
        }
        public enum Direction
        {
            S,
            W,
            N,
            E
        }

   
    }
}

