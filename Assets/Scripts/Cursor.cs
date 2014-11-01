using UnityEngine;
using System.Collections;

public class Cursor : MonoBehaviour
{

    public Texture2D cursorTexture;
    private Vector2 offset;
	// Use this for initialization
	void Start () {
	    UnityEngine.Cursor.SetCursor(cursorTexture, offset, CursorMode.Auto);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
