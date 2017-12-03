using Android.App;
using Android.Widget;
using Android.OS;
using XamarinMultiPane.Fragments;

namespace XamarinMultiPane
{
    [Activity(Label = "XamarinMultiPane", MainLauncher = true)]
    public class MainActivity : Activity, IOnHeadlineSelectedListener
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);

            // Si el FrameLayout existe, entonces estamos en un
            // dispositivo pequeño
            if (FindViewById(Resource.Id.fragment_container) != null)
            {
                if (savedInstanceState != null)
                {
                    return;
                }

                HeadlinesFragment firstFragment = new HeadlinesFragment();
                //firstFragment.Arguments = Intent.Extras;

                FragmentManager.BeginTransaction()
                        .Add(Resource.Id.fragment_container, firstFragment).Commit();
            }

        }

        public void OnArticleSelected(int position)
        {
            ArticleFragment articleFrag =  FragmentManager.FindFragmentById<ArticleFragment>(Resource.Id.article_fragment);

            if (articleFrag != null)
            {
                articleFrag.updateArticleView(position);
            }
            else
            {
                ArticleFragment newFragment = new ArticleFragment();
                Bundle args = new Bundle();
                args.PutInt(ArticleFragment.ARG_POSITION, position);
                newFragment.Arguments = args;
                FragmentTransaction transaction = FragmentManager.BeginTransaction();

                // Replace whatever is in the fragment_container view with this fragment,
                // and add the transaction to the back stack so the user can navigate back
                transaction.Replace(Resource.Id.fragment_container, newFragment);
                transaction.AddToBackStack(null);

                // Commit the transaction
                transaction.Commit();
            }
        }

    }
}

