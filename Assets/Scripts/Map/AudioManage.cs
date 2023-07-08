using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManage : MonoBehaviour
{
    AudioSource audioSource;
    AudioClip shootingPlayer;
    AudioClip shootingCreeps;

    void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();// audio Source
        shootingPlayer = Resources.Load<AudioClip>("Sound/laser_01");
        shootingCreeps = Resources.Load<AudioClip>("Sound/laser_02");


    }
    public void ShootingPlayer()
    {
        audioSource.PlayOneShot(shootingPlayer);
    }
    public void ShootingCreeps()
    {
        audioSource.PlayOneShot(shootingCreeps);
    }
    public static AudioManage GetAudio()
    {
        GameObject audio = GameObject.FindGameObjectWithTag("audio");
        AudioManage audio_manager = audio.GetComponent<AudioManage>();
        return audio_manager;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
