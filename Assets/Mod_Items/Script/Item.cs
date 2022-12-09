using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public enum Tag {Normal }
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

    public void SetData(ItemTemplate template)
    {
        Name = template.Name;
        ID = template.ID;
        Description = template.Description;
        FileName = template.FileName;
        tags = template.tags;
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
    /// 标签栏
    /// </summary>
    public Tag[] tags = new Tag[3];
}