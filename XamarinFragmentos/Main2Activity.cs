using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using XamarinFragmentos.Fragmentos;

namespace XamarinFragmentos
{
    [Activity(Label = "Main2Activity", MainLauncher = false)]
    public class Main2Activity : Activity, IManejadorMensaje
    {
        private TextView txtMensaje;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main2);

            txtMensaje = FindViewById<TextView>(Resource.Id.txtMensaje);

            var fragment = new FragmentSender();
            var transaction = FragmentManager.BeginTransaction();
            transaction.Add(Resource.Id.fragmentContainer, fragment);
            transaction.Commit();
        }

        public void ProcesarMensaje(string mensaje)
        {
            txtMensaje.Text = mensaje.ToUpper();
        }
    }
}