using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.InteropServices;

public class LogOut : MonoBehaviour
{
    [SerializeField] string url;
    [SerializeField] GameObject logIn;
    [SerializeField] GameObject app;

    [DllImport("__Internal")]
    private static extern void deleteCookie(string name);


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnLogoutButtonClicked()
    {
        
        StartCoroutine(Register());
    }

    IEnumerator Register()
    {
        var json = JsonUtility.ToJson(AppManager.CurrentUser);
        WWWForm form = new WWWForm();
        form.AddField("username", AppManager.CurrentUser.Data.UserName);
        Debug.Log(json);
        form.AddField("password", AppManager.CurrentUser.Data.Password);
        form.AddField("data", json);

        //UserObject token = new UserObject();

        //JsonUtility.FromJsonOverwrite(json, token);
        //Debug.Log("Data from token: " + token.Data.CustomShelves[0].booksHeld.ToString());

        WWW w = new WWW(url, form);
        yield return w;

        if (w.error != null)
        {
       
            Debug.Log("<color=red>" + w.text + "</color>");//error
        }
        else
        {
            if (w.isDone)
            {
                if (w.text.Contains("error"))
                {
                    
                    Debug.Log("<color=red>" + w.text + "</color>");//error
                }
                else
                {
                    //open welcom panel
                    logIn.SetActive(true);
                    Debug.Log("<color=green>" + w.text + "User Data Saved" + "</color>");//user exist
                    deleteCookie("user");
                    app.SetActive(false);
                    

                }
            }
        }


        w.Dispose();

    }

    public void SerializeStatic()
    {
        var json = JsonUtility.ToJson(AppManager.CurrentUser);
    }
}
