using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShelfType { TOREAD, READ, FAVORITES, RECOMMENDATION, READING, DONOTREC};
[Flags] public enum Genre { 
    FICTION = (1 << 0),
    ROMANCE = (1 << 1),
    HORROR = (1 << 2),
    HISTORICAL = (1 << 3),
    ACTION = (1 << 4),
    THRILLER = (1 << 5),
    COMEDY = (1 << 6),
    CHILDREN = (1 << 7)
};

[System.Serializable]
public class Shelf : MonoBehaviour {

    public ShelfType type;
    public string shelfName;
    protected List<BookData> booksHeld = new List<BookData>();

    public GameObject shelfContainerInUI;

    // Update is called once per frame
    void Update() {
        //Perform updates based on shelf type
    }

    public virtual void AddBook(BookData book) {
        if (book == null) return;
        booksHeld.AddUnique(book);
    }

    public virtual void RemoveBook(BookData book)
    {
        if (book == null) return;
        if(booksHeld.Remove(book)) {
            Debug.Log($"Trying to remove book: {book} which is not in the shelf.");
        }
    }

    // Casting down to IEnumerable prevents other classes 
    // from freely modifying the contents of this shelf.
    public IEnumerable<BookData> GetBooks() => booksHeld;
    // If getting a list is really necessary, replace GetBooks() by this:
    //public List<BookObject> GetBooksList() => new List<BookObject>(booksHeld);
}
