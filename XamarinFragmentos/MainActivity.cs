using Android.App;
using Android.Widget;
using Android.OS;
using XamarinFragmentos.Fragmentos;

namespace XamarinFragmentos
{
    [Activity(Label = "XamarinFragmentos", MainLauncher = false)]
    public class MainActivity : Activity
    {
        private FragmentCaps fragment;
        private TextView txtActivity;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            PrepararBotones();

            fragment = new FragmentCaps();
            var transaction = FragmentManager.BeginTransaction();
            transaction.Add(Resource.Id.fragmentCapsContainer, fragment);
            transaction.Commit();
        }

        private void PrepararBotones()
        {
            txtActivity = FindViewById<TextView>(Resource.Id.txtActivity);
            var btnEnviarFragmento = FindViewById<Button>(Resource.Id.btnEnviarAlFragmento);
            btnEnviarFragmento.Click += BtnEnviarFragmento_Click;

            var btnLimpiar = FindViewById<Button>(Resource.Id.btnLimpiar);
            btnLimpiar.Click += BtnLimpiar_Click;
        }

        private void BtnEnviarFragmento_Click(object sender, System.EventArgs e)
        {
            fragment.AsignarTexto(txtActivity.Text);
        }

        private void BtnLimpiar_Click(object sender, System.EventArgs e)
        {
            fragment.Limpiar();
        }
    }
}

