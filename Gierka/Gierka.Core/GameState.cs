// W Gierka.Core/GameState.cs
namespace Gierka.Core
{
    public class GameState
    {
        // Punkty Wpływu - będą modyfikowane
        public int PolishZlotyPoints { get; set; } = 0;
        public int PoliticalPoints{ get; set; } = 0;
        public int MilitaryPoints { get; set; } = 0;
        public int IsraelFuntsPoints { get; set; } = 0;


        // Inne parametry stanu gry
        public int CurrentTurnYear { get; set; } = 1976;
        public string LastLocation { get; set; } = "Sejm";

        public float ResHeight{ get; set; } = 600;
        public float ResWidth{ get; set; } = 800;
    }
}