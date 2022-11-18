using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CreateAssetMenu(fileName = "BookData", menuName = "ScriptableObjects/BookData", order = 1)]
public class Book : ScriptableObject
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


    // Equivalent of an object constructor.
    public static Book Create(string id, string name, string author, float rating, Genre genre) {
        Book newBook = ScriptableObject.CreateInstance<Book>();
        AssetDatabase.CreateAsset(newBook, AssetDatabase.GenerateUniqueAssetPath("Assets/ScriptableObjects/BookData.asset"));

        newBook.Init(id, name, author, rating, genre);
        AssetDatabase.SaveAssetIfDirty(newBook);

        return newBook;
    }

    // Value assignment part of constructor.
    void Init(string id, string title, string author, float rating, Genre genre) {
        this.id = id;
        this.title = title;
        this.author = author;
        this.rating = rating;
        this.genre = genre;
    }
}