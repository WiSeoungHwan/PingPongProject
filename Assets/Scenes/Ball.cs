using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour {
    [SerializeField]
    float speed;

    float radius;
    Vector2 direction;
	// Use this for initialization
	void Start () {
        direction = Vector2.one.normalized;
        radius = transform.localScale.x / 2;
	}


    // Update is called once per frame
    void Update () {
        transform.Translate(direction * speed * Time.deltaTime);

        // Bounce off Top and Bottom
        if(transform.position.y < GameManager.bottomLeft.y + radius && direction.y < 0 ){
            direction.y = -direction.y;
        }
        if (transform.position.y > GameManager.topRight.y - radius && direction.y > 0)
        {
            direction.y = -direction.y;
        }

        //Game Over
        if (transform.position.x < GameManager.bottomLeft.x + radius && direction.x < 0){
            Debug.Log("Right Player wins~");
            Time.timeScale = 0;
            enabled = false;
        }
        if (transform.position.x > GameManager.topRight.x - radius && direction.x > 0)
        {
            Debug.Log("Left Player wins~");
            Time.timeScale = 0;
            enabled = false;
        }

	}

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag.Equals("Padle"))
        {
            bool isRight = collision.GetComponent<Padle>().isRight;

            if (isRight && direction.x > 0)
            {
                direction.x = -direction.x;
            }
            if (!isRight && direction.x < 0)
            {
                direction.x = -direction.x;
            }

        }
    }
}
