using Android.Support.V4.App;
using Android.Content;
using Android.Support.V4.View;
using System.Collections.Generic;
using System;
using Android.Runtime;
using Android.OS;

public class ViewPagerAdapter : FragmentStatePagerAdapter
{
	private class ViewPagerItem
	{
		public Type Type { get; set; }

		public Fragment CachedFragment { get; set; }
	}

	private readonly Context _context;
	private readonly ViewPager _viewPager;
	private readonly Dictionary<int, ViewPagerItem> _fragments = new Dictionary<int, ViewPagerItem> ();

	public ViewPagerAdapter (IntPtr javaReference, JniHandleOwnership transfer)
		: base (javaReference, transfer)
	{
	}

	public ViewPagerAdapter (Context context, ViewPager pager, FragmentManager fm)
		: base (fm)
	{
		_context = context;
		_viewPager = pager;
	}

	public override Fragment GetItem (int position)
	{
		if (!_fragments.ContainsKey (position))
			return null;
 
		var bundle = new Bundle ();
		bundle.PutInt ("number", position);
		_fragments [position].CachedFragment = Fragment.Instantiate (_context,
			FragmentJavaName (_fragments [position].Type), bundle);
		return _fragments [position].CachedFragment;
	}

	public override int Count {
		get { return _fragments.Count; }
	}

	public void AddFragment (Type fragType, int position = -1)
	{
		if (position < 0 && _fragments.Count == 0)
			position = 0;
		else if (position < 0 && _fragments.Count > 0)
			position = _fragments.Count;
 
		_fragments.Add (position, new ViewPagerItem {
			Type = fragType
		});
 
		NotifyDataSetChanged ();
	}

	public void RemoveFragment (int position)
	{
		DestroyItem (null, position, _fragments [position].CachedFragment);
		_fragments.Remove (position);
		NotifyDataSetChanged ();
		_viewPager.SetCurrentItem (position - 1, false);
	}

	protected virtual string FragmentJavaName (Type fragmentType)
	{
		var namespaceText = fragmentType.Namespace ?? "";
		if (namespaceText.Length > 0)
			namespaceText = namespaceText.ToLowerInvariant () + ".";
		return namespaceText + fragmentType.Name;
	}
} 