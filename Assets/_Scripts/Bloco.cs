using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bloco : MonoBehaviour
{
    private int life;
    private Color color1;
    private Color white;
    // Start is called before the first frame update
    void Start()
    {
        life = Random.Range(1,3);
        color1= new Color(174,255,251); // era para ir de 0 a 1, mas a cor ficou bem legal e decidi deixar assim.
        // color1 = new Color(0.682353f,1,0.9843137f);
        white = Color.white;

        transform.GetComponent<Renderer>().material.color = color1;
        // life = 2;
        if (life ==2){
            transform.GetComponent<Renderer>().material.color = white;
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
        {
                if (life==1){
                        Destroy(gameObject);
                }
                else{
                    transform.GetComponent<Renderer> ().material.color = color1;
                        life--;
                }
        }
}
