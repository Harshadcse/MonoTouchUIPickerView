using System;
using System.Collections.Generic;
using System.Drawing;

using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace MonoTouchUIPickerView
{
	public partial class MonoTouchUIPickerViewViewController : UIViewController
	{
		private readonly IList<string> colors = new List<string>
		{
			"Blue",
			"Green",
			"Red",
			"Purple",
			"Yellow"
		};

		private string selectedColor;

		public MonoTouchUIPickerViewViewController () : base ("MonoTouchUIPickerViewViewController", null)
		{
		}
		
		public override void DidReceiveMemoryWarning ()
		{
			// Releases the view if it doesn't have a superview.
			base.DidReceiveMemoryWarning ();
			
			// Release any cached data, images, etc that aren't in use.
		}
		
		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			
			// Perform any additional setup after loading the view, typically from a nib.
			this.SetupPicker();
		}
		
		public override void ViewDidUnload ()
		{
			base.ViewDidUnload ();
			
			// Clear any references to subviews of the main view in order to
			// allow the Garbage Collector to collect them sooner.
			//
			// e.g. myOutlet.Dispose (); myOutlet = null;
			
			ReleaseDesignerOutlets ();
		}
		
		public override bool ShouldAutorotateToInterfaceOrientation (UIInterfaceOrientation toInterfaceOrientation)
		{
			// Return true for supported orientations
			return (toInterfaceOrientation != UIInterfaceOrientation.PortraitUpsideDown);
		}

		private void SetupPicker()
		{
			// Setup the picker and model
			PickerModel model = new PickerModel(this.colors);
			model.PickerChanged += (sender, e) => {
				this.selectedColor = e.SelectedValue;
			};

			UIPickerView picker = new UIPickerView();
			picker.ShowSelectionIndicator = true;
			picker.Model = model;

			// Setup the toolbar
			UIToolbar toolbar = new UIToolbar();
			toolbar.BarStyle = UIBarStyle.Black;
			toolbar.Translucent = true;
			toolbar.SizeToFit();

			// Create a 'done' button for the toolbar and add it to the toolbar
			UIBarButtonItem doneButton = new UIBarButtonItem("Done", UIBarButtonItemStyle.Done,
			                                                 (s, e) => {
				this.ColorTextField.Text = selectedColor;
				this.ColorTextField.ResignFirstResponder();
			});
			toolbar.SetItems(new UIBarButtonItem[]{doneButton}, true);

			// Tell the textbox to use the picker for input
			this.ColorTextField.InputView = picker;

			// Display the toolbar over the pickers
			this.ColorTextField.InputAccessoryView = toolbar;
		}
	}
}

