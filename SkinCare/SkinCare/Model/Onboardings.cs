using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace SkinCare.Model
{
    public class Onboardings
    {
        public object ImagePath { get; set; }
        public string Header { get; set; }
        public string Content { get; set; }
        public View CarouselItems { get; set; }
    }
}
