using UnityEngine;

public class FavoritesShelf : Shelf {
    
    private void Awake() {
        BookData.OnFavorite += AddBook;
        BookData.OnUnfavorite += RemoveBook;
    }
}
