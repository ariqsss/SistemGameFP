using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cursorku : MonoBehaviour
{
    // Start is called before the first frame update
    public Texture2D cursorArrow;
    void Start()
    {
        DontDestroyOnLoad(transform.gameObject);
        Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.ForceSoftware);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
