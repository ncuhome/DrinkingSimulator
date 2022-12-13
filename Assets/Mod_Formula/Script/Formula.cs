using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft;
using Newtonsoft.Json;
using System.IO;
using System.Linq;
using System;

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
        string[] mt = new string[materials.Length];
        for(int i=0;i< materials.Length; i++)
        {
            mt[i] = materials[i];
        }
        for(int i = 0;i<Materials.Length;i++)
        {
            string m = Materials[i];
            if (m == "Null") { continue; }
            bool ext = false;
            for(int k=0;k< mt.Length;k++)
            {
                if (mt[k] == "Null") { continue; }
                if (mt[k] == m)
                {
                    mt[k] = "Null";
                    ext = true;
                    break;
                }
            }
            if (!ext) { return false; }
        }
        return true;
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