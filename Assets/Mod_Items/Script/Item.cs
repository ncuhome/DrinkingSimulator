using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public enum Tag { Normal }
public class Item : MonoBehaviour
{
    /// <summary>
    /// 物品名称
    /// </summary>
    public string Name;
    /// <summary>
    /// 物品ID
    /// </summary>
    public int ID;
    /// <summary>
    /// 物品描述
    /// </summary>
    public string Description;
    /// <summary>
    /// 贴图名称
    /// </summary>
    public string FileName;
    /// <summary>
    /// 旋转参数
    /// </summary>
    public float t;
    /// <summary>
    /// 标签栏
    /// </summary>
    public Tag[] tags = new Tag[3];
    /// <summary>
    /// 甜度
    /// </summary>
    public int Sweet;
    /// <summary>
    /// 酸度
    /// </summary>
    public int Acid;
    /// <summary>
    /// 酒精含量
    /// </summary>
    public int Alcohol;
    /// <summary>
    /// 温度
    /// </summary>
    public int Temperature;
    /// <summary>
    /// 猎奇程度
    /// </summary>
    public int Abnormal;

    public void SetData(ItemTemplate template)
    {
        Name = template.Name;
        ID = template.ID;
        Description = template.Description;
        FileName = template.FileName;
        tags[0] = template.Tag1;
        tags[1] = template.Tag2;
        tags[2] = template.Tag3;
        Sweet = template.Sweet;
        Acid = template.Acid;
        Alcohol = template.Alcohol;
        Temperature = template.Temperature;
        Abnormal = template.Abnormal;
    }
}

public class ItemTemplate
{
    /// <summary>
    /// 物品名称
    /// </summary>
    public string Name;
    /// <summary>
    /// 物品ID
    /// </summary>
    public int ID;
    /// <summary>
    /// 物品描述
    /// </summary>
    public string Description;
    /// <summary>
    /// 贴图名称
    /// </summary>
    public string FileName;

    /// <summary>
    /// 标签1
    /// </summary>
    public Tag Tag1;
    /// <summary>
    /// 标签2
    /// </summary>
    public Tag Tag2;
    /// <summary>
    /// 标签3
    /// </summary>
    public Tag Tag3;

    /// <summary>
    /// 甜度
    /// </summary>
    public int Sweet;
    /// <summary>
    /// 酸度
    /// </summary>
    public int Acid;
    /// <summary>
    /// 酒精含量
    /// </summary>
    public int Alcohol;
    /// <summary>
    /// 温度
    /// </summary>
    public int Temperature;
    /// <summary>
    /// 猎奇程度
    /// </summary>
    public int Abnormal;
}