using Android.Content;
using Android.Graphics.Drawables;
using SkinCare.Droid.Renderers;
using SkinCare.Renderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Color = Android.Graphics.Color;

[assembly: ExportRenderer(typeof(BorderlessEntry), typeof(BorderlessEntryAndroid))]
namespace SkinCare.Droid.Renderers
{
    public class BorderlessEntryAndroid : EntryRenderer
    {
        public BorderlessEntryAndroid(Context context) : base(context) { }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (Control != null)
            {
                GradientDrawable gradientDrawable = new GradientDrawable();
                gradientDrawable.SetColor(Color.Transparent);
                Control.SetBackground(gradientDrawable);
            }
        }
    }
}