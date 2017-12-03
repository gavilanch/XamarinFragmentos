using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;
using Android.Graphics;

namespace XamarinFragmentos.Fragmentos
{
    public class FragmentSimple : Fragment
    {
        private readonly string mensaje;
        private readonly string color;

        public FragmentSimple(string mensaje, string color)
        {
            this.mensaje = mensaje;
            this.color = color;
        }

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            var view = inflater.Inflate(Resource.Layout.fragmentSimple, container, false);

            var txtTitle = view.FindViewById<TextView>(Resource.Id.txtTitle);
            txtTitle.Text = mensaje;

            var linearLayout = view.FindViewById<LinearLayout>(Resource.Id.linearLayout);
            linearLayout.SetBackgroundColor(Color.ParseColor(color));

            return view;

        }
    }
}