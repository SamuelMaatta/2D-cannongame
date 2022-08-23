using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannoncode1 : MonoBehaviour
{
    public GameObject cannonBall = null;
    public GameObject smallCannonBall = null;
    private GameObject sight = null;
    private float angle = 0f;
    private float cannonPower = 6000f;
    private GameObject aid = null;
    private int x = 1;
    private Vector2 moveDirection;
    private Vector2 prevPos = new Vector2(-8.9f, 1.1f); 
     private float dirAngle = 0f;
    // Start is called before the first frame update
    void Start()
    {
        this.sight = GameObject.Find("Sight");
    }

    // Update is called once per frame
    void Update()
    {
        this.angle = this.GetComponent<Transform>().rotation.eulerAngles.z;

        if (Input.GetKey(KeyCode.LeftArrow) && (this.angle < 85f))
        {
            this.GetComponent<Transform>().Rotate(0f, 0f, 10f * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow) && (this.angle > 5f))
        {
            this.GetComponent<Transform>().Rotate(0f, 0f, -10f * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            aid = Instantiate(this.cannonBall, this.sight.GetComponent<Transform>().position,
                                            this.sight.GetComponent<Transform>().rotation);
                                        
            float radAngle = this.angle * Mathf.Deg2Rad;
            float x1 = Mathf.Cos(radAngle);
            float y1 = Mathf.Sin(radAngle);

            aid.GetComponent<Rigidbody2D>().AddForce(new Vector2(x1, y1) * this.cannonPower);
            moveDirection = aid.GetComponent<Rigidbody2D>().position - prevPos;
            if(moveDirection != Vector2.zero)
            {
                float dirAngle = Mathf.Atan2(moveDirection.y, moveDirection.x) * Mathf.Rad2Deg + 60f;
                aid.GetComponent<Rigidbody2D>().transform.rotation = Quaternion.AngleAxis(dirAngle, Vector3.forward);
            }

            Destroy(aid.gameObject, 7f);
        }

        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            this.dirAngle = this.aid.GetComponent<Transform>().rotation.eulerAngles.z;
            float radDirAngle = this.dirAngle * Mathf.Deg2Rad;
            float x1 = Mathf.Cos(radDirAngle);
            float y1 = Mathf.Sin(radDirAngle); 
            Debug.Log("Tulostetaan apurit");
            while (x < 4)
            {
                GameObject smallAid = Instantiate(this.smallCannonBall, this.aid.GetComponent<Transform>().position +new Vector3(x/4f,x/3f,0f),
                                                    this.aid.GetComponent<Transform>().rotation);
                smallAid.GetComponent<Rigidbody2D>().AddForce(new Vector2(x1, y1) * this.cannonPower);
            /*   smallAid.GetComponent<Rigidbody2D>().AddForce(new Vector2(this.aid.GetComponent<Transform>().position.x, 
                                                            this.aid.GetComponent<Transform>().position.y) *
                                                            this.cannonPower/2); */
                x++;
                Debug.Log("Tulostetaan apuri nro " + x);
                Destroy(smallAid.gameObject, 7f);
            }
            Destroy(this.aid.gameObject);
            x = 0;
        }
    }
}
