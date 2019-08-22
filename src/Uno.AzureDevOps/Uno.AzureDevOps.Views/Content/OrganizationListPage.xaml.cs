﻿using System.Diagnostics.CodeAnalysis;
using Uno.AzureDevOps.Client;
using Uno.AzureDevOps.Presentation;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238
namespace Uno.AzureDevOps.Views.Content
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	[SuppressMessage("", "CA1801", Justification = "Event handler")]
	public sealed partial class OrganizationListPage : Page
	{
		public OrganizationListPage()
		{
			InitializeComponent();
			DataContext = new OrganizationListPageViewModel();
		}

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			(DataContext as OrganizationListPageViewModel).OnNavigatedTo();
			base.OnNavigatedTo(e);
		}

		private void ListView_ItemClick(object sender, ItemClickEventArgs e)
		{
			(DataContext as OrganizationListPageViewModel)?.NavigateToProjectListPage(e.ClickedItem as AccountData);
		}

		private void HamburgerButton_Click(object sender, RoutedEventArgs e)
		{
			if (LargeViewNavigation.Visibility == Visibility.Collapsed)
			{
				LargeViewNavigation.Visibility = Visibility.Visible;
				LargeViewNavigation.SetValue(Grid.ColumnProperty, 0);
				ContentView.SetValue(Grid.ColumnProperty, 0);
			}
			else
			{
				LargeViewNavigation.Visibility = Visibility.Collapsed;
				ContentView.SetValue(Grid.ColumnProperty, 1);
			}
		}
	}
}
