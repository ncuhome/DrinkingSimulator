using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shaker : MonoBehaviour
{
    public static Shaker Instance { get; private set; }
    public bool inShaker = false;
    public bool startPour = false;
    public Vector3 pourPos;
    public Vector3 liquidPos;
    public GameObject LiquidPre = null;
    public Transform liquidParent = null;
    public ItemOPC wineOPC = null;
    public MeshRenderer meshRenderer;

    public float pourTime = 0f;

    private float curEuler_z;
    private float targetEuler_z;
    private bool startMix = false;
    public float spinSpeed = 120f;

    private string[] wine = new string[6];
    private int wineIndex = 0;
    public CupLid cupLid;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        wine = new string[6];
        for (int i = 0; i <= 5; i++)
        {
            wine[i] = "Null";
        }
        wineIndex = 0;
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

        if (startMix)
        {
            transform.eulerAngles = new Vector3(0f, 0f, curEuler_z);
            if (targetEuler_z > 0)
            {
                if (curEuler_z < targetEuler_z)
                {
                    curEuler_z += Time.deltaTime * spinSpeed;
                }
                else
                {
                    targetEuler_z = -targetEuler_z;
                }
            }
            else
            {
                if (curEuler_z > targetEuler_z)
                {
                    curEuler_z -= Time.deltaTime * spinSpeed;
                }
                else
                {
                    targetEuler_z = -targetEuler_z;
                }
            }
        }
        else
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
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
            Destroy(liquidPar, 4.0f);
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
    public bool CanAddWine()
    {
        return (wineIndex <= 5);
    }

    public void AddWine(string wineName)
    {
        wine[wineIndex] = wineName;
        wineIndex++;
    }

    public void CloseLid()
    {
        cupLid.startMove = true;
        cupLid.targetPos_y = 0.45f;
        StartCoroutine(StartMix());
    }

    public IEnumerator StartMix()
    {
        yield return new WaitForSeconds(1.2f);
        cupLid.startMove = false;
        startMix = true;
        targetEuler_z = 30f;
        StartCoroutine(OpenLid());
    }

    public IEnumerator OpenLid()
    {
        yield return new WaitForSeconds(2f);
        startMix = false;
        cupLid.startMove = true;
        cupLid.targetPos_y = 1.5f;
        StartCoroutine(EndMix());
    }

    public IEnumerator EndMix()
    {
        yield return new WaitForSeconds(1f);
        cupLid.startMove = false;
        string targetWine = FormulaPanel.Make(wine);
        Debug.Log(wine[0] + " " + wine[1] + " " + wine[2] + " " + wine[3] + " " + wine[4] + " " + wine[5]);
        Debug.Log(targetWine);
        wine = new string[6];
        for (int i = 0; i <= 5; i++)
        {
            wine[i] = "Null";
        }
        wineIndex = 0;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag == "Item")
        {
            inShaker = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.transform.tag == "Item")
        {
            inShaker = false;
        }
    }

    public void OnMouseDown()
    {
        if (startPour) { return; }
        if (wineIndex >= 2)
        {
            CloseLid();
        }
        else
        {
            //提示不能调酒
            Debug.Log("原料不够");
        }
    }
}
