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

    public GameObject[] shelfContainerInUI;


    public TextMeshProUGUI shelfName;


    public TMP_Dropdown moveToShelf;


    public TextMeshProUGUI userName;




    private void OnEnable()
    {
        ClearBookSlots();
        MakeBookSlots();
        Debug.Log("Shelf was loaded");
        SetDescription("", false);

        AppManager.LoadBooks();
        populateDrops();

        userName.text = "User: " + AppManager.CurrentUser.Data.UserName; 


    }
    public void setActive(int type)
    {
        currentShelf = null;
        foreach (Shelf shelf in AppManager.CurrentUser.Data.CustomShelves)
        { //Set Shelf Visibility for Current User

            if ((int)shelf.type == type)
            {
                currentShelf = shelf;
                shelfName.text = shelf.type.ToString();
                ClearBookSlots();
                MakeBookSlots();
            }


        }
    }

    public void Refresh()
    {
        ClearBookSlots();
        MakeBookSlots();
    }

    
    

    public List<List<BookObject>> sortByGenre(ShelfType type)
    {
        Shelf currentShelf = null;
        foreach (Shelf shelf in AppManager.CurrentUser.Data.CustomShelves)
        {
            if (shelf.type == type)
            {
                currentShelf = shelf;
            }
        }
        if (currentShelf == null)
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

        foreach (BookObject book in currentBooks)
        {
            if ((book.Data.genre & Genre.FICTION) > 0)
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
        UpdateFaveButton();
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
        if (currentShelf != null)
        {
            foreach (BookObject book in currentShelf.GetBooks())
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
        if (currentBook != null)
        {


            Shelf favoriteShelf = null;

            foreach (Shelf s in AppManager.CurrentUser.Data.CustomShelves)
            {
                if (s.type == ShelfType.FAVORITES)
                {
                    favoriteShelf = s;
                }
            }

            if (favoriteShelf == null)
            {
                return;
            }

            bool currentFavoriteStatus = favoriteShelf.CheckIfContains(currentBook);

            if (!currentFavoriteStatus)
            {
                currentShelf.RemoveBook(currentBook);
                favoriteShelf.AddBook(currentBook);
               
                FavoriteButton.GetComponent<FavoriteButton>().Click(true);
            }
            else
            {
                favoriteShelf.RemoveBook(currentBook);
                FavoriteButton.GetComponent<FavoriteButton>().Click(false);
            }

            //currentBook.Data.isFavorite = !currentBook.Data.isFavorite;


        }
    }

    public void UpdateFaveButton()
    {
        if (currentBook != null)
        {


            Shelf favoriteShelf = null;

            foreach (Shelf s in AppManager.CurrentUser.Data.CustomShelves)
            {
                if (s.type == ShelfType.FAVORITES)
                {
                    favoriteShelf = s;
                }
            }

            if (favoriteShelf == null)
            {
                return;
            }

            bool currentFavoriteStatus = favoriteShelf.CheckIfContains(currentBook);

            if (!currentFavoriteStatus)
            {

                FavoriteButton.GetComponent<FavoriteButton>().Click(false);
            }
            else
            {

                FavoriteButton.GetComponent<FavoriteButton>().Click(true);
            }

        }

    }

    public void populateDrops()
    {
       
        moveToShelf.options.Clear();

        foreach (Shelf b in AppManager.CurrentUser.Data.CustomShelves)
        {
            TMP_Dropdown.OptionData data = new TMP_Dropdown.OptionData();
            data.text = b.type.ToString();
           moveToShelf.options.Add(data);
        }
        TMP_Dropdown.OptionData data2 = new TMP_Dropdown.OptionData();
        data2.text = "REMOVE";
        moveToShelf.options.Add(data2); 
    }

    public void MoveCurrentBook()
    {


        string valueShelf = moveToShelf.options[moveToShelf.value].text;


        //Find shelf

        Shelf addHere = null;



        foreach (Shelf s in AppManager.CurrentUser.Data.CustomShelves)
        {
            if (s.type.ToString().Equals(valueShelf))
            {
                addHere = s;
            }

        }



        if (currentBook != null && addHere != null)
        {


            addHere.AddBook(currentBook);
            if (currentShelf.type != ShelfType.FAVORITES)
            {
                currentShelf.RemoveBook(currentBook);
            }


        }
        else if (addHere == null && valueShelf.Equals("REMOVE"))
        {
            currentShelf.RemoveBook(currentBook);
        }

    }
}
