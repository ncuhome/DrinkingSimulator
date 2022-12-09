using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 需要给物体加上碰撞体才能触发以下事件
public class PointerChange : MonoBehaviour
{
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    // 鼠标进入物体时改变指针为 cursorTexture
    void OnMouseEnter()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        //Debug.Log("mouseenter");
    }
    // 鼠标离开物体时恢复默认指针
    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
       // Debug.Log("mouseexit");

    }

}
