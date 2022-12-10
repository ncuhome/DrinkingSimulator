using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SetCustomer : MonoBehaviour
{
    public Material wink;

    private int maxc = 1;//顾客数量

    public ArrayList customerlist = new ArrayList();
    
    /// <summary>
    /// 生成一个顾客(1:人类\2：兽人\3：精灵)
    /// </summary>
    public Customer InitCutomer()
    {
        GameObject cus;
        int n = UnityEngine.Random.Range(1, 4);
        cus = Instantiate(Resources.Load("Prefb/Customer" + n.ToString())) as GameObject;

        if (n == 1)
        {
            int m = UnityEngine.Random.Range(1, 4);
            cus.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Image/person" + m.ToString());
        }
        else if (n == 2)
        {
            int m = UnityEngine.Random.Range(1, 3);
            cus.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Image/animal" + m.ToString());
        }
        else if (n == 3)
        {
            //int m = UnityEngine.Random.Range(1, 3);
            //cus.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("kk") as Sprite;
        }
        return cus.AddComponent<Customer>();
    }
<<<<<<< Updated upstream
    /*
    public void DelCustomer()
    {
        Customer cus;

        if(cus.isevaluate == true)
        {
            //leave
        }
=======


    IEnumerator Wink()
    {

        //Vector4 now1 = wink.GetVector("_Param");
        //float n = Mathf.Lerp(now1.y, 0f, 0.9f * Time.deltaTime);
        //wink.SetVector("_Param", new Vector4(0.8f, n, 1f, 1f));
        customerlist.Add(InitCutomer());
        yield return new WaitForSeconds(1f);//5f


>>>>>>> Stashed changes
    }
    */



    // Start is called before the first frame update
    void Start()
    {
        wink.SetVector("_Param", new Vector4(0.8f, 1f, 1f, 1f));

    }

    // Update is called once per frame
    void Update()
    {
        if (customerlist.Count < maxc)
        {
            StartCoroutine("Wink");

        }
        else
        {
            StopCoroutine("Wink");

            Vector4 now2 = wink.GetVector("_Param");
            float m = Mathf.Lerp(now2.y, 1f, 0.6f * Time.deltaTime);
            wink.SetVector("_Param", new Vector4(0.8f, m, 1f, 1f));
        }


    }
}
