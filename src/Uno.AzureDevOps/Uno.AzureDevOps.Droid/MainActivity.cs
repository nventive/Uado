using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Uno.AzureDevOps.Client;
using Xamarin.Essentials;

namespace Uno.AzureDevOps.Droid
{
	[Activity(
		// We need to set Name, otherwise a random one is generated at every build, which causes the app to be removed from the home screen on app-updates. 
		// The Name must be the fully qualified name of the class, with the namespace part in lowercase.
		// https://docs.microsoft.com/en-us/xamarin/android/platform/java-integration/android-callable-wrappers#android-callable-wrapper-naming
		Name = "uno.azuredevops.droid.MainActivity",
		Theme = "@style/splashscreen",
		MainLauncher = true,
		ConfigurationChanges = ConfigChanges.ScreenSize,
		ScreenOrientation = ScreenOrientation.Portrait,
		WindowSoftInputMode = SoftInput.AdjustPan | SoftInput.StateHidden
	)]
	public class MainActivity : Windows.UI.Xaml.ApplicationActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			// Switch to app theme on activity start
			base.SetTheme(Resource.Style.AppTheme);
			base.OnCreate(bundle);
			//Init Xamarin essentials is needed for Android only
			Xamarin.Essentials.Platform.Init(this, bundle);

			SetOrientationOnIdiom();
#if !DEBUG
			AppCenter.Start(ClientConstants.AppCenterSecret,
							   typeof(Analytics), typeof(Crashes));
#endif
		}

		private void SetOrientationOnIdiom()
		{
			var idiom = DeviceInfo.Idiom;

			if (idiom == DeviceIdiom.Tablet)
			{
				RequestedOrientation = ScreenOrientation.FullSensor;
			}
			else if (idiom == DeviceIdiom.Phone)
			{
				RequestedOrientation = ScreenOrientation.Portrait;
			}
			else
			{
				RequestedOrientation = ScreenOrientation.Portrait;
			}

		}
	}
}
