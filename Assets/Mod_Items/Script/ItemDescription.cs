using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
        animator.SetBool("display",true);
    }

    public void Disappear()
    {
        animator.SetBool("display", false);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
