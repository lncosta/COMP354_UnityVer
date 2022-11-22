using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShelfManager : MonoBehaviour
{
   
   
    public GameObject blankBookSlot;

    public GameObject activeShelfContainer; 

 
    public void setActive(ShelfType type)
    {
        foreach (Shelf shelf in AppManager.CurrentUser.Data.CustomShelves)
        { //Set Shelf Visibility for Current User
            if (shelf.type == type)
            {
                shelf.shelfContainerInUI.SetActive(true);
                activeShelfContainer = shelf.shelfContainerInUI; 
            }
            else
            {
                shelf.shelfContainerInUI.SetActive(false);
            }
        }
    }
   
}
