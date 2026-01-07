using System.Linq;
using BCrypt.Net;

namespace Gierka.Core
{
    public class AuthService
    {
        public bool Register(string login, string password)
        {
            if (string.IsNullOrWhiteSpace(login) || login.Length < 3)
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(password) || password.Length < 6)
            {
                return false;
            }

            // Tworzymy kontekst do pracy z bazą
            using (var context = new GierkaDbContext())
            {
                // 1. Sprawdź, czy login jest już zajęty
                if (context.Users.Any(u => u.Login == login))
                {
                    // Login zajęty
                    return false;
                }
                string passwordHash = BCrypt.Net.BCrypt.HashPassword(password);
             
                // 2. Stwórz nowego użytkownika
                var newUser = new User
                {
                    Login = login,
                    PasswordHash = passwordHash
                };

                // 3. Dodaj go do bazy i zapisz zmiany
                context.Users.Add(newUser);
                context.SaveChanges();

                // 4. Inicjalizuj stan gry dla nowego użytkownika
                var initialGameState = new GameState();
                GameService.SaveGame(newUser, initialGameState, "Autosave");

                return true; // Rejestracja pomyślna
            }
        }

        public User Login(string login, string password)
        {
            if (string.IsNullOrWhiteSpace(login) || string.IsNullOrWhiteSpace(password))
            {
                return null; // Zwróć null (nieudane logowanie)
            }

            using (var context = new GierkaDbContext())
            {
                // 1. Znajdź użytkownika po loginie.
                // Używamy FirstOrDefault, żeby znaleźć pierwszego (lub null, jeśli nie ma).
                // To jest zapytanie do bazy danych: "SELECT * FROM Users WHERE Login = @login"
                var user = context.Users.FirstOrDefault(u => u.Login == login);

                if (user == null)
                {
                    return null; // Brak użytkownika
                }

                bool isValid = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);

                if (isValid)
                {
                    // Logowanie udane!
                    return user; // Zwracamy zalogowanego Usera
                }
                else
                {
                    // Hasło niepoprawne
                    return null;
                }
            }
        }
    }
}