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

    public int getBookScore(BookObject book) // This returns a sum of the scores of the book's author and the book's genre
    {
        string author = book.getAuthor(); // Need a method to recover the author of the book
        Genre genre = book.getGenre(); // Need a method to recover the genre of the book

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
        this.authorScores = getAuthorScores();
        this.genreScores = getGenreScores();
    }

    private void incrementScore(ref Dictionary<string, int> dico, string key, int increment)
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

    private void incrementScore(ref Dictionary<Genre, int> dico, Genre key, int increment)
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

    private void shelfAuthorScore(ref Dictionary<string, int> scores, Shelf shelf, int increment)
    {
        BookObject book;
        string bookAuthor;
        List<BookObject> booksHeld = shelf.getBooks(); // Need a method to recover the number of books in a shelf

        for (int i = 0; i < booksHeld.Count; i++) 
        {
            book = booksHeld[i];
            bookAuthor = book.getAuthor();
            incrementScore(ref scores, bookAuthor, increment);
        }
    }

    private void shelfGenreScore(ref Dictionary<Genre, int> scores, Shelf shelf, int increment)
    {
        BookObject book;
        Genre bookGenre;
        List<BookObject> booksHeld = shelf.getBooks();

        for (int i = 0; i < booksHeld.Count; i++)
        {
            book = booksHeld[i];
            bookGenre = book.getGenre();
            incrementScore(ref scores, bookGenre, increment);
        }
    }

    private Dictionary<string, int> getAuthorScores()
    {
        // Need methods to acquire each predefined shelf in a user's data
        Shelf toRead = Data.getToReadShelf();
        Shelf reading = Data.getToReadShelf();
        Shelf read = Data.getToReadShelf();
        Shelf favorite = Data.getToReadShelf();

        Dictionary<string, int> authorScores = new Dictionary<string, int>();

        shelfAuthorScore(ref authorScores, toRead, 1);
        shelfAuthorScore(ref authorScores, reading, 2);
        shelfAuthorScore(ref authorScores, read, 2);
        shelfAuthorScore(ref authorScores, favorite, 1);

        return authorScores;
    }

    private Dictionary<Genre, int> getGenreScores()
    {
        Shelf toRead = this.getToReadShelf();
        Shelf reading = this.getToReadShelf();
        Shelf read = this.getToReadShelf();
        Shelf favorite = this.getToReadShelf();

        Dictionary<Genre, int> genreScores = new Dictionary<Genre, int>();

        shelfGenreScore(ref genreScores, toRead, 1);
        shelfGenreScore(ref genreScores, reading, 2);
        shelfGenreScore(ref genreScores, read, 2);
        shelfGenreScore(ref genreScores, favorite, 1);

        return genreScores;
    }
}
