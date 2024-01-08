using Capture.Vision.Maui;

namespace Dynamsoft.Maui8.Patch;

public static class AppBuilderExtensions
{
    public static MauiAppBuilder UseCustomCameraView(this MauiAppBuilder builder)
    {
        builder.UseNativeCameraView();
        return builder;
    }
}
