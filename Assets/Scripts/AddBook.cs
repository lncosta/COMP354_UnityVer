using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AddBook : MonoBehaviour
{
    public bool visible = false;
    public GameObject addButtonPanel;

    public TMP_Dropdown bookDrop;
    public TMP_Dropdown shelfDrop;
    
    public BookData bookDataSample;


    // Start is called before the first frame update
    void Start()
    {
        //populateDrops(); //Needs static values to be set, else throws exception
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ButtonClick()
    {
        visible = !visible;

        addButtonPanel.SetActive(visible);

        BookObject sample = new BookObject();
        sample.Data = bookDataSample;

        foreach(Shelf s in AppManager.CurrentUser.Data.CustomShelves)
        {
            s.AddBook(sample);
        }

    }

    public void populateDrops()
    {
        bookDrop.options.Clear();

        foreach (BookObject b in AppManager.bookMasterList)
        {
            TMP_Dropdown.OptionData data = new TMP_Dropdown.OptionData();
            data.text = b.Data.title;
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
        //TODO
    }
}
