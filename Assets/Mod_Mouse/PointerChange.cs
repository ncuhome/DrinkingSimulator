using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��Ҫ�����������ײ����ܴ��������¼�
public class PointerChange : MonoBehaviour
{
    public Texture2D onDragTexture;
    public Texture2D onEnterTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    // �����ק����ʱ�ı�ָ��Ϊ onDragTexture
    void OnMouseDrag()
    {
        Cursor.SetCursor(onDragTexture, hotSpot, cursorMode);
    }

    //�����������ʱ��Ϊ onEnterTexture
    private void OnMouseEnter()
    {
        Cursor.SetCursor(onEnterTexture, hotSpot, cursorMode);

    }
    //�뿪����ʱ�ָ�Ĭ��ָ��
    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);

    }
    // ��ק�����ɿ�ʱ�ָ�Ĭ��ָ��
    void OnMouseUp()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);

    }

}
