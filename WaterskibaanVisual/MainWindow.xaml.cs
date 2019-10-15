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

        public static void DrawSporter(int x, int y, int Diameter, Color KledingKleur, Canvas cv)
        {
            Brush brush = new SolidColorBrush(Color.FromArgb(KledingKleur.A, KledingKleur.R, KledingKleur.G, KledingKleur.B));

            Ellipse circle = new Ellipse()
            {
                Width = Diameter,
                Height = Diameter,
                Stroke = brush,
                StrokeThickness = Diameter
            };

            int yWithMargin, xWithMargin;

            yWithMargin = (y * Diameter) + ((y-1) * Diameter/2);
            xWithMargin = (x * Diameter) + ((x-1) * Diameter/2);

            Canvas.SetTop(circle, yWithMargin);
            Canvas.SetLeft(circle, xWithMargin);
           
            cv.Children.Add(circle);
        }

        private void WindowLoaded(object sender, RoutedEventArgs e)
        {
            Game = new Game();
            Game.NieuweBezoeker += BezoekerHandler;
            Game.InstructieAfgelopen += InstructieHandler;
            Game.LijnenVerplaatst += LijnenVerplaatstHandler;
            Game.Initialize();
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
                    //clear
                    ClearCanvas(CanvasWachtInstructie);
                    // Added WachtrijInstructie
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

                    ClearCanvas(CanvasInstructie);
                    int TempInstrCountHorizontal = 1;
                    foreach (Sporter s in Game.InstructieGroep.Rij)
                    {
                        DrawSporter(TempInstrCountHorizontal, 1, 15, Color.FromArgb(s.KledingKleur.A, s.KledingKleur.R, s.KledingKleur.G, s.KledingKleur.B), CanvasInstructie);
                        TempInstrCountHorizontal++;
                    }

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
