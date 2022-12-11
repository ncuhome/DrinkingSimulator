using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FormulaPanel : MonoBehaviour
{
    #region 预制体
    public GameObject FormulaCellPerfb;
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
    /// 原酒系统
    /// </summary>
    public ItemSystem mitem1;
    /// <summary>
    /// 材料系统
    /// </summary>
    public ItemSystem mitem2;

    /// <summary>
    /// 面板是否展开
    /// </summary>
    private bool openned = false;

    /// <summary>
    /// 物品信息表
    /// </summary>
    public List<ItemTemplate> Items;
    /// <summary>
    /// 配方表
    /// </summary>
    static Formula[] formulas;
    /// <summary>
    /// 物品项 物体表
    /// </summary>
    public List<GameObject> Posts = new List<GameObject>();
    /// <summary>
    /// 引用成品表文件名称(在dataSheet下
    /// </summary>
    public string dataPath;
    /// <summary>
    /// 配方文件路径
    /// </summary>
    public string formulaPath;
    /// <summary>
    /// 当前光标索引
    /// </summary>
    public int index;
    #endregion

    #region 响应函数

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
    /// 更新配方项目
    /// </summary>
    public void UpdateItems()
    {
        foreach (GameObject g in Posts)
        {
            Destroy(g);
        }
        Posts.Clear();
        int ddx = 700;//修正值
        int ux = 0, uy = 0;
        for (int i = 0; i < formulas.Length; i++)
        {
            int p = i;
            GameObject obj = Instantiate(FormulaCellPerfb, Vector2.zero, Quaternion.identity);
            obj.transform.Find("Button").GetComponent<Button>().onClick.AddListener(() => Select(p));

            Posts.Add(obj);

            RectTransform rt = obj.GetComponent<RectTransform>();
            ux = 0;
            uy = ddx - 180 * i;
            rt.SetParent(Container.transform);
            rt.localPosition = new Vector2(ux, uy);

            Image image = obj.transform.Find("OverItem").GetComponent<Image>();
            string spriteName = " ";
            foreach (ItemTemplate itm in Items)
            {
                if (formulas[i].Name == itm.Name)
                {
                    spriteName = itm.FileName; break;
                }
            }

            if (spriteName != " ") { image.sprite = Resources.Load<Sprite>("Mod_Items/" + spriteName); }
            else { image.sprite = Resources.Load<Sprite>("Mod_Items/" + "RUM_test"); }

            for (int k = 0; k < 6; k++)
            {
                if (formulas[i].Materials[k] == "Null") { break; }
                Debug.Log($"NOW{i}");
                image = obj.transform.Find("Material" + (k + 1)).GetComponent<Image>();

                spriteName = " ";
                foreach (ItemTemplate itm in mitem1.Items)
                {
                    if (formulas[i].Materials[k] == itm.Name)
                    {
                        spriteName = itm.FileName; break;
                    }
                }
                if(spriteName == " ")
                {
                    foreach (ItemTemplate itm in mitem2.Items)
                    {
                        if (formulas[i].Materials[k] == itm.Name)
                        {
                            spriteName = itm.FileName; break;
                        }
                    }
                }
                if (spriteName != " ") { image.sprite = Resources.Load<Sprite>("Mod_Items/" + spriteName); }
                else { image.sprite = Resources.Load<Sprite>("Mod_Items/" + "RUM_test"); }
            }

        }
        Container.GetComponent<RectTransform>().offsetMin = new Vector2(0, uy - ddx - 300);
    }

    /// <summary>
    /// 获取合成物品,
    /// </summary>
    /// <param name="materials">添加的全部配方</param>
    /// <returns></returns>
    public static string Make(string[] materials)
    {
        foreach (Formula formula in formulas)
        {
            if (formula.isMake(materials))
            {
                string[] backM = formula.getMaterials(materials);
                if (backM.Length > 0) { return "不可名状物"; }
                return formula.Name;
            }
        }
        return "不可名状物";
    }

    #endregion


    #region 按钮委托

    public void OpenClose()
    {
        PanelAnimator.SetTrigger("pressed");
        if (openned) { openned = false; }
        else { openned = true; UpdateItems(); }
    }
    #endregion

    #region Unity

    private void Awake()
    {
        //更新成品表
        string path = Application.dataPath + @"/Mod_Formula/DataSheet/" + dataPath + ".json";
        string txt = File.ReadAllText(path);
        Items = JsonConvert.DeserializeObject<List<ItemTemplate>>(txt);

        //更新配方表
        string formulaFile = Application.dataPath + @"/Mod_Formula/DataSheet/" + formulaPath + ".json";
        txt = File.ReadAllText(formulaFile);
        FormulaT[] formulasT = JsonConvert.DeserializeObject<FormulaT[]>(txt);
        formulas = new Formula[formulasT.Length];
        for (int i = 0; i < formulas.Length; i++)
        {
            formulas[i] = new Formula(formulasT[i]);
        }
    }

    void Start()
    {

    }


    void Update()
    {

    }
    #endregion
}
