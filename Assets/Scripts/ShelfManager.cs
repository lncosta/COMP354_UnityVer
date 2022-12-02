using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShelfManager : MonoBehaviour
{
   
   
    public GameObject blankBookSlot;
    public GameObject shelfPanel;
    public TextMeshProUGUI bookDescriptionText;
    public GameObject FavoriteButton;

    public BookData currentBook; 


    public GameObject activeShelfContainer;
    public Shelf currentShelf;




    private void OnEnable()
    {
        ClearBookSlots();
        MakeBookSlots();
        Debug.Log("Shelf was loaded");
        SetDescription("", false);
    }
    public void SetActive(ShelfType type)
    {
        currentShelf = null; 
        foreach (Shelf shelf in AppManager.shelves)
        { //Set Shelf Visibility for Current User
            if (shelf.type == type)
            {
                shelf.shelfContainerInUI.SetActive(true);
                activeShelfContainer = shelf.shelfContainerInUI;
                currentShelf = shelf;
            }
            else
            {
                shelf.shelfContainerInUI.SetActive(false);
            }
        }
    }


    public List<List<BookData>> sortByGenre(ShelfType type)
    {
        Shelf currentShelf = null;
        foreach(Shelf shelf in AppManager.shelves)
        {
            if(shelf.type == type)
            {
                currentShelf = shelf;
            }
        }
        if(currentShelf == null)
        {
            return null;
        }

        IEnumerable<BookData> currentBooks = currentShelf.GetBooks();
        List<BookData> fiction = new List<BookData>();
        List<BookData> romance = new List<BookData>();
        List<BookData> horror = new List<BookData>();
        List<BookData> historical = new List<BookData>();
        List<BookData> action = new List<BookData>();
        List<BookData> thriller = new List<BookData>();
        List<BookData> comedy = new List<BookData>();
        List<BookData> children = new List<BookData>();

        foreach(BookData book in currentBooks)
        {
            if((book.genre & Genre.FICTION) > 0)
            {
                fiction.Add(book);
            }
            if ((book.genre & Genre.ROMANCE) > 0)
            {
                romance.Add(book);
            }
            if ((book.genre & Genre.HORROR) > 0)
            {
                horror.Add(book);
            }
            if ((book.genre & Genre.HISTORICAL) > 0)
            {
                historical.Add(book);
            }
            if ((book.genre & Genre.ACTION) > 0)
            {
                action.Add(book);
            }
            if ((book.genre & Genre.THRILLER) > 0)
            {
                thriller.Add(book);
            }
            if ((book.genre & Genre.COMEDY) > 0)
            {
                comedy.Add(book);
            }
            if ((book.genre & Genre.CHILDREN) > 0)
            {
                children.Add(book);
            }
        }


        // Add all book lists together
        List<List<BookData>> output = new List<List<BookData>>(7);
        output.Add(romance);
        output.Add(fiction);
        output.Add(horror);
        output.Add(historical);
        output.Add(action);
        output.Add(thriller);
        output.Add(comedy);
        output.Add(children);
        return output;
    }


    public void BookWasSelected(string bookDescription, bool activeButton, BookData newBook)
    {
        currentBook = newBook;
        bookDescriptionText.text = bookDescription;
        FavoriteButton.GetComponent<FavoriteButton>().Click(activeButton);
    }


    void ClearBookSlots()
    {
        for (int i = 0; i < shelfPanel.transform.childCount; i++)
        {
            Destroy(shelfPanel.transform.GetChild(i).gameObject);
        }
    }

    public void SetDescription(string description, bool favoriteButtonActive)
    {
        bookDescriptionText.text = description;
        FavoriteButton.GetComponent<FavoriteButton>().Click(favoriteButtonActive);
    }

    void MakeBookSlots()
    {
        if (currentShelf)
        {
            foreach(BookData book in currentShelf.GetBooks())
            {
                GameObject temp = Instantiate(blankBookSlot, shelfPanel.transform.position, Quaternion.identity);
                temp.transform.SetParent(shelfPanel.transform);

                ShelfSlot newSlot = temp.GetComponent<ShelfSlot>();

                if (newSlot)
                {
                    newSlot.Create(book, this);
                }

            }
        }

    }


    public void PressFavoriteButton()
    {
        if (currentBook == null) { return; }

        bool currentFavoriteStatus = currentBook.FavoriteButtonClicked();

        Shelf favoriteShelf = GameObject.FindGameObjectsWithTag("FavoriteShelf")[0].GetComponent<Shelf>();

        if (currentFavoriteStatus)
        {
            favoriteShelf.AddBook(currentBook); 
        }
        else
        {
            favoriteShelf.RemoveBook(currentBook); 
        }

        currentBook.isFavorite = !currentBook.isFavorite;
    }
}
