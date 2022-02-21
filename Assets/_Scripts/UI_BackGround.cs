using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_BackGround : MonoBehaviour
{

    public GameObject BackGroundImage;
    // Start is called before the first frame update
    void Start()
    {
        ScreenCredentials();
    }

    public void ScreenCredentials(){
        var heigh = Camera.main.orthographicSize *2;
        var width = heigh * Screen.width / Screen.height;
        var backg = BackGroundImage.GetComponent<SpriteRenderer>().sprite;
        var unitWidth = backg.textureRect.width / backg.pixelsPerUnit;  
        var unitHeigt = backg.textureRect.height / backg.pixelsPerUnit;
        BackGroundImage.GetComponent<SpriteRenderer>().transform.localScale = new Vector3(width / unitWidth, heigh / unitHeigt);
    } 

    // Update is called once per frame
    void Update()
    {
        
    }
}
