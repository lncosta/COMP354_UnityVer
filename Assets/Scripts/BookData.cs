using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


[CreateAssetMenu(fileName = "BookData", menuName = "ScriptableObjects/BookData", order = 1)]
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
    public static BookData Create(string id, string name, string author, float rating, Genre genre) {
        BookData newBook = ScriptableObject.CreateInstance<BookData>();
        AssetDatabase.CreateAsset(newBook, AssetDatabase.GenerateUniqueAssetPath("Assets/Resources/BookData/BookData.asset"));

        newBook.Init(id, name, author, rating, genre);
        AssetDatabase.SaveAssetIfDirty(newBook);

        return newBook;
    }
#endif


    // Value assignment part of constructor.
    void Init(string id, string title, string author, float rating, Genre genre) {
        this.id = id;
        this.title = title;
        this.author = author;
        this.rating = rating;
        this.genre = genre;
    }


    // Raise this event when this book gets favorited so that shelves can react accordingly.
    public static event Action<BookData> OnFavorite;
    public static event Action<BookData> OnUnfavorite;


    public void Favorite() { OnFavorite.Invoke(this); }
    public void Unfavorite() { OnUnfavorite.Invoke(this); }

    public bool FavoriteButtonClicked() {
        return this.isFavorite;
    }
}