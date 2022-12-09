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
        
    }

    private void OnMouseDrag()
    {
        
    }

    private void OnMouseEnter()
    {
        DescriptionPanel.Display(item.Name, item.Description);
    }

    private void OnMouseExit()
    {
        DescriptionPanel.Disappear();
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
