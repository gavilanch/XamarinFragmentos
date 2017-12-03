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

namespace XamarinMultiPane.Fragments
{
    public class HeadlinesFragment : ListFragment
    {
        IOnHeadlineSelectedListener mCallback;

        public override void OnCreate(Bundle savedInstanceState)
        {
           
            base.OnCreate(savedInstanceState);

            int layout = Build.VERSION.SdkInt >= BuildVersionCodes.Honeycomb ?
             Android.Resource.Layout.SimpleListItemActivated1 : Android.Resource.Layout.SimpleListItem1;

            ListAdapter = new ArrayAdapter<string>(Activity, layout, News.Titles);
        }

        public override void OnStart()
        {
            base.OnStart();
            
            if (FragmentManager.FindFragmentById(Resource.Id.article_fragment) != null)
            {
                ListView.ChoiceMode = ChoiceMode.Single;
            }
        }

        public override void OnAttach(Context context)
        {
            base.OnAttach(context);

            try
            {
                mCallback = (IOnHeadlineSelectedListener)context;
            }
            catch (Java.Lang.ClassCastException e)
            {
                throw new Java.Lang.ClassCastException(context.ToString()
                        + " must implement OnHeadlineSelectedListener");
            }

        }

        public override void OnListItemClick(ListView l, View v, int position, long id)
        {
            mCallback.OnArticleSelected(position);
            ListView.SetItemChecked(position, true);
        }

    }
}