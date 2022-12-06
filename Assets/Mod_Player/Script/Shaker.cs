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
