using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
    [SerializeField]
    Ball ball;
    [SerializeField]
    Padle padle;
    public static Vector2 bottomLeft;
    public static Vector2 topRight;
    // Use this for initialization
    void Start()
    {
        // convert screen's pixel cordinate into game's cordinate ( in this case 0, 0 ) 
        bottomLeft = Camera.main.ScreenToWorldPoint(new Vector2(0, 0));
        topRight = Camera.main.ScreenToWorldPoint(new Vector2(Screen.width, Screen.height));


        Instantiate(ball);

        Padle padle1 = Instantiate(padle) as Padle;
        Padle padle2 = Instantiate(padle) as Padle;
        padle1.Init(true); // right padle 
        padle2.Init(false); // left padle 


    }
	// Update is called once per frame
	void Update () {
		
	}
}
