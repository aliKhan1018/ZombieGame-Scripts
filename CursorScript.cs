using UnityEngine;

public class CursorScript : MonoBehaviour
{
	public Texture2D texture;
	public Vector2 hotspot;
	public bool isVisible = true;
	public CursorLockMode lockMode;

	// private Vector2 newHotspot;

	private void Awake()
	{
		hotspot = new Vector2(texture.width * 0.5f, texture.height * 0.5f);

		Cursor.SetCursor(texture, hotspot, CursorMode.Auto);
	}

	private void Start()
	{
		Cursor.visible = isVisible;
		Cursor.lockState = lockMode;
	}

	

}
