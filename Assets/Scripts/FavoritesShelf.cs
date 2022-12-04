using UnityEngine;

public class FavoritesShelf : Shelf {
    
    private void Awake() {
        BookObject.OnFavorite += AddBook;
        BookObject.OnUnfavorite += RemoveBook;
    }
}
