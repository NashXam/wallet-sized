using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace WalletSized.Android
{
	[Activity (Label = "AddStuffActivity")]			
	public class AddStuffActivity : Activity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			SetContentView (Resource.Layout.AddStuff);

			var label = FindViewById<TextView> (Resource.Id.screen2Label);
			label.Text = Intent.GetStringExtra("FirstData") ?? "Data not available";

			Button addNote = FindViewById<Button> (Resource.Id.AddNote);

			addNote.Click += delegate {

				var myNote = FindViewById<EditText> (Resource.Id.MyNote).Text;

				var main = new Intent(this, typeof(MainActivity));
				main.PutExtra("FirstData", myNote);
				StartActivity(main);
			};
		}
	}
}

