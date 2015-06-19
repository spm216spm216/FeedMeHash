using System;
using System.Web;
using System.Web.UI;
using TweetSharp;
using Hammock;
/// <summary>
/// This file creates the first page of the program. Here, only one search bar
/// is presented, prompting the user for a hashtag. It then sends the user to
/// the searchPage document and prints tweets from the hashtag. This file also
/// authenticates the twitter REST API connection for the rest of the program.
/// </summary>
namespace GiveMeHashFinal
{
	
	public partial class Default : System.Web.UI.Page
	{
		private static string keyword = null; // create a private keyword used throughout the rest of program
		public static TwitterService service; // creates a twitter connection that can be used throughout program
		public void tweetButtonClicked (object sender, EventArgs args)
		{
			// The following information is required to create a secure connection to the twitter API.
			// These settings allow for a read only connection.
			service = new TwitterService ("jIfGzjO9CD1KctjJf8pAdpxGN", "fZ1jg3P0pF7QZ57GeP44CvIL9BRjrYS5HAFTWh1NuSFi39PshH", "3329866965-3eJlvfFUrOBD89FONcVmflD84LLwlDTbcHaEemc", "7YSv1sHtR1dZl5PJyD0xX2Wpo2p6TQRnP2hNb4zFVPbft");
			service.AuthenticateWith("3329866965-3eJlvfFUrOBD89FONcVmflD84LLwlDTbcHaEemc", "7YSv1sHtR1dZl5PJyD0xX2Wpo2p6TQRnP2hNb4zFVPbft");
			keyword = mainBox.Text;
			Response.Redirect ("searchPage.aspx");
		}

		public static string getKeyword (){ // used to get the keyword in other files in this program
			return keyword;
		}

		public static void setKeyword (string txt){ // used to set the keyword in other files in this program
			keyword = txt;
		}
	}
}

