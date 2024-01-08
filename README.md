# Dynamsoft.Maui8

Maui8.0.3でBarcodeReaderが表示されない原因調査とパッチ作成をしました。

下記コミットを参照してください。
https://github.com/startbits/Dynamsoft.Maui8/commit/9d320a15013d1d5d10e64036d451bf59ed12b50d

これが正しい方法かは不明ですがひとまず。
本家の修正を待つのも一つの手です。

# 解説(Maui8.0.3's Bug?)
~~~
<FrameLayout
  android:layout_width="match_parent"
  android:layout_height="match_parent">

  <TextureView
    android:layout_width="wrap_content"
    android:layout_height="wrap_content" />

</FrameLayout>
~~~
Maui7ではTextureViewの高さはFrameLayoutの高さと一致するが、Maui8では0になってしまう模様。
~~~
<FrameLayout
  android:layout_width="match_parent"
  android:layout_height="match_parent">

  <TextureView
    android:layout_width="200"
    android:layout_height="200" />

</FrameLayout>
~~~
サイズ指定は動くので、FrameLayoutのサイズを伝播させるようにした。
https://github.com/startbits/Dynamsoft.Maui8/blob/main/Dynamsoft.Maui8.Patch/Platforms/Android/CameraView.cs#L27
~~~
textureView?.Layout(e.Left, e.Top, e.Right, e.Bottom);
~~~
すでに正しいサイズになっていた場合、後続(OnLayout)が無駄に実施されることはないので常に呼んでも問題ないと思う。