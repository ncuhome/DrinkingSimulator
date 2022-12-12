using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class SetCustomer : MonoBehaviour
{
    public Material wink;

    private int maxc = 1;//顾客数量

    //public ArrayList customerlist = new ArrayList();
    public Customer[] customerlist;

    /// <summary>
    /// 生成一个顾客(1:人类\2：兽人\3：精灵)
    /// </summary>
    public Customer InitCutomer()
    {
        GameObject cus;
        int n = UnityEngine.Random.Range(1, 4);
        int m = UnityEngine.Random.Range(1, 4);
        cus = Instantiate(Resources.Load("Prefb/Customer" + n.ToString())) as GameObject;
        Shaker.Instance.canAddWine = true;

        if (n == 1)
        {
            cus.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Image/person" + m.ToString());
        }
        else if (n == 2)
        {
            cus.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Image/animal" + m.ToString());
        }
        else if (n == 3)
        {
            cus.GetComponent<SpriteRenderer>().sprite = Resources.Load<Sprite>("Image/genie" + m.ToString());
        }
        return cus.AddComponent<Customer>();
    }



    IEnumerator Wink()
    {
        Debug.Log("bbb");
        Vector4 now1 = wink.GetVector("_Param");
        float n = Mathf.Lerp(now1.y, 0f, 1.6f * Time.deltaTime);
        wink.SetVector("_Param", new Vector4(0.8f, n, 1f, 1f));
        yield return new WaitForSeconds(5f);//5f
        if(n - 0.1f < 0.01f)
        {
            MediaPlayer.Instance.MediaPlay(Media.Steps);
        }
        if (customerlist[0] != null)
        {
            Destroy(customerlist[0].gameObject);
            customerlist[0] = null;
        }
        yield return new WaitForSeconds(0.5f);

        if (customerlist[0] == null)
        {
            customerlist[0] = InitCutomer();
        }



    }



    // Start is called before the first frame update
    void Start()
    {
        customerlist = new Customer[maxc];
        wink.SetVector("_Param", new Vector4(0.8f, 1f, 1f, 1f));
        customerlist[0] = InitCutomer();
    }

    // Update is called once per frame
    void Update()
    {
        if (customerlist[0] != null)
        {
            if (customerlist[0].evaluate != 0 && customerlist[0].isput == false)
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
}
