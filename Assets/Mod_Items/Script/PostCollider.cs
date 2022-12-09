using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PostCollider : MonoBehaviour
{
    /// <summary>
    /// 鼠标进入项中
    /// </summary>
    public Action enter;
    /// <summary>
    /// 鼠标按下
    /// </summary>
    public Action pressed;
    #region 鼠标操作事件
    private void OnMouseDown()
    {
        pressed();
    }

    private void OnMouseDrag()
    {

    }

    private void OnMouseEnter()
    {
        enter();
        Debug.Log("Enter");
    }

    private void OnMouseExit()
    {
    }

    private void OnMouseUp()
    {

    }
    #endregion

    #region Unity
    void Start()
    {

    }

    void Update()
    {

    }
    #endregion
}
