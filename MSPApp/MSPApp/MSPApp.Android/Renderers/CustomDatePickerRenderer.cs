using System;
using Android.Graphics.Drawables;
using MSPApp.Controls;
using MSPApp.Droid.Renderers;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomDatePicker), typeof(CustomDatePickerRenderer))]
namespace MSPApp.Droid.Renderers
{
    public class CustomDatePickerRenderer : DatePickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        {
            base.OnElementChanged(e);

            if (Control == null || e.NewElement == null) return;

            if (!(e.NewElement is CustomDatePicker extPicker)) return;
            if (e.OldElement != null) return;

            //var gradient = new GradientDrawable();
            //gradient.SetColor(Color.White.ToAndroid());
            //gradient.SetCornerRadius(10);
            //gradient.SetStroke(1, Color.Gray.ToAndroid());

            Element.MinimumDate = DateTime.Today;
            //Control.SetBackground(gradient);
        }

    }
}