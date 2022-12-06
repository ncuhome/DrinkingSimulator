using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaker : MonoBehaviour
{
    public static Shaker Instance { get; private set; }
    public Transform wineSlider = null;
    private float wineScale_y = 0f;
    private float winePosition_y = -3f;
    public Boolean inShaker = false;
    public Boolean startPour = false;
    public Vector3 pourPos;
    public Item wine;
    /// <summary>
    /// 生命影响值
    /// </summary>
    public float HealthEffect;
    /// <summary>
    /// 压力影响值
    /// </summary>
    public float PressureEffect;
    /// <summary>
    /// 醉酒影响值
    /// </summary>
    public float DrunkEffect;

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
            HealthEffect += Time.deltaTime * wine.HealthEffect;
            PressureEffect += Time.deltaTime * wine.PressureEffect;
            DrunkEffect += Time.deltaTime * wine.DrunkEffect;

            wineScale_y += Time.deltaTime * 6f / 10f;
            winePosition_y += Time.deltaTime * 3f / 10f;
            wineSlider.localScale.Set(4.2f, wineScale_y, 1f);
            wineSlider.localPosition.Set(0f, winePosition_y, 0f);
        }

        if (pourTime >= 10f)
        {
            EndPour();
        }
    }

    public void StartPour()
    {
        startPour = true;
    }

    public void EndPour()
    {
        startPour = false;
    }

    public void Drink()
    {
        HealthEffect /= pourTime;
        PressureEffect /= pourTime;
        DrunkEffect /= pourTime;
        pourTime = 0f;
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
