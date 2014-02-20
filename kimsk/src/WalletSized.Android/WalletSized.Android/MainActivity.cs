using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace WalletSized.Android
{
	[Activity (Label = "WalletSized.Android", MainLauncher = true)]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			Button one = FindViewById<Button> (Resource.Id.One);

			if (!string.IsNullOrEmpty (Intent.GetStringExtra ("FirstData"))) {
				one.Text = Intent.GetStringExtra ("FirstData");
			}

			one.Click += delegate {
				var addStuff = new Intent(this, typeof(AddStuffActivity));
				addStuff.PutExtra("FirstData", "Add Stuff to the 1st Slot");
				StartActivity(addStuff);
			};
		}
	}
}


