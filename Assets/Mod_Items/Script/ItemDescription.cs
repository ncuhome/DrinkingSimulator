using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Threading;

public class ItemDescription : MonoBehaviour
{
    /// <summary>
    /// 名称文本
    /// </summary>
    public TMP_Text nameK;
    /// <summary>
    /// 描述文本
    /// </summary>
    public TMP_Text descriptionK;
    /// <summary>
    /// 本体动画器
    /// </summary>
    public Animator animator;

    public int status = 0;
    private float timer = 0;

    public void Display(string Name,string Desctiption)
    {
        nameK.text = Name;

        float x = Input.mousePosition.x;
        float y = Input.mousePosition.y;

        if(y < 500)
        {
            y = 500;
        }
        if(x > 1520)
        {
            x = 1520;
        }
        transform.position = new Vector2(x, y);

        descriptionK.text = Desctiption;
    }

    public void Disappear()
    {
        animator.SetBool("display", false);
    }

    // Update is called once per frame
    void Update()
    {
        switch (status)
        {
            case 0://等待鼠标进入

                break;
            case 1://鼠标已进入区域
                timer = 0;
                status = 2;
                break;
            case 2://延时显示
                timer += Time.deltaTime;
                if(timer > 0.5f)
                {
                    animator.SetBool("display", true);
                }
                break;
        }
    }
}
