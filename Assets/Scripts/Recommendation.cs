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

	public List<BookObject> getRecommendations(List<BookObject> booksDatabase) // Will return the first 10 books after sorting the whole database
    {
		user.buildScores();
		booksDatabase.Sort(bookComparer);

		return booksDatabase.GetRange(0,10);

	}

	private int bookComparer(BookObject b1, BookObject b2) // Compares the score of two books
    {
		return (user.GetBookScore(b1) - user.GetBookScore(b2)+rnd.Next(-2, 2)); // Add an element of randomness in the sorting
    }
}
