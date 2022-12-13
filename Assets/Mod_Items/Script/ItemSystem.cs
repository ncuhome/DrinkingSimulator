using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;


public class ItemSystem : MonoBehaviour
{
    #region 属性
    #region 预制体
    /// <summary>
    /// 物品项预制体
    /// </summary>
    public GameObject ItemSpotPrefb;
    #endregion
     
    #region 关联物体
    /// <summary>
    /// 名称文本
    /// </summary>
    public TMP_Text NameTxt;
    /// <summary>
    /// 描述文本
    /// </summary>
    public TMP_Text DescriptionTxt;
    /// <summary>
    /// 选择面板
    /// </summary>容器
    public GameObject Container;
    /// <summary>
    /// 面板动画器
    /// </summary>
    public Animator PanelAnimator;
    /// <summary>
    /// 选物体平台
    /// </summary>
    public ItemsPlane plane;
    #endregion
    /// <summary>
    /// 是否为选择面板
    /// </summary>
    public bool selectedPanel = false;
    /// <summary>
    /// 面板是否展开
    /// </summary>
    private bool openned = false;
    /// <summary>
    /// 物品信息表
    /// </summary>
    public List<ItemTemplate> Items;
    /// <summary>
    /// 物品项 物体表
    /// </summary>
    public List<GameObject> Posts = new List<GameObject>();
    /// <summary>
    /// 引用物品表文件名称(在dataSheet下
    /// </summary>
    public string dataPath;
    /// <summary>
    /// 当前光标索引
    /// </summary>
    public int index;
    #endregion

    #region 按钮委托
    /// <summary>
    /// 按钮显示信息
    /// </summary>
    /// <param name="index"></param>
    public void Checkout(int index)
    {
        this.index = index;
        plane.aimIndex = index;
        OpenClose();
    }
    /// <summary>
    /// 按钮选中
    /// </summary>
    /// <param name="index"></param>
    public void Select(int index)
    {
        //Debug.Log($"INDEX:{index}");
        this.index = index;
        NameTxt.text = Items[index].Name;
        DescriptionTxt.text = Items[index].Description;
    }
    /// <summary>
    /// 展开或关闭面板
    /// </summary>
    public void OpenClose()
    {
        MeidiaPlay();
        PanelAnimator.SetTrigger("pressed");
        if (openned) { openned = false;  }
        else { openned = true;  }
    }
    #endregion

    #region 响应函数
    private void MeidiaPlay()
    {
        GetComponent<AudioSource>().Play();
    }
    /// <summary>
    /// 更新物品列表栏显示
    /// </summary>
    public void UpdateItems()
    {
        foreach (GameObject g in Posts)
        {
            Destroy(g);
        }
        Posts.Clear();
        int ux = 0, uy = 0;
        for (int i = 0; i < Items.Count; i++)
        {
            GameObject obj = Instantiate(ItemSpotPrefb, Vector2.zero, Quaternion.identity);
            Posts.Add(obj);

            RectTransform rt = obj.GetComponent<RectTransform>();
            ux = -500 + 250 * (i % 5);
            uy = -200 - 250 * (i / 5);
            rt.SetParent(Container.transform);
            rt.localPosition = new Vector3(ux, uy,-100);

            GameObject ii = rt.Find("ItemImage").gameObject;
            int select = i;
            if(Items[i].FileName != " ")
            {
                ii.GetComponent<Image>().sprite = Resources.Load<Sprite>("Mod_Items/" + Items[i].FileName);
            }
            else
            {
                ii.GetComponent<Image>().sprite = Resources.Load<Sprite>("Mod_Items/" + "RUM_test");
            }
            ii.GetComponent<PostCollider>().enter = delegate () { Select(select); };
            ii.GetComponent<PostCollider>().pressed = delegate () { Checkout(select); };

        }
        Container.GetComponent<RectTransform>().offsetMin = new Vector2(0, uy - 200);
    }
    #endregion

    #region Unity
    private void Awake()
    {

        string path = Application.streamingAssetsPath + @"/DataSheet/" + dataPath + ".json";
        string txt = File.ReadAllText(path);
        //Debug.Log(txt);
        Items = JsonConvert.DeserializeObject<List<ItemTemplate>>(txt);

        if (selectedPanel)
        {
            plane.FirstDisplay();
        }
    }

    public void Start()
    {
        UpdateItems();
    }
    #endregion
}
