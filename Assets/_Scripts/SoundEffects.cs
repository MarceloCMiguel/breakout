using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundEffect : MonoBehaviour
{
    public static AudioClip colisao;
    static AudioSource audioSrc;
    // Start is called before the first frame update
    void Start()
    {
        colisao = Resources.Load<AudioClip>("Collision");
        audioSrc = GetComponent<AudioSource>();
        

    }

    // Update is called once per frame
    void Update()
    {
        audioSrc.PlayOneShot(colisao);
    }
    public static void PlaySound(string clip){
        switch(clip){
            case "colisao":
            audioSrc.PlayOneShot(colisao);
            break;
        }
    }

}
