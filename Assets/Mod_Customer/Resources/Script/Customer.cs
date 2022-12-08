using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class Customer : MonoBehaviour
{
    private ArrayList x = new ArrayList() {0, 1, 2, 3, 4}; //(甜酸酒温猎)
    public int[] order;//点单表
    public int[] demand;
    public int type;//顾客类型(0:具体\1:宽泛)


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

                Destroy(al);
            }
            else
            {
                Debug.Log("No");
            }
        }
        else
        {

        }

    }

    // Start is called before the first frame update
    void Start()
    {
        order = InitOrder();
    }

    // Update is called once per frame
    void Update()
    {

    }
}
