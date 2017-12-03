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
    public class ArticleFragment : Fragment
    {
        public static readonly String ARG_POSITION = "position";
        int mCurrentPosition = -1;
        private TextView article;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Create your fragment here
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            if (savedInstanceState != null)
            {
                mCurrentPosition = savedInstanceState.GetInt(ARG_POSITION);
            }

            //return inflater.Inflate(Resource.Layout.article_view, container, false);
            var view = inflater.Inflate(Resource.Layout.article_view, container, false);
            article = view.FindViewById<TextView>(Resource.Id.article);
            return view;

        }

        public override void OnStart()
        {
            base.OnStart();
            Bundle args = Arguments;
            if (args != null)
            {
                // Set article based on argument passed in
                updateArticleView(args.GetInt(ARG_POSITION));
            }
            else if (mCurrentPosition != -1)
            {
                // Set article based on saved instance state defined during onCreateView
                updateArticleView(mCurrentPosition);
            }

        }

        public void updateArticleView(int position)
        {
          //  TextView article = (TextView)Activity.FindViewById(Resource.Id.article);
            article.Text = News.Bodies[position];
            mCurrentPosition = position;
        }

        public override void OnSaveInstanceState(Bundle outState)
        {
            base.OnSaveInstanceState(outState);
            outState.PutInt(ARG_POSITION, mCurrentPosition);
        }
    }
}