using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager : MonoBehaviour
{
    static UserObject _currentUser;
    public static UserObject CurrentUser { get => _currentUser; }

    public static List<Shelf> shelves;


    public GameObject loginCanvas;
    public GameObject mainAppCanvas;

    public int currentPage;

    public static List<BookData> bookMasterList;

    private void Awake() {
        const string BOOK_PATH = "BookData";
        BookData[] loadedBooks = Resources.LoadAll<BookData>(BOOK_PATH);
        bookMasterList = new List<BookData>(loadedBooks.Length);

        foreach (var book in loadedBooks) {
            bookMasterList.Add(book);
        }
    }

    [SerializeField] List<BookData> nonGeneuineBookMasterListForThePurposesOfDisplayOnly;
    private void Start() {
        nonGeneuineBookMasterListForThePurposesOfDisplayOnly = bookMasterList;
    }

}
