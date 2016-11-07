package md53a2f3ebebcc4fab54de8c0323a278ce4;


public class Act_Button_Fisk
	extends android.app.Activity
	implements
		mono.android.IGCUserPeer
{
	static final String __md_methods;
	static {
		__md_methods = 
			"n_onCreate:(Landroid/os/Bundle;)V:GetOnCreate_Landroid_os_Bundle_Handler\n" +
			"";
		mono.android.Runtime.register ("Akva20150407.Act_Button_Fisk, Akva20150407, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", Act_Button_Fisk.class, __md_methods);
	}


	public Act_Button_Fisk () throws java.lang.Throwable
	{
		super ();
		if (getClass () == Act_Button_Fisk.class)
			mono.android.TypeManager.Activate ("Akva20150407.Act_Button_Fisk, Akva20150407, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null", "", this, new java.lang.Object[] {  });
	}


	public void onCreate (android.os.Bundle p0)
	{
		n_onCreate (p0);
	}

	private native void n_onCreate (android.os.Bundle p0);

	java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
