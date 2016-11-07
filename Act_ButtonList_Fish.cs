
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
using Android.Support.V4.App;
using Android.Support.V4.View;

namespace Akva20150407
{
	[Activity (Label = "Act_Button_Fisk")]			
	public class Act_Button_Fisk : Activity
	{
	
	    int NUM_ITEMS = 10;

		private ViewPager _viewPager;
		private ViewPagerAdapter _adapter;

    	ViewPager mPager;
	
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			/*
			SetContentView(Resource.Layout.Layout_list_search);
			SetContentView(Resource.Layout.Layout_list_search);
			
			_viewPager = FindViewById<ViewPager> (Resource.Id.viewPager);
			_adapter = new ViewPagerAdapter (this, _viewPager, SupportFragmentManager);
			_viewPager.Adapter = _adapter; 

			mAdapter = new Akva20150407.Act_Button_Fisk.MyAdapter(Android.App.FragmentManager);

			mPager = (ViewPager) FindViewById(Resource.Id.Pager);
			mPager.Adapter=mAdapter;*/
		}

		/*
    public class ArrayListFragment : Android.App.ListFragment {
		int mNum;	

		Akva20150407.Act_Button_Fisk.ArrayListFragment newInstance(int num) {
	    //Log.i("Act_ButtonList_Fish", "ArrayListFragment newInstance " + num);
	    Akva20150407.Act_Button_Fisk.ArrayListFragment f = new Akva20150407.Act_Button_Fisk.ArrayListFragment();

	    // Supply num input as an argument.
	    Bundle args = new Bundle();
	    args.PutInt("num", num);
	    f.SetArguments(args);

	    return f;
	}

			public override void OnCreate(Bundle savedInstanceState) {
	    //Log.i("Act_ButtonList_Fish_Search", "ArrayListFragment 1 onCreate " + savedInstanceState);
	    base.OnCreate(savedInstanceState);
	    mNum = GetArguments() != null ? GetArguments().GetInt("num") : 1;
	}

			public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState) {
	    //Log.i("Act_ButtonList_Fish_Search", "ArrayListFragment 2 onCreateView " + savedInstanceState);
	    View v = inflater.inflate(R.layout.layout_list_search, container, false);
	    //Log.i("Act_ButtonList_Fish_Search", "ArrayListFragment 2 onCreateView v=" + v);
	    final View tv = v.findViewById(R.id.searchbox);
	    //final CharSequence searchphrase;

	    //int temp = pack_fishy.Array_Fish.Total_FishFilled;
	    //Log.i("Act_ButtonList_Fish_Search", "ArrayListFragment 2 onCreateView species listed=" + temp);
	    //Log.i("Act_ButtonList_Fish_Search", "ArrayListFragment 2 onCreateView tv=" + tv);
	    //((TextView) tv).setText(temp + " species listed");
	    return v;
	}

	
			public override void OnActivityCreated(Bundle savedInstanceState) {
	    super.onActivityCreated(savedInstanceState);
	    Context c = getActivity();
	    int i = android.R.layout.simple_list_item_1;
	    //Array_Fish Array_Fish = new Array_Fish(false, "search");
	    Array_Fish_Singleton.getInstance().updateLists(false, "search");
	    String[] s = Array_Fish_Singleton.FishNames_Sorted;
	    //Log.i("Act_ButtonList_Fish_Search","Context="+c);
	    //Log.i("Act_ButtonList_Fish_Search","int="+i);
	    //Log.i("Act_ButtonList_Fish_Search","String[]="+s);
	    ArrayAdapter AA = new ArrayAdapter<String>(c, i, s);
	    SetListAdapter(AA);
	}

	
		public override void OnListItemClick(ListView l, View v, int position, long id) {
		    //Log.i("Act_ButtonList_Fish_Search", "ArrayListFragment onListItemClick " + position);
				Intent intent = new Intent(v.getContext(), typeof(Act_FishInfo));
		    HashMap<String, Object> hashmap = new HashMap<String, Object>();
		    //Array_Fish Array_Fish = new Array_Fish(true, "");
		    //Array_Fish_Singleton.getInstance().updateLists(true, "");
		    String FishNameSelected = Array_Fish_Singleton.FishNames_Sorted[(int) id];
		    //Log.i("Act_ButtonList_Fish_Match", "ArrayListFragment onListItemClick FishNameSelected " + FishNameSelected);
		    hashmap = Array_Fish_Singleton.getFishHashmap(FishNameSelected);
		    intent.putExtra("hashmap", hashmap);
		    startActivity(intent);
    	}*/
		}
}

