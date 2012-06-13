# UnitySimpleDebugView
Simple debug view for Unity.

![](https://github.com/yhirano/UnitySimpleDebugView/raw/master/Doc/Devu_Screenshot.png)

## Usage
	Devu.Log(string.Format("Mouse Position x={0}", mousePosition.x));
	Devu.Log(string.Format("Mouse Position y={0}", mousePosition.y));
	Devu.Log(string.Format("Mouse Position z={0}", mousePosition.z));

## Notice
Devu.FontSize value does NOT effect Android/iOS device.  
If you want to change the size of these devices

* Import TTF font to Assets.
* Specify the font to Devu.Font.
* Setting Ascii or Unicode as Character setting and change font size in TTF font Inspector.