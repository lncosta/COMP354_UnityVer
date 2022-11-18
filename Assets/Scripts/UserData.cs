using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UserData", menuName = "ScriptableObjects/UserData", order = 2)]
public class UserData : MonoBehaviour
{
    public string userName;
    public string password;
    public string email;

    public UserShelves shelfData;
}
