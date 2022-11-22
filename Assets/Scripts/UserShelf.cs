using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
//[CreateAssetMenu(fileName = "New User Shelf", menuName = "User/User Shelves")]
public class UserShelf : MonoBehaviour
{
    public List<Shelf> shelfList; //Store current state of user shelves data.
}
