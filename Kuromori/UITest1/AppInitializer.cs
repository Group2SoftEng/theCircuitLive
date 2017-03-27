﻿using System;
using System.IO;
using System.Linq;
using Xamarin.UITest;
using Xamarin.UITest.Queries;

namespace Kuromori.DataStructure
{
    public class AppInitializer
    {
        public static IApp StartApp(Platform platform)
        {
            if (platform == Platform.Android)
            {
                return ConfigureApp
                   
                    .Android
                     //.ApkFile(@"C:/Users/dharless1/Source/Repos/theCircuitLive/Kuromori.Droid.apk")
                     .ApkFile(@"C:/Users/dharless1/Source/Repos/theCircuitLive/Kuromori/Kuromori/Kuromori.Droid/bin/Debug/Kuromori.Droid.apk")
                    // .ApkFile(@"C:/Users/Daniel/Source/Repos/theCircuitLive/Kuromori/Kuromori/Kuromori.Droid/bin/Debug/Kuromori.Droid.apk")
                    .StartApp();
            }

            return ConfigureApp
                .iOS
                .StartApp();
        }
    }
}

