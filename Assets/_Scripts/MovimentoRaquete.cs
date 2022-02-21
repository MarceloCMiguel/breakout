using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoRaquete : MonoBehaviour
{   
    [Range(1, 15)]
    public float velocidade=7.5f;
    GameManager gm;
    // Start is called before the first frame update
    void Start()
    {
        gm = GameManager.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        // primeira execução nas rotinas de Update() da Bola e Raquete.
        Vector2 posicaoViewport = Camera.main.WorldToViewportPoint(transform.position);
        if (gm.gameState != GameManager.GameState.GAME) return;
        float inputX = Input.GetAxis("Horizontal");
        if(Input.GetKeyDown(KeyCode.Escape) && gm.gameState == GameManager.GameState.GAME) {
            gm.ChangeState(GameManager.GameState.PAUSE);
        }
        if ((posicaoViewport.x <0 && inputX <0) ||(posicaoViewport.x >1 && inputX >0)){
            return;
        }
        // else if (posicaoViewport.x >1 && inputX >0){
        //     return;
        // }
        else{
            transform.position += new Vector3(inputX, 0, 0) * Time.deltaTime * velocidade;
        }

        
        

        if(Input.GetKeyDown(KeyCode.Escape) && gm.gameState == GameManager.GameState.GAME) {
            gm.ChangeState(GameManager.GameState.PAUSE);
        }
        // Vector3 ballPosition = GameObject.FindGameObjectWithTag("Bola").transform.position;
        // if (ballPosition.y < transform.position.y){
        //     Reset();
        // }
    }

    public void Reset(){
        transform.position = new Vector3(0, -4,0);
    }
}
