using Microsoft.EntityFrameworkCore; // Musimy to zaimportować!
using System;
using System.IO;
namespace Gierka.Core
{
    // Nasza klasa "dziedziczy" po DbContext.
    // Oznacza to, że przejmuje wszystkie super-moce EF Core 
    // do zarządzania bazą danych.
    public class GierkaDbContext : DbContext
    {
        // Te właściwości mówią EF Core: 
        // "Chcę mieć w bazie tabelę o nazwie 'Users', 
        // która będzie oparta na moim planie (klasie) 'User'".
        public DbSet<User> Users { get; set; }

        // "Chcę też mieć tabelę 'GameSaves' opartą na planie 'GameSave'".
        public DbSet<GameSave> GameSaves { get; set; }

        // Ta metoda konfiguruje połączenie z bazą danych.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // AppContext.BaseDirectory to ścieżka do folderu, 
            // w którym działa aplikacja (czyli .../bin/Debug/...)
            var dbPath = Path.Combine(AppContext.BaseDirectory, "gierka.db");

            // Mówimy EF, aby zawsze używał tej ścieżki
            optionsBuilder.UseSqlite($"Data Source={dbPath}");
        }
    }
}