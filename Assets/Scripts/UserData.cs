using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable, CreateAssetMenu(fileName ="UserData", menuName ="ScriptableObject/UserData", order =2)]
public class UserData : ScriptableObject
{
    string _userName;
    string _password;
    List<string> _favoriteBooks;
    List<string> _toReadBooks;
    List<string> _readingBooks;
    List<string> _readBooks;

    public UserData(string userName, string password, List<string> favoriteBooks, List<string> toReadBooks, List<string> readingBooks, List<string> readBooks) {
        _userName = userName;
        _password = password;
        _favoriteBooks = favoriteBooks;
        _toReadBooks = toReadBooks;
        _readingBooks = readingBooks;
        _readBooks = readBooks;
    }

    // These are C# shortcuts for get methods.
    public string UserName { get => _userName; }
    public string Password { get => _password; }
    public IList<string> FavoriteBooks { get => _favoriteBooks; }
    public IList<string> ToReadBooks { get => _toReadBooks; }
    public IList<string> ReadingBooks { get => _readingBooks; }
    public IList<string> ReadBooks { get => _readBooks; }
    public List<Shelf> CustomShelves { get => new List<Shelf>(); }

    public void SetNewUsername(string newName) { _userName = newName; }
}
