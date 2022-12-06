using UnityEngine;

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
    public string Decription;
    /// <summary>
    /// 贴图名称
    /// </summary>
    public string FileName;
    /// <summary>
    /// 生命影响值
    /// </summary>
    public float HealthEffect;
    /// <summary>
    /// 压力影响值
    /// </summary>
    public float PressureEffect;
    /// <summary>
    /// 醉酒影响值
    /// </summary>
    public float DrunkEffect;
}
