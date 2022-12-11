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
    private GameObject itemDrag;
    private ItemOPC itemOPC;

    #region 鼠标监听
    private void OnMouseDown()
    {
        DescriptionPanel.Disappear();
        if (Shaker.Instance.startPour) { return; }
        GetComponent<BoxCollider2D>().enabled = false;
        GetComponent<SpriteRenderer>().enabled = false;
        itemDrag = Instantiate(gameObject, transform.localPosition, transform.rotation);
        Destroy(itemDrag.GetComponent<ItemCollider>());
        itemDrag.GetComponent<BoxCollider2D>().enabled = true;
        itemDrag.GetComponent<SpriteRenderer>().enabled = true;
        itemOPC = itemDrag.AddComponent<ItemOPC>();
        itemOPC.Item = gameObject;
        itemOPC.item = itemOPC.GetComponent<Item>();
        if (GetComponent<Item>().LiquidMaterial != " ")
        {
            itemOPC.liquidMaterial = Resources.Load<Material>("Material/" + GetComponent<Item>().LiquidMaterial);
        }
        else
        {
            itemOPC.liquidMaterial = Resources.Load<Material>("Material/LightBlue");
        }
        itemOPC.OnMouseDown();
    }

    private void OnMouseDrag()
    {
        if (Shaker.Instance.startPour) { return; }
        itemOPC.OnMouseDrag();
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
        if (Shaker.Instance.startPour) { return; }
        itemOPC.OnMouseUp();
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
