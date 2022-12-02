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

        foreach (BookObject b in AppManager.bookMasterList)
        {
            TMP_Dropdown.OptionData data = new TMP_Dropdown.OptionData();
            string titleAbriged = b.Data.id + " - " + b.Data.title;
            if (b.Data.title.Length > 46)
            {
                titleAbriged = b.Data.id + " - " + b.Data.title.Substring(0, 45) + "...";
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
        //TODO
    }
}
