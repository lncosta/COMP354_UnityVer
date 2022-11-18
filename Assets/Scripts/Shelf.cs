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
public class Shelf : MonoBehaviour
{

    public ShelfType type;
    public string shelfName; 
    public List<Book> booksHeld = new List<Book>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Perform updates based on shelf type
    }
}
