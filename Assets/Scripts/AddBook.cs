using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Text.RegularExpressions;

public class AddBook : MonoBehaviour
{
    public bool visible = false;
    public GameObject addButtonPanel;

    public TMP_Dropdown bookDrop;
    public TMP_Dropdown shelfDrop;
    
    public BookData bookDataSample;

    private string shelfName;


    public TextMeshProUGUI shelfNameUI;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonClick()
    {
        visible = !visible;

        addButtonPanel.SetActive(visible);

        if (visible)
        {
            shelfName = shelfNameUI.text;
            shelfNameUI.text = "Pick a book and shelf:";
        }
        else
        {
            shelfNameUI.text = shelfName; //Reset name of shelf; 
        }


        populateDrops();

        /*BookObject sample = new BookObject();
        sample.Data = bookDataSample;

        foreach(Shelf s in AppManager.CurrentUser.Data.CustomShelves)
        {
            s.AddBook(sample);
        }*/

    }

    public void populateDrops()
    {
        bookDrop.options.Clear();
        shelfDrop.options.Clear(); 

        foreach (BookObject b in AppManager.bookMasterList)
        {
            TMP_Dropdown.OptionData data = new TMP_Dropdown.OptionData();
            string titleAbriged = b.Data.id + "- " + b.Data.title;
            if (b.Data.title.Length > 46)
            {
                titleAbriged = b.Data.id + "- " + b.Data.title.Substring(0, 45) + "...";
            }
           
            data.text = titleAbriged;
            
            bookDrop.options.Add(data);
        }

        foreach (Shelf b in AppManager.CurrentUser.Data.CustomShelves)
        {
            TMP_Dropdown.OptionData data = new TMP_Dropdown.OptionData();
            data.text = b.type.ToString();
            shelfDrop.options.Add(data);
        }
    }

    public void addBookToShelf()
    {
       

        string valueBook = bookDrop.options[bookDrop.value].text;
        string idBook = valueBook.Split("-")[0];
        string valueShelf = shelfDrop.options[shelfDrop.value].text;

        Debug.Log(valueShelf + "->" + valueBook);

        //Find shelf

        Shelf addHere = null;
        BookObject toAdd = null;

        foreach (BookObject b in AppManager.bookMasterList)
        {
            if (idBook.Equals(b.Data.id))
            {
                toAdd = b;
            }
        }
        foreach (Shelf s in AppManager.CurrentUser.Data.CustomShelves)
        {
            if (s.type.ToString().Equals(valueShelf))
            {
                addHere = s;
            }
           
        }

        

        if(toAdd != null && addHere != null)
        {
            foreach (Shelf s in AppManager.CurrentUser.Data.CustomShelves)
            {
                if (toAdd != null && s.booksHeld.Contains(toAdd) && s.type != ShelfType.FAVORITES)
                {
                    s.RemoveBook(toAdd); //Remove any duplicates
                }
            }

            addHere.AddBook(toAdd);
            shelfNameUI.text = "Book was added to shelf!";
            AppManager.refresh = true; 
        }
    }
}
