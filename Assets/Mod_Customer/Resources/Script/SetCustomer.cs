using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetCustomer : MonoBehaviour
{
    private int maxc = 2;//顾客数量

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
            if(cus.GetComponent<Customer>().order.Length == 0)
            {
                //顾客离开
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        customerlist = new Customer[maxc - 1];

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
