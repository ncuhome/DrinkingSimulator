using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductOPC : MonoBehaviour
{
    private Vector3 screenPos; //????
    private Vector3 offset; //??????????

    /// <summary>
    /// ????????????????????
    /// </summary>
    private bool isDrag = false; //????????
    public bool inProduct = false;
    public bool inCustomer = false;
    private Customer customer;
    public bool inTrashBin = false;

    #region ??????
    public void OnMouseDown()
    {
        screenPos = Camera.main.WorldToScreenPoint(transform.position);
        transform.localScale = new Vector2(21.74f, 23.04f);
        offset = screenPos - Input.mousePosition;
        isDrag = true;
    }

    public void OnMouseDrag()
    {
        if (Shaker.Instance.startPour) { return; }
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition + offset); // ??????
    }

    private void OnMouseEnter()
    {

    }

    private void OnMouseExit()
    {

    }

    public void OnMouseUp()
    {
        if (Shaker.Instance.startPour) { return; }
        if (inCustomer) // 递给顾客
        {
            //Debug.Log("递给顾客");
            customer.Drink(this.gameObject);
            Shaker.Instance.canAddWine = false;
            Shaker.Instance.productMode = false;
            MediaPlayer.Instance.MediaPlay(Media.Drink_Short);
            Shaker.Instance.GetComponent<SpriteRenderer>().enabled = true;
            Shaker.Instance.GetComponent<BoxCollider2D>().enabled = true;
            Shaker.Instance.cupLid.GetComponent<SpriteRenderer>().enabled = true;
            Shaker.Instance.cupLid.GetComponent<BoxCollider2D>().enabled = true;
            Shaker.Instance.shakerCollider.GetComponent<PolygonCollider2D>().enabled = true;
            Destroy(this.gameObject);
        }
        if (inTrashBin)
        {
            Shaker.Instance.productMode = false;
            Shaker.Instance.GetComponent<SpriteRenderer>().enabled = true;
            Shaker.Instance.GetComponent<BoxCollider2D>().enabled = true;
            Shaker.Instance.cupLid.GetComponent<SpriteRenderer>().enabled = true;
            Shaker.Instance.cupLid.GetComponent<BoxCollider2D>().enabled = true;
            Shaker.Instance.shakerCollider.GetComponent<PolygonCollider2D>().enabled = true;
            Destroy(this.gameObject);
        }
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Customer")
        {
            inCustomer = true;
            customer = other.GetComponent<Customer>();
        }
        if (other.transform.tag == "Item")
        {
            inProduct = true;
        }
        if (other.tag == "TrashBin")
        {
            inTrashBin = true;
        }
        if (other.transform.tag == "Liquid")
        {
            Destroy(other.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Customer")
        {
            inCustomer = false;
        }
        if (other.transform.tag == "Item")
        {
            inProduct = false;
        }
        if (other.tag == "TrashBin")
        {
            inTrashBin = false;
        }
    }
}
