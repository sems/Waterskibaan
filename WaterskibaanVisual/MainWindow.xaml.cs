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
using Waterskibaan;

namespace WaterskibaanVisual
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public Game Game { get; set; }
        public MainWindow()
        {
            InitializeComponent();
        }

        private static void DrawSporter(int x, int y, int Diameter, Color KledingKleur, Canvas cv)
        {
            Brush brush = new SolidColorBrush(Color.FromArgb(KledingKleur.A, KledingKleur.R, KledingKleur.G, KledingKleur.B));

            Ellipse circle = new Ellipse()
            {
                Width = Diameter,
                Height = Diameter,
                Stroke = brush,
                StrokeThickness = Diameter,
            };

            int yWithMargin, xWithMargin;

            yWithMargin = (y * Diameter) + ((y-1) * Diameter/2);
            xWithMargin = (x * Diameter) + ((x-1) * Diameter/2);

            Canvas.SetTop(circle, yWithMargin);
            Canvas.SetLeft(circle, xWithMargin);
            Canvas.SetZIndex(circle, 5);
           
            cv.Children.Add(circle);
        }

        private static void DrawLabel(int x, int y, string name, Canvas cv, bool outside)
        {
            int width = 25;
            if (outside)
                width *= 2;

            Label dynamicLabel = new Label
            {
                Name = $"Label_{name}",
                Content = name,
                Width = width,
                Height = 25,
                FontSize = 10,
            };

            int yWithMargin, xWithMargin, Diameter;
            Diameter = 25;
            
            yWithMargin = (y * Diameter) + ((y - 1) * Diameter / 2);
            xWithMargin = (x * Diameter) + ((x - 1) * Diameter / 2);

            if (outside)
                yWithMargin -= 25;

            Canvas.SetTop(dynamicLabel, yWithMargin);
            Canvas.SetLeft(dynamicLabel, xWithMargin);
            Canvas.SetZIndex(dynamicLabel, 10);

            cv.Children.Add(dynamicLabel);
        }

        private static void DrawLine(int x, int y, Canvas cv)
        {
            int yWithMargin, xWithMargin, yCableWithMargin, xCableWithMargin, Diameter, xCable, yCable;
            Diameter = 25;
            yCable = xCable = 6;

            yWithMargin = (y * Diameter) + ((y - 1) * Diameter / 2) + 12;
            xWithMargin = (x * Diameter) + ((x - 1) * Diameter / 2) + 12;
            yCableWithMargin = (yCable * Diameter) + ((yCable - 1) * Diameter / 2) + 12;
            xCableWithMargin = (xCable * Diameter) + ((xCable - 1) * Diameter / 2) + 12;

            // Create a Line  
            Line line = new Line
            {
                X1 = xWithMargin,
                Y1 = yWithMargin,
                X2 = xCableWithMargin,
                Y2 = yCableWithMargin
            };

            // Create a red Brush  
            SolidColorBrush redBrush = new SolidColorBrush();
            redBrush.Color = Colors.Black;

            // Set Line's width and color  
            line.StrokeThickness = 4;
            line.Stroke = redBrush;
            Canvas.SetZIndex(line, 4);

            // Add line to the Grid.  
            cv.Children.Add(line);
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            Game = new Game();
            Game.NieuweBezoeker += BezoekerHandler;
            Game.InstructieAfgelopen += InstructieHandler;
            Game.LijnenVerplaatst += LijnenVerplaatstHandler;
            
            Game.Initialize();
            // opdracht 14
            Game.NieuweBezoeker += Game.Logger.NieuwBezoeker;            
        }

        private void BezoekerHandler(NieuweBezoekerArgs args) => UpdateCanvas();

        private void InstructieHandler(InstructieAfgelopenArgs args) => UpdateCanvas();

        private void LijnenVerplaatstHandler() => UpdateCanvas();

        private void UpdateCanvas()
        {
            
            try
            {
                Application.Current.Dispatcher.Invoke(() =>
                {
                    // Counters
                    LineCounter.Content = Game.Waterskibaan.LijnenVoorraad.GetAantalLijnen();
                    PlayerCounter.Content = Game.Logger.GetTotaalBezoekers();
                    HighestScore.Content = Game.Logger.GetHoogsteScore();
                    RedCounter.Content = Game.Logger.GetAantalBezoekersMetRood();
                    LapsCounter.Content = Game.Logger.GetTotaalAantalRondjes();
                    AllMoves.Content = Game.Logger.AlleHuidigeMoves();

                    //clear
                    ClearCanvas(CanvasWachtInstructie);
                    
                    // WachtrijInstructie
                    int TempWachtrijInstrCountHorizontal = 1;
                    int TempWachtrijInstrCountVertical = 1;
                    foreach (Sporter s in Game.WachtrijInstructie.Rij)
                    {
                        if (TempWachtrijInstrCountHorizontal == 20)
                        {
                            TempWachtrijInstrCountHorizontal = 1;
                            TempWachtrijInstrCountVertical++;
                        }
                        DrawSporter(TempWachtrijInstrCountHorizontal, TempWachtrijInstrCountVertical, 10, Color.FromArgb(s.KledingKleur.A, s.KledingKleur.R, s.KledingKleur.G, s.KledingKleur.B), CanvasWachtInstructie);
                        TempWachtrijInstrCountHorizontal++;
                    }

                    // Instructie
                    ClearCanvas(CanvasInstructie);
                    int TempInstrCountHorizontal = 1;
                    foreach (Sporter s in Game.InstructieGroep.Rij)
                    {
                        DrawSporter(TempInstrCountHorizontal, 1, 15, Color.FromArgb(s.KledingKleur.A, s.KledingKleur.R, s.KledingKleur.G, s.KledingKleur.B), CanvasInstructie);
                        TempInstrCountHorizontal++;
                    }

                    // WachtStart
                    ClearCanvas(CanvasWachtStart);
                    int TempWachtrijStartCountHorizontal = 1;
                    int TempWachtrijStartCountVertical = 1;
                    foreach (Sporter s in Game.WachtrijStarten.Rij)
                    {
                        if (TempWachtrijStartCountHorizontal == 20)
                        {
                            TempWachtrijStartCountHorizontal = 1;
                            TempWachtrijStartCountVertical++;
                        }
                        DrawSporter(TempWachtrijStartCountHorizontal, TempWachtrijStartCountVertical, 10, Color.FromArgb(s.KledingKleur.A, s.KledingKleur.R, s.KledingKleur.G, s.KledingKleur.B), CanvasWachtStart);
                        TempWachtrijStartCountHorizontal++;
                    }

                    // Waterskibaan;
                    ClearCanvas(CanvasBaan);
                    int[,] locations = new int[,]
                    {
                        {2, 4},
                        {4, 4},
                        {6, 4},
                        {8, 4},
                        {10, 4},
                        {10, 8},
                        {8, 8},
                        {6, 8},
                        {4, 8},
                        {2, 8}
                    };

                    DrawSporter(6, 6, 25, Color.FromRgb(0, 0, 0), CanvasBaan);

                    int i = 0;
                    foreach (Lijn lijn in Game.Waterskibaan.Kabel.GetLijnen().ToList())
                    {
                        Sporter sp = lijn.Sporter;
                        
                        DrawSporter(locations[i, 0], locations[i, 1], 25, Color.FromArgb(sp.KledingKleur.A, sp.KledingKleur.R, sp.KledingKleur.G, sp.KledingKleur.B), CanvasBaan);
                        // Label number
                        DrawLabel(locations[i, 0], locations[i, 1], i.ToString(), CanvasBaan, false);

                        //Label action
                        if (sp.HuidigeMove != null)
                        {
                            DrawLabel(locations[i, 0], locations[i, 1], sp.HuidigeMove.ToString(), CanvasBaan, true);
                        }

                        // Line to cable
                        DrawLine(locations[i, 0], locations[i, 1], CanvasBaan);
                        i++;
                        sp = null;
                    }

                    // Lichste;
                    ClearCanvas(CanvasLichsteBezoekers);
                    int limitCount = 0;
                    foreach (var item in Game.Logger.SorteerOpLichsteKleur().Reverse())
                    {
                        //CanvasLichsteBezoekers
                        if (limitCount <= 9)
                        {
                            DrawSporter(1+limitCount, 1, 10, Color.FromArgb(item.Value.A, item.Value.R, item.Value.G, item.Value.B), CanvasLichsteBezoekers);
                            limitCount++;
                        }
                    }
                });
            }
            catch (NullReferenceException) { 
                Environment.Exit(0); 
            }
        }

        private void ClearCanvas(Canvas cv)
        {
            for (int i = cv.Children.Count - 1; i >= 0; i += -1)
            {
                UIElement Child = cv.Children[i];
                if (!(Child is Line))
                    cv.Children.Remove(Child);
            }
        }
    }
}
