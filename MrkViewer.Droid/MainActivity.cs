﻿using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using MrkViewer.Core;

namespace MrkViewer.Droid
{
    // http://stackoverflow.com/questions/11152838/why-isnt-my-app-on-the-list-of-apps-to-open-txt-file
    [Activity(Label = "MrkViewer",
        MainLauncher = true, Icon = "@drawable/icon")]
    [IntentFilter(
        new[] { Intent.ActionView },
        Categories = new[]
        { 
            Intent.CategoryDefault,
            Intent.CategoryBrowsable,
        },
        DataScheme="file",
        DataMimeType="*/*",
        DataPathPattern=".*\\.md"
    )]
    public class MainActivity : Xamarin.Forms.Platform.Android.FormsApplicationActivity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            //Intent intent = Intent;
            string action = Intent.Action;
            string type = Intent.Type;

            if (Intent.ActionSend.Equals(action) && !String.IsNullOrEmpty(type))
            {
                Android.Net.Uri fileUri = (Android.Net.Uri)Intent.GetParcelableExtra(Intent.ExtraStream);
                if (fileUri != null)
                {
                    using (var fileInput = ContentResolver.OpenInputStream(fileUri))
                    {

                    }
                }
            }


            global::Xamarin.Forms.Forms.Init(this, bundle);
            var app = new MrkViewerApp();
            LoadApplication(app);
        }
    }
}

