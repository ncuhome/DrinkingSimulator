using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//取代了音频序号的枚举类
public enum Media
{
    Drink_Long = 1,
    Drink_Short = 2,
    Shake = 3,
    Poor_Fast = 4,
    Poor_Slow = 5,
    Drop = 6,
    Cheers = 7
}

public class MediaPlayer : MonoBehaviour
{
    public static MediaPlayer Instance;

    //音频，以及将音频与枚举值相关联的字典
    public AudioClip drink_Long, drink_Short, shake,poor_Fast,poor_Slow,drop,cheers;

    public Dictionary<Media, AudioClip> myMedias = new Dictionary<Media, AudioClip>();

    public AudioSource player;

    private void Awake()
    {
        MediaPlayer.Instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        MediaLoader();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void MediaLoader()
    {
        myMedias.Add(Media.Drink_Long, drink_Long);
        myMedias.Add(Media.Drink_Short, drink_Short);
        myMedias.Add(Media.Shake, shake);
        myMedias.Add(Media.Poor_Fast, poor_Fast);
        myMedias.Add(Media.Poor_Slow, poor_Slow);
        myMedias.Add(Media.Drop, drop);
        myMedias.Add(Media.Cheers, cheers);
    }

    public void MediaPlay(Media mediaName)
    {
        AudioClip audioClip = myMedias[mediaName];

        player = GetComponent<AudioSource>();
        player.Stop();
        player.clip = audioClip;
        player.Play();
    }

}
