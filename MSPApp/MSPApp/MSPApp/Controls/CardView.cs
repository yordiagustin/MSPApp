using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MSPApp.Controls
{
    public class CardView : Frame
    {
        public CardView()
        {
            Padding = 0;
            if (Device.RuntimePlatform != Device.iOS) return;

            HasShadow = false;
            OutlineColor = Color.Transparent;
            BackgroundColor = Color.Transparent;
        }
    }
}
