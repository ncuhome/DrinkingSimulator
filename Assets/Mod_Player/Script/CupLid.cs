using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupLid : MonoBehaviour
{
    public float targetPos_y;
    public float curPos_y;
    public bool startMove;
    public float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (startMove)
        {
            transform.localPosition = new Vector3(transform.localPosition.x, curPos_y, transform.localPosition.z);
            if (targetPos_y > 1f)
            {
                if (curPos_y < targetPos_y)
                {
                    curPos_y += Time.deltaTime * moveSpeed;
                }
                else
                {
                    curPos_y = targetPos_y;
                }
            }
            else
            {
                if (curPos_y > targetPos_y)
                {
                    curPos_y -= Time.deltaTime * moveSpeed;
                }
                else
                {
                    curPos_y = targetPos_y;
                }
            }
        }
        else
        {
            curPos_y = transform.localPosition.y;
        }

    }

    private void OnMouseDown()
    {
        Shaker.Instance.OnMouseDown();
    }
}
