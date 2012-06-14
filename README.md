# UnitySimpleDebugView
Simple debug view for Unity.

![](https://github.com/yhirano/UnitySimpleDebugView/raw/master/Doc/Devu_Screenshot.png)

## Usage
	Devu.Log(string.Format("Mouse Position x={0}", mousePosition.x));
	Devu.Log(string.Format("Mouse Position y={0}", mousePosition.y));
	Devu.Log(string.Format("Mouse Position z={0}", mousePosition.z));

## Notice
Devu.FontSize("Font Size" in Devu inspector) value does NOT effect Android/iOS device.  
If you want to change font size of these devices

1. Import TTF font to Assets.
2. Specify the font to Devu.Font(or "Font" in Devu inspector).  
![](https://github.com/yhirano/UnitySimpleDebugView/raw/master/Doc/SpecifyFont.png)
3. Setting Ascii or Unicode to Character setting and change Font size setting in TTF font Inspector.  
![](https://github.com/yhirano/UnitySimpleDebugView/raw/master/Doc/SettingFont.png)