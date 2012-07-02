using UnityEngine;
using System.Collections;

public class Devu : MonoBehaviour
{

#region Public fields
	
	/// <summary>
	/// The position of debug view.
	/// </summary>
	public int viewX = 5;
	
	/// <summary>
	/// The position of debug view.
	/// </summary>
	public int viewY = 5;
	
	/// <summary>
	/// The width of debug view.
	/// </summary>
	public int width = 200;
	
	/// <summary>
	/// The height of debug view.
	/// </summary>
	public int height = 125;
	
	/// <summary>
	/// The font.
	/// </summary>
	public Font font = null;
	
	/// <summary>
	/// The color of the font.
	/// </summary>
	public Color fontColor = new Color (0, 1, 0);
	
	/// <summary>
	/// The size of the font.
	/// </summary>
	/// <description>
	/// This value effects only dynamic font supported envirment (Currentry Editor/PC/Mac only).
	/// </description>
	public int fontSize = 0;
	
	/// <summary>
	/// The text offset x.
	/// </summary>
	public int textOffsetX = 8;
	
	/// <summary>
	/// The text offset y.
	/// </summary>
	public int textOffsetY = 8;
	
	/// <summary>
	/// The color of the debug view background.
	/// </summary>
	public Color backgroundColor = new Color (0, 0, 0, 0.5F);
	
#endregion
	
#region Private fields
	
	/// <summary>
	/// The singleton instance.
	/// </summary>
	private static Devu instance = null;
	
	/// <summary>
	/// The debug log text.
	/// </summary>
	private string text = string.Empty;
	
	/// <summary>
	/// The view text.
	/// </summary>
	private string viewText = string.Empty;
	
	/// <summary>
	/// Debug view position.
	/// </summary>
	private Rect viewPosition = new Rect ();

	/// <summary>
	/// The GUI style.
	/// </summary>
	private GUIStyle guiStyle = new GUIStyle ();
	
	/// <summary>
	/// The background texture of debug view.
	/// </summary>
	private Texture2D backgroundTexture = null;
	
	/// <summary>
	/// The text offset in debug view.
	/// </summary>
	private Vector2 textOffset = new Vector2 (8, 8);
	
	private bool viewEnabled = true;
	
#endregion
	
	void Start ()
	{
		// Create singleton instance.
		CreateInstance ();
	}
	
	void Update ()
	{
		// Copy debug log to view GUI.
		viewText = text;
		
		// Flash text.
		text = string.Empty;
	}
	
	void OnGUI ()
	{
		if (viewEnabled == false) {
			return;
		}
		
		viewPosition.x = viewX;
		viewPosition.y = viewY;
		viewPosition.width = width;
		viewPosition.height = height;
		
		if (backgroundTexture == null) {
			backgroundTexture = new Texture2D (1, 1);
		}
		// Fill the texture.
		for (int y = 0; y < backgroundTexture.height; ++y) {
			for (int x  = 0; x < backgroundTexture.width; ++x) {
				backgroundTexture.SetPixel (x, y, backgroundColor);
			}
		}
		// Apply all SetPixel calls
		backgroundTexture.Apply ();
		
		if (font != null) {
			guiStyle.font = font;
		}
		
		// Font size value effects only dynamic font supported envirment (Currentry PC/Mac only). 
#if UNITY_EDITOR || UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN
		guiStyle.fontSize = fontSize;
#endif // #if UNITY_EDITOR || UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN

		guiStyle.normal.textColor = fontColor;
		guiStyle.normal.background = backgroundTexture;
#if FALSE
		guiStyle.hover.textColor = fontColor; // nessecary?
		guiStyle.hover.background = backgroundTexture; // nessecary?
		guiStyle.active.textColor = fontColor; // nessecary?
		guiStyle.active.background = backgroundTexture; // nessecary?
		guiStyle.focused.textColor = fontColor; // nessecary?
		guiStyle.focused.background = backgroundTexture; // nessecary?
		guiStyle.onNormal.textColor = fontColor; // nessecary?
		guiStyle.onNormal.background = backgroundTexture; // nessecary?
		guiStyle.onHover.textColor = fontColor; // nessecary?
		guiStyle.onHover.background = backgroundTexture; // nessecary?
		guiStyle.onActive.textColor = fontColor; // nessecary?
		guiStyle.onActive.background = backgroundTexture; // nessecary?
		guiStyle.onFocused.textColor = fontColor; // nessecary?
		guiStyle.onFocused.background = backgroundTexture;
#endif // #if FALSE

		textOffset.x = textOffsetX;
		textOffset.y = textOffsetY;
		guiStyle.contentOffset = textOffset;
		
		//GUI.Label (ViewPosition, viewText, guiStyle);
		GUI.Box (viewPosition, viewText, guiStyle);
	}
	
#region Public methods
	
	/// <summary>
	/// The position of debug view.
	/// </summary>
	public static int ViewX
	{
		set {
			CreateInstance();
			instance.viewX = value;
		}
	}
	
	/// <summary>
	/// The position of debug view.
	/// </summary>
	public static int ViewY
	{
		set {
			CreateInstance();
			instance.viewY = value;
		}
	}
	
	/// <summary>
	/// The width of debug view.
	/// </summary>
	public static int Width
	{
		set {
			CreateInstance();
			instance.width = value;
		}
	}
	
	/// <summary>
	/// The height of debug view.
	/// </summary>
	public static int Height
	{
		set {
			CreateInstance();
			instance.height = value;
		}
	}
	
	/// <summary>
	/// The font.
	/// </summary>
	public static Font Font
	{
		set {
			CreateInstance();
			instance.font = value;
		}
	}

	/// <summary>
	/// The color of the font.
	/// </summary>
	public static Color FontColor
	{
		set {
			CreateInstance();
			instance.fontColor = value;
		}
	}
	
	/// <summary>
	/// The size of the font.
	/// </summary>
	/// <description>
	/// This value effects only dynamic font supported envirment (Currentry Editor/PC/Mac only).
	/// </description>
	public static int FontSize
	{
		set {
			CreateInstance();
			instance.fontSize = value;
		}
	}
	
	/// <summary>
	/// The text offset x.
	/// </summary>
	public static int TextOffsetX
	{
		set {
			CreateInstance();
			instance.textOffsetX = value;
		}
	}
	
	/// <summary>
	/// The text offset y.
	/// </summary>
	public static int TextOffsetY
	{
		set {
			CreateInstance();
			instance.textOffsetX = value;
		}
	}
	
	/// <summary>
	/// The color of the debug view background.
	/// </summary>
	public Color BackgroundColor
	{
		set {
			CreateInstance();
			instance.backgroundColor = value;
		}
	}
	
	public bool ViewEnabled
	{
		set {
			CreateInstance();
			instance.viewEnabled = value;
		}
	}
	
	public static void Log (object obj)
	{
		if (obj == null) {
			return;
		}

		Log (obj.ToString());
	}
	
	public static void Log (string text)
	{
		if (text == null || text.Length == 0) {
			return;
		}

		// Create singleton instance if not created.
		CreateInstance ();

		instance.text += text + "\n";
	}
	
#endregion

#region Private methods
	
	/// <summary>
	/// Creates the singleton instance.
	/// </summary>
	private static void CreateInstance ()
	{
		if (instance == null) {
			instance = (Devu)FindObjectOfType (typeof(Devu));
			if (instance == null) {
				instance = (new GameObject ("Devu")).AddComponent<Devu> ();
			}
		}
	}
	
#endregion
}
