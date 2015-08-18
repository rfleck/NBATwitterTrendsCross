using System;
using Xamarin.Forms;
using System.Collections;
using System.Collections.Generic; 
using System.Linq;
using NBATwitterTrendsCross;

namespace NBATwitterTrendsCross
{
	public class SearchPage : ContentPage
	{
		private Label appTitle = new Label();
		private Label searchPrompt = new Label();
		private Label appStatus = new Label();
		private ListView displayTeamList = new ListView();
		private StackLayout dataContainer = new StackLayout();
		private TeamListViewModel TeamList = new TeamListViewModel();
		private Label teamName = new Label();
		private Label teamCity = new Label();

		public SearchPage ()
		{
			appTitle.FontSize = 40;
			appTitle.TextColor = Color.Silver; 
			appTitle.FontAttributes = FontAttributes.Bold; 
			appTitle.Text = "NBA Twitter Trends";

			searchPrompt.FontSize = 20;
			searchPrompt.TextColor = Color.White;
			searchPrompt.Text = "Choose your NBA team:";

			appStatus.FontSize = 14;
			appStatus.TextColor = Color.Yellow;
			appStatus.Text = "Loading...";

			displayTeamList.Header = "List Header - Start";
			displayTeamList.ItemsSource = TeamList.InitiateListValues(); 
			displayTeamList.ItemTemplate = new DataTemplate( () => 
			{
				teamName.SetBinding(Label.TextProperty, "teamName");
				teamCity.SetBinding(Label.TextProperty, "teamCity");
				return new ViewCell
				{
					View = new StackLayout
					{
						Padding = new Thickness(0, 5),
						Orientation = StackOrientation.Horizontal,
						Children = 
						{
							teamName,
							teamCity
						}
					}
				};	
			});
			displayTeamList.Footer = "List Footer - End";
			dataContainer.Orientation = StackOrientation.Vertical; 
			dataContainer.Children.Add(appTitle);
			dataContainer.Children.Add(searchPrompt);
			dataContainer.Children.Add (displayTeamList);
			dataContainer.Children.Add(appStatus); 
			this.Content = dataContainer;
		}
	}
}