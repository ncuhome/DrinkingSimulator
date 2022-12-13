using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BubbleTextLoader : MonoBehaviour
{
    public static BubbleTextLoader instance;

    public TMP_Text bubbleText;

    public GameObject bubble;
    public GameObject customer;

    // Start is called before the first frame update
    void Start()
    {
        BubblePop();
    }

    // Update is called once per frame
    void Update()
    {

    }

    //获取内容
    public void GetBubbleText(string text)
    {
        bubbleText.text = text;
        bubble.SetActiveRecursively(true);
        Invoke("BubblePop", 10);
    }

    //获取顾客坐标，使对话气泡出现在顾客右上方
    void GetBubblePostion()
    {
        float x = customer.GetComponent<RectTransform>().anchoredPosition.x;
        float y = customer.GetComponent<RectTransform>().anchoredPosition.y;

        bubble.transform.position = new Vector2(x + 50, y + 50);
    }

    //气泡消失(可加入特定条件)
    void BubblePop()
    {
        bubble.SetActiveRecursively(false);
    }
}
