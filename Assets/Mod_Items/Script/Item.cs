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
    /// <summary>
    /// 是否处于控制权
    /// </summary>
    public bool control;
    /// <summary>
    /// 液体材质
    /// </summary>
    public string LiquidMaterial;
    /// <summary>
    /// 物体状态
    /// </summary>
    public string State;
    public void SetData(ItemTemplate template)
    {
        Name = template.Name;
        Description = template.Description;
        FileName = template.FileName;
        Sweet = template.Sweet;
        Acid = template.Acid;
        Alcohol = template.Alcohol;
        Temperature = template.Temperature;
        Abnormal = template.Abnormal;
        LiquidMaterial = template.LiquidMaterial;
        State = template.State;
    }
}

public class ItemTemplate
{
    /// <summary>
    /// 物品名称
    /// </summary>
    public string Name;
    /// <summary>
    /// 物品描述
    /// </summary>
    public string Description;
    /// <summary>
    /// 贴图名称
    /// </summary>
    public string FileName;

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
    /// <summary>
    /// 液体材质
    /// </summary>
    public string LiquidMaterial;
    /// <summary>
    /// 物体状态
    /// </summary>
    public string State;
}