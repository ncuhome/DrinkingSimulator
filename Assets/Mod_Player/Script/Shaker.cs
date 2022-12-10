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
    public Vector3 liquidPos;
    public GameObject LiquidPre = null;
    public Transform liquidParent = null;
    public ItemOPC wineOPC = null;
    public MeshRenderer meshRenderer;

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
        }

        if (pourTime >= 3f)
        {
            EndPour();
        }
    }

    public void InstantiateLiquid()
    {
        for (int i = 0; i < 40; i++)
        {
            var random = UnityEngine.Random.value;
            var liquidPar = Instantiate(LiquidPre, liquidPos + new Vector3(random * 50, random * 40, 0), Quaternion.identity);
            liquidPar.GetComponent<Rigidbody2D>().velocity = new Vector3(-random * 50, -random * 40, 0);
            liquidPar.transform.SetParent(liquidParent);
            Destroy(liquidPar, 6.0f);
        }
    }

    public void StartPour()
    {
        inShaker = false;
        startPour = true;
    }

    public void EndPour()
    {
        pourTime = 0f;
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
