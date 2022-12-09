using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft;
using Newtonsoft.Json;
using System.IO;

public class ItemFormula : MonoBehaviour
{
    /// <summary>
    /// 配方文件路径
    /// </summary>
    public static string path;
    /// <summary>
    /// 配方表
    /// </summary>
    static Formula[] formulas;

    #region 功能

    

    /// <summary>
    /// 更新配方表
    /// </summary>
    public void UpdateFormula()
    {
        //读取配方表
        string formulaFile = Application.dataPath + path;
        string txt = File.ReadAllText(formulaFile);
        formulas = JsonConvert.DeserializeObject<Formula[]>(txt);
    }
    #endregion

    #region Unity

    private void Awake()
    {
        UpdateFormula();
    }

    void Start()
    {
        
    }

    
    void Update()
    {
        
    }
    #endregion
}

class Formula
{
    /// <summary>
    /// 成品名称
    /// </summary>
    public string Name;
    /// <summary>
    /// 材料1名称
    /// </summary>
    public string material1;
    /// <summary>
    /// 材料2名称
    /// </summary>
    public string material2;
    /// <summary>
    /// 材料3名称
    /// </summary>
    public string material3;
    /// <summary>
    /// 材料4名称
    /// </summary>
    public string material4;
    /// <summary>
    /// 材料5名称
    /// </summary>
    public string material5;
    /// <summary>
    /// 材料6名称
    /// </summary>
    public string material6;
    /// <summary>
    /// 材料7名称
    /// </summary>
    public string material7;
}