using System.Reflection;
using Android.Views;
using Android.Widget;

namespace Dynamsoft.Maui8.Patch;

public partial class CameraView
{
    protected override void OnHandlerChanged()
    {
        base.OnHandlerChanged();
        if (Handler != null)
        {
            // Patching for Dynamsoft. It may also work for Camera.Maui.
            // https://github.com/yushulx/Capture-Vision-Maui
            // https://github.com/hjam40/Camera.MAUI
            // The regrettable thing is that ViewHandler and PlatformView are internal. So the approach is limited.
            if (Handler.PlatformView is FrameLayout platformView)
            {
                var field = platformView.GetType().GetField("textureView", BindingFlags.NonPublic | BindingFlags.Instance);
                var textureView = field?.GetValue(platformView) as TextureView;
                void OnLayoutChange(object? sender, Android.Views.View.LayoutChangeEventArgs e)
                {
                    // Bug in mono-android sdk34?
                    // For some reason, the height of Maui8 is 0. Adjust the layout only the first time.
                    // If the layout is correct, OnLayout doesn't fire, so I don't care.
                    textureView?.Layout(e.Left, e.Top, e.Right, e.Bottom);
                    // You may not need to cancel the event. If you need to rotate, adjust it.
                    platformView.LayoutChange -= OnLayoutChange;
                }
                platformView.LayoutChange += OnLayoutChange;
            }
        }
    }
}
