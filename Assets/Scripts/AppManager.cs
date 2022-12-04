using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor; 

public class AppManager : MonoBehaviour
{
    static UserObject _currentUser;
    public static UserObject CurrentUser { get => _currentUser; set { _currentUser = value; } }



    public GameObject loginCanvas;
    public GameObject mainAppCanvas;

    public int currentPage;

    public static List<BookObject> bookMasterList;

    public static bool refresh = false; 

    
    private void Awake()
    {
       
    }

    public static void LoadBooks() {
        const string BOOK_PATH = "BookData";

        //Debug.Log(Application.dataPath + BOOK_PATH);
        BookData[] loadedBooks = Resources.LoadAll<BookData>(BOOK_PATH);
        bookMasterList = new List<BookObject>();

        foreach (var book in loadedBooks)
        {
            BookObject toAdd = new BookObject();
            toAdd.Data = book;
            bookMasterList.Add(toAdd);
        }

        Debug.Log("Books loaded:"  + bookMasterList.Count);

    }
    /*[SerializeField] List<BookData> nonGeneuineBookMasterListForThePurposesOfDisplayOnly;
    private void Start()
    {
        nonGeneuineBookMasterListForThePurposesOfDisplayOnly = bookMasterList;
    }*/
}
