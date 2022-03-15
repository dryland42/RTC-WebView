using Android.Annotation;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Webkit;
using Android.Widget;
using CPE.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CPE.MyWebView), typeof(MyWebViewRenderer))]
namespace CPE.Droid
{
    public class MyWebViewRenderer : WebViewRenderer
    {
        Activity mContext;
        public MyWebViewRenderer(Context context) : base(context)
        {
            this.mContext = context as Activity;
        }
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.WebView> e)
        {
            base.OnElementChanged(e);
            if (e.NewElement != null)
            {
                var customWebView = Element as MyWebView;
                Control.Settings.MediaPlaybackRequiresUserGesture = false;
                Control.Settings.AllowUniversalAccessFromFileURLs = true;
                Control.Settings.JavaScriptEnabled = true;
                Control.Settings.SupportZoom();
                Control.Settings.SetAppCacheEnabled(true);
                Control.Settings.DomStorageEnabled = true;
                Control.Settings.JavaScriptCanOpenWindowsAutomatically = true;
                Control.ZoomOut();
                Control.ZoomIn();
                Control.Settings.BuiltInZoomControls = false;
                Control.Settings.LoadWithOverviewMode = true;
                Control.Settings.UseWideViewPort = true;
                Control.Settings.SetRenderPriority(WebSettings.RenderPriority.High);
                if (Build.VERSION.SdkInt > BuildVersionCodes.Lollipop)
                    Control.Settings.MixedContentMode = MixedContentHandling.CompatibilityMode;
                Control.Settings.SetPluginState(WebSettings.PluginState.OnDemand);
                Control.Settings.GetPluginState();
                Control.Settings.AllowFileAccess = true;
                Control.ClearCache(true);
                Control.SetWebChromeClient(new MyWebClient(mContext));
                //Control.SetWebChromeClient(new WebChromeClient());
                Control.SetWebViewClient(new WebViewClient());
                Control.LoadUrl(customWebView.Url);
                //Control.Settings.UserAgentString = "Mozilla/5.0 (Linux; Android 4.4; Nexus 5 Build/_BuildID_) AppleWebKit/537.36 (KHTML, like Gecko) Version/4.0 Chrome/30.0.0.0 Mobile Safari/537.36";
            }
        }
        public class MyWebClient : WebChromeClient
        {
            Activity mContext;
            public MyWebClient(Activity context)
            {
                this.mContext = context;
            }
            [TargetApi(Value = 21)]
            public override void OnPermissionRequest(PermissionRequest request)
            {
                mContext.RunOnUiThread(() => {
                    request.Grant(request.GetResources());

                });

            }

            public override void OnShowCustomView(Android.Views.View view, ICustomViewCallback callback)
            {
                base.OnShowCustomView(view, callback);

                if (view.GetType() == typeof(FrameLayout)) 
                { 
                    FrameLayout frame = (FrameLayout)view;

                    if (frame.FocusedChild.GetType() == typeof(VideoView)) 
                    { 
                        VideoView video = (VideoView)frame.FocusedChild;
                        frame.RemoveView(video);
                        mContext.SetContentView(video);
                        video.Start();
                    }
                }
            }

            //public override void onShowCustomView(View view, CustomViewCallback callback)
            //{
            //    super.onShowCustomView(view, callback);
            //    if (view instanceof FrameLayout){
            //        FrameLayout frame = (FrameLayout)view;
            //        if (frame.getFocusedChild() instanceof VideoView){
            //            VideoView video = (VideoView)frame.getFocusedChild();
            //            frame.removeView(video);
            //            a.setContentView(video);
            //            video.setOnCompletionListener(this);
            //            video.setOnErrorListener(this);
            //            video.start();
            //        }
            //    }
            //}
        }

    }

}