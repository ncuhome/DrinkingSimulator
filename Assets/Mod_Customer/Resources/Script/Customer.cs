using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Customer : MonoBehaviour
{
    public int[] order;//�㵥��


    private int maxo = 4;//���㵥��
    private int maxi = 5;//����ѡ����

    /// <summary>
    /// ���ɶ���
    /// </summary>
    public int[] InitOrder()
    {
        int n = UnityEngine.Random.Range(1, maxo + 1);
        int[] myo = new int[n];

        for (int i = 0; i < n; i++)
        {
            int m = UnityEngine.Random.Range(0, maxi);
            myo[i] = m;
        }

        return myo;
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
