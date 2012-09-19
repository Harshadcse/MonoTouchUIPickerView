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
			PickerModel model = new PickerModel(this.colors);
			model.PickerChanged += (sender, e) => {
				this.selectedColor = e.SelectedValue;
			};

			UIPickerView picker = new UIPickerView();
			picker.ShowSelectionIndicator = true;
			picker.Model = model;

			this.ColorTextField.InputView = picker;
		}
	}
}

