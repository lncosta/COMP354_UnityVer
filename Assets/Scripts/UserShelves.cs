using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
[CreateAssetMenu(fileName = "New User Shelf", menuName = "User/User Shelves")]
public class UserShelves : MonoBehaviour
{
   public List<Shelf> shelves = new List<Shelf>();
}
