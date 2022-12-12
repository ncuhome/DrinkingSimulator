using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;
using TMPro;
using System.Runtime.CompilerServices;
using UnityEngine.Windows;

public class Customer : MonoBehaviour
{
    public int evaluate;//评价(0:未评价\1:不符合\2:低分\3:高分)
    public int[] order;//点单表
    public int[] demand;
    public int type;//顾客类型(0:具体\1:宽泛)
    public bool isput = true;
    public GameObject bubble;

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
    private bool startDrink;

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

            int k = maxtype;
            demand = new int[n];

            for (int i = 0; i < n; i++)
            {
                int m = UnityEngine.Random.Range(0, k);

                if (i == 0)
                {
                    myo[i] = a;
                    demand[i] = -1;
                }
                else
                {
                    myo[i] = (int)x[m];
                    x.Remove(x[m]);
                    k--;

                    int d = UnityEngine.Random.Range(0, 101);
                    demand[i] = d;
                }

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

    public void GetProducts()
    {
        products = Resources.Load("Script/Product") as TextAsset;
        productlist = products.text.Split('\n', StringSplitOptions.RemoveEmptyEntries);

        for (int i = 0; i < productlist.Length; i++)
        {
            productlist[i] = productlist[i].Substring(0, productlist[i].Length - 1);
        }
    }

    public string GetEvaluation(int e)
    {
        string mye;

        TextAsset evaluations = Resources.Load("Script/Evaluation") as TextAsset;
        string[] tmplist = evaluations.text.Split('\n');
        string[] evaluationlist = tmplist[e - 1].Split('-');

        int n = UnityEngine.Random.Range(0, evaluationlist.Length + 1);

        if(n < evaluationlist.Length)
        {
            mye = evaluationlist[n];
            return mye;
        }
        else
        {
            mye = evaluationlist[n - 1];
            return mye;
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


            if (demand[i] <= min)
            {
                myo += "低的";
            }
            else if (demand[i] <= mid)
            {
                myo += "适中的";
            }
            else if (demand[i] <= max)
            {
                myo += "高的";
            }
            myo += ",";
        }

        if (type == 0)
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

    public int StartEvaluate(GameObject al, int n)
    {
        int mye = 0;
        int r = 20;

        int sweet = al.GetComponent<Item>().Sweet;
        int acid = al.GetComponent<Item>().Acid;
        int alcohol = al.GetComponent<Item>().Alcohol;
        int temperature = al.GetComponent<Item>().Temperature;
        int abnormal = al.GetComponent<Item>().Abnormal;

        int s = 0;

        for (int i = n; i < demand.Length; i++)
        {
            if (order[i] == 0)
            {
                if ((demand[i] >= sweet - 30 - r) && demand[i] <= sweet - 30 + r)
                {
                    s += 1;
                }
            }
            else if (order[i] == 1)
            {
                if ((demand[i] >= acid + 20 - r) && demand[i] <= acid + 20 + r)
                {
                    s += 1;
                }
            }
            else if (order[i] == 2)
            {
                if ((demand[i] >= alcohol - 40 - r) && demand[i] <= alcohol - 40 + r)
                {
                    s += 1;
                }
            }
            else if (order[i] == 3)
            {
                if ((demand[i] >= temperature + 80 - r) && demand[i] <= temperature + 80 + r)
                {
                    s += 1;
                }
            }
            else if (order[i] == 4)
            {
                if ((demand[i] >= abnormal - 150 - r) && demand[i] <= abnormal - 150 + r)
                {
                    s += 1;
                }
            }
        }

        if (demand.Length < 3)
        {
            if (s == demand.Length)
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
            if (s >= demand.Length - 1)
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
        isput = true;
        if (text[0] != '请')
        {
            bubble.transform.position = new Vector3(9f, 1.8f, 0f);
            bubble.transform.localScale = new Vector3(2.76f, 4f, 1f);
            for (int j = 0; j < 6; j++)
            {
                string word = "······".Substring((0), j);
                settext.text = word;
                yield return new WaitForSeconds(0.15f);
            }
        }
        yield return new WaitForSeconds(1f);

        for (int j = 0; j < text.Length; j++)
        {
            string word = text.Substring((0), j);
            settext.text = word;
            bubble.transform.localPosition = new Vector3(9f, (float)(1.8f - ((int)(settext.text.Length / 8) * 0.35f)), 0f);
            bubble.transform.localScale = new Vector3(2.76f, (float)(4f + ((int)(settext.text.Length / 8) * 1.2f)), 1f);

            yield return new WaitForSeconds(0.15f);
        }
        yield return new WaitForSeconds(5f);

        isput = false;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // if (collision.tag != "Product") { return; }
        // if (!startDrink) { return; }
        // GameObject al = collision.gameObject;

        // if (type == 0)
        // {

        //     if (al.GetComponent<Item>().Name == productlist[order[0]])
        //     {
        //         Debug.Log("a");
        //         int e = StartEvaluate(al, 1);
        //         StartCoroutine("PutText", GetEvaluation(e));
        //         evaluate = e;
        //     }
        //     else
        //     {
        //         StartCoroutine("PutText", GetEvaluation(1));
        //         evaluate = 1;
        //     }
        // }
        // else
        // {
        //     int e = StartEvaluate(al, 0);
        //     StartCoroutine("PutText", GetEvaluation(e));
        //     evaluate = e;
        // }

    }

    public void Drink(GameObject al)
    {
        startDrink = true;
        if (type == 0)
        {

            if (al.GetComponent<Item>().Name == productlist[order[0]])
            {
                Debug.Log("a");
                int e = StartEvaluate(al, 1);
                StartCoroutine("PutText", GetEvaluation(e));
                evaluate = e;
            }
            else
            {
                StartCoroutine("PutText", GetEvaluation(1));
                evaluate = 1;
            }
        }
        else
        {
            int e = StartEvaluate(al, 0);
            StartCoroutine("PutText", GetEvaluation(e));
            evaluate = e;
        }

    }

    // Start is called before the first frame update
    void Awake()
    {
        GetProducts();

        settext = transform.Find("OrderText").gameObject.GetComponent<TextMeshPro>();
        bubble = transform.Find("Bubble").gameObject;

        evaluate = 0;
        order = InitOrder();
        myorder = GetOrder();
        StartCoroutine(PutText(myorder));
    }

    // Update is called once per frame
    void Update()
    {
        if (evaluate == 0)
        {
            isput = true;
        }

        if (isput == false)
        {
            StopCoroutine("PutText");
        }
    }
}
