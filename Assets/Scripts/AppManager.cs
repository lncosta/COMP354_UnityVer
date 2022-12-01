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
        const string BOOK_PATH = "Books";
        BookData[] loadedBooks = Resources.LoadAll<BookData>(BOOK_PATH);
        //bookMasterList = new List<BookData>(loadedBooks.Length);
        bookMasterList = new List<BookData>(loadedBooks);

        //foreach (var book in loadedBooks) {
        //    bookMasterList.Add(book);
        //}
        Debug.Log("BOOK LIST: " + loadedBooks);
    }
}
