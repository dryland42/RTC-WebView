using Plugin.Permissions;
using Plugin.Permissions.Abstractions;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace CPE
{
    public partial class MainPage : ContentPage
    {
        MyWebView _webView;
        Button _button;
        StackLayout stackLayout;
        public MainPage()
        {
            InitializeComponent();

            Task<bool> b = initPerTest();
            System.Diagnostics.Debug.Write("permissions============================================================" + b.Result);
            initView();
            initCameraPermission();
            initMicPermission();
        }

        private async Task<bool> initPerTest()
        {
            PermissionStatus statusCamera = await CrossPermissions.Current.CheckPermissionStatusAsync<CameraPermission>();

            var statusMicrophone = await CrossPermissions.Current.CheckPermissionStatusAsync<MicrophonePermission>();
            return statusCamera == PermissionStatus.Granted && statusMicrophone == PermissionStatus.Granted;
        }

        private async void initMicPermission() {
            var status = await CrossPermissions.Current.CheckPermissionStatusAsync<MicrophonePermission>();
            if (status != PermissionStatus.Granted)
            {
                if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Camera))
                {
                    await DisplayAlert("Microphone access required", "Application requires use of microphone", "OK");
                }

                var results = await CrossPermissions.Current.RequestPermissionAsync<MicrophonePermission>();
            }

            if (status != PermissionStatus.Unknown)
            {
                await DisplayAlert("Microphone Access Denied", "Can not continue, try again.", "OK");
            }
        }
        private async void initCameraPermission()
        {
            var status = await CrossPermissions.Current.CheckPermissionStatusAsync<CameraPermission>();

            if (status != PermissionStatus.Granted)
            {
                if (await CrossPermissions.Current.ShouldShowRequestPermissionRationaleAsync(Permission.Camera))
                {
                    await DisplayAlert("Camera access required", "Application requires use of camera", "OK");
                }

                var results = await CrossPermissions.Current.RequestPermissionAsync<CameraPermission>();
            }

            if (status == PermissionStatus.Granted)
            {

            }
            else if (status != PermissionStatus.Unknown)
            {
                await DisplayAlert("Camera Access Denied", "Can not continue, try again.", "OK");
            }
        }

        private void initView()
        {

            _button = new Button
            {
                Text = "add webview",
                WidthRequest = 100,
                HeightRequest = 50
            };
            _button.Clicked += _button_Clicked;

            stackLayout = new StackLayout()
            {
                Orientation = StackOrientation.Vertical,
                Padding = new Thickness(5, 20, 5, 10),
                Children = { _button }
            };

            Content = new StackLayout { Children = { stackLayout } };
        }

        private void _button_Clicked(object sender, EventArgs e)
        {
            _webView = new MyWebView
            {
                Source = "https://fir-rtc-4522a.firebaseapp.com/",
                WidthRequest = 1000,
                HeightRequest = 1000
            };
            stackLayout.Children.Add(_webView);
        }
    }
}
