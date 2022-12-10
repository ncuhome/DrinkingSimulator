using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using TMPro;
using System.Runtime.CompilerServices;

public class Customer : MonoBehaviour
{
    private int evaluate;//评价(0:未评价\1:不符合\2:低分\3:高分)
    public int[] order;//点单表
    public int[] demand;
    public int type;//顾客类型(0:具体\1:宽泛)

    private TextAsset products;//成品酒单
    private string[] productlist;
    private ArrayList x = new ArrayList() { 0, 1, 2, 3, 4 }; //(甜酸酒温猎)
    private string[] xs = { "甜度", "酸度", "度数", "温度", "猎奇度" };
    private int maxorder = 4;//最大点单数
    private int maxtype = 5;//最大可选择种类数
    private int maxal = 16;//最大可选择酒数
    private string myorder;
    private string myevaluation;
    private TextMeshPro settext;

    /// <summary>
    /// 生成订单
    /// </summary>
    public int[] InitOrder()
    {
        int[] myo;

        int t = UnityEngine.Random.Range(0, 2);
        type = t;

        if (type == 0)
        {
            int n = UnityEngine.Random.Range(1, maxorder + 1);
            int a = UnityEngine.Random.Range(0, maxal);
            myo = new int[n];
            myo[0] = a;

            int k = maxtype;
            demand = new int[n - 1];

            for (int i = 0; i < n - 1; i++)
            {
                int m = UnityEngine.Random.Range(0, k);

                myo[i] = (int)x[m];
                x.Remove(x[m]);
                k--;

                int d = UnityEngine.Random.Range(0, 101);
                demand[i] = d;

            }

            return myo;

        }
        else
        {
            int n = UnityEngine.Random.Range(1, maxorder + 1);
            int k = maxtype;

            myo = new int[n];
            demand = new int[n];

            for (int i = 0; i < n; i++)
            {
                int m = UnityEngine.Random.Range(0, k);

                myo[i] = (int)x[m];
                x.Remove(x[m]);
                k--;

                int d = UnityEngine.Random.Range(0, 101);
                demand[i] = d;

            }

            return myo;

        }
    }

    public string GetOrder()
    {
        string myo = "请给我来一杯";
        int min = 33;
        int mid = 66;
        int max = 100;

        for (int i = order.Length - 1; i > 0; i--)
        {
            myo += xs[order[i]];

            int k;
            if(type == 0)
            {
                k = i - 1;
            }
            else
            {
                k = 1;
            }

            if (demand[k] <= min)
            {
                myo += "低的";
            }
            else if (demand[k] <= mid)
            {
                myo += "适中的";
            }
            else if (demand[k] <= max)
            {
                myo += "高的";
            }
            myo += ",";
        }

        if(type == 0)
        {

            myo += productlist[order[0]];
        }
        else
        {
            myo += xs[order[0]];
            if (demand[0] <= min)
            {
                myo += "低的酒";
            }
            else if (demand[0] <= mid)
            {
                myo += "适中的酒";
            }
            else if (demand[0] <= max)
            {
                myo += "高的酒";
            }
        }

        myo += "吧！";

        return myo;
    }

    public int StartEvaluate(GameObject al)
    {
        int mye = 0;

        int sweet = al.GetComponent<Item>().Sweet;
        int acid = al.GetComponent<Item>().Acid;
        int alcohol = al.GetComponent<Item>().Alcohol;
        int temperature = al.GetComponent<Item>().Temperature;
        int abnormal = al.GetComponent<Item>().Abnormal;

        int s = 0;

        for (int i = 0; i < demand.Length; i++)
        {
            if (order[i] == 0)
            {
                if ((demand[i] >= sweet - 10) && demand[i] <= sweet + 10)
                {
                    s += 1;
                }
            }
            else if (order[i] == 1)
            {
                if ((demand[i] >= acid - 10) && demand[i] <= acid + 10)
                {
                    s += 1;
                }
            }
            else if (order[i] == 2)
            {
                if ((demand[i] >= alcohol - 10) && demand[i] <= alcohol + 10)
                {
                    s += 1;
                }
            }
            else if (order[i] == 3)
            {
                if ((demand[i] >= temperature - 10) && demand[i] <= temperature + 10)
                {
                    s += 1;
                }
            }
            else if (order[i] == 4)
            {
                if ((demand[i] >= abnormal - 10) && demand[i] <= abnormal + 10)
                {
                    s += 1;
                }
            }
        }

        Debug.Log("s:"+s);

        if (demand.Length < 3)
        {
            if(s == demand.Length)
            {
                mye = 3;
            }
            else
            {
                mye = 2;
            }
        }
        else
        {
            if(s >= demand.Length - 1)
            {
                mye = 3;
            }
            else
            {
                mye = 2;
            }
        }

        return mye;

    }

    IEnumerator PutText(string text)
    {
        for (int j = 0; j < text.Length; j++)
        {
            string word = text.Substring((0), j);
            settext.text = word;
            yield return new WaitForSeconds(0.1f);
        }
        yield return new WaitForSeconds(0.4f);

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject al = collision.gameObject;
        if(type == 0)
        {

            if (productlist[order[0]] == al.GetComponent<Item>().Name)
            {
                evaluate = StartEvaluate(al);
                //Destroy(al);
            }
            else
            {
                evaluate = 1;
                //Destroy(al);
            }
        }
        else
        {
            evaluate = StartEvaluate(al);
            //Destroy(al);
        }

        //Debug.Log(evaluate);
        //Debug.Log(al.GetComponent<Item>().Name);
        //Debug.Log(productlist[order[0]]);


    }

    // Start is called before the first frame update
    void Awake()
    {
        products = Resources.Load("Script/Product") as TextAsset;
        productlist = products.text.Split('\n');

        settext = transform.Find("OrderText").gameObject.GetComponent<TextMeshPro>();

        evaluate = 0;
        order = InitOrder();
        myorder = GetOrder();
        StartCoroutine(PutText(myorder));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
