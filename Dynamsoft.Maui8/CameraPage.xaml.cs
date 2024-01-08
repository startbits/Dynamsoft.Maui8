namespace Dynamsoft.Maui8;

public partial class CameraPage : ContentPage
{
	public CameraPage()
	{
		InitializeComponent();
        BarcodeQRCodeReader.InitLicense("DLS2eyJoYW5kc2hha2VDb2RlIjoiMjAwMDAxLTE2NDk4Mjk3OTI2MzUiLCJvcmdhbml6YXRpb25JRCI6IjIwMDAwMSIsInNlc3Npb25QYXNzd29yZCI6IndTcGR6Vm05WDJrcEQ5YUoifQ==");
    }

    private void OnCameraViewResultReady(object sender, Capture.Vision.Maui.ResultReadyEventArgs e)
    {
        if (e.Result != null)
        {
            foreach (var result in (BarcodeQRCodeReader.Result[])e.Result)
            {
                System.Diagnostics.Debug.WriteLine(result.Text);
            }
        }
    }
}
