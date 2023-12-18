using System.Text;

namespace TP3
{
  public class Program
  {
    // Sources des données
    public const string PUBLISHERS_FILE = "publishers.csv";
    public const string GAMES_FILE = "games.csv";
    public const char ACTOR_SEPARATION_TOKEN = ';';

    // Identification des colonnes 
    public const int COLUMN_TITLE = 0;
    public const int COLUMN_YEAR = 1;
    public const int COLUMN_CATEGORY = 2;
    public const int COLUMN_RATING = 3;
    public const int COLUMN_PUBLISHER = 4;
    public const int COLUMN_COUNT = COLUMN_PUBLISHER + 1;

    // Choix de menu
    public const int QUIT = 0;
    public const int READ_GAME = 1;
    public const int MODIFY_GAME = 2;
    public const int DELETE_GAME = 3;
    public const int LIST_GAMES = 4;
    public const int ADD_PUBLISHER = 5;

    // Types de jeux
    public const int RTS = 0;
    public const int SHOOTER = 1;
    public const int MOBA = 2;
    public const int RPG = 4;
    public const int SANDBOX = 5;
    public static int[] ALL_CATEGORIES = { RTS, SHOOTER, MOBA, RPG, SANDBOX};
    public static string[] ALL_CATEGORIES_NAMES = { "RTS", "SHOOTER", "MOBA", "RPG","SANDBOX" };

   
    public static void Main ( string[] args )
    {
      // Lecture des données de l'application      
      // A décommenter lorsque les structures Game et Publisher auront été codées
      // List<Publisher> allPublishers = ReadPublishersFromFile (PUBLISHERS_FILE);
      // List<Game> allGames = ReadGamesFromFile (GAMES_FILE);



      // A compléter avec le menu 


      // Écriture des données de l'application      
      // A décommenter lorsque les structures Game et Publisher auront été codées
      // WriteGamesToFile (allGames, GAMES_FILE);
      // WritePublishersToFile (allPublishers, PUBLISHERS_FILE);
    }




    
    // A décommenter lorsque les structures Game et Publisher auront été codées
    /*
    private static void WritePublishersToFile ( List<Publisher> allPublishers, string fileName )
    {
      string[] allLines = new string[allPublishers.Count];

      for (int i = 0; i < allPublishers.Count; i++)
      {
        StringBuilder stringBuilder = new StringBuilder ();
        stringBuilder.Append (allPublishers[i].Name);
        stringBuilder.Append ("," + Convert.ToString (allPublishers[i].Country));
        allLines[i] = stringBuilder.ToString ();
      }
      WriteFile (fileName, allLines);
    }
    private static void WriteGamesToFile ( List<Game> allGames, string fileName )
    {
      string[] allLines = new string[allGames.Count];

      for (int i = 0; i < allGames.Count; i++)
      {
        StringBuilder stringBuilder = new StringBuilder ();
        stringBuilder.Append (allGames[i].Title);
        stringBuilder.Append ("," + Convert.ToString (allGames[i].Year));
        stringBuilder.Append ("," + Convert.ToString ((int)allGames[i].GameCategory));
        stringBuilder.Append ("," + Convert.ToString (allGames[i].Rating));
        stringBuilder.Append ("," + Convert.ToString (allGames[i].GamePublisher));
        allLines[i] = stringBuilder.ToString ();
      }
      WriteFile (fileName, allLines);
    }

    private static List<Publisher> ReadPublishersFromFile ( string filename )
    {
      List<Publisher> publishers = new List<Publisher> ();
      string[] allLines = ReadFile (filename);
      for (int i = 0; i < allLines.Length; i++)
      {
        if (!String.IsNullOrEmpty (allLines[i]))
        {
          string[] currentLine = allLines[i].Split (",", StringSplitOptions.RemoveEmptyEntries);
          Publisher newPublisher = new Publisher ();
          newPublisher.Name = currentLine[0];
          newPublisher.Country = currentLine[1];

          publishers.Add (newPublisher);
        }
      }
      return publishers;
    }

    private static List<Game> ReadGamesFromFile ( string fileName )
    {
      List<Game> allGames = new List<Game> ();
      string[] allLines = ReadFile (fileName);
      for (int i = 0; i < allLines.Length && !String.IsNullOrEmpty (allLines[i]); i++)
      {
        string[] currentLine = allLines[i].Split (",", StringSplitOptions.RemoveEmptyEntries);
        Game newGame = new Game ();
        newGame.Title = currentLine[COLUMN_TITLE];
        newGame.Year = int.Parse (currentLine[COLUMN_YEAR]);
        newGame.Rating = int.Parse (currentLine[COLUMN_RATING]);
        newGame.GameCategory = int.Parse(currentLine[COLUMN_CATEGORY]);
        newGame.GamePublisher = int.Parse (currentLine[COLUMN_PUBLISHER]);
        allGames.Add (newGame);
      }
      return allGames;
    }
    */
    /// <summary>
    /// Lit un fichier texte et stocke une ligne par cellule de tableau.
    /// </summary>
    /// <param name="fileName">Nom du fichier à lire. Il doit être situé
    /// dans le dossier bin/Debug/net6.0</param>
    /// <param name="nbLinesMax">Nombres de lignes maximum qui pourront être lues dans le fichier</param>
    /// <returns>Un tableau des lignes lues</returns>
    public static string[] ReadFile ( string fileName )
    {
      StreamReader reader = new StreamReader (fileName, System.Text.Encoding.UTF8);
      List<string> allLines = new List<string> ();

      while (!reader.EndOfStream)
      {
#pragma warning disable CS8600 // Conversion de littéral ayant une valeur null ou d'une éventuelle valeur null en type non-nullable.
        string line = reader.ReadLine ();
#pragma warning restore CS8600 // Conversion de littéral ayant une valeur null ou d'une éventuelle valeur null en type non-nullable.
        allLines.Add (line);
      }

      reader.Close ();

      return allLines.ToArray ();
    }

    /// <summary>
    /// Écrit un fichier texte à partir d'un tableau de lignes.
    /// </summary>
    /// <param name="fileName">Nom du fichier à écrire. Il sera situé
    /// dans le dossier bin/Debug/net5.0</param>
    /// <param name="linesToWrite">Tableau contenant les lignes à écrire</param>
    public static void WriteFile ( string fileName, string[] linesToWrite )
    {
      StreamWriter writer = new StreamWriter (fileName, false, System.Text.Encoding.UTF8);

      for (int i = 0; i < linesToWrite.Length; i++)
      {
        writer.WriteLine (linesToWrite[i]);
      }

      writer.Close ();
    }
    

  }
}