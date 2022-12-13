using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemOPC : MonoBehaviour
{
    public GameObject Item;
    private Vector3 screenPos; //????
    private Vector3 offset; //??????????

    /// <summary>
    /// ????????????????????
    /// </summary>
    public Material liquidMaterial;
    private Boolean isDrag = false; //????????
    private Boolean startPour = false; // ????????
    private float targetEuler_z = 0f; // ?????
    private float curEuler_z = 0f; // ????
    /// <summary>
    /// ?????? ?/s
    /// </summary>
    public float spinSpeed = 360f;
    public Item item;

    #region ??????
    public void OnMouseDown()
    {
        screenPos = Camera.main.WorldToScreenPoint(transform.position);
        item.transform.localScale = new Vector2(21.74f, 23.04f);
        offset = screenPos - Input.mousePosition;
        isDrag = true;
    }

    public void OnMouseDrag()
    {
        if (!Shaker.Instance.canAddWine) return;
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
        if (startPour) { return; }
        if ((Shaker.Instance.inShaker) && (!Shaker.Instance.productMode)) // ???????????????????
        {
            if ((!Shaker.Instance.startPour))
            {
                if (Shaker.Instance.CanAddWine())
                {
                    if (GetComponent<Item>().State == "Liquid")
                    {
                        StartPour();
                    }
                    if (GetComponent<Item>().State == "Solid")
                    {
                        AddSolid();
                    }
                }
                else
                {
                    //?????
                    MediaPlayer.Instance.MediaPlay(Media.Error);
                    if (Item != null)
                    {
                        Item.GetComponent<BoxCollider2D>().enabled = true;
                        Item.GetComponent<SpriteRenderer>().enabled = true;
                    }
                    Destroy(this.gameObject);
                }
            }
        }
        else if ((Shaker.Instance.productMode) && (Shaker.Instance.productOPC.inProduct))
        {
            if ((!Shaker.Instance.startPour))
            {
                if (Shaker.Instance.seasoningIndex < 5)
                {
                    if (GetComponent<Item>().State == "Liquid")
                    {
                        StartPour();
                    }
                    if (GetComponent<Item>().State == "Solid")
                    {
                        AddSolid();
                    }
                }
                else
                {
                    //?????
                    MediaPlayer.Instance.MediaPlay(Media.Error);
                    if (Item != null)
                    {
                        Item.GetComponent<BoxCollider2D>().enabled = true;
                        Item.GetComponent<SpriteRenderer>().enabled = true;
                    }
                    Destroy(this.gameObject);
                }
            }
        }
        else
        {
            if (Item != null)
            {
                Item.GetComponent<BoxCollider2D>().enabled = true;
                Item.GetComponent<SpriteRenderer>().enabled = true;
            }
            Destroy(this.gameObject);
        }
    }
    #endregion
    /// <summary>
    /// ????
    /// </summary>
    private void StartPour()
    {
        startPour = true;
        Shaker.Instance.wineOPC = this;
        Shaker.Instance.canAddWine = false;

        if (!Shaker.Instance.productMode)
        {
            Shaker.Instance.pourPos = Shaker.Instance.transform.position + new Vector3(135.2f, 229.6f, 0);
            Shaker.Instance.liquidPos = Shaker.Instance.transform.position + new Vector3(95.2f, 209.6f, 0);
        }
        else
        {
            Shaker.Instance.pourPos = Shaker.Instance.productItem.transform.position + new Vector3(155.2f, 229.6f, 0);
            Shaker.Instance.liquidPos = Shaker.Instance.productItem.transform.position + new Vector3(115.2f, 209.6f, 0);
        }

        transform.position = Shaker.Instance.pourPos;
        targetEuler_z = 120f;
        StartCoroutine("StartShakerPour");
    }

    private IEnumerator StartShakerPour()
    {
        Shaker.Instance.meshRenderer.material = liquidMaterial;
        Shaker.Instance.InstantiateLiquid();
        yield return new WaitForSeconds(0.4f);
        Shaker.Instance.StartPour();
        if (!Shaker.Instance.productMode)
        {
            Shaker.Instance.AddWine(this.GetComponent<Item>().Name);
        }
        else
        {
            Shaker.Instance.AddSeasoning(this.GetComponent<Item>());
        }
        StartCoroutine(StartPlayAudio());
    }

    private IEnumerator StartPlayAudio()
    {
        yield return new WaitForSeconds(1f);
        MediaPlayer.Instance.MediaPlay(Media.Poor_Fast);
    }
    /// <summary>
    /// ?????
    /// </summary>
    public void EndPourSpin()
    {
        targetEuler_z = 0f;
        StartCoroutine("EndPour");
    }

    public IEnumerator EndPour()
    {
        yield return new WaitForSeconds(0.4f);
        if (Item != null)
        {
            Item.GetComponent<BoxCollider2D>().enabled = true;
            Item.GetComponent<SpriteRenderer>().enabled = true;
        }
        Shaker.Instance.inShaker = false;
        Shaker.Instance.canAddWine = true;
        Destroy(this.gameObject);
    }

    private void AddSolid()
    {
        Shaker.Instance.StartPour();
        if (!Shaker.Instance.productMode)
        {
            Shaker.Instance.AddWine(this.GetComponent<Item>().Name);
        }
        else
        {
            Shaker.Instance.AddSeasoning(this.GetComponent<Item>());
        }
        MediaPlayer.Instance.MediaPlay(Media.Drop);
        if (Item != null)
        {
            Item.GetComponent<BoxCollider2D>().enabled = true;
            Item.GetComponent<SpriteRenderer>().enabled = true;
        }
        Shaker.Instance.pourTime = 0f;
        Shaker.Instance.startPour = false;
        Shaker.Instance.inShaker = false;
        Destroy(this.gameObject);
    }

    #region Unity
    void Start()
    {

    }

    void Update()
    {

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
