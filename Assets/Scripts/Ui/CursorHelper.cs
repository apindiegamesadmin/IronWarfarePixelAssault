using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CursorHelper : MonoBehaviour
{
    public Texture2D cursorArrow;

    public void Awake()
    {
        //Cursor.SetCursor(cursorArrow, Vector2.zero, CursorMode.ForceSoftware);
        cursorSet(cursorArrow);
    }

    void cursorSet(Texture2D tex)
    {
        CursorMode mode = CursorMode.ForceSoftware;
        Vector2 hotSpot = new Vector2(tex.width / 2, tex.height / 2);
        Cursor.SetCursor(tex, hotSpot, mode);
    }
}
