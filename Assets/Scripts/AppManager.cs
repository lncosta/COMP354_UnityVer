using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager : MonoBehaviour
{
    static UserObject _currentUser;
    public static UserObject CurrentUser { get => _currentUser; }



    public GameObject loginCanvas;
    public GameObject mainAppCanvas;

    public int currentPage;

    public static List<BookObject> bookMasterList; 
}
