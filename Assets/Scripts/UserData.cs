using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "UserData", menuName = "ScriptableObjects/UserData", order = 2)]
[System.Serializable]
[SerializeField]
public class UserData
{
    [SerializeField] string _userName;
    [SerializeField] string _password;
    [SerializeField] string _email;
    [SerializeField] string[] _favoriteBooksIds;
    [SerializeField] public List<Shelf> _customShelves;
    

    // These are C# shortcuts for get methods.
    public string UserName { get => _userName; }
    public string Password { get => _password; }
    public string Email { get => _email; }
    public string[] FavoriteBookIds { get => _favoriteBooksIds; }
    public List<Shelf> CustomShelves { get => new List<Shelf>(CustomShelves); set { _customShelves = new List<Shelf>() ; } }



    public void SetNewUsername(string newName) { _userName = newName; }
    public void SetNewPassword(string newPassword) { _password = newPassword; }
    public void SetNewEmail(string newEmail) { _email = newEmail; }
}
