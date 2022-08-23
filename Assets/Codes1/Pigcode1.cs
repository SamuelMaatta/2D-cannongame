using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pigcode1 : MonoBehaviour
{
    private GameObject pig = null;
    private float rotation = 0f;
    private float counter = 0;
    // Start is called before the first frame update
    public GameObject toSmoke = null;
    void Start()
    {
        pig = GameObject.Find("Pigball");
    }

    // Update is called once per frame
    void Update()
    {
        this.rotation = this.GetComponent<Transform>().rotation.eulerAngles.z;
        if (this.rotation > 10f && this.rotation < 350f || counter > 5) 
        {
            this.counter = counter + Time.deltaTime * 20;
        }

        if (this.counter > 35)
        {
            GameObject intoThinAir = Instantiate(this.toSmoke, this.GetComponent<Transform>().position,
                                            Quaternion.identity);
            Destroy(intoThinAir.gameObject, 2f);
            Destroy(this.gameObject);
        }
    }
}
