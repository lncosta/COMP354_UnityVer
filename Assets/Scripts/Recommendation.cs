using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
public class Recommendation: MonoBehaviour
{
	public int rnd; 
	private UserObject user;

    public void Start()
    {
		
		user = AppManager.CurrentUser; 
    }
    public List<BookObject> getRecommendations(List<BookObject> booksDatabase) // Will return the first 10 books after sorting the whole database
    {
		List<BookObject> recommendations = new List<BookObject>();
		IEnumerable<BookObject> doNotRec = user.getShelf(ShelfType.DONOTREC).GetBooks(); // Get the books that shouldn't be recommended
		List<string> doNotRecId = new List<string>();
		foreach(BookObject book in doNotRec)
        {
			doNotRecId.Add(book.Data.id);

		}
		int next = 0; // The next book to add from the sorted DB

		user.buildScores(); // Creates the score of each author/Genre inside the user's shelves
		booksDatabase.Sort(bookComparer); // Sort the database according to the scores
		
		// Adds the next book in line, or skips it if it is banned
		while(recommendations.Count < 10)
        {
            if (doNotRecId.Contains(booksDatabase[next].Data.id))
			{
				next++;
            }
            else
            {
				recommendations.Add(booksDatabase[next]);
				next++;

			}

		}

		return recommendations;
	}

	private int bookComparer(BookObject b1, BookObject b2) // Compares the score of two books
    {
		return (user.GetBookScore(b1) - user.GetBookScore(b2)+Random.Range(-2, 2)); // Add an element of randomness in the sorting
    }
}
