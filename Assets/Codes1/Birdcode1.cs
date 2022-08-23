using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Birdcode1 : MonoBehaviour
{
    public Camera cam;
    private float lookDir = 0f;
    private float previousPosY = -1.1f;
    private float previousPosX = -8.9f;
    private Vector2 direction;
    public GameObject birdBall = null;
    private Vector2 mousePos;
    private float counter = 0f; 
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);

        this.counter = counter + Time.deltaTime * 20;
        Debug.Log("Aika: " + counter);

        direction = mousePos - this.birdBall.GetComponent<Rigidbody2D>().position;
        Debug.Log(direction);
     /*   this.lookDir =  Mathf.Atan2((this.birdBall.GetComponent<Rigidbody2D>().position.y - previousPosY), 
                                        (this.birdBall.GetComponent<Rigidbody2D>().position.x - previousPosX))
                                         * Mathf.Rad2Deg - 180f; */
        this.lookDir =  Mathf.Atan2((direction.y), (direction.x)) * Mathf.Rad2Deg - 90f;
        this.birdBall.GetComponent<Rigidbody2D>().rotation = lookDir;                                                                                       
        Debug.Log(lookDir);
        if ((counter % 5) < 0.05) {
            this.previousPosY = this.birdBall.GetComponent<Rigidbody2D>().position.y;
            this.previousPosX = this.birdBall.GetComponent<Rigidbody2D>().position.x;
        }
    }
}
