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

namespace XamarinFragmentos.Fragmentos
{
    public class FragmentSender : Fragment
    {
        private EditText txtMensaje;
        private IManejadorMensaje manejadorMensaje;

        public override void OnAttach(Context context)
        {
            base.OnAttach(context);
           
            manejadorMensaje = (IManejadorMensaje)context;
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment
            var view =inflater.Inflate(Resource.Layout.fragmentSender, container, false);

            txtMensaje = view.FindViewById<EditText>(Resource.Id.txtMensaje);
            var btnEnviar = view.FindViewById<Button>(Resource.Id.btnEnviar);
            btnEnviar.Click += BtnEnviar_Click;

            return view;

        }

        private void BtnEnviar_Click(object sender, EventArgs e)
        {
            manejadorMensaje.ProcesarMensaje(txtMensaje.Text);
        }
    }
}