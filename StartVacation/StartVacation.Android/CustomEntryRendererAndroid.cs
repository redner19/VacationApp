using Android.Content;
using StartVacation.Droid;
using StartVacation.Utils.CustomRenderer;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntry), typeof(CustomEntryRendererAndroid))]
namespace StartVacation.Droid
{
    class CustomEntryRendererAndroid : EntryRenderer
    {
        public CustomEntryRendererAndroid(Context context): base(context){}

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if(e.OldElement == null)
            {
                Control.Background = null;
            }
        }
    }
}