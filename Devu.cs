using UnityEngine;
using System.Collections;

public class Devu : MonoBehaviour
{

#region Public fields
	
	/// <summary>
	/// The position of debug view.
	/// </summary>
	public int X = 5;
	
	/// <summary>
	/// The position of debug view.
	/// </summary>
	public int Y = 5;
	
	/// <summary>
	/// The width of debug view.
	/// </summary>
	public int Width = 200;
	
	/// <summary>
	/// The height of debug view.
	/// </summary>
	public int Height = 125;
	
	/// <summary>
	/// The font.
	/// </summary>
	public Font Font = null;
	
	/// <summary>
	/// The color of the font.
	/// </summary>
	public Color FontColor = new Color (0, 1, 0);
	
	/// <summary>
	/// The size of the font.
	/// </summary>
	/// <description>
	/// This value effects only dynamic font supported envirment (Currentry Editor/PC/Mac only).
	/// </description>
	public int FontSize = 0;
	
	/// <summary>
	/// The text offset x.
	/// </summary>
	public int TextOffsetX = 8;
	
	/// <summary>
	/// The text offset y.
	/// </summary>
	public int TextOffsetY = 8;
	
	/// <summary>
	/// The color of the debug view background.
	/// </summary>
	public Color BackgroundColor = new Color (0, 0, 0, 0.5F);
	
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
		viewPosition.x = X;
		viewPosition.y = Y;
		viewPosition.width = Width;
		viewPosition.height = Height;
		
		if (backgroundTexture == null) {
			backgroundTexture = new Texture2D (1, 1);
		}
		// Fill the texture.
		for (int y = 0; y < backgroundTexture.height; ++y) {
			for (int x  = 0; x < backgroundTexture.width; ++x) {
				backgroundTexture.SetPixel (x, y, BackgroundColor);
			}
		}
		// Apply all SetPixel calls
		backgroundTexture.Apply ();
		
		if (Font != null) {
			guiStyle.font = Font;
		}
		
		// Font size value effects only dynamic font supported envirment (Currentry PC/Mac only). 
#if UNITY_EDITOR || UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN
		guiStyle.fontSize = FontSize;
#endif // #if UNITY_EDITOR || UNITY_STANDALONE_OSX || UNITY_STANDALONE_WIN

		guiStyle.normal.textColor = FontColor;
		guiStyle.normal.background = backgroundTexture;
#if FALSE
		guiStyle.hover.textColor = FontColor; // nessecary?
		guiStyle.hover.background = backgroundTexture; // nessecary?
		guiStyle.active.textColor = FontColor; // nessecary?
		guiStyle.active.background = backgroundTexture; // nessecary?
		guiStyle.focused.textColor = FontColor; // nessecary?
		guiStyle.focused.background = backgroundTexture; // nessecary?
		guiStyle.onNormal.textColor = FontColor; // nessecary?
		guiStyle.onNormal.background = backgroundTexture; // nessecary?
		guiStyle.onHover.textColor = FontColor; // nessecary?
		guiStyle.onHover.background = backgroundTexture; // nessecary?
		guiStyle.onActive.textColor = FontColor; // nessecary?
		guiStyle.onActive.background = backgroundTexture; // nessecary?
		guiStyle.onFocused.textColor = FontColor; // nessecary?
		guiStyle.onFocused.background = backgroundTexture;
#endif // #if FALSE

		textOffset.x = TextOffsetX;
		textOffset.y = TextOffsetY;
		guiStyle.contentOffset = textOffset;
		
		//GUI.Label (ViewPosition, viewText, guiStyle);
		GUI.Box (viewPosition, viewText, guiStyle);
	}
	
#region Public methods
	
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
