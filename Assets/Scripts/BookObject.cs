using System;
using UnityEngine;

[System.Serializable]
[SerializeField]
public class BookObject{
    // Raise this event when this book gets favorited so that shelves can react accordingly.
    public static event Action<BookObject> OnFavorite;
    public static event Action<BookObject> OnUnfavorite;

    [SerializeField] BookData _data;

    [SerializeField] public BookData Data { get => _data; set { _data = value; } }


    public void Favorite() { OnFavorite.Invoke(this); }
    public void Unfavorite() { OnUnfavorite.Invoke(this); }

    public bool FavoriteButtonClicked()
    {
        return _data.isFavorite;
    }

}