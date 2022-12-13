using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Exit : MonoBehaviour
{
    public SpriteRenderer img;
    public float speed = 1;

    private float value = 1;
    private int status = 0;

    private void OnMouseDown()
    {
        ExitQ();
    }

    public void ExitQ()
    {
        Debug.Log("exit");
        Application.Quit();
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        switch(status)
        {
            case 0:
                value -= Time.deltaTime * speed;
                img.color = new Color(value, value, value, 1);
                if (value <= 0.55f) { status = 1; }
                break;
            case 1:
                value += Time.deltaTime * speed;
                img.color = new Color(value, value, value, 1);
                if (value >= 1) { status = 0; }
                break;
        }
    }
}
