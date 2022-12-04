using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[System.Serializable]
public class UserObject : MonoBehaviour
{
    [SerializeField] UserData _data;
    public UserData Data { get => _data; }
    private Dictionary<string, int> authorScores; // The score for each author present in the user premade shelves
    private Dictionary<Genre, int> genreScores; // The score for each genre present in the user premade shelves

    // getShelf() Explores the shelves of the user to obtain the requested one
    public Shelf getShelf(ShelfType shelftype)
    {
        List<Shelf> CustomShelves = Data.CustomShelves;
        foreach (Shelf shelf in CustomShelves)
        {
            if(shelf.type == shelftype)
            {
                return shelf;
            }
        }

        return null;
    }

    // GetBookScore(): This returns a sum of the scores of the book's author and the book's genre. 0 if the book is in a shelf
    public int GetBookScore(BookData book)
    {
        string author = book.author;
        Genre genre = book.genre;
        //string author = string.Empty;
        //Genre genre = 0;

        int aScore;
        int gScore;

        Shelf toRead = getShelf(ShelfType.TOREAD);
        Shelf reading = getShelf(ShelfType.READING);
        Shelf read = getShelf(ShelfType.READ);
        Shelf favorites = getShelf(ShelfType.FAVORITES);
        //Shelf toRead = null, reading = null, read = null, favorite = null;

        // Verify if the book is already in a shelf
        if (toRead.GetBooks().Contains(book) || reading.GetBooks().Contains(book) || read.GetBooks().Contains(book) || favorites.GetBooks().Contains(book))
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
    // buildScores(): Scans the premade shelves to retrieve the score of the contained authors and genres
    public void buildScores()
    {
        this.authorScores = GetAuthorScores();
        this.genreScores = GetGenreScores();
    }
    // IncrementScore(): Increases by "increment" the score of an author/genre if it exists, sets it to "increment" if it doesn't
    private void IncrementScore(ref Dictionary<string, int> dico, string author, int increment)
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

    // ShelfAuthorScore(): Scans a premade shelf and increases the score of the authors it contains
    private void ShelfAuthorScore(ref Dictionary<string, int> scores, Shelf shelf, int increment)
    {
        IEnumerable<BookData> booksHeld = shelf.GetBooks(); // Need a method to recover the books in a shelf

        foreach (BookData book in booksHeld) {
            IncrementScore(ref scores, book.author, increment);
        }
    }

    // ShelfGenreScore(): Scans a premade shelf and increases the score of the genres it contains
    private void ShelfGenreScore(ref Dictionary<Genre, int> scores, Shelf shelf, int increment)
    { 
        IEnumerable<BookData> booksHeld = shelf.GetBooks();

        foreach (BookData book in booksHeld) {
            IncrementScore(ref scores, book.genre, increment);
        }
    }

    // GetAuthorScores(): Gets the scores for all the authors in a premade shelf
    private Dictionary<string, int> GetAuthorScores()
    {
        Shelf toRead = getShelf(ShelfType.TOREAD);
        Shelf reading = getShelf(ShelfType.READING);
        Shelf read = getShelf(ShelfType.READ);
        Shelf favorites = getShelf(ShelfType.FAVORITES);
        //Shelf toRead = null, reading = null, read = null, favorite = null;

        Dictionary<string, int> authorScores = new Dictionary<string, int>();

        ShelfAuthorScore(ref authorScores, toRead, 1); // Having a book in the toRead shelf yields 1 point
        ShelfAuthorScore(ref authorScores, reading, 1); // Having a book in the reading shelf yields 2 point
        ShelfAuthorScore(ref authorScores, read, 1); // Having a book in the read shelf yields 2 point
        ShelfAuthorScore(ref authorScores, favorites, 3); // Having a book in the favorite shelf yields 1 additional point

        return authorScores;
    }
    // GetGenreScores(): Gets the scores for all the genres in a premade shelf
    private Dictionary<Genre, int> GetGenreScores()
    {
        Shelf toRead = getShelf(ShelfType.TOREAD);
        Shelf reading = getShelf(ShelfType.READING);
        Shelf read = getShelf(ShelfType.READ);
        Shelf favorites = getShelf(ShelfType.FAVORITES);
        //Shelf toRead = null, reading = null, read = null, favorite = null;

        Dictionary<Genre, int> genreScores = new Dictionary<Genre, int>();

        ShelfGenreScore(ref genreScores, toRead, 1);
        ShelfGenreScore(ref genreScores, reading, 1);
        ShelfGenreScore(ref genreScores, read, 1);
        ShelfGenreScore(ref genreScores, favorites, 3);

        return genreScores;
    }
}
