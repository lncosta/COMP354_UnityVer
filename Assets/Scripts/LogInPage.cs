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

                    
				}
			}
		}

		login.interactable = true;
		

		w.Dispose ();
    }
}
