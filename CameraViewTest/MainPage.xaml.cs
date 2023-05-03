namespace CameraViewTest;

public partial class MainPage : ContentPage
{
    public MainPage()
    {
        InitializeComponent();

        Application.Current.UserAppTheme = AppTheme.Light;

        // Barcode Option
        //this.cameraView.BarCodeOptions = new Camera.MAUI.ZXingHelper.BarcodeDecodeOptions
        //{
        //    AutoRotate = true,
        //    PossibleFormats = { ZXing.BarcodeFormat.QR_CODE, ZXing.BarcodeFormat.CODABAR },
        //    ReadMultipleCodes = false,
        //    TryHarder = true,
        //    TryInverted = true
        //};
    }

    private void cameraView_CamerasLoaded(object sender, EventArgs e)
    {
        if (cameraView.NumCamerasDetected > 0)
        {
            if (cameraView.NumMicrophonesDetected > 0)
            {
                cameraView.Microphone = cameraView.Microphones.First();
            }
            cameraView.Camera = cameraView.Cameras.First();

            MainThread.BeginInvokeOnMainThread(async () =>
            {
                await cameraView.StopCameraAsync();
                await cameraView.StartCameraAsync();
            });
        }
    }

    private void taskPhotoButton_Clicked(object sender, EventArgs e)
    {
        this.photoImage.Source = cameraView.GetSnapShot(Camera.MAUI.ImageFormat.PNG);
    }

    private void mirrorWsitch_Toggled(object sender, ToggledEventArgs e)
    {
        if (e.Value)
        {
            this.cameraView.MirroredImage = true;
        }
        else
        {
            this.cameraView.MirroredImage = false;
        }
    }
}

