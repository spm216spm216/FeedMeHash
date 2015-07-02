using System;
using System.IO;
using System.Web;
using System.Web.UI.WebControls;
using System.Web.UI;
using System.Text.RegularExpressions;
using TweetSharp;
using Hammock;

/// <summary>
/// This page is an extension of the default page called "searchPage". Here,
/// the user can search for a hashtage with additional filters. This page
/// includes a secondary textbox that filters the 100 tweets containing the
/// original hashtag using regular expressions. It also includes a dropbox where the user
/// can select results to be listed by date (recent first), popularity, or a 
/// mix of the two, which is done through the package tweetsharp.
/// </summary>
namespace GiveMeHashFinal
{
	
	public partial class searchPage : System.Web.UI.Page
	{ 
		// This method creates tweet boxes for the keyword given on the default page.
		protected void Page_Load(object sender, EventArgs e)
		{
			TwitterSearchResult tweets = Default.service.Search (new SearchOptions { 
				// searches with 3 filters: keyword, result type, and number of results
				Q = "#" + Default.getKeyword(), 
				Resulttype = TwitterSearchResultType.Recent, 
				Count = 50,
				IncludeEntities = false
			});
			foreach (var tweet in tweets.Statuses) {
				// txt is a combination between text and asp.net code for formatting
				string txt = tweet.User.Name + " (" + tweet.User.ScreenName + ") " + "<br /><p class=\"tab\">" + tweet.Text + "</p>";
				Literal1.Text = Literal1.Text + boxBuilder (txt);
			}
		}

		// method sets new keyword value to text value in the first textbox (hashbox).
		public void findTweetsClicked (object sender, EventArgs args)
		{
			Default.setKeyword(hashBox.Text);
			tweetBuilder ();
		}

		// this method loads the page with tweets using the selected filters
		public void tweetBuilder ()
		{
			Literal1.Text = null; // sets literal placeholder to null (clears all prior tweets)
			TwitterSearchResult tweets;
			if (filter.SelectedValue == "2") { //if dropdown box text value is mixed
				tweets = Default.service.Search (new SearchOptions {
					// searches with 3 filters: keyword, result type, and number of results
					Q = "#" + Default.getKeyword (),
					Resulttype = TwitterSearchResultType.Mixed,
					Count = 50,
					IncludeEntities = false
				});
			} else if (filter.Text == "1") { // if dropdown box text value is popularity
				tweets = Default.service.Search (new SearchOptions {
					// searches with 3 filters: keyword, result type, and number of results
					Q = "#" + Default.getKeyword (),
					Resulttype = TwitterSearchResultType.Popular,
					Count = 50,
					IncludeEntities = false
				});
			} else { // if original search or dropdown text value is date
				tweets = Default.service.Search (new SearchOptions { 
					// searches with 3 filters: keyword, result type, and number of results
					Q = "#" + Default.getKeyword(), 
					Resulttype = TwitterSearchResultType.Recent, 
					Count = 50,
					IncludeEntities = false
				});
			}

			if (tweets != null) // if there are tweets found with selected keyword
			{
				string txt = null;

				//normal search without filter
				if (string.IsNullOrEmpty(filterBox.Text)) {
					foreach (var tweet in tweets.Statuses) {
						// txt is a combination between text and asp.net code for formatting
						txt = tweet.User.Name + " (" + tweet.User.ScreenName + ") " + "<br /><p class=\"tab\">" + tweet.Text + "</p>";
						Literal1.Text = Literal1.Text + boxBuilder (txt); // adds a tweet box to page
					}
				}

				//search with a secondary filter, uses regex to filter
				else {
					int counter = 0; // make sure there are tweets with secondary filter
					foreach (var tweet in tweets.Statuses) {
						string pattern = filterBox.Text; // set secondary filter
						//if statement that uses regex to find tweets with secondary filter, ignoring case
						if (System.Text.RegularExpressions.Regex.IsMatch(tweet.Text, pattern, System.Text.RegularExpressions.RegexOptions.IgnoreCase))
						{
							// txt is a combination between text and asp.net code for formatting
							txt = tweet.User.Name + " (" + tweet.User.ScreenName + ") " + "<br /><p class=\"tab\">" + tweet.Text + "</p>";
							Literal1.Text = Literal1.Text + boxBuilder (txt); // adds a tweet box to page
							counter++; // tweet with secondary filter found
						}
					}
					if (counter == 0) { // if none of the orginal 100 tweets have the secondary filter
						Literal1.Text = "No tweets found with \"" + filterBox.Text + "\" as a secondary filter.";
					}
				}
			}

			else{ // no tweets with the original hashtag found
				Literal1.Text = "No tweets found";
			}
		}

		// This method is responsable for creating tweet boxes. It takes a regular string and passes back a string 
		// containing html code.
		public string boxBuilder(string txt)
		{
			Literal1.Text = null; 
			StringWriter stringWriter = new StringWriter (); // used to combine html elements and eventually convert to string

			using (HtmlTextWriter writer = new HtmlTextWriter (stringWriter)) 
			{
				writer.AddAttribute (HtmlTextWriterAttribute.Width, "300px"); // creates the width of the tweet box
				// puts a border on the tweet box
				writer.AddAttribute (HtmlTextWriterAttribute.Style, "border: 2px solid grey; margin: 50px; padding: 25px;");
				writer.RenderBeginTag(HtmlTextWriterTag.Div); // begins a <div> to incorperate the attributes above
				writer.Write(txt); // writes text inbetween <div> tags
				writer.RenderEndTag(); // ends </div> tag
			}
			return stringWriter.ToString(); // pass a string back
		}
	}
}

