using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using static UnityEngine.Rendering.DebugUI.Table;

public class Twinkle : MonoBehaviour
{
    public GameObject arrow;
    public GameObject beer;
    float time1 = 0;
    float time2 = 0;


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
            beer.GetComponent<Light2D>().intensity = n;
        }
        if (time2 >= 8)
        {
            time2 = 0;
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
        Debug.Log(time2);
    }
}
