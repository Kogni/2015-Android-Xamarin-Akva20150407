using Android.App;
using Android.Widget;
using Android.OS;
using Android.Support.V4.View;

namespace Akva20150407
{
	[Activity (Label = "Act_MainGUI")]			
	public class Act_MainGUI : Activity
//	public class Act_MainGUI : FragmentActivity
	{
		//ViewPager mViewPager;
		//TabsAdapter mTabsAdapter;

		//ActionBar.Tab Tab1, Tab2, Tab3;

		/*private readonly Context _context;
		private readonly TabHost _tabHost;
		private readonly ViewPager _viewPager;*/
		//private readonly List<TabInfo> _tabs = new List<TabInfo> ();

		//Frag_Aquarium akvarie = new Frag_Aquarium();
		//int count = 1;

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			SetContentView (Resource.Layout.Layout_frame);
			Button fishbuttonlist3 = FindViewById<Button> (Resource.Id.button_browse);
			fishbuttonlist3.Click += delegate {
				StartActivity(typeof(Act_Button_Fisk));
			};

			//RequestWindowFeature (WindowFeatures.ActionBar);
			//SetContentView (Resource.Layout.Main);
			//InitializeActionBar ();

			//mViewPager = new ViewPager(this);
			//mViewPager.SetId(Resource.Id.Pager);
			//SetContentView(mViewPager);

			/*var Tab1 = ActionBar.NewTab();
			ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
			Tab1.SetText("Match list");
			Tab1.SetTabListener(
				new TabListener<CrumbsOverviewFragment>());
			ActionBar.AddTab(homeTab);*/
			//bar.SetDisplayOptions(0, ActionBar.DISPLAY_SHOW_TITLE);

			//Intent intent = Intent();
			//Dictionary<String, Object> hashMap = (Dictionary<String, Object>) intent.GetSerializableExtra("hashmap");
			//Controller class_Controller = Controller.GetInstance();
			//Log.i("-----Act_MainGUI", "OnCreateView hashMap=" + class_Aquarium.hashmap); <-- vellykket
			//Bundle bundle = new Bundle();
			//bundle.PutSerializable("hashMap", (Serializable) class_Aquarium.hashmap);
			//bundle.PutString("name", "From Activity");
			//Frag_Aquarium fragobj = new Frag_Aquarium();
			//fragobj.SetArguments(bundle);

			//bar.SetDisplayShowHomeEnabled(false);
			//bar.SetDisplayShowTitleEnabled(false);

			//Array_Fish_Singleton.GetInstance();

			//mTabsAdapter = new TabsAdapter(this, mViewPager);
			//mTabsAdapter.AddTab(bar.NewTab().SetText("Search"), typeof(Act_ButtonList_Fish_Search.ListFragment), bundle);
			//mTabsAdapter.AddTab(bar.NewTab().SetText("Match list"), typeof(Act_ButtonList_Fish_Match.ListFragment), bundle);
			//mTabsAdapter.AddTab(bar.NewTab().SetText("Full list"), typeof(Act_ButtonList_Fish.ListFragment), bundle);
			//mTabsAdapter.AddTab(bar.NewTab().SetText("Your tank"), typeof(Frag_Aquarium), bundle);
			//mTabsAdapter.AddTab(bar.NewTab().SetText("Frag_Tabs"), typeof(Frag_Tabs), bundle);

			/*if (savedInstanceState != null) {
				bar.SetSelectedNavigationItem(savedInstanceState.GetInt("tab", 0));
			}*/

			//GetWindow().GetDecorView().SetBackgroundColor(Color.Rgb(0, 0, 100));
			//InitializeActionBar ();
		}

		/*
		public class TabInfo
		{
			public string Tag;
			public Class Class;
			public Bundle Args;

			public Android.App.Fragment Fragment { get; set; }

			public TabInfo (string tag, Class _class, Bundle args)
			{
				Tag = tag;
				Class = _class;
				Args = args;
			}
		}*/

		/*public class DummyTabFactory : Object, TabHost.ITabContentFactory
		{
			private readonly Context _context;
			public DummyTabFactory(Context context)
			{
				_context = context;
			}
			public View CreateTabContent(string tag)
			{
				var v = new View(_context);
				v.SetMinimumHeight(0);
				v.SetMinimumWidth(0);
				return v;
			}
		}*/



		/*private void InitializeActionBar ()
		{

			ActionBar.NavigationMode = ActionBarNavigationMode.Tabs;
			var homeTab = ActionBar.NewTab ();
			/*homeTab.SetTabListener(
				new TabListener<CrumbsOverviewFragment>());
			homeTab.SetText (Resource.String.topic_button_browse);
			//homeTab.TabSelected += OnTabSelected;
			ActionBar.AddTab (homeTab);
		}*/
			
		/*protected override void onSaveInstanceState(Bundle outState) {
			base.OnSaveInstanceState(outState);
			outState.PutInt("tab", GetActionBar().GetSelectedNavigationIndex());
		}*/

		/*public static class TabsAdapter : FragmentPagerAdapter, TabListener, OnPageChangeListener {
			private   Context mContext;
			private   ActionBar mActionBar;
			private   ViewPager mViewPager;
			private   IList<TabInfo> mTabs = new IList<TabInfo>();

			static   class TabInfo {
				private   Class<?> clss;
				private   Bundle args;

				TabInfo(Class<?> _class, Bundle _args) {
					clss = _class;
					args = _args;
				}
			}

			public TabsAdapter(FragmentActivity activity, TabHost tabHost, ViewPager pager)
				: base(activity.SupportFragmentManager)
			{
				_context = activity;
				_tabHost = tabHost;
				_viewPager = pager;
				_tabHost.SetOnTabChangedListener(this);
				_viewPager.Adapter = this;
				_viewPager.SetOnPageChangeListener(this);
			}
			/*
			public TabsAdapter(Activity activity, ViewPager pager) {
				base(getFragmentManager());
				mContext = activity;
				mActionBar = activity.GetActionBar();
				mViewPager = pager;
				mViewPager.SetAdapter(this);
				mViewPager.SetOnPageChangeListener(this);
			}

			public void AddTab(TabHost.TabSpec tabSpec, Class clss, Bundle args)
			{
				tabSpec.SetContent(new DummyTabFactory(_context));
				var tag = tabSpec.Tag;
				var info = new TabInfo(tag, clss, args);
				_tabs.Add(info);
				_tabHost.AddTab(tabSpec);
				NotifyDataSetChanged();
			}
			/*
			public void AddTab(ActionBar.Tab tab, Class<?> clss, Bundle args) {
				TabInfo info = new TabInfo(clss, args);
				tab.SetTag(info);
				tab.SetTabListener(this);
				mTabs.Add(info);
				mActionBar.AddTab(tab);
				NotifyDataSetChanged();
			}
				
			public override int GetCount() {
				return mTabs.Count();
			}
			public override Fragment GetItem(int position)
			{
				var info = _tabs[position];
				return Fragment.Instantiate(_context, info.Class.Name, info.Args);
			}

			/*public override Fragment GetItem(int position) {
				TabInfo info = mTabs.Get(position);
				return Fragment.Instantiate(mContext, info.Class.Name, info.Args);
			}
				
			public override void OnPageScrolled(int position, float positionOffset, int positionOffsetPixels) {
			}
				
			public override void OnPageSelected(int position) {
				mActionBar.SetSelectedNavigationItem(position);
			}
				
			public override void OnPageScrollStateChanged(int state) {
			}
				
			public override void OnTabSelected(Tab tab, FragmentTransaction ft) {
				Object tag = tab.GetTag();
				for (int i = 0; i < mTabs.Count(); i++) {
					if (mTabs.Get(i) == tag) {
						mViewPager.SetCurrentItem(i);
					}
				}
			}
				
			public override void OnTabUnselected(Tab tab, FragmentTransaction ft) {
			}
				
			public override void OnTabReselected(Tab tab, FragmentTransaction ft) {
			}
		}*/

		/*public class TabListener<T> : Java.Lang.Object, ActionBar.ITabListener
			where T: Fragment, new()
		{
			private T _fragment;

			/// <summary>
			/// initializes a new instance of the tab listener
			/// </summary>
			public TabListener()
			{
				_fragment = new T();
			}

			/// <summary>
			/// Initializes a new instance of the tab listener
			/// </summary>
			/// <param name="fragment"></param>
			protected TabListener(T fragment)
			{
				_fragment = fragment;
			}

			/// <summary>
			/// Handles the reselection of the tab
			/// </summary>
			/// <param name="tab"></param>
			/// <param name="ft"></param>
			public void OnTabReselected(ActionBar.Tab tab, FragmentTransaction ft)
			{

			}

			/// <summary>
			/// Adds the fragment when the tab was selected
			/// </summary>
			/// <param name="tab"></param>
			/// <param name="ft"></param>
			public void OnTabSelected(ActionBar.Tab tab, FragmentTransaction ft)
			{
				ft.Add(Resource.Id.MainFragmentContainer,_fragment, typeof(T).FullName);
			}

			/// <summary>
			/// Removes the fragment when the tab was deselected
			/// </summary>
			/// <param name="tab"></param>
			/// <param name="ft"></param>
			public void OnTabUnselected(ActionBar.Tab tab, FragmentTransaction ft)
			{
				ft.Remove( _fragment);
			}
		}*/
	}
}

