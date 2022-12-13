using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;

public enum Tag { Normal }
public class Item : MonoBehaviour
{
    /// <summary>
    /// ????
    /// </summary>
    public string Name;
    /// <summary>
    /// ????
    /// </summary>
    public string Description;
    /// <summary>
    /// ????
    /// </summary>
    public string FileName;
    /// <summary>
    /// ????
    /// </summary>
    public float t;
    /// <summary>
    /// ??
    /// </summary>
    public int Sweet;
    /// <summary>
    /// ??
    /// </summary>
    public int Acid;
    /// <summary>
    /// ????
    /// </summary>
    public int Alcohol;
    /// <summary>
    /// ??
    /// </summary>
    public int Temperature;
    /// <summary>
    /// ????
    /// </summary>
    public int Abnormal;
    /// <summary>
    /// ???????
    /// </summary>
    public bool control;
    /// <summary>
    /// ????
    /// </summary>
    public string LiquidMaterial;
    /// <summary>
    /// ????
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
    /// ????
    /// </summary>
    public string Name;
    /// <summary>
    /// ????
    /// </summary>
    public string Description;
    /// <summary>
    /// ????
    /// </summary>
    public string FileName;

    /// <summary>
    /// ??
    /// </summary>
    public int Sweet;
    /// <summary>
    /// ??
    /// </summary>
    public int Acid;
    /// <summary>
    /// ????
    /// </summary>
    public int Alcohol;
    /// <summary>
    /// ??
    /// </summary>
    public int Temperature;
    /// <summary>
    /// ????
    /// </summary>
    public int Abnormal;
    /// <summary>
    /// ????
    /// </summary>
    public string LiquidMaterial;
    /// <summary>
    /// ????
    /// </summary>
    public string State;
}