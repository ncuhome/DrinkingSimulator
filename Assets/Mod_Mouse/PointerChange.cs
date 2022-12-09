using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ��Ҫ�����������ײ����ܴ��������¼�
public class PointerChange : MonoBehaviour
{
    public Texture2D cursorTexture;
    public CursorMode cursorMode = CursorMode.Auto;
    public Vector2 hotSpot = Vector2.zero;

    // ����������ʱ�ı�ָ��Ϊ cursorTexture
    void OnMouseEnter()
    {
        Cursor.SetCursor(cursorTexture, hotSpot, cursorMode);
        //Debug.Log("mouseenter");
    }
    // ����뿪����ʱ�ָ�Ĭ��ָ��
    void OnMouseExit()
    {
        Cursor.SetCursor(null, Vector2.zero, cursorMode);
       // Debug.Log("mouseexit");

    }

}
