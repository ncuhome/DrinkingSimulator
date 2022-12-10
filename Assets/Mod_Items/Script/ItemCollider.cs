using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollider : MonoBehaviour
{
    /// <summary>
    /// 描述面板对象
    /// </summary>
    public ItemDescription DescriptionPanel;
    /// <summary>
    /// 物品对象(自身)
    /// </summary>
    public Item item;

    #region 鼠标监听
    private void OnMouseDown()
    {
        item.control = true;
    }

    private void OnMouseDrag()
    {
        item.control = true;
        DescriptionPanel.Disappear();
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
