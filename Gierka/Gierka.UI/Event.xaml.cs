using Gierka.Core;
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

namespace Gierka.UI
{
    public partial class Event : Window
    {
        void ExecuteCommand(string text, int amount)
        {
            if (commandMap.TryGetValue(text, out var action))
            {
                action(amount);
            }
            else
            {
                Console.WriteLine($"Unknown command: {text}");
            }
        }

        Dictionary<string, Action<int>> commandMap = new()
        {
            { "Punkt Polityczny",   amount => AddPP(amount) },
           // { "Punkt Strajku",      amount => AddPS(amount) },
           // { "Punkt Interwencji",  amount => AddPI(amount) },
            { "Punkt Militarny",    amount => AddPM(amount) },
            { "zl",                 amount => Addzl(amount) },
            { "funty izraelskie",   amount => Addfi(amount) }
        };

        private static void Addfi(int amount)
        {
            SessionContext.CurrentGameState.IsraelFuntsPoints += amount;
        }

        private static void Addzl(int amount)
        {
            SessionContext.CurrentGameState.PolishZlotyPoints += amount;
        }

        private static void AddPM(int amount)
        {
            SessionContext.CurrentGameState.MilitaryPoints += amount;
        }

        private static void AddPP(int amount)
        {
            SessionContext.CurrentGameState.PoliticalPoints += amount;
        }

        string choice1;
        string choice2;
        public Event(string message, string option1, string option2)
        {
            InitializeComponent();
            MessageText.Text = message;
            choice1 = option1;
            YesButton.Content = choice1;
            choice2 = option2;
            NoButton.Content = choice2;

        }
        private void Yes_Click(object sender, RoutedEventArgs e)
        {
            
            string phrase = choice1;
            string[] words = phrase.Split(',');

            foreach (var word in words)
            {
                string trimmed = word.Trim();
                string[] parts = trimmed.Split(' ', 2);
                string numberPart = parts[0];
                string numberToken = numberPart.Replace("+", "");
                if (!int.TryParse(numberToken, out int number))
                    continue;
                string textPart = parts.Length > 1 ? parts[1] : "";
                ExecuteCommand(textPart, number);
                
            }
            Close();
        }

        private void No_Click(object sender, RoutedEventArgs e)
        {
            string phrase = choice2;
            string[] words = phrase.Split(',');

            foreach (var word in words)
            {
                string trimmed = word.Trim();
                string[] parts = trimmed.Split(' ', 2);
                string numberPart = parts[0];
                string numberToken = numberPart.Replace("+", "");
                if (!int.TryParse(numberToken, out int number))
                    continue;
                string textPart = parts.Length > 1 ? parts[1] : "";
                ExecuteCommand(textPart, number);

            }
            Close();
        }
    }
}