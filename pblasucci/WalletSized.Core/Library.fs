//
//  Library.fs
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
namespace WalletSized.Core

open System

type WalletItem =
  { Name  :string
    Stamp :DateTime 
    Value :WalletItemValue }
  
  override item.ToString () =
    sprintf "{WalletItem.Name=%s; Stamp=%A; Value=%A}"
            item.Name
            item.Stamp
            item.Value

and WalletItemValue =
  | Note  of string
  | Link  of string
  | Photo of string 

  override item.ToString () =
    match item with
    | Note  value -> sprintf "Note %s"  value
    | Link  value -> sprintf "Link %s"  value
    | Photo value -> sprintf "Photo %s" value

// extensions to simplfy being called from languages other than F#
type WalletItem with
  static member Note (name,value) =
    {Name=name; Stamp=DateTime.UtcNow; Value=Note value}
  static member Link (name,value) =
    {Name=name; Stamp=DateTime.UtcNow; Value=Link value}
  static member Photo (name,value) =
    {Name=name; Stamp=DateTime.UtcNow; Value=Photo value}
