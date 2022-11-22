using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class LogInPage : MonoBehaviour
{
    // These are to help navigation with the keyboard
    EventSystem system;
    public Selectable firstInput;
    public Button submit;
    
    // InputFields and message UI
    public TMP_InputField Username;
    public TMP_InputField Password;
    public TextMeshProUGUI message;

    // inputed username and password
    private string username;
    private string password;

    // "Database" of usernames and passwords
    private List<string> usernames;
    private List<string> passwords;

    // Canvas for the BookApp
    public Canvas bookApp;
    // Start is called before the first frame update
    void Start()
    {
        system = EventSystem.current;
        firstInput.Select();
        // creates two new users with two passwords
        usernames = new List<string>();
        usernames.Add("user1");
        usernames.Add("user2");
        passwords = new List<string>();
        passwords.Add("please");
        passwords.Add("please");
    }

    // Everything here is just to allow the user to switch inputs with tab and submit with Enter
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            Selectable next = system.currentSelectedGameObject.GetComponent<Selectable>().FindSelectableOnDown();
            if (next != null)
            {
                next.Select();
            }
        }
        else if (Input.GetKeyDown(KeyCode.KeypadEnter))
        {
            logIn();
            Debug.Log("Button Pressed");
        }
    }

    
    public void logIn()
    {
        // receive inputs and save them into variables
        username = Username.text;
        password = Password.text;
        int index = usernames.IndexOf(username);
        // if the inputted user name exists in the database
        if (index >= 0)
        {   
            //check the index of the found username and see if the password of that index matches (login successful)
            if (passwords[index] == password)
            {
                Debug.Log("Got it");
                
                bookApp.gameObject.SetActive(true);
                this.gameObject.SetActive(false);
            }
            // password is incorect
            else
            {
                message.SetText("Incorrect password please try again.");
            }
        }
        // if the username doesn't exist in the database notify the user
        else
        {
            message.SetText("No such username in database please try again.");
        }
        
    }
}
