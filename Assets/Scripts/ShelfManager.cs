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

    public BookObject currentBook; 


    public GameObject activeShelfContainer;
    public Shelf currentShelf;




    private void OnEnable()
    {
        ClearBookSlots();
        MakeBookSlots();
        Debug.Log("Shelf was loaded");
        SetDescription("", false);
    }
    public void setActive(ShelfType type)
    {
        currentShelf = null;
        foreach (Shelf shelf in AppManager.CurrentUser.Data.CustomShelves)
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


    public List<List<BookObject>> sortByGenre(ShelfType type)
    {
        Shelf currentShelf = null;
        foreach(Shelf shelf in AppManager.CurrentUser.Data.CustomShelves)
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

        IEnumerable<BookObject> currentBooks = currentShelf.GetBooks();
        List<BookObject> fiction = new List<BookObject>();
        List<BookObject> romance = new List<BookObject>();
        List<BookObject> horror = new List<BookObject>();
        List<BookObject> historical = new List<BookObject>();
        List<BookObject> action = new List<BookObject>();
        List<BookObject> thriller = new List<BookObject>();
        List<BookObject> comedy = new List<BookObject>();
        List<BookObject> children = new List<BookObject>();

        foreach(BookObject book in currentBooks)
        {
            if((book.Data.genre & Genre.FICTION) > 0)
            {
                fiction.Add(book);
            }
            if ((book.Data.genre & Genre.ROMANCE) > 0)
            {
                romance.Add(book);
            }
            if ((book.Data.genre & Genre.HORROR) > 0)
            {
                horror.Add(book);
            }
            if ((book.Data.genre & Genre.HISTORICAL) > 0)
            {
                historical.Add(book);
            }
            if ((book.Data.genre & Genre.ACTION) > 0)
            {
                action.Add(book);
            }
            if ((book.Data.genre & Genre.THRILLER) > 0)
            {
                thriller.Add(book);
            }
            if ((book.Data.genre & Genre.COMEDY) > 0)
            {
                comedy.Add(book);
            }
            if ((book.Data.genre & Genre.CHILDREN) > 0)
            {
                children.Add(book);
            }
        }


        // Add all book lists together
        List<List<BookObject>> output = new List<List<BookObject>>(7);
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


    public void BookWasSelected(string bookDescription, bool activeButton, BookObject newBook)
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
            foreach(BookObject book in currentShelf.GetBooks())
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
        if (currentBook)
        {
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

            currentBook.Data.isFavorite = !currentBook.Data.isFavorite;
        }
    }

}
