using Gierka.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
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

namespace Gierka.UI
{
    /// <summary>
    /// Logika interakcji dla klasy Gra.xaml
    /// </summary>
    
    public partial class Gra : UserControl
    {

        //int PuPo, PuMi, Zlotowki, Funty = 0;



        // private MediaPlayer player = new MediaPlayer();

        public Gra()
        {
            InitializeComponent();
            Wyswietleniepolitycznych.Text = SessionContext.CurrentGameState.PoliticalPoints.ToString();
            Wyswietleniemilitarnych.Text = SessionContext.CurrentGameState.MilitaryPoints.ToString();
            Wyswietleniezlotowek.Text = SessionContext.CurrentGameState.PolishZlotyPoints.ToString();
            WyswietlenieFuntow.Text = SessionContext.CurrentGameState.IsraelFuntsPoints.ToString();

           // string path = System.IO.Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Music", "LInternationale (Instrumental Version).mp3");

            string MuzykaStart = "Music/LInternationale (Instrumental Version).mp3";
            MediaManager.Load(MuzykaStart);
            MediaManager.Play();

            // Ustaw głośność (0.0 - 1.0)
            
            //player.Volume = 0.3;

        }   
        private void DodajPP(object sender, RoutedEventArgs e)
        {

            SessionContext.CurrentGameState.PoliticalPoints += 10;
            Wyswietleniepolitycznych.Text = SessionContext.CurrentGameState.PoliticalPoints.ToString();
           
        }

        private void DodajPM(object sender, RoutedEventArgs e)
        {
            SessionContext.CurrentGameState.MilitaryPoints += 10;
            Wyswietleniemilitarnych.Text = SessionContext.CurrentGameState.MilitaryPoints.ToString();
        }

        private void DodajPieniadze(object sender, RoutedEventArgs e)
        {
            SessionContext.CurrentGameState.PolishZlotyPoints += 10;
            Wyswietleniezlotowek.Text = SessionContext.CurrentGameState.PolishZlotyPoints.ToString();
        }

        private void DodajFuntyIzraelskie(object sender, RoutedEventArgs e)
        {
            SessionContext.CurrentGameState.IsraelFuntsPoints += 10;
            WyswietlenieFuntow.Text = SessionContext.CurrentGameState.IsraelFuntsPoints.ToString();
        }

        private void Gdansk(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null)
            {



                mainWindow.NavigateTo(new Gdansk());

            }
        }

        private void Sejm(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null)
            {



                mainWindow.NavigateTo(new Sejm());

            }
        }
        private void Mon(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;
            if (mainWindow != null)
            {



                mainWindow.NavigateTo(new Mon());

            }
        }

        private void JednorekiGierek(object sender, RoutedEventArgs e) {
            JednorekiGierek automat = new JednorekiGierek();
            MainWindow mainWindow = Window.GetWindow(this) as MainWindow;

            if (mainWindow != null)
            {

                mainWindow.NavigateTo(new JednorekiGierek());

            }
        }

        public void AktualizujZasoby()
        {
            // Używamy tego samego kodu, co w konstruktorze, aby odświeżyć wyświetlane liczniki
            Wyswietleniepolitycznych.Text = SessionContext.CurrentGameState.PoliticalPoints.ToString();
            Wyswietleniemilitarnych.Text = SessionContext.CurrentGameState.MilitaryPoints.ToString();
            Wyswietleniezlotowek.Text = SessionContext.CurrentGameState.PolishZlotyPoints.ToString();
            WyswietlenieFuntow.Text = SessionContext.CurrentGameState.IsraelFuntsPoints.ToString();
        }

    }
}
