//
//  MasterViewController.cs
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
using MonoTouch.UIKit;
using MonoTouch.Foundation;

using WalletSized.Core;

namespace WalletSized {
  public partial class MasterViewController : UITableViewController {
    DataSource dataSource;

    public MasterViewController () : base ("MasterViewController",null) {
      Title = NSBundle.MainBundle.LocalizedString ("WalletSized","WalletSized");

      // Custom initialization
    }

    public DetailViewController DetailViewController {
      get;
      set;
    }

    void AddNewItem (object sender,EventArgs args) {
      dataSource.Objects.Insert (0,WalletItem.Note("Test","Test"));

      using (var indexPath = NSIndexPath.FromRowSection (0,0))
        TableView.InsertRows (new NSIndexPath[] { indexPath },UITableViewRowAnimation.Automatic);
    }

    public override void DidReceiveMemoryWarning () {
      // Releases the view if it doesn't have a superview.
      base.DidReceiveMemoryWarning ();
      
      // Release any cached data, images, etc that aren't in use.
    }

    public override void ViewDidLoad () {
      base.ViewDidLoad ();

      // Perform any additional setup after loading the view, typically from a nib.
      NavigationItem.LeftBarButtonItem = EditButtonItem;

      var addButton = new UIBarButtonItem (UIBarButtonSystemItem.Add,AddNewItem);
      NavigationItem.RightBarButtonItem = addButton;

      TableView.Source = dataSource = new DataSource (this);
    }

    class DataSource : UITableViewSource {
      static readonly NSString CellIdentifier = new NSString ("Cell");
      readonly List<WalletItem> objects = new List<WalletItem> (10);
      readonly MasterViewController controller;

      public DataSource (MasterViewController controller) {
        this.controller = controller;
      }

      public IList<WalletItem> Objects {
        get { return objects; }
      }
      // Customize the number of sections in the table view.
      public override int NumberOfSections (UITableView tableView) {
        return 1;
      }

      public override int RowsInSection (UITableView tableview,int section) {
        return objects.Count;
      }
      // Customize the appearance of table view cells.
      public override UITableViewCell GetCell (UITableView tableView,NSIndexPath indexPath) {
        var cell = tableView.DequeueReusableCell (CellIdentifier);
        if (cell == null) {
          cell = new UITableViewCell (UITableViewCellStyle.Default,CellIdentifier);
          cell.Accessory = UITableViewCellAccessory.DisclosureIndicator;
        }

        cell.TextLabel.Text = objects[indexPath.Row].Name;
        //TODO: extend with picture
        return cell;
      }

      public override bool CanEditRow (UITableView tableView,NSIndexPath indexPath) {
        // Return false if you do not want the specified item to be editable.
        return true;
      }

      public override void CommitEditingStyle (UITableView tableView,UITableViewCellEditingStyle editingStyle,NSIndexPath indexPath) {
        if (editingStyle == UITableViewCellEditingStyle.Delete) {
          // Delete the row from the data source.
          objects.RemoveAt (indexPath.Row);
          controller.TableView.DeleteRows (new NSIndexPath[] { indexPath },UITableViewRowAnimation.Fade);
        } else if (editingStyle == UITableViewCellEditingStyle.Insert) {
          // Create a new instance of the appropriate class, insert it into the array, and add a new row to the table view.
        }
      }
      /*
      // Override to support rearranging the table view.
      public override void MoveRow (UITableView tableView, NSIndexPath sourceIndexPath, NSIndexPath destinationIndexPath)
      {
      }
      */
      /*
      // Override to support conditional rearranging of the table view.
      public override bool CanMoveRow (UITableView tableView, NSIndexPath indexPath)
      {
        // Return false if you do not want the item to be re-orderable.
        return true;
      }
      */
      public override void RowSelected (UITableView tableView,NSIndexPath indexPath) {
        if (controller.DetailViewController == null)
          controller.DetailViewController = new DetailViewController ();

        controller.DetailViewController.SetDetailItem (objects [indexPath.Row]);

        // Pass the selected object to the new view controller.
        controller.NavigationController.PushViewController (controller.DetailViewController,true);
      }
    }
  }
}
