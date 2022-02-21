using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGround_Sound : MonoBehaviour
{
    GameManager gm;
    AudioSource audioSource;
    bool is_pause;
    // private GameObject Audio1;
    // public GameObject raquete;
    // Start is called before the first frame update
    void Start()
    {  
        is_pause = false;
        gm = GameManager.GetInstance();
        // AudioSource Audio1 = GameObject.Find("BG_Sound").getComponent().Stop();
        // Audio1.Stop();
        audioSource = GetComponent<AudioSource>();
        // audioSource.Stop();
        
    }

    // Update is called once per frame
    void Update()
    {
        // audioSource = GetComponent<AudioSource>();
        if (gm.gameState == GameManager.GameState.PAUSE ||gm.gameState == GameManager.GameState.ENDGAME ){
            audioSource.Pause();
            is_pause = true;
        }
        if ((gm.gameState == GameManager.GameState.GAME || gm.gameState == GameManager.GameState.MENU)  && is_pause){
            audioSource.UnPause();
            is_pause = false;
        }
    }
}
