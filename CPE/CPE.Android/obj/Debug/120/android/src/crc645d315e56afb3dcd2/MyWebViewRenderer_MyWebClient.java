package crc645d315e56afb3dcd2;


public class MyWebViewRenderer_MyWebClient
	extends android.webkit.WebChromeClient
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onPermissionRequest:(Landroid/webkit/PermissionRequest;)V:GetOnPermissionRequest_Landroid_webkit_PermissionRequest_Handler\n" +
			"n_onShowCustomView:(Landroid/view/View;Landroid/webkit/WebChromeClient$CustomViewCallback;)V:GetOnShowCustomView_Landroid_view_View_Landroid_webkit_WebChromeClient_CustomViewCallback_Handler\n" +
			"";
		mono.android.Runtime.register ("CPE.Droid.MyWebViewRenderer+MyWebClient, CPE.Android", MyWebViewRenderer_MyWebClient.class, __md_methods);
	}


	public MyWebViewRenderer_MyWebClient ()
	{
		super ();
		if (getClass () == MyWebViewRenderer_MyWebClient.class)
			mono.android.TypeManager.Activate ("CPE.Droid.MyWebViewRenderer+MyWebClient, CPE.Android", "", this, new java.lang.Object[] {  });
	}

	public MyWebViewRenderer_MyWebClient (android.app.Activity p0)
	{
		super ();
		if (getClass () == MyWebViewRenderer_MyWebClient.class)
			mono.android.TypeManager.Activate ("CPE.Droid.MyWebViewRenderer+MyWebClient, CPE.Android", "Android.App.Activity, Mono.Android", this, new java.lang.Object[] { p0 });
	}

	@android.annotation.TargetApi(
value = 21)

	public void onPermissionRequest (android.webkit.PermissionRequest p0)
	{
		n_onPermissionRequest (p0);
	}

	private native void n_onPermissionRequest (android.webkit.PermissionRequest p0);


	public void onShowCustomView (android.view.View p0, android.webkit.WebChromeClient.CustomViewCallback p1)
	{
		n_onShowCustomView (p0, p1);
	}

	private native void n_onShowCustomView (android.view.View p0, android.webkit.WebChromeClient.CustomViewCallback p1);

	private java.util.ArrayList refList;
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
