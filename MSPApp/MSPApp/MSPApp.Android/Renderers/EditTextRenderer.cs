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
using MSPApp.Controls;
using MSPApp.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(EditTextRenderer))]
namespace MSPApp.Droid.Renderers
{
    public class EditTextRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (Control != null)
            {
                Control.Background = Android.App.Application.Context.GetDrawable(Resource.Xml.rounded_corners);
                Control.Gravity = GravityFlags.Left;
                Control.SetPadding(30, 40, 0, 40);
            }
        }
    }
}