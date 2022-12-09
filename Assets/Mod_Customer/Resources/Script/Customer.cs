using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Customer : MonoBehaviour
{
    public bool isevaluate;
    public int[] order;//点单表
    public int[] demand;
    public int type;//顾客类型(0:具体\1:宽泛)

    private ArrayList x = new ArrayList() { 0, 1, 2, 3, 4 }; //(甜酸酒温猎)
    private int maxorder = 4;//最大点单数
    private int maxtype = 4;//最大可选择种类数
    private int maxal = 16;//最大可选择酒数

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
            int n = UnityEngine.Random.Range(1, maxal + 1);
            myo = new int[1];
            myo[0] = n;

            return myo;

        }
        else
        {
            int n = UnityEngine.Random.Range(1, maxtype + 1);
            int k = 5;

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

    private void OnTriggerStay2D(Collider2D collision)
    {
        GameObject al = collision.gameObject;
        if(type == 0)
        {
            if(al.GetComponent<Item>().ID == (int)order[0])
            {
                Debug.Log("Yes");
                isevaluate = true;
                Destroy(al);
            }
            else
            {
                Debug.Log("No");
                isevaluate = true;
                Destroy(al);
            }
        }
        else
        {
            int sweet = al.GetComponent<Item>().Sweet;
            int acid = al.GetComponent<Item>().Acid;
            int alcohol = al.GetComponent<Item>().Alcohol;
            int temperature = al.GetComponent<Item>().Temperature;
            int abnormal = al.GetComponent<Item>().Abnormal;

            int s = 0;

            for (int i = 0; i < order.Length; i++)
            {
                if(order[i] == 0)
                {
                    if((demand[i] >= sweet-10) || demand[i] <= sweet+10)
                    {
                        s += 1;
                    }
                }
                else if (order[i] == 1)
                {
                    if ((demand[i] >= acid - 10) || demand[i] <= acid + 10)
                    {
                        s += 1;
                    }
                }
                else if (order[i] == 1)
                {
                    if ((demand[i] >= alcohol - 10) || demand[i] <= alcohol + 10)
                    {
                        s += 1;
                    }
                }
                else if (order[i] == 1)
                {
                    if ((demand[i] >= temperature - 10) || demand[i] <= temperature + 10)
                    {
                        s += 1;
                    }
                }
                else if (order[i] == 1)
                {
                    if ((demand[i] >= abnormal - 10) || demand[i] <= abnormal + 10)
                    {
                        s += 1;
                    }
                }
            }

            if (s == order.Length)
            {
                Debug.Log("Yes");
                isevaluate = true;
                Destroy(al);
            }
            else
            {
                Debug.Log("No");
                isevaluate = true;
                Destroy(al);
            }
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        isevaluate = false;
        order = InitOrder();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
