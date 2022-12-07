using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaker : MonoBehaviour
{
    public static Shaker Instance { get; private set; }
    public Boolean inShaker = false;
    public Boolean startPour = false;
    public Vector3 pourPos;
    public ItemOPC wineOPC = null;
    public Transform maskTransform = null;
    public float maskPos_y = 0f;

    public float pourTime = 0f;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (startPour)
        {
            pourTime += Time.deltaTime;
            maskPos_y -= Time.deltaTime * 200f;
            maskTransform.localPosition = new Vector3(30f, maskPos_y, 10f);
        }

        if (pourTime >= 1f)
        {
            EndPour();
        }
    }

    public void StartPour()
    {
        startPour = true;
        maskPos_y = -100f;
    }

    public void EndPour()
    {
        pourTime = 0f;
        maskTransform.localPosition = new Vector3(30f, -100f, 10f);
        startPour = false;
        wineOPC.EndPourSpin();
    }

    public void Drink()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        inShaker = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        inShaker = false;
    }
}
