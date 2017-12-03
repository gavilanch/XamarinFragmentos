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
    [Activity(Label = "BackstackActivity", MainLauncher = true)]
    public class BackstackActivity : Activity
    {
        private FragmentSimple fragmento1;
        private FragmentSimple fragmento2;
        private FragmentSimple fragmento3;
        private FragmentSimple fragmento4;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Backstack);

            fragmento1 = new FragmentSimple("fragmento1", "red");
            fragmento2 = new FragmentSimple("fragmento2", "purple");
            fragmento3 = new FragmentSimple("fragmento3", "green");
            fragmento4 = new FragmentSimple("fragmento4", "gray");

            PrepararBotones();

        }

        private void PrepararBotones()
        {
            var btnAdd1 = FindViewById<Button>(Resource.Id.btnAdd1);
            btnAdd1.Click += BtnAdd1_Click;

            var btnRemove1 = FindViewById<Button>(Resource.Id.btnRemove1);
            btnRemove1.Click += BtnRemove1_Click;

            var btnAdd2 = FindViewById<Button>(Resource.Id.btnAdd2);
            btnAdd2.Click += BtnAdd2_Click;

            var btnAdd3 = FindViewById<Button>(Resource.Id.btnAdd3);
            btnAdd3.Click += BtnAdd3_Click;

            var btnAdd4 = FindViewById<Button>(Resource.Id.btnAdd4);
            btnAdd4.Click += BtnAdd4_Click;

            var btnDeshacer = FindViewById<Button>(Resource.Id.btnDeshacer);
            btnDeshacer.Click += BtnDeshacer_Click;
        }

        private void BtnAdd1_Click(object sender, EventArgs e)
        {
            var transaction = FragmentManager.BeginTransaction();
            transaction.Add(Resource.Id.fragmentContainer, fragmento1, "fragmento1");
            transaction.AddToBackStack("fragmento1");
            transaction.Commit();
        }


        private void BtnRemove1_Click(object sender, EventArgs e)
        {
            var fragment = FragmentManager.FindFragmentByTag<FragmentSimple>("fragmento1");
            if (fragment != null)
            {
                var transaction = FragmentManager.BeginTransaction();
                transaction.Remove(fragment);
                transaction.AddToBackStack("remove1");
                transaction.Commit();
            }
        }

        private void BtnAdd2_Click(object sender, EventArgs e)
        {
            var transaction = FragmentManager.BeginTransaction();
            transaction.Add(Resource.Id.fragmentContainer, fragmento2, "fragmento2");
            transaction.AddToBackStack("fragmento2");
            transaction.Commit();
        }

        private void BtnAdd3_Click(object sender, EventArgs e)
        {
            var transaction = FragmentManager.BeginTransaction();
            transaction.Add(Resource.Id.fragmentContainer, fragmento3, "fragmento3");
            transaction.AddToBackStack("fragmento3");
            transaction.Commit();
        }

        private void BtnAdd4_Click(object sender, EventArgs e)
        {
            var transaction = FragmentManager.BeginTransaction();
            transaction.Add(Resource.Id.fragmentContainer, fragmento4, "fragmento4");
            transaction.AddToBackStack("fragmento4");
            transaction.Commit();
        }

        private void BtnDeshacer_Click(object sender, EventArgs e)
        {
            // Simplemente remueve la última transacción
            //FragmentManager.PopBackStack();

            // Me regresa hasta la transacción fragmento1
            //FragmentManager.PopBackStack("fragmento1", PopBackStackFlags.None);

            // Revierte todas las transacciones incluida la de fragmento1
            FragmentManager.PopBackStack("fragmento1", PopBackStackFlags.Inclusive);

        }
    }
}