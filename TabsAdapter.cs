using System.Collections.Generic;
using Android.Content;
using Android.OS;
using Android.Views;
using Android.Widget;
using Android.Support.V4.App;
using Java.Lang;
using Android.Support.V4.View;

namespace Akva20150407
{

	public class TabsAdapter : FragmentPagerAdapter, TabHost.IOnTabChangeListener, ViewPager.IOnPageChangeListener
	{
		private readonly Context _context;
		private readonly TabHost _tabHost;
		private readonly ViewPager _viewPager;
		private readonly List<TabInfo> _tabs = new List<TabInfo> ();

		public class TabInfo
		{
			public string Tag;
			public Class Class;
			public Bundle Args;

			public Fragment Fragment { get; set; }

			public TabInfo (string tag, Class _class, Bundle args)
			{
				Tag = tag;
				Class = _class;
				Args = args;
			}
		}

		public class DummyTabFactory : Object, TabHost.ITabContentFactory
		{
			private readonly Context _context;

			public DummyTabFactory (Context context)
			{
				_context = context;
			}

			public View CreateTabContent (string tag)
			{
				var v = new View (_context);
				v.SetMinimumHeight (0);
				v.SetMinimumWidth (0);
				return v;
			}
		}

		public TabsAdapter (FragmentActivity activity, TabHost tabHost, ViewPager pager)
			: base (activity.SupportFragmentManager)
		{
			_context = activity;
			_tabHost = tabHost;
			_viewPager = pager;
			_tabHost.SetOnTabChangedListener (this);
			_viewPager.Adapter = this;
			_viewPager.SetOnPageChangeListener (this);
		}

		public void AddTab (TabHost.TabSpec tabSpec, Class clss, Bundle args)
		{
			tabSpec.SetContent (new DummyTabFactory (_context));
			var tag = tabSpec.Tag;
			var info = new TabInfo (tag, clss, args);
			_tabs.Add (info);
			_tabHost.AddTab (tabSpec);
			NotifyDataSetChanged ();
		}

		public override int Count {
			get {
				return _tabs.Count;
			}
		}

		public override Fragment GetItem (int position)
		{
			var info = _tabs [position];
			return Fragment.Instantiate (_context, info.Class.Name, info.Args);
		}

		public void OnTabChanged (string tabId)
		{
			var position = _tabHost.CurrentTab;
			_viewPager.CurrentItem = position;
		}

		public void OnPageScrolled (int position, float positionOffset, int positionOffsetPixels)
		{
		}

		public void OnPageSelected (int position)
		{

			var widget = _tabHost.TabWidget;
			var oldFocusability = widget.DescendantFocusability;
			widget.DescendantFocusability = DescendantFocusability.BlockDescendants;
			_tabHost.CurrentTab = position;
			widget.DescendantFocusability = oldFocusability;
		}

		public void OnPageScrollStateChanged (int state)
		{
		}
	}
}