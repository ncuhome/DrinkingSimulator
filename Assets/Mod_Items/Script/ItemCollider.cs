using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollider : MonoBehaviour
{
    /// <summary>
    /// 描述浮窗
    /// </summary>
    public ItemDescription DescriptionPanel;
    /// <summary>
    /// 关联的物品信息
    /// </summary>
    public Item item;

    #region 鼠标操作事件
    private void OnMouseDown()
    {
        item.control = true;
    }

    private void OnMouseDrag()
    {
        item.control = true;
    }

    private void OnMouseEnter()
    {
        item.control = true;
        DescriptionPanel.Display(item.Name, item.Description);
    }

    private void OnMouseExit()
    {
        item.control = false;
        DescriptionPanel.Disappear();
    }

    private void OnMouseUp()
    {
        item.control = false;
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
