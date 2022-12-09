using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOPC : MonoBehaviour
{
    private Vector3 screenPos; //屏幕坐标
    private Vector3 offset; //鼠标和物体中心坐标差

    /// <summary>
    /// 物体固定位置（如果松开鼠标会传回去的位置
    /// </summary>
    public Vector3 staticPos;
    public Material liquidMaterial;
    private Boolean isDrag = false; //是否处于抓取状态
    private Boolean startPour = false; // 是否开始倒酒状态
    private float targetEuler_z = 0f; // 旋转目标角
    private float curEuler_z = 0f; // 当前角度
    /// <summary>
    /// 物体旋转速度 度/s
    /// </summary>
    public float spinSpeed = 360f;

    #region 鼠标操作事件
    private void OnMouseDown()
    {
        screenPos = Camera.main.WorldToScreenPoint(transform.position);
        offset = screenPos - Input.mousePosition;
        isDrag = true;
    }

    private void OnMouseDrag()
    {
        if (startPour) return;
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition + offset); // 跟随鼠标移动
    }

    private void OnMouseEnter()
    {

    }

    private void OnMouseExit()
    {

    }

    private void OnMouseUp()
    {
        if (Shaker.Instance.inShaker) // 如果移动到调酒杯上就倒酒，否则移回原位
        {
            if ((!startPour))
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
    /// <summary>
    /// 开始倒酒
    /// </summary>
    private void StartPour()
    {
        startPour = true;
        Shaker.Instance.wineOPC = this;
        transform.position = Shaker.Instance.pourPos;
        Shaker.Instance.meshRenderer.material = liquidMaterial;
        targetEuler_z = 120f;
        StartCoroutine("StartShakerPour");
    }

    private IEnumerator StartShakerPour()
    {
        Shaker.Instance.meshRenderer.material = liquidMaterial;
        Shaker.Instance.InstantiateLiquid();
        yield return new WaitForSeconds(0.4f);
        Shaker.Instance.StartPour();
    }
    /// <summary>
    /// 将酒瓶回转
    /// </summary>
    public void EndPourSpin()
    {
        targetEuler_z = 0f;
        StartCoroutine("EndPour");
    }

    public IEnumerator EndPour()
    {
        yield return new WaitForSeconds(0.4f);
        transform.position = staticPos;
        startPour = false;
    }

    #region Unity
    void Start()
    {

    }

    void Update()
    {
        // 设置固定位置
        if ((!isDrag) && (!startPour))
        {
            staticPos = transform.position;
        }

        // 旋转物体
        transform.eulerAngles = new Vector3(0f, 0f, curEuler_z);
        if (targetEuler_z != 0)
        {
            if (curEuler_z < targetEuler_z)
            {
                curEuler_z += Time.deltaTime * spinSpeed;
            }
            else
            {
                curEuler_z = targetEuler_z;
            }
        }
        else
        {
            if (curEuler_z > targetEuler_z)
            {
                curEuler_z -= Time.deltaTime * spinSpeed;
            }
            else
            {
                curEuler_z = targetEuler_z;
            }
        }
    }
    #endregion
}
