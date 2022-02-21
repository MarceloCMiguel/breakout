using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimentoBola : MonoBehaviour
{
    [Range(1, 15)]
    public float velocidade = 7.5f;
    private Vector3 direcao;

    GameManager gm;
    public GameObject raquete;
    private Vector3 raquete_scale;
    // SoundEffect sound_effect;
    // Start is called before the first frame update
    void Start()
    {
        // sound_effect = GameObject.Find("SoundEffect");
        raquete = GameObject.FindGameObjectWithTag("Player");

        float dirX = Random.Range(-5.0f, 5.0f);
        float dirY = Random.Range(1.0f, 5.0f);
        direcao = new Vector3(dirX, dirY).normalized;
        
        gm = GameManager.GetInstance();
        
    }

    // Update is called once per frame
    void Update()
    {
        // primeira execução nas rotinas de Update() da Bola e Raquete.
        if (gm.gameState != GameManager.GameState.GAME) return;
        // Debug.Log($"Vidas: {gm.vidas} \t | \t Pontos: {gm.pontos}");
        transform.position += direcao * Time.deltaTime * velocidade;
        Vector2 posicaoViewport = Camera.main.WorldToViewportPoint(transform.position);
        if( posicaoViewport.x < 0.01 || posicaoViewport.x > 0.995 )
        {
                direcao = new Vector3(-direcao.x, direcao.y);
        }
        if (posicaoViewport.y > 0.99 )
        {
                direcao = new Vector3(direcao.x, -direcao.y);
        }

        if(posicaoViewport.y < 0)
        {
            gm.vidas--;
            raquete.transform.position = new Vector3(0,-4,0);
            // raquete.transform.position = savedPosition;

            Reset();
        }

    }

    public void Go_To_Platform(){
        Vector3 playerPosition = GameObject.FindGameObjectWithTag("Player").transform.position;
       transform.position = playerPosition + new Vector3(0, 0.5f, 0);
       float dirX = Random.Range(-5.0f, 5.0f);
       float dirY = Random.Range(2.0f, 5.0f);
       direcao = new Vector3(dirX, dirY).normalized;
    }



    private void Reset()
   {
       Go_To_Platform();
       
       if(gm.vidas <= 0 && gm.gameState == GameManager.GameState.GAME)
       {
           gm.ChangeState(GameManager.GameState.ENDGAME);
        }     
   }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.gameObject.CompareTag("Player"))
        {
            

            Vector3 ball_position = transform.position;
            raquete_scale = raquete.transform.localScale;
            Vector3 raquete_position = raquete.transform.position;
            Debug.Log($"Raquete scale: {raquete_scale.x}");

            Debug.Log($"Raquete position: {raquete.transform.position}");
            Debug.Log($"Ball position: {ball_position}");
            float dirX = 0.0f;

            if(ball_position.x < raquete_position.x){
                dirX = Random.Range(-5.0f, 0.0f);
            }
            else if (ball_position.x > raquete_position.x){
                dirX = Random.Range(0.0f, 5.0f);
            }
            else{
                dirX = 0.0f;
            }
            // float dirX = Random.Range(-5.0f, 5.0f);
            float dirY = Random.Range(1.0f, 5.0f);

            direcao = new Vector3(dirX, dirY).normalized;
        }
        else if(col.gameObject.CompareTag("Bloco"))
        {
            // sound_effect.PlaySound("colisao");
            direcao = new Vector3(direcao.x, -direcao.y);
            gm.pontos++;
        }
    }

}
