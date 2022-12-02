using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using Shelf.Genre;

[System.Serializable]
public class UserObject : MonoBehaviour
{
    [SerializeField] UserData _data;
    public UserData Data { get => _data; }
    private Dictionary<string, int> authorScores; // The score for each author present in the user premade shelves
    private Dictionary<Genre, int> genreScores; // The score for each genre present in the user premade shelves

    public int GetBookScore(BookData book) // This returns a sum of the scores of the book's author and the book's genre
    {
        //string author = book.getAuthor(); // Need a method to recover the author of the book
        //Genre genre = book.getGenre(); // Need a method to recover the genre of the book
        string author = string.Empty;
        Genre genre = 0;

        int aScore;
        int gScore;

        // Need methods to acquire each predefined shelf in a user's data
        //Shelf toRead = Data.getToReadShelf();
        //Shelf reading = Data.getToReadShelf();
        //Shelf read = Data.getToReadShelf();
        //Shelf favorite = Data.getToReadShelf();
        Shelf toRead = null, reading = null, read = null, favorite = null;

        if (toRead.GetBooks().Contains(book) || reading.GetBooks().Contains(book) || read.GetBooks().Contains(book) || favorite.GetBooks().Contains(book)) // Verify if the book is already in a shelf
        {
            return 0;
        }
        if (authorScores.ContainsKey(author)) // If the author has no score, return it as 0 (otherwise return its score)
        {
            aScore = authorScores[author];
        }
        else
        {
            aScore = 0;
        }
        if (genreScores.ContainsKey(genre)) // If the genre has no score, return it as 0 (otherwise return its score)
        {
            gScore = genreScores[genre];
        }
        else
        {
            gScore = 0;
        }

        return aScore+gScore;
    }

    public void buildScores() // Scans the premade shelves to retrieve the score of the contained authors and genres
    {
        this.authorScores = GetAuthorScores();
        this.genreScores = GetGenreScores();
    }

    private void IncrementScore(ref Dictionary<string, int> dico, string author, int increment) // Increases by "increment" the score of an author/genre if it exists, sets it to increment if it doesn't
    {
        if (dico.ContainsKey(author))
        {
            dico[author] = dico[author] + increment;
        }
        else
        {
            dico[author] = increment;
        }
    }

    private void IncrementScore(ref Dictionary<Genre, int> dico, Genre genre, int increment)
    {
        if (dico.ContainsKey(genre))
        {
            dico[genre] = dico[genre] + increment;
        }
        else
        {
            dico[genre] = increment;
        }
    }

    private void ShelfAuthorScore(ref Dictionary<string, int> scores, Shelf shelf, int increment) // Scans a premade shelf and increase the score of the authors it contains
    {
        IEnumerable<BookData> booksHeld = shelf.GetBooks(); // Need a method to recover the books in a shelf

        foreach (BookData book in booksHeld) {
            IncrementScore(ref scores, book.author, increment);
        }
    }

    private void ShelfGenreScore(ref Dictionary<Genre, int> scores, Shelf shelf, int increment) // Scans a premade shelf and increase the score of the genres it contains
    { 
        IEnumerable<BookData> booksHeld = shelf.GetBooks();

        foreach (BookData book in booksHeld) {
            IncrementScore(ref scores, book.genre, increment);
        }
    }

    private Dictionary<string, int> GetAuthorScores() // Get the score for all the authors in a premade shelf
    {
        // Need methods to acquire each predefined shelf in a user's data
        //Shelf toRead = Data.getToReadShelf();
        //Shelf reading = Data.getToReadShelf();
        //Shelf read = Data.getToReadShelf();
        //Shelf favorite = Data.getToReadShelf();
        Shelf toRead = null, reading = null, read = null, favorite = null;

        Dictionary<string, int> authorScores = new Dictionary<string, int>();

        ShelfAuthorScore(ref authorScores, toRead, 1); // Having a book in the toRead shelf yields 1 point
        ShelfAuthorScore(ref authorScores, reading, 1); // Having a book in the reading shelf yields 2 point
        ShelfAuthorScore(ref authorScores, read, 1); // Having a book in the read shelf yields 2 point
        ShelfAuthorScore(ref authorScores, favorite, 3); // Having a book in the favorite shelf yields 1 additional point

        return authorScores;
    }

    private Dictionary<Genre, int> GetGenreScores() // Get the score for all the genres in a premade shelf
    {
        //Shelf toRead = this.getToReadShelf();
        //Shelf reading = this.getToReadShelf();
        //Shelf read = this.getToReadShelf();
        //Shelf favorite = this.getToReadShelf();
        Shelf toRead = null, reading = null, read = null, favorite = null;

        Dictionary<Genre, int> genreScores = new Dictionary<Genre, int>();

        ShelfGenreScore(ref genreScores, toRead, 1);
        ShelfGenreScore(ref genreScores, reading, 1);
        ShelfGenreScore(ref genreScores, read, 1);
        ShelfGenreScore(ref genreScores, favorite, 3);

        return genreScores;
    }
}
