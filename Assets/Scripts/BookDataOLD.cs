//using System;
//using UnityEngine;

//public class BookData {
//    // Raise this event when this book gets favorited so that shelves can react accordingly.
//    public static event Action<BookData> OnFavorite;
//    public static event Action<BookData> OnUnfavorite;

//    [SerializeField] BookData _data;

//    public BookData Data { get => _data; }


//    public void Favorite() { OnFavorite.Invoke(this); }
//    public void Unfavorite() { OnUnfavorite.Invoke(this); }

//    public bool FavoriteButtonClicked()
//    {
//        return _data.isFavorite;
//    }

//    public BookData(BookData data) {
//        _data = data;
//    }
//}