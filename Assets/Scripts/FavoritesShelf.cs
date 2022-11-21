using UnityEngine;

public class FavoritesShelf : Shelf {
    
    private void Awake() {
        BookObject.OnFavorite += AddBook;
        BookObject.OnUnfavorite += RemoveBook;
    }

    void AddBook(BookObject toAdd) {
        booksHeld.AddUnique(toAdd);
    }

    void RemoveBook(BookObject toRemove) {
        if(!booksHeld.Remove(toRemove)) {
            Debug.Log($"Trying to remove book: {toRemove} which is not in the shelf.");
        }
    }
}
