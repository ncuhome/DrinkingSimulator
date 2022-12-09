using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft;
using Newtonsoft.Json;
using System.IO;
using System.Linq;

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
    /// 获取合成物品,
    /// </summary>
    /// <param name="materials">添加的全部配方</param>
    /// <param name="backM">返回的</param>
    /// <returns></returns>
    public static string Make(string[] materials,out string[] backM)
    {
        foreach(Formula formula in formulas) 
        {
            if(formula.isMake(materials))
            {
                backM = formula.getMaterials(materials);
                return formula.Name;
            }
        }
        backM = materials;
        return "不可名状物";
    }

    /// <summary>
    /// 更新配方表
    /// </summary>
    public void UpdateFormula()
    {
        //读取配方表
        string formulaFile = Application.dataPath + path;
        string txt = File.ReadAllText(formulaFile);
        FormulaT[] formulasT = JsonConvert.DeserializeObject<FormulaT[]>(txt);
        formulas = new Formula[formulasT.Length];
        for(int i=0;i<formulas.Length;i++)
        {
            formulas[i] = new Formula(formulasT[i]);
        }
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
    public string[] Materials = new string[7];

    public Formula(FormulaT t)
    {
        Name = t.Name;
        Materials[0] = t.material1;
        Materials[1] = t.material2;
        Materials[2] = t.material3;
        Materials[3] = t.material4;
        Materials[4] = t.material5;
        Materials[5] = t.material6;
        Materials[6] = t.material7;
    }

    /// <summary>
    /// 判断此材料是否可合成此物品
    /// </summary>
    /// <param name="materials">材料组</param>
    /// <returns></returns>
    public bool isMake(string[] materials)
    {
        foreach (string m in Materials)
        {
            bool mk = false;
            if (m == "Null") { continue; }
            foreach(string n in materials)
            {
                if (n == m) { mk = true; }
            }
            if (!mk) { return false; }
        }
        return true;
    }
    /// <summary>
    /// 获取非自身所需材料的材料
    /// </summary>
    /// <returns></returns>
    public string[] getMaterials(string[] materials)
    {
        List<string> list = new List<string>();
        foreach (string m in materials)
        {
            bool mk = false;
            if (m == "Null") { continue; }
            foreach (string n in Materials)
            {
                if (n == m) { mk = true; }
            }
            if (!mk) { list.Add(m); }
        }
        return list.ToArray();
    }
}

class FormulaT
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