using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManage : MonoBehaviour
{
    AudioSource audioSource;
    AudioClip shootingPlayer;

    void Awake()
    {
        audioSource = gameObject.AddComponent<AudioSource>();// audio Source
        shootingPlayer = Resources.Load<AudioClip>("Sound/laser_01");

    }
    public void ShootingPlayer()
    {
        audioSource.PlayOneShot(shootingPlayer);
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
