
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
using Android.Content.PM;

using Xamarin.ActionbarSherlockBinding;


using IMenu = Xamarin.ActionbarSherlockBinding.Views.IMenu;
using IMenuItem = Xamarin.ActionbarSherlockBinding.Views.IMenuItem;
using MenuItem = Xamarin.ActionbarSherlockBinding.Views.MenuItem;
using ISubMenu = Xamarin.ActionbarSherlockBinding.Views.ISubMenu;
using Xamarin.ActionbarSherlockBinding.App;

namespace Akva20150407
{
	[Activity (Label = "Support13Demos")]			
	public class Support13Demos : SherlockListActivity
	{

		protected override void OnCreate (Bundle savedInstanceState)
		{
			base.OnCreate (savedInstanceState);

			
			String path = Intent.GetStringExtra ("com.pynting.akvaapp.apis.Path");

			if (path == null) {
				path = "";
			}

			ListAdapter = new SimpleAdapter (this, GetData (path),
				Android.Resource.Layout.SimpleListItem1, new String[] { "title" },
				new int[] { Android.Resource.Id.Text1 });
			ListView.TextFilterEnabled = true;
		}

		protected List<IDictionary<String, Object>> GetData (string prefix)
		{
			List<IDictionary<String, Object>> myData = new List<IDictionary<String, Object>> ();

			Intent mainIntent = new Intent (Intent.ActionMain, null);
			mainIntent.AddCategory ("com.pynting.akvaapp.SUPPORT13_SAMPLE_CODE");

			PackageManager pm = PackageManager;
			var list = pm.QueryIntentActivities (mainIntent, 0);

			if (null == list)
				return myData;

			String[] prefixPath;
			String prefixWithSlash = prefix;

			if (prefix == "") {
				prefixPath = null;
			} else {
				prefixPath = prefix.Split ('/');
				prefixWithSlash = prefix + "/";
			}

			int len = list.Count ();

			IDictionary<String, Boolean> entries = new JavaDictionary<String, Boolean> ();

			for (int i = 0; i < len; i++) {
				ResolveInfo info = list [i];
				var labelSeq = info.LoadLabel (pm);
				String label = labelSeq != null
					? labelSeq.ToString ()
					: info.ActivityInfo.Name;

				if (prefixWithSlash.Length == 0 || label.StartsWith (prefixWithSlash)) {

					String[] labelPath = label.Split ('/');

					String nextLabel = prefixPath == null ? labelPath [0] : labelPath [prefixPath.Length];

					if ((prefixPath != null ? prefixPath.Length : 0) == labelPath.Length - 1) {
						AddItem (myData, nextLabel, ActivityIntent (
							info.ActivityInfo.ApplicationInfo.PackageName,
							info.ActivityInfo.Name));
					} else {
						if (entries.ContainsKey (nextLabel)) {
							AddItem (myData, nextLabel, BrowseIntent (prefix == "" ? nextLabel : prefix + "/" + nextLabel));
							entries [nextLabel] = true;
						}
					}
				}
			}

			myData.Sort (sDisplayNameComparator);

			return myData;
		}

		static string ToString (Object obj)
		{
			return obj != null ? obj.ToString () : null;
		}

		private readonly static Comparison<IDictionary<string, object>> sDisplayNameComparator = (map1, map2) => {
			return string.Compare (ToString (map1 ["title"]), ToString (map2 ["title"]));
		};

		protected Intent ActivityIntent (String pkg, String componentName)
		{
			Intent result = new Intent ();
			result.SetClassName (pkg, componentName);
			return result;
		}

		protected Intent BrowseIntent (String path)
		{
			Intent result = new Intent ();
			result.SetClass (this, typeof(Support13Demos));
			result.PutExtra ("com.pynting.akvaapp.apis.Path", path);
			return result;
		}

		protected void AddItem (List<IDictionary<String, Object>> data, String name, Intent intent)
		{
			var temp = new JavaDictionary<string, Object> ();
			temp ["title"] = name;
			temp ["intent"] = intent;
			data.Add (temp);
		}

		protected override void OnListItemClick (ListView l, View v, int position, long id)
		{
			var map = (IDictionary<String, Object>)l.GetItemAtPosition (position);
			Intent intent = (Intent)map ["intent"];
			StartActivity (intent);
		}

	}
}

