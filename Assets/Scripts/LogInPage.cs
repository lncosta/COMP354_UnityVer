using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.InteropServices;

public class LogInPage : MonoBehaviour
{
    [SerializeField] GameObject WebApp;

    [SerializeField] TMP_InputField username;
    [SerializeField] TMP_InputField password;

    [SerializeField] TextMeshProUGUI errorMessage;

    [SerializeField] Button login;

    [SerializeField] string url;

    WWWForm form;

    private string cookie = "";
    private bool checkCookie = false;


    [DllImport("__Internal")]
    private static extern void setCookie(string name, string value, int exdays);


    [DllImport("__Internal")]
    private static extern string getCookie(string name);


    public void OnLoginButtonClicked()
    {
        login.interactable = false;
        StartCoroutine(Login());
    }

    public void OnRegisterButtonClicked()
    {
        login.interactable = false;
        StartCoroutine(RegisterUser());
    }
    private void Update()
    { 
        if(!checkCookie)
        {
            cookie = getCookie("user");
            Debug.Log("Cookie: " + cookie);
            checkCookie = true;
            if(cookie != "")
            {
                StartCoroutine(LoginWithCookie());
            }
            
        }
        else
        {
            return;
        }
    }

    public void checkIfData(string w, string username, string password)
    {
        if (w.Equals("NONE") || w.Equals("") || w == null)
        {
            //{ TOREAD, READ, FAVORITES, RECOMMENDATION, READING, DONOTREC};

            UserData newData = new UserData();

            List<Shelf> newShelves = new List<Shelf>();

            newData._customShelves = new List<Shelf>();

            Shelf toRead = new Shelf();
            toRead.type = ShelfType.TOREAD;
            newData._customShelves.Add(toRead);

            Shelf read = new Shelf();
            read.type = ShelfType.READ;
            newData._customShelves.Add(read);

            Shelf favorites = new Shelf();
            favorites.type = ShelfType.FAVORITES;
            newData._customShelves.Add(favorites);


            Shelf rec = new Shelf();
            rec.type = ShelfType.RECOMMENDATION;
            newData._customShelves.Add(rec);

            Shelf reading = new Shelf();
            reading.type = ShelfType.READING;
            newData._customShelves.Add(reading);

            Shelf donotrec = new Shelf();
            donotrec.type = ShelfType.DONOTREC;
            newData._customShelves.Add(donotrec);

            newData.SetNewUsername(username);
            newData.SetNewPassword(password);

            UserObject newUser = new UserObject();

            newUser.Data = newData;

            AppManager.CurrentUser = newUser;


            Debug.Log("New user initiated:" + newUser.Data.UserName);




        }
        else
        {
            var token = JsonUtility.FromJson<UserObject>(w);

            AppManager.CurrentUser = token;

            Debug.Log("User Data loaded." + token.Data.UserName);
        }
    }

    IEnumerator RegisterUser()
    {
        Debug.Log("Attempting to Register User");
        form = new WWWForm();

        form.AddField("username", username.text);
        form.AddField("password", password.text);
        form.AddField("IsSetToRegister", "Yes"); 


        WWW w = new WWW(url, form);
        yield return w;

        if (w.error != null)
        {
            errorMessage.text = "404 not found!";
            Debug.Log("<color=red>" + w.text + "</color>");//error
        }
        else
        {
            if (w.isDone)
            {
                if (w.text.Contains("error"))
                {
                    errorMessage.text = "Invalid username or password!";
                    Debug.Log("<color=red>" + w.text + "</color>");//error
                }
                else
                {
                    //open welcome panel
                    errorMessage.text = "User registered! Please log in above";
                    Debug.Log(w.text);
                    Debug.Log("<color=green>" + w.text + "</color>");//user exist
                    
                }
            }
        }

        login.interactable = true;


        w.Dispose();
    }

    IEnumerator Login()
    {
        form = new WWWForm();

        form.AddField("username", username.text);
        form.AddField("password", password.text);
    

        WWW w = new WWW (url, form);
        yield return w;

        if (w.error != null) {
			errorMessage.text = "404 not found!";
			Debug.Log("<color=red>"+w.text+"</color>");//error
		} else {
			if (w.isDone) {
				if (w.text.Contains ("error")) {
					errorMessage.text = "invalid username or password!";
					Debug.Log("<color=red>"+w.text+"</color>");//error
				} else {
                    //open welcome panel

                    Debug.Log(w.text);
                    checkIfData(w.text, username.text, password.text);
					WebApp.SetActive (true);
					Debug.Log("<color=green>"+w.text+"</color>");//user exist
                    string cookieData = username.text + "," + password.text;
                    setCookie("user", cookieData, 1);
                    
				}
			}
		}

		login.interactable = true;
		

		w.Dispose ();
    }

    IEnumerator LoginWithCookie()
    {
        Debug.Log("<color=green>" + "Log in with cookie was called!" + "</color>");
        form = new WWWForm();


        string[] userInfo = cookie.Split(',');
        Debug.Log("<color=green>" + "Username: " + userInfo[0] + "</color>");
        Debug.Log("<color=green>" + "Password: " + userInfo[1] + "</color>");


        form.AddField("username", userInfo[0]);
        form.AddField("password", userInfo[1]);



        WWW w = new WWW(url, form);
        yield return w;

        if (w.error != null)
        {
            errorMessage.text = "404 not found!";
            Debug.Log("<color=red>" + w.text + "</color>");//error
        }
        else
        {
            if (w.isDone)
            {
                if (w.text.Contains("error"))
                {
                    errorMessage.text = "invalid username or password!";
                    Debug.Log("<color=red>" + w.text + "</color>");//error
                }
                else
                {
                    //open welcome panel
                    Debug.Log(w.text);
                    checkIfData(w.text, userInfo[0], userInfo[1]);
                    WebApp.SetActive(true);
                    Debug.Log("<color=green>" + w.text + "</color>");//user exist

                }
            }
        }


        w.Dispose();
    }


}
