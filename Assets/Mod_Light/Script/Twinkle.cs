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
            float now = arrow.GetComponent<Light2D>().intensity;
            float n = Mathf.Lerp(now, 0f, 4f * Time.deltaTime);
            arrow.GetComponent<Light2D>().intensity = n;
        }
        else
        {
            float now = arrow.GetComponent<Light2D>().intensity;
            float n = Mathf.Lerp(now, 8f, 4f * Time.deltaTime);
            arrow.GetComponent<Light2D>().intensity = n;
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
            int n = UnityEngine.Random.Range(1, 11);
            int m = UnityEngine.Random.Range(1, 8);
            beer.GetComponent<Light2D>().intensity = n;
            letter.GetComponent<Light2D>().intensity = m;
        }
        if (time2 >= 8)
        {
            time2 = 0;
        }
    }

    public void TopLight()
    {
        time3 += Time.deltaTime;
        if (time3 < 1)
        {
            var now = toplight.GetComponent<Light2D>().color;
            float n = Mathf.Lerp(now.g, 1f, 0.01f);
            toplight.GetComponent<Light2D>().color = new Color(now.r, n, now.b, now.a);
        }
        else if(time3 < 2)
        {
            var now = toplight.GetComponent<Light2D>().color;
            float n = Mathf.Lerp(now.b, 1.5f, 0.01f);
            toplight.GetComponent<Light2D>().color = new Color(now.r, now.g, n, now.a);
        }
        else if(time3 < 3)
        {
            var now = toplight.GetComponent<Light2D>().color;
            float n = Mathf.Lerp(now.r, 1f, 0.01f);
            toplight.GetComponent<Light2D>().color = new Color(n, now.g, now.b, now.a);
        }
        else if (time3 < 4)
        {
            var now = toplight.GetComponent<Light2D>().color;
            float n = Mathf.Lerp(now.g, 1.5f, 0.01f);
            toplight.GetComponent<Light2D>().color = new Color(now.r, n, now.b, now.a);
        }
        else if (time3 < 5)
        {
            var now = toplight.GetComponent<Light2D>().color;
            float n = Mathf.Lerp(now.b, 1f, 0.01f);
            toplight.GetComponent<Light2D>().color = new Color(now.r, now.g, n, now.a);
        }
        else if (time3 < 6)
        {
            var now = toplight.GetComponent<Light2D>().color;
            float n = Mathf.Lerp(now.r, 1.5f, 0.01f);
            toplight.GetComponent<Light2D>().color = new Color(n, now.g, now.b, now.a);
        }
        if(time3 > 6)
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
        //TopLight();
        //Debug.Log(time2);
        TopLight();
    }
}
