using System;
using System.Collections.Generic;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace WalletSized
{
	[Activity (Label = "Wallet-Sized", MainLauncher = true)]
	public class MainActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// refactor this so we aren't hard-coding a bunch of buttons
			var buttonList = new List<ImageButton> {
				FindViewById<ImageButton> (Resource.Id.imageButton1),
				FindViewById<ImageButton> (Resource.Id.imageButton2),
				FindViewById<ImageButton> (Resource.Id.imageButton3),
				FindViewById<ImageButton> (Resource.Id.imageButton4),
				FindViewById<ImageButton> (Resource.Id.imageButton5),
				FindViewById<ImageButton> (Resource.Id.imageButton6),
				FindViewById<ImageButton> (Resource.Id.imageButton7),
				FindViewById<ImageButton> (Resource.Id.imageButton8),
				FindViewById<ImageButton> (Resource.Id.imageButton9),
				FindViewById<ImageButton> (Resource.Id.imageButton10)
			};


			buttonList.ForEach (b => b.Click += delegate {
				var modal = BuildAndShowDialog ();
				var urlRadioButton = modal.FindViewById<RadioButton>(Resource.Id.urlRadioButton);
				var textRadioButton = modal.FindViewById<RadioButton>(Resource.Id.textRadioButton);
				var pictureRadioButton = modal.FindViewById<RadioButton>(Resource.Id.pictureRadioButton);
			});
		}

		private void OkClicked(object sender, DialogClickEventArgs dialogClickEventArgs)
		{
			var dialog = sender as AlertDialog;

			if (null != dialog)
			{

			}
		}

		private void CancelClicked(object sender, DialogClickEventArgs dialogClickEventArgs)
		{
			var dialog = sender as AlertDialog;

			if (null != dialog)
			{

			}
		}

		private View BuildAndShowDialog()
		{
			var modal = LayoutInflater.Inflate(Resource.Layout.Modal, null);
			var builder = new AlertDialog.Builder(this);
			builder.SetTitle("Watchu wanna add?");
			builder.SetView(modal);
			builder.SetPositiveButton("OK", OkClicked);
			builder.SetNegativeButton("Cancel", CancelClicked);
			builder.Create();
			builder.Show();
			return modal;
		}
	}
}


