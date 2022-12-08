using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SetCustomer : MonoBehaviour
{
    private int maxc = 1;//顾客数量

    public Customer[] customerlist;
    
    /// <summary>
    /// 生成一个顾客
    /// </summary>
    public Customer InitCutomer()
    {
        GameObject cus;
        int n = UnityEngine.Random.Range(1, 4);
        cus = Instantiate(Resources.Load("Prefb/Customer" + n.ToString())) as GameObject;
        return cus.AddComponent<Customer>();
    }

    public void DelCustomer()
    {
        Customer cus;

        for(int i = 0; i < maxc; i++)
        {
            cus = customerlist[i];

        }
    }

    // Start is called before the first frame update
    void Start()
    {
        customerlist = new Customer[maxc];

        for (int i = 0; i < maxc; i++)
        {
            customerlist[i] = InitCutomer();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
