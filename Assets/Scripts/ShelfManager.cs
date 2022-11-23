using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ShelfManager : MonoBehaviour
{
   
   
    public GameObject blankBookSlot;
    public GameObject shelfPanel;
    public TextMeshProUGUI bookDescriptionText;
    public GameObject FavoriteButton;


    public GameObject activeShelfContainer; 

 
    public void SetActive(ShelfType type) {
        foreach (Shelf shelf in AppManager.Instance.CurrentUser.Data.CustomShelves) { 
            //Set Shelf Visibility for Current User
            if (shelf.type == type) {
                shelf.shelfContainerInUI.SetActive(true);
                activeShelfContainer = shelf.shelfContainerInUI; 
            }
            else {
                shelf.shelfContainerInUI.SetActive(false);
            }
        }
    }
   
}
