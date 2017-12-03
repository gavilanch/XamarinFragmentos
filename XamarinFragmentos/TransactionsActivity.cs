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
    [Activity(Label = "TransactionsActivity", MainLauncher = false)]
    public class TransactionsActivity : Activity
    {
        private FragmentSimple fragmento1;
        private FragmentSimple fragmento2;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.Transaction);

            fragmento1 = new FragmentSimple("fragmento 1", "purple");
            fragmento2 = new FragmentSimple("fragmento 2", "red");

            PrepararBotones();
        }

        private void PrepararBotones()
        {
            var btnAdd1 = FindViewById<Button>(Resource.Id.btnAddFragment1);
            btnAdd1.Click += BtnAdd1_Click;

            var btnAdd2 = FindViewById<Button>(Resource.Id.btnAddFragment2);
            btnAdd2.Click += BtnAdd2_Click;

            var btnRemove1 = FindViewById<Button>(Resource.Id.btnRemoveFragment1);
            btnRemove1.Click += BtnRemove1_Click;

            var btnRemove2 = FindViewById<Button>(Resource.Id.btnRemoveFragment2);
            btnRemove2.Click += BtnRemove2_Click;

            var btnReplaceBy1 = FindViewById<Button>(Resource.Id.btnReplaceBy1);
            btnReplaceBy1.Click += BtnReplaceBy1_Click;

            var btnReplaceBy2 = FindViewById<Button>(Resource.Id.btnReplaceBy2);
            btnReplaceBy2.Click += BtnReplaceBy2_Click;

            var btnAttach1 = FindViewById<Button>(Resource.Id.btnAttach1);
            btnAttach1.Click += BtnAttach1_Click;

            var btnDetach1 = FindViewById<Button>(Resource.Id.btnDetach1);
            btnDetach1.Click += BtnDetach1_Click;

            var btnShow1 = FindViewById<Button>(Resource.Id.btnShow1);
            btnShow1.Click += BtnShow1_Click;

            var btnHide1 = FindViewById<Button>(Resource.Id.btnHide1);
            btnHide1.Click += BtnHide1_Click;
        }

        private void BtnAdd1_Click(object sender, EventArgs e)
        {
            var transaction = FragmentManager.BeginTransaction();
            transaction.Add(Resource.Id.fragmentContainer, fragmento1, "fragment1");
            transaction.Commit();
        }

        private void BtnRemove1_Click(object sender, EventArgs e)
        {
            var fragment = FragmentManager.FindFragmentByTag<FragmentSimple>("fragment1");
            if (fragment != null)
            {
                var transaction = FragmentManager.BeginTransaction();
                transaction.Remove(fragment);
                transaction.Commit();
            }
            else
            {
                Toast.MakeText(this, "fragmento 1 no encontrado", ToastLength.Short).Show();
            }
        }

        private void BtnAdd2_Click(object sender, EventArgs e)
        {
            var transaction = FragmentManager.BeginTransaction();
            transaction.Add(Resource.Id.fragmentContainer, fragmento2, "fragment2");
            transaction.Commit();
        }

        private void BtnRemove2_Click(object sender, EventArgs e)
        {
            var fragment = FragmentManager.FindFragmentByTag<FragmentSimple>("fragment2");
            if (fragment != null)
            {
                var transaction = FragmentManager.BeginTransaction();
                transaction.Remove(fragment);
                transaction.Commit();
            }
            else
            {
                Toast.MakeText(this, "fragmento 2 no encontrado", ToastLength.Short).Show();
            }
        }

        private void BtnReplaceBy1_Click(object sender, EventArgs e)
        {
            var transaction = FragmentManager.BeginTransaction();
            transaction.Replace(Resource.Id.fragmentContainer, fragmento1, "fragment1");
            transaction.Commit();
        }

        private void BtnReplaceBy2_Click(object sender, EventArgs e)
        {
            var transaction = FragmentManager.BeginTransaction();
            transaction.Replace(Resource.Id.fragmentContainer, fragmento2, "fragment2");
            transaction.Commit();
        }

        private void BtnDetach1_Click(object sender, EventArgs e)
        {
            var fragment = FragmentManager.FindFragmentByTag<FragmentSimple>("fragment1");
            if (fragment != null)
            {
                var transaction = FragmentManager.BeginTransaction();
                transaction.Detach(fragmento1);
                transaction.Commit();
            }
        }

        private void BtnAttach1_Click(object sender, EventArgs e)
        {
            var fragment = FragmentManager.FindFragmentByTag<FragmentSimple>("fragment1");
            if (fragment != null)
            {
                var transaction = FragmentManager.BeginTransaction();
                transaction.Attach(fragmento1);
                transaction.Commit();
            }
        }

        private void BtnHide1_Click(object sender, EventArgs e)
        {
            var fragment = FragmentManager.FindFragmentByTag<FragmentSimple>("fragment1");
            if (fragment != null)
            {
                var transaction = FragmentManager.BeginTransaction();
                transaction.Hide(fragmento1);
                transaction.Commit();
            }
        }

        private void BtnShow1_Click(object sender, EventArgs e)
        {
            var fragment = FragmentManager.FindFragmentByTag<FragmentSimple>("fragment1");
            if (fragment != null)
            {
                var transaction = FragmentManager.BeginTransaction();
                transaction.Show(fragmento1);
                transaction.Commit();
            }
        }


    }
}