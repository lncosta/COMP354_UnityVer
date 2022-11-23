using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.UI; 

public class FavoriteButton : MonoBehaviour
{
    // Start is called before the first frame update

    public Sprite IsFave;
    public Sprite IsNotFave;

  
    public bool isActive = true; 
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Click(bool currentFaveStatus)
    {
        Image toChange = GetComponent<Image>();
        if (currentFaveStatus)
        {
            toChange.sprite= IsFave;
        }
        else
        {
            toChange.sprite = IsNotFave;
        }

        isActive = currentFaveStatus;
    }
}
