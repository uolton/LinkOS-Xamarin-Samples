﻿/***********************************************
 * CONFIDENTIAL AND PROPRIETARY 
 * 
 * The source code and other information contained herein is the confidential and exclusive property of
 * ZIH Corp. and is subject to the terms and conditions in your end user license agreement.
 * This source code, and any other information contained herein, shall not be copied, reproduced, published, 
 * displayed or distributed, in whole or in part, in any medium, by any means, for any purpose except as
 * expressly permitted under such license agreement.
 * 
 * Copyright ZIH Corp. 2018
 * 
 * ALL RIGHTS RESERVED
 ***********************************************/

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using XamarinPrintStation.Droid;

[assembly: ExportRenderer(typeof(Xamarin.Forms.Button), typeof(ZebraButtonRenderer))]
namespace XamarinPrintStation.Droid {
    public class ZebraButtonRenderer : ButtonRenderer {
        public ZebraButtonRenderer(Context context) : base(context) {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e) {
            base.OnElementChanged(e);

            if (Control != null) {
                SetBackgroundColor();

                Control.SetTextColor(Color.White.ToAndroid());
                Control.StateListAnimator = null;
            }
        }

        protected override void OnElementPropertyChanged(object sender, PropertyChangedEventArgs e) {
            base.OnElementPropertyChanged(sender, e);

            if (e.PropertyName == nameof(Xamarin.Forms.Button.IsEnabled) && Control != null) {
                SetBackgroundColor();
            }
        }

        private void SetBackgroundColor() {
            Control.SetBackgroundColor(Element != null && Element.IsEnabled ? ZebraColor.ZebraBlue.ToAndroid() : ZebraColor.ZebraBlueDisabled.ToAndroid());
        }
    }
}