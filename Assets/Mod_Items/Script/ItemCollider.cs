using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemCollider : MonoBehaviour
{
    /// <summary>
    /// ??????
    /// </summary>
    public ItemDescription DescriptionPanel;
    /// <summary>
    /// ????(??)
    /// </summary>
    public Item item;
    private GameObject itemDrag;
    private ItemOPC itemOPC;

    #region ????
    private void OnMouseDown()
    {
        DescriptionPanel.Disappear();
        if (Shaker.Instance.wineOPC != null && Shaker.Instance.wineOPC.startPour) { return; }
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
        if (Shaker.Instance.wineOPC != null && Shaker.Instance.wineOPC.startPour) { return; }
        itemOPC.OnMouseDrag();
    }

    private void OnMouseEnter()
    {
        DescriptionPanel.Display(item.Name, item.Description);
        DescriptionPanel.status = 1;
    }

    private void OnMouseExit()
    {
        DescriptionPanel.Disappear();
        DescriptionPanel.status = 0;
    }

    private void OnMouseUp()
    {
        if (Shaker.Instance.wineOPC != null && Shaker.Instance.wineOPC.startPour) { return; }
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
