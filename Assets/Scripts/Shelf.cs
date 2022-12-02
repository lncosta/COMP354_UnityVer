using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShelfType { TOREAD = 0, READ =1, FAVORITES =2, RECOMMENDATION =3, READING=4, DONOTREC =5};
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
public class Shelf {

    public ShelfType type;
    public string shelfName;
    [SerializeField] protected List<BookObject> booksHeld = new List<BookObject>();

    [SerializeField] public List<string> ids; 

    //public GameObject shelfContainerInUI;

    // Update is called once per frame
    void Update() {
        //Perform updates based on shelf type
    }

    public void AddBook(BookObject book) {

        if (book != null)
        {
            booksHeld.Add(book);
            ids.Add(book.Data.id);
        }
    
    }

    public void RemoveBook(BookObject book)
    {
        if (book != null)
        {
            booksHeld.Remove(book);
            ids.Remove(book.Data.id);
        }
        
    }

    // Casting down to IEnumerable prevents other classes 
    // from freely modifying the contents of this shelf.
    public IEnumerable<BookObject> GetBooks() => booksHeld;
    // If getting a list is really necessary, replace GetBooks() by this:
    //public List<BookObject> GetBooksList() => new List<BookObject>(booksHeld);
}
