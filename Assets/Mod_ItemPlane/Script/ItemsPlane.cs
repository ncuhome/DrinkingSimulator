
using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class ItemsPlane : MonoBehaviour
{
    #region 预制体
    /// <summary>
    /// 物品预制体
    /// </summary>
    public GameObject ItemsPrefb;
    #endregion

    #region 属性

    /// <summary>
    /// 是否是右边的盘子
    /// </summary>
    public bool isRight;
    /// <summary>
    /// 当前转盘的所在索引位置
    /// </summary>
    public int index;
    /// <summary>
    /// 目标位置索引
    /// </summary>
    public int aimIndex;
    /// <summary>
    /// 旋转速率
    /// </summary>
    public float speedT = 0.5f;
    /// <summary>
    ///增速倍率
    /// </summary>
    public float multSpeed = 0.1f;
    /// <summary>
    /// 速度阻碍率
    /// </summary>
    public float impede;
    /// <summary>
    /// 旋转角度(rad)
    /// </summary>
    public float t;
    /// <summary>
    /// 鼠标旧坐标
    /// </summary>
    public Vector2 mouse_old;
    /// <summary>
    /// 计时器
    /// </summary>
    private float timer;
    /// <summary>
    /// 鼠标是否进入判定区域
    /// </summary>
    public bool Enter;
    /// <summary>
    /// 滚轮加速倍率
    /// </summary>
    public float speedAdWl;
    /// <summary>
    /// 转盘最大速率
    /// </summary>
    public float speedMax;
    #endregion

    /// <summary>
    /// 物体描述浮窗
    /// </summary>
    public ItemDescription ItemDescription;
    /// <summary>
    /// 关联的物品系统
    /// </summary>
    public ItemSystem itemsys;
    /// <summary>
    /// 盘子贴图
    /// </summary>
    public GameObject plane;
    /// <summary>
    /// 关联的物品物体
    /// </summary>
    public List<GameObject> Items = new List<GameObject>();
    /// <summary>
    /// 旋转角度计数器
    /// </summary>
    private float TCounter;

    #region 响应函数
    /// <summary>
    /// 旋转
    /// </summary>
    public void Rotate()
    {
        /***变更角度值***/
        if (speedT > speedMax) { speedT = speedMax; }
        else if (speedT < -speedMax) { speedT = -speedMax; }
        t += speedT * Time.deltaTime;

        if (t > 360) { t -= 360; }
        else if (t < -360) { t += 360; }


        plane.transform.localRotation = Quaternion.Euler(new Vector3(60, 0, t * (float)Math.PI / 180));
        for (int i = 0; i < Items.Count; i++)
        {
            GameObject item = Items[i];
            if (item.GetComponent<Item>().control) { continue; }
            float pt = item.GetComponent<Item>().t;
            pt += speedT * Time.deltaTime;
            while (pt > 360)
            {
                pt -= 360;
            }
            while (pt < -360)
            {
                pt += 360;
            }
            double nt = Math.PI * pt / 180;

            float lx = -300 + 500 * (float)Math.Cos(nt);
            float ly = 280 + 200 * (float)Math.Sin(nt);
            float lz = (float)nt - 100;

            float sx = 21.74f * (0.75f - (float)nt / 10);
            float sy = 23.04f * (0.75f - (float)nt / 10);

            if (isRight)
            {
                lz = -(float)nt - 100;
                sx = 21.74f * (0.75f + (float)nt / 10);
                sy = 21.74f * (0.75f + (float)nt / 10);
                nt = Math.PI * (pt+180) / 180;
                lx = 1920 + 300 + 500 * (float)Math.Cos(nt);
                ly = 280 + 200 * (float)Math.Sin(nt);
            }

            item.transform.position = new Vector3(lx, ly, lz);

            item.transform.localScale = new Vector2(sx, sy);
            item.GetComponent<Item>().t = pt;
        }

        int creat = 0;

        for (int i = 0; i < Items.Count; i++)
        {
            GameObject item = Items[i];
            float pt = item.GetComponent<Item>().t;
            //超出显示范围后
            if (pt < -90)
            {
                i--;
                Items.Remove(item);
                Destroy(item);
                creat = 1;
            }
            else if (pt > 90)
            {
                i--;
                Items.Remove(item);
                Destroy(item);
                creat = 2;
            }
        }
        if (creat == 1)
        {
            index++;
            while (index >= itemsys.Items.Count)
            {
                index -= itemsys.Items.Count;
            }
            CreatItem(90, index + 2);

        }
        else if (creat == 2)
        {
            index--;
            while (index < 0)
            {
                index += itemsys.Items.Count;
            }
            CreatItem(-90, index - 2);
        }


        //速度衰减
        speedT *= impede;
        if (Math.Abs(speedT) < 1.0e-3) { speedT = 0; }
    }
    /// <summary>
    /// 根据角度在指定位置创建一个物品对象
    /// </summary>
    /// <param name="pt"></param>
    public void CreatItem(float pt, int itemindex)
    {
        float lx = -300 + 500 * (float)Math.Cos(Math.PI * pt / 180);
        float ly = 280 + 200 * (float)Math.Sin(Math.PI * pt / 180);

        if(isRight)
        {
            lx = 1920 + 300 + 500 * (float)Math.Cos(Math.PI * (pt + 180) / 180);
            ly = 280 + 200 * (float)Math.Sin(Math.PI * (pt + 180) / 180);
        }

        GameObject obj = Instantiate(ItemsPrefb,
            new Vector2(lx, ly),
            Quaternion.identity);
        obj.transform.rotation = Quaternion.identity;
        int pindex = itemindex;

        while (pindex < 0)
        {
            pindex += itemsys.Items.Count;
        }
        while (pindex >= itemsys.Items.Count)
        {
            pindex -= itemsys.Items.Count;
        }

        obj.GetComponent<ItemCollider>().DescriptionPanel = ItemDescription;
        obj.GetComponent<Item>().SetData(itemsys.Items[pindex]);
        obj.GetComponent<Item>().t = pt;
        if(itemsys.Items[pindex].FileName != " ")
        {
            obj.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Mod_Items/" + itemsys.Items[pindex].FileName);
        }
        else
        {
            obj.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Mod_Items/" + "RUM_test");
        }
        Items.Add(obj);
    }
    /// <summary>
    /// 初次显示
    /// </summary>
    public void FirstDisplay()
    {
        /******角度******/
        int t1 = -45;
        int t2 = 0;
        int t3 = 45;
        int t4 = -90;
        //int t5 = 90;
        /*************/

        CreatItem(t1, itemsys.Items.Count - 1);
        CreatItem(t2, 0);
        CreatItem(t3, 1);
        CreatItem(t4, 2);
        // CreatItem(t5, itemsys.Items.Count - 2);
    }
    #endregion


    #region 鼠标监听
    private void OnMouseEnter()
    {
        Enter = true;
    }
    private void OnMouseExit()
    {
        Enter = false;
    }
    private void OnMouseDown()
    {
        mouse_old = Input.mousePosition;
        speedT = 0;
        timer = 0;
    }
    private void OnMouseDrag()
    {
        timer += Time.deltaTime;
        if (timer > 0.1f)//鼠标记录间隔
        {
            timer = 0;
            Vector2 move = (Vector2)Input.mousePosition - mouse_old;
            float speedAd = move.magnitude * multSpeed;

            //Debug.Log($"OLD:{mouse_old.y}  NEW:{Input.mousePosition.y}");
            if (Input.mousePosition.y < mouse_old.y)
            {
                if(isRight)
                {
                    speedT += speedAd;
                }
                else
                {
                    speedT -= speedAd;
                }
               
            }
            else
            {
                if (isRight)
                {
                    speedT -= speedAd;
                }
                else
                {
                    speedT += speedAd;
                }
            }
            mouse_old = Input.mousePosition;
        }
    }

    private void OnMouseUp()
    {
        timer = 0;
    }
    #endregion


    #region Unity

    private void Awake()
    {
    }
    void Start()
    {

    }


    void Update()
    {
        if (speedT != 0)
        {
            Rotate();
        }
        //Debug.Log(Enter);
        if (Enter)
        {
            float dv = Input.GetAxis("Mouse ScrollWheel");
            //Debug.Log($"DV:{dv}");
            if (dv > 0)
            {
                while (dv > 0)
                {
                    if (isRight)
                    {
                        speedT -= 100 * speedAdWl;
                    }
                    else
                    {
                        speedT += 100 * speedAdWl;
                    }
                    dv -= 0.1f;
                }
            }
            else if (dv < 0)
            {
                while (dv < 0)
                {
                    if (isRight)
                    {
                        speedT += 100 * speedAdWl;
                    }
                    else
                    {
                        speedT -= 100 * speedAdWl;
                    }
                    dv += 0.1f;
                }
            }
        }

        if (aimIndex > -1)
        {
            if (aimIndex == index)
            {
                speedT = 0;
                aimIndex = -1;
            }
            else if (aimIndex == index - 1)
            {
                speedT = speedMax / 10;
            }
            else
            {
                speedT = speedMax;
            }
        }
    }
    #endregion Unity
}
