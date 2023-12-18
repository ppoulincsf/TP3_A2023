using Xunit;
using TP3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP3.Tests
{
  public class LibraryTests
  {
  /*
    private List<Game> CreateGameList ( int nbGames )
    {
      List<Game> gameList = new List<Game> ();
      List<Publisher> allPublishers = new List<Publisher> ();

      for (int j = 0; j < 5; j++)
      {
        Publisher newPublisher = new Publisher ();
        newPublisher.Name = "Publisher " + j;
        newPublisher.Country = "Country " + j;
        allPublishers.Add (newPublisher);
      }

      for (int i = 0; i < nbGames; i++)
      {
        Game game = new Game ();
        game.Title = $"{Program.COLUMN_HEADERS[Program.COLUMN_TITLE]} {i}";
        game.Year = 2000 + i;
        game.GameCategory = (int)(i % Program.ALL_CATEGORIES.Length);
        game.Rating = i % 10;
        game.GamePublisher = i % allPublishers.Count;
        gameList.Add (game);
      }
      return gameList;
    }
    [Fact ()]
    public void InsertGame_EmptyList_ListWithOneElement ()
    {
      const string ANY_TITLE = "Any Title";
      const int ANY_YEAR = 1999;
      const int ANY_CATEGORY = Program.MOBA;
      const int ANY_RATING = 7;
      const int DEFAULT_NB_GAMES = 0;
      const int ANY_PUBLISHER = 2;

      List<Game> allGames = new List<Game> ();

      Game gameInfo = new Game ();
      gameInfo.Title = ANY_TITLE;
      gameInfo.Year = ANY_YEAR;
      gameInfo.GameCategory = ANY_CATEGORY;
      gameInfo.Rating = ANY_RATING;
      gameInfo.GamePublisher = ANY_PUBLISHER;

      Library.InsertGame (allGames, gameInfo);

      Assert.Single (allGames);
      Assert.Equal (ANY_TITLE, allGames[DEFAULT_NB_GAMES].Title);
      Assert.Equal (ANY_YEAR, allGames[DEFAULT_NB_GAMES].Year);
      Assert.Equal (ANY_CATEGORY, allGames[DEFAULT_NB_GAMES].GameCategory);
      Assert.Equal (ANY_RATING, allGames[DEFAULT_NB_GAMES].Rating);
      Assert.Equal (ANY_PUBLISHER, allGames[DEFAULT_NB_GAMES].GamePublisher);
    }
    [Fact ()]
    public void InsertGame_NullGame_Exception ()
    {
      List<Game> allGames = new List<Game> ();
      Assert.Throws<System.ArgumentException> (() => Library.InsertGame (allGames, null));
    }
    [Fact ()]
    public void InsertGame_NotEmptyList_ListWithOneMoreElement ()
    {
      const string ANY_TITLE = "Any Title";
      const int ANY_YEAR = 1999;
      const int ANY_CATEGORY = Program.MOBA;
      const int ANY_RATING = 7;
      const int DEFAULT_NB_GAMES = 12;
      const int ANY_PUBLISHER = 2;

      List<Game> allGames = CreateGameList (DEFAULT_NB_GAMES);


      Game gameInfo = new Game ();
      gameInfo.Title = ANY_TITLE;
      gameInfo.Year = ANY_YEAR;
      gameInfo.GameCategory = ANY_CATEGORY;
      gameInfo.Rating = ANY_RATING;
      gameInfo.GamePublisher = ANY_PUBLISHER;

      Library.InsertGame (allGames, gameInfo);

      Assert.Equal (DEFAULT_NB_GAMES + 1, allGames.Count);
      Assert.Equal (ANY_TITLE, allGames[DEFAULT_NB_GAMES].Title);
      Assert.Equal (ANY_YEAR, allGames[DEFAULT_NB_GAMES].Year);
      Assert.Equal (ANY_CATEGORY, allGames[DEFAULT_NB_GAMES].GameCategory);
      Assert.Equal (ANY_RATING, allGames[DEFAULT_NB_GAMES].Rating);
      Assert.Equal (ANY_PUBLISHER, allGames[DEFAULT_NB_GAMES].GamePublisher);
    }
    [Fact ()]
    public void RemoveGame_GameNumBiggerThanListSize_Exception ()
    {
      const int DEFAULT_NB_GAMES = 12;
      List<Game> allGames = CreateGameList (DEFAULT_NB_GAMES);
      Assert.Throws<ArgumentException> (() => { Library.RemoveGame (allGames, DEFAULT_NB_GAMES + 1); });
    }
    [Fact ()]
    public void RemoveGame_NegativeGameNum_Exception ()
    {
      const int DEFAULT_NB_GAMES = 12;
      List<Game> allGames = CreateGameList (DEFAULT_NB_GAMES);
      Assert.Throws<ArgumentException> (() => { Library.RemoveGame (allGames, -1); });
    }
    [Fact ()]
    public void RemoveGame_NotEmptyListAndValidGameNum_ListWithOneLessElement ()
    {

      const int DEFAULT_NB_GAMES = 12;
      const int ANY_VALID_GAME_NUM = DEFAULT_NB_GAMES / 2;

      List<Game> allGames = CreateGameList (DEFAULT_NB_GAMES);

      Library.RemoveGame (allGames, ANY_VALID_GAME_NUM);

      Assert.Equal (DEFAULT_NB_GAMES - 1, allGames.Count);
    }
    [Fact ()]
    public void UpdateGame_GameNumBiggerThanListSize_Exception ()
    {
      const int DEFAULT_NB_GAMES = 12;

      List<Game> allGames = CreateGameList (DEFAULT_NB_GAMES);
      Assert.Throws<ArgumentException> (() => { Library.UpdateGame (allGames, DEFAULT_NB_GAMES + 1, new Game ()); });
    }
    [Fact ()]
    public void UpdateMovie_NegativeMovieNum_Exception ()
    {
      const int DEFAULT_NB_GAMES = 12;

      List<Game> allGames = CreateGameList (DEFAULT_NB_GAMES);
      Assert.Throws<ArgumentException> (() => { Library.UpdateGame (allGames, -1, new Game ()); });
    }
    [Fact ()]
    public void UpdateMovie_NotEmptyListAndValidMovieNum_ListWithMovieUpdated ()
    {

      const int DEFAULT_NB_GAMES = 12;
      const int ANY_VALID_GAME_NUM = DEFAULT_NB_GAMES / 2;
      const string ANY_TITLE = "Any Title";
      const int ANY_YEAR = 1999;
      const int ANY_CATEGORY = Program.MOBA;
      const int ANY_RATING = 7;
      const int ANY_PUBLISHER = 2;

      List<Game> allGames = CreateGameList (DEFAULT_NB_GAMES);


      Game gameInfo = new Game ();
      gameInfo.Title = ANY_TITLE;
      gameInfo.Year = ANY_YEAR;
      gameInfo.GameCategory = ANY_CATEGORY;
      gameInfo.Rating = ANY_RATING;
      gameInfo.GamePublisher = ANY_PUBLISHER;

      Library.UpdateGame (allGames, ANY_VALID_GAME_NUM, gameInfo);

      Assert.Equal (DEFAULT_NB_GAMES, allGames.Count);
      Assert.Equal (gameInfo.Title, allGames[ANY_VALID_GAME_NUM].Title);
      Assert.Equal (gameInfo.Year, allGames[ANY_VALID_GAME_NUM].Year);
      Assert.Equal (gameInfo.Rating, allGames[ANY_VALID_GAME_NUM].Rating);
      Assert.Equal (gameInfo.GameCategory, allGames[ANY_VALID_GAME_NUM].GameCategory);
      Assert.Equal (gameInfo.GamePublisher, allGames[ANY_VALID_GAME_NUM].GamePublisher);
    }
    [Fact ()]
    public void UpdateGame_NullGame_Exception ()
    {
      const int DEFAULT_NB_GAMES = 12;
      const int ANY_VALID_GAME_NUM = DEFAULT_NB_GAMES / 2;

      List<Game> allGames = CreateGameList (DEFAULT_NB_GAMES);
      Assert.Throws<ArgumentException> (() => { Library.UpdateGame (allGames, ANY_VALID_GAME_NUM, null); });
    }
    */
  }
}
