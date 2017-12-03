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
    [Activity(Label = "Main3Activity", MainLauncher = false)]
    public class Main3Activity : Activity, IManejadorMensaje
    {
        private FragmentCaps fragmentCaps;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Main3);

            fragmentCaps = new FragmentCaps();
            var fragmentSender = new FragmentSender();
            var transaction = FragmentManager.BeginTransaction();

            transaction.Add(Resource.Id.contenedorIzquierdo, fragmentSender);
            transaction.Add(Resource.Id.contenedorDerecho, fragmentCaps);
            transaction.Commit();
        }

        public void ProcesarMensaje(string mensaje)
        {
            fragmentCaps.AsignarTexto(mensaje);
        }

    }
}