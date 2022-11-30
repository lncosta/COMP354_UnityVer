using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LogInPage : MonoBehaviour
{   
    [SerializeField] GameObject WebApp;

    [SerializeField] TMP_InputField username;
    [SerializeField] TMP_InputField password;

    [SerializeField] TextMeshProUGUI errorMessage;

    [SerializeField] Button login;

    [SerializeField] string url;

    WWWForm form;

    public void OnLoginButtonClicked()
    {
        login.interactable = false;
        StartCoroutine (Login());
    }

    IEnumerator Login()
    {
        form = new WWWForm();

        form.AddField ("username", username.text);
        form.AddField ("password", password.text);

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
					//open welcom panel
					WebApp.SetActive (true);
					Debug.Log("<color=green>"+w.text+"</color>");//user exist

                    // Load the shelves with books from the database
                    //foreach(Shelf shelf in AppManager.CurrentUser.Data.CustomShelves)
                    //{
                    //    if(shelf.type == ShelfType.TOREAD)
                    //    {
                    //        Debug.Log("<color=yellow>In TO_READ shelf</color>");
                    //    } else if(shelf.type == ShelfType.READING)
                    //    {
                    //        Debug.Log("<color=yellow>In READING shelf</color>");
                    //    } else if(shelf.type == ShelfType.READ)
                    //    {
                    //        Debug.Log("<color=yellow>In READ shelf</color>");
                    //    } else if(shelf.type == ShelfType.FAVORITES)
                    //    {
                    //        Debug.Log("<color=yellow>In FAVORITES shelf</color>");
                    //    } else if(shelf.type == ShelfType.RECOMMENDATION)
                    //    {
                    //        Debug.Log("<color=yellow>In RECOMMENDATION shelf</color>");
                    //    }
                    //}
				}
			}
		}

		login.interactable = true;
		

		w.Dispose ();
    }
}
