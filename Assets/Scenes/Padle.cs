using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Padle : MonoBehaviour {
    [SerializeField]
    float speed;

    float height;

    string input;
    public bool isRight;
	// Use this for initialization
	void Start () {
        height = transform.localScale.y;
        speed = 10f;

	}
    public void Init(bool isRightPadle){

        isRight = isRightPadle;

        Vector2 pos = Vector2.zero;

        if(isRightPadle){
            // Place paddle on the right of screen // 오른쪽
            pos = new Vector2(GameManager.topRight.x, 0);
            pos -= Vector2.right * transform.localScale.x;

            input = "PadleRight";
        }else{
            // Place paddle on the left of screen // 왼쪽 
            pos = new Vector2(GameManager.bottomLeft.x, 0);
            pos += Vector2.right * transform.localScale.x;
            input = "PadleLeft";
        }
        // Update this paddle's  positon
        transform.position = pos;
        transform.name = input;
    }

	// Update is called once per frame
	void Update () {
        float move = Input.GetAxis(input) * Time.deltaTime * speed;
        if(transform.position.y < GameManager.bottomLeft.y + height / 2 && move < 0){
            move = 0;
        }
        if (transform.position.y > GameManager.topRight.y - height / 2 && move > 0)
        {
            move = 0;
        }
        transform.Translate(move * Vector2.up);
    }

}
