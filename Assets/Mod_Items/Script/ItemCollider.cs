using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollider : MonoBehaviour
{
    /// <summary>
    /// ????
    /// </summary>
    public ItemDescription DescriptionPanel;
    /// <summary>
    /// ???????
    /// </summary>
    public Item item;

    #region ??????
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
