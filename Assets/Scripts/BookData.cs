using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CreateAssetMenu(fileName = "BookData", menuName = "ScriptableObjects/BookData", order = 1)]
[System.Serializable]
[SerializeField]
public class BookData : ScriptableObject
{
    public string id;
    public string title;

    public Shelf shelf = null;

    public bool isFavorite = false;
    public bool isRecommended = false;
    public bool canBeRecommended = true;

    public Genre genre;

    public string author;
    public float rating;

    public Sprite bookCover;


#if UNITY_EDITOR
    // Equivalent of an object constructor.
    public static BookData Create(string id, string name, string author, float rating, Genre genre)
    {
        BookData newBook = ScriptableObject.CreateInstance<BookData>();
       
        AssetDatabase.CreateAsset(newBook, AssetDatabase.GenerateUniqueAssetPath("Assets/Resources/BookData/BookData.asset"));

        int genreInt = Random.Range(0, 7); 
        newBook.Init(id, name, author, rating, (Genre)genreInt);
        EditorUtility.SetDirty(newBook);
        AssetDatabase.SaveAssetIfDirty(newBook);

        return newBook;
    }
#endif


    // Value assignment part of constructor.
    void Init(string id, string title, string author, float rating, Genre genre)
    {
        this.id = id;
        this.title = title;
        this.author = author;
        this.rating = rating;
        this.genre = genre;
    }


    
}