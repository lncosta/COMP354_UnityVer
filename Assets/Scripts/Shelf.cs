using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum ShelfType { TOREAD, READ, FAVORITES, RECOMMENDATION, READING};
public enum Genre { ROMANCE, HORROR, HISTORICAL, ACTION, THRILLER, FICTION, COMEDY, CHILDREN };
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
