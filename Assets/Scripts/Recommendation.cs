using System;
using System.Collections.Generic;
public class Recommendation
{
	Random rnd = new Random();
	private UserObject user;
	public Recommendation(AppManager appManager)
	{
		//user = appManager.getCurrentUser; // Need a way to recover the current user of the app
	}

	public List<BookData> getRecommendations(List<BookData> booksDatabase) // Will return the first 10 books after sorting the whole database
    {
		List<BookData> recommendations = new List<BookData>();
		IEnumerable<BookData> doNotRec = user.getShelf(ShelfType.DONOTREC).GetBooks(); // Get the books that shouldn't be recommended
		List<string> doNotRecId = new List<string>();
		foreach(BookData book in doNotRec)
        {
			doNotRecId.Add(book.id);

		}
		int next = 0; // The next book to add from the sorted DB

		user.buildScores(); // Creates the score of each author/Genre inside the user's shelves
		booksDatabase.Sort(bookComparer); // Sort the database according to the scores
		
		// Adds the next book in line, or skips it if it is banned
		while(recommendations.Count < 10)
        {
            if (doNotRecId.Contains(booksDatabase[next].id))
			{
				next++;
            }
            else
            {
				recommendations.Add(booksDatabase[next]);

			}

		}

		return recommendations;
	}

	private int bookComparer(BookData b1, BookData b2) // Compares the score of two books
    {
		return (user.GetBookScore(b1) - user.GetBookScore(b2)+rnd.Next(-2, 2)); // Add an element of randomness in the sorting
    }
}
