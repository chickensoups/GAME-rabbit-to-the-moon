using UnityEngine;
using System.Collections;

public class AudioManager : MySingleton<AudioManager>
{

    public AudioSource bombNormal;
    public AudioSource bombShooter;
    public AudioSource bombWave;
    public AudioSource bombTarget;
    public AudioSource bombAcid;
    public AudioSource bulletMeetWall;

    public AudioSource win;
    public AudioSource lose;
    public AudioSource beat;

    public AudioSource bgMusic;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private AudioSource getAudio(Constants.ResourcesName name)
    {
        switch (name)
        {
            case Constants.ResourcesName.bombNormal:
                return bombNormal;
            case Constants.ResourcesName.bombShooter:
                return bombShooter;
            case Constants.ResourcesName.bombWave:
                return bombWave;
            case Constants.ResourcesName.bombTarget:
                return bombTarget;
            case Constants.ResourcesName.bombAcid:
                return bombAcid;
            case Constants.ResourcesName.bulletMeetWall:
                return bulletMeetWall;
            case Constants.ResourcesName.winSound:
                return win;
            case Constants.ResourcesName.loseSound:
                return lose;
            case Constants.ResourcesName.beatSound:
                return beat;
            case Constants.ResourcesName.bgMusic:
                return bgMusic;
            default:
                return bombNormal;
        }
    }

    public void playSound(Constants.ResourcesName name)
    {
        if (PlayerDataUtil.playerData.soundEnabled)
        {
            getAudio(name).Play();
        }
    }
}
