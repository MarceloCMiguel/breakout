using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HighScore : MonoBehaviour
{
    Text textComp;
    GameManager gm;
    int high_score;
    // Start is called before the first frame update
    void Start()
    {
        textComp = GetComponent<Text>();
        gm = GameManager.GetInstance();
        high_score = gm.pontos;
    }

    // Update is called once per frame
    void Update()
    {
        if (gm.pontos > high_score){
            high_score = gm.pontos;
            textComp.text = $"HighScore: {high_score}";
        }
    }
}
