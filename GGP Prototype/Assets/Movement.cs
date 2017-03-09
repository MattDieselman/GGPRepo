using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    float speed = 1;

    private bool collideT = false;
    private bool collideB = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        //var move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
       // transform.position += move * speed * Time.deltaTime;


        this.transform.position += Vector3.right * speed * Time.deltaTime;
        if (this.name == "Cube")
        {
            if (Input.GetKey(KeyCode.Space) && !collideT)
            {
                this.transform.position += Vector3.up * 7  * Time.deltaTime;
            }
            else if ((!collideB && !collideT) || Input.GetKeyUp(KeyCode.Space))
            {
                this.transform.position += Vector3.down * 7  * Time.deltaTime;
            }
        }
        speed += .001f;
	}

    void OnCollisionEnter(Collision c)
    {
        if (this.name == "Cube")
        {
            if (c.gameObject.tag == "Obst")
            {
                this.transform.position = Vector3.zero;
                GameObject[] temp = GameObject.FindGameObjectsWithTag("Scene");
                temp[0].transform.position = new Vector3(0, 4, 0);
                temp[1].transform.position = new Vector3(0, -4, 0);
            }
            if (c.gameObject.name == "Top")
            {
                collideT = true;
            }
            if (c.gameObject.name == "Bot")
            {
                collideB = true;
            }
        }
    }
    void OnCollisionExit(Collision c)
    {
        if (this.name == "Cube")
        {
            if (c.gameObject.name == "Top")
                collideT = false;
            if (c.gameObject.name == "Bot")
                collideB = false;
        }
    }
}
