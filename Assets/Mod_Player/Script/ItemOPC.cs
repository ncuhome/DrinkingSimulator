using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOPC : MonoBehaviour
{
    private Vector3 screenPos; //��Ļ����
    private Vector3 offset; //�����������������

    public Vector3 staticPos; //����ԭ��λ�ã�����ɿ����ᴫ��ȥ��λ��
    public Boolean isDrag = false;
    public Boolean inShaker = false;
    public Boolean startPour = false;

    #region �������¼�
    private void OnMouseDown() {
        screenPos = Camera.main.WorldToScreenPoint(transform.position);
        offset = screenPos - Input.mousePosition; 
        isDrag = true;   
    }

    private void OnMouseDrag() {
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition + offset);    
    }

    private void OnMouseEnter()
    {

    }

    private void OnMouseExit()
    {

    }

    private void OnMouseUp()
    {
        transform.position = staticPos;
        isDrag = false;
    }
    #endregion

    #region Unity
    void Start()
    {

    }

    void Update()
    {
        if (!isDrag)
        {
            staticPos = transform.position;
        }
    }
    #endregion
}
