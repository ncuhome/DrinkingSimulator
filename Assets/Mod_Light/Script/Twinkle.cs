using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using static UnityEngine.Rendering.DebugUI.Table;

public class Twinkle : MonoBehaviour
{
    public GameObject arrow;
    public GameObject beer;
    public GameObject letter;
    public GameObject toplight;
    float time1 = 0;
    float time2 = 0;
    float time3 = 0;


    public void Alight()
    {
        time1 += Time.deltaTime;
        if(time1 < 2)
        {
            var now = arrow.GetComponent<SpriteRenderer>().color;
            float n = Mathf.Lerp(now.r, 0.5f, 0.7f * Time.deltaTime);
            arrow.GetComponent<SpriteRenderer>().color = new Color(n, n, n, 1);
        }
        else
        {
            var now = arrow.GetComponent<SpriteRenderer>().color;
            float n = Mathf.Lerp(now.r, 1f, 0.7f * Time.deltaTime);
            arrow.GetComponent<SpriteRenderer>().color = new Color(n, n, n, 1);
        }

        if(time1 >= 4)
        {
            time1 = 0;
        }
    }
    public void Blight()
    {
        time2 += Time.deltaTime;
        if (Mathf.Abs(time2 - 4) < 0.3f)
        {
            float n = UnityEngine.Random.Range(0f, 0.5f);
            float m = UnityEngine.Random.Range(0f, 1f);
            beer.GetComponent<SpriteRenderer>().color = new Color(n, n, n, 1);
            letter.GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, m);
        }
        if (time2 >= 8)
        {
            time2 = 0;
        }
    }

    public void TopLight()
    {
        time3 += Time.deltaTime;
        if (time3 < 2)
        {
            var now = toplight.GetComponent<Light>().color;
            float n = Mathf.Lerp(now.g, 1f, 0.01f);
            toplight.GetComponent<Light>().color = new Color(now.r, n, now.b, now.a);
        }
        else if(time3 < 4)
        {
            var now = toplight.GetComponent<Light>().color;
            float n = Mathf.Lerp(now.b, 2f, 0.01f);
            toplight.GetComponent<Light>().color = new Color(now.r, now.g, n, now.a);
        }
        else if(time3 < 6)
        {
            var now = toplight.GetComponent<Light>().color;
            float n = Mathf.Lerp(now.r, 1f, 0.01f);
            toplight.GetComponent<Light>().color = new Color(n, now.g, now.b, now.a);
        }
        else if (time3 < 8)
        {
            var now = toplight.GetComponent<Light>().color;
            float n = Mathf.Lerp(now.g, 2f, 0.01f);
            toplight.GetComponent<Light>().color = new Color(now.r, n, now.b, now.a);
        }
        else if (time3 < 10)
        {
            var now = toplight.GetComponent<Light>().color;
            float n = Mathf.Lerp(now.b, 1f, 0.01f);
            toplight.GetComponent<Light>().color = new Color(now.r, now.g, n, now.a);
        }
        else if (time3 < 12)
        {
            var now = toplight.GetComponent<Light>().color;
            float n = Mathf.Lerp(now.r, 2f, 0.01f);
            toplight.GetComponent<Light>().color = new Color(n, now.g, now.b, now.a);
        }
        if(time3 > 12)
        {
            time3 = 0;
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame

    void Update()
    {
        Alight();
        Blight();
        TopLight();
    }
}
