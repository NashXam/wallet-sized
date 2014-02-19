//
//  DetailViewController.cs
//
//  Author:
//       Paulmichael Blasucci <pblasucci@gmail.com>
//
//  Copyright (c) 2014 
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU Lesser General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU Lesser General Public License for more details.
//
//  You should have received a copy of the GNU Lesser General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.
using System;
using System.Drawing;
using System.Collections.Generic;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

using WalletSized.Core;

namespace WalletSized {
  public partial class DetailViewController : UIViewController {
    WalletItem detailItem;

    public DetailViewController () : base ("DetailViewController",null) {
      Title = NSBundle.MainBundle.LocalizedString ("Details","Details");

      // Custom initialization
    }

    public void SetDetailItem (object newDetailItem) {
      if (detailItem != newDetailItem) {
        detailItem = (WalletItem) newDetailItem;
        
        // Update the view
        ConfigureView ();
      }
    }

    void ConfigureView () {
      // Update the user interface for the detail item
      if (IsViewLoaded && detailItem != null)
        detailDescriptionLabel.Text = String.Format ("[{1}] {0}: {2}"
                                                    ,detailItem.Name
                                                    ,detailItem.Stamp
                                                    ,detailItem.Value);
    }

    public override void DidReceiveMemoryWarning () {
      // Releases the view if it doesn't have a superview.
      base.DidReceiveMemoryWarning ();
      
      // Release any cached data, images, etc that aren't in use.
    }

    public override void ViewDidLoad () {
      base.ViewDidLoad ();
      
      // Perform any additional setup after loading the view, typically from a nib.
      ConfigureView ();
    }
  }
}

