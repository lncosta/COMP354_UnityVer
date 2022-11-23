using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShelfSlot : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField] private TextMeshProUGUI bookName;
    [SerializeField] private Image bookCover;

    public Sprite bookSprite;
    public Genre bookGenre;
    public string bookSummary;
    public string author;
    public float rating;

    public bool isFavorite = false;
    public bool isRecommended = false;
    public bool canBeRecommended = true;

    public BookObject thisBook;
    public ShelfManager thisShelfManager;



    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Create(BookObject book, ShelfManager newManager)
    {
        thisBook = book;
        thisShelfManager = newManager;

        if (thisBook)
        {
            bookCover.sprite = thisBook.Data.bookCover;

        }

    }

    public void ClickAction()
    {
        if (thisBook)
        {
            thisShelfManager.BookWasSelected(thisBook.Data.title + "\n" + thisBook.Data.author + "\n"  + thisBook.Data.genre.ToString(),thisBook.Data.isFavorite, thisBook); 
        }
    }
}
