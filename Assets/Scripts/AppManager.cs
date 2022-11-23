using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AppManager : Singleton<AppManager>
{
    // Do we need to be using a monobehaviour for the current user?
    // Could we just let the appmanager hold an instance of UserData instead?

    UserObject _currentUser;
    public UserObject CurrentUser { get => _currentUser; }
    public void SetCurrentUser(UserObject newUser) {
        // validation checks (if any)
        _currentUser = newUser;
    } 

    public GameObject loginCanvas;
    public GameObject mainAppCanvas;

    public int currentPage;

    protected override void Awake() {
        base.Awake();
        Instance = this;
    }
}
