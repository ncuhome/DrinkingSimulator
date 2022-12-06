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
    public Boolean startPour = false;
    public float pourTime = 0f;

    #region 鼠标操作事件
    private void OnMouseDown()
    {
        screenPos = Camera.main.WorldToScreenPoint(transform.position);
        offset = screenPos - Input.mousePosition;
        isDrag = true;

        if ((startPour) && (pourTime > 2f))
        {
            EndPour();
        }

    }

    private void OnMouseDrag()
    {
        if (startPour) return;
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
        if (Shaker.Instance.inShaker)
        {
            if ((!startPour) && (Shaker.Instance.pourTime <= 10f))
            {
                StartPour();
            }
        }
        else
        {
            transform.position = staticPos;
        }
        isDrag = false;
    }
    #endregion

    private void StartPour()
    {
        startPour = true;
        pourTime = 0f;
        Shaker.Instance.wine = this.GetComponent<Item>();
        transform.position = Shaker.Instance.pourPos;
        transform.eulerAngles = new Vector3(0, 0, 120);
        Shaker.Instance.StartPour();
    }

    private void EndPour()
    {
        startPour = false;
        transform.eulerAngles = Vector3.zero;
        Shaker.Instance.EndPour();
    }

    #region Unity
    void Start()
    {

    }

    void Update()
    {
        if ((!isDrag) && (!Shaker.Instance.startPour))
        {
            staticPos = transform.position;
        }
        if (startPour)
        {
            pourTime += Time.deltaTime;
        }
    }
    #endregion
}
