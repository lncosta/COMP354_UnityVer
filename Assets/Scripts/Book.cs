using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "BookData", menuName = "ScriptableObjects/BookData", order = 1)]
public class Book : ScriptableObject
{
    public string title;

    public Shelf shelf = null;

    public bool isFavorite = false;
    public bool isRecommended = false;
    public bool canBeRecommended = true;

    public Genre genre;

    public string author;
    public int rating;

    public Sprite bookCover; 
}