using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestButton : MonoBehaviour
{
    private AudioSource player;

    MediaPlayer MediaPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickLDButton()
    {
        MediaPlayer.Instance.MediaPlay(Media.Drink_Long);
    }
}
