using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 需要给物体加上碰撞体才能触发以下事件
public class PointerChange : MonoBehaviour
{
    public Texture2D onDragTexture;
    public Texture2D onEnterTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    // 鼠标拖拽物体时改变指针为 onDragTexture
    void OnMouseDrag()
    {
        Cursor.SetCursor(onDragTexture, hotSpot, cursorMode);
    }

    //鼠标移入物体时变为 onEnterTexture
    private void OnMouseEnter()
    {
        Cursor.SetCursor(onEnterTexture, hotSpot, cursorMode);

    }
    //离开物体时恢复默认指针
    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);

    }
    // 拖拽物体松开时恢复默认指针
    void OnMouseUp()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);

    }

}
