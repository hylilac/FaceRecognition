using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content;
using Android.Provider;
using Android.Content.PM;
using System.Collections.Generic;

namespace FaceRecognition
{
    [Activity(Label = "FaceRecognition", MainLauncher = true, Icon = "@drawable/icon", Theme = "@style/MyTheme")]
    public class MainActivity : Activity
    {
        private ImageView picture;
        private Button takePhoto;
        private Toolbar toolbar;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);
            takePhoto = FindViewById<Button>(Resource.Id.take_photo);
            picture = FindViewById<ImageView>(Resource.Id.picture);
            SetActionBar(toolbar);
            ActionBar.Title = "人脸比对";
            ActionBar.SetDisplayHomeAsUpEnabled(true);
            takePhoto.Click += (s, e) =>
            {
                Intent intent = new Intent(MediaStore.ActionImageCapture);
                StartActivity(intent);
            };            

        }

        private bool IsThereAnAppToTakePictures()
        {
            Intent intent = new Intent(MediaStore.ActionImageCapture);
            IList<ResolveInfo> availableActivities = PackageManager.QueryIntentActivities(intent, PackageInfoFlags.MatchDefaultOnly);
            return availableActivities != null && availableActivities.Count > 0;
        }
    }
}

