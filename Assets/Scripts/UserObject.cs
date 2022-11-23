using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Shelf.Genre;

public class UserObject : MonoBehaviour
{
    [SerializeField] UserData _data;
    public UserData Data { get => _data; }
    private Dictionary<string, int> authorScores; // The score for each author present in the user premade shelves
    private Dictionary<Genre, int> genreScores; // The score for each genre present in the user premade shelves

    public int GetBookScore(BookObject book) // This returns a sum of the scores of the book's author and the book's genre
    {
        //string author = book.getAuthor(); // Need a method to recover the author of the book
        //Genre genre = book.getGenre(); // Need a method to recover the genre of the book
        string author = string.Empty;
        Genre genre = 0;

        int aScore;
        int gScore;
        if (authorScores.ContainsKey(author))
        {
            aScore = authorScores[author];
        }
        else
        {
            aScore = 0;
        }
        if (genreScores.ContainsKey(genre))
        {
            gScore = genreScores[genre];
        }
        else
        {
            gScore = 0;
        }

        return aScore+gScore;
    }

    public void buildScores()
    {
        this.authorScores = GetAuthorScores();
        this.genreScores = GetGenreScores();
    }

    private void IncrementScore(ref Dictionary<string, int> dico, string key, int increment)
    {
        if (dico.ContainsKey(key))
        {
            dico[key] = dico[key] + increment;
        }
        else
        {
            dico[key] = increment;
        }
    }

    private void IncrementScore(ref Dictionary<Genre, int> dico, Genre key, int increment)
    {
        if (dico.ContainsKey(key))
        {
            dico[key] = dico[key] + increment;
        }
        else
        {
            dico[key] = increment;
        }
    }

    private void ShelfAuthorScore(ref Dictionary<string, int> scores, Shelf shelf, int increment) {
        IEnumerable<BookObject> booksHeld = shelf.GetBooks(); // Need a method to recover the number of books in a shelf

        foreach (BookObject book in booksHeld) {
            IncrementScore(ref scores, book.Data.author, increment);
        }
    }

    private void ShelfGenreScore(ref Dictionary<Genre, int> scores, Shelf shelf, int increment) {
        IEnumerable<BookObject> booksHeld = shelf.GetBooks();

        foreach (BookObject book in booksHeld) {
            IncrementScore(ref scores, book.Data.genre, increment);
        }
    }

    private Dictionary<string, int> GetAuthorScores()
    {
        // Need methods to acquire each predefined shelf in a user's data
        //Shelf toRead = Data.getToReadShelf();
        //Shelf reading = Data.getToReadShelf();
        //Shelf read = Data.getToReadShelf();
        //Shelf favorite = Data.getToReadShelf();
        Shelf toRead = null, reading = null, read = null, favorite = null;

        Dictionary<string, int> authorScores = new Dictionary<string, int>();

        ShelfAuthorScore(ref authorScores, toRead, 1);
        ShelfAuthorScore(ref authorScores, reading, 2);
        ShelfAuthorScore(ref authorScores, read, 2);
        ShelfAuthorScore(ref authorScores, favorite, 1);

        return authorScores;
    }

    private Dictionary<Genre, int> GetGenreScores()
    {
        //Shelf toRead = this.getToReadShelf();
        //Shelf reading = this.getToReadShelf();
        //Shelf read = this.getToReadShelf();
        //Shelf favorite = this.getToReadShelf();
        Shelf toRead = null, reading = null, read = null, favorite = null;

        Dictionary<Genre, int> genreScores = new Dictionary<Genre, int>();

        ShelfGenreScore(ref genreScores, toRead, 1);
        ShelfGenreScore(ref genreScores, reading, 2);
        ShelfGenreScore(ref genreScores, read, 2);
        ShelfGenreScore(ref genreScores, favorite, 1);

        return genreScores;
    }
}
