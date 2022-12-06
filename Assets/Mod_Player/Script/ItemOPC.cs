using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOPC : MonoBehaviour
{
    private Vector3 screenPos; //屏幕坐标
    private Vector3 offset; //鼠标和物体中心坐标差

    public Vector3 staticPos; //物体原本位置（如果松开鼠标会传回去的位置
    public Boolean isDrag = false;
    public Boolean inShaker = false;
    public Boolean startPour = false;

    #region 鼠标操作事件
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
