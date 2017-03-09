using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manage : MonoBehaviour {
    public GameObject prefab;
    public GameObject[] spawns = new GameObject[10];
	// Use this for initialization
	void Start () {
        for (int i = 0; i < 10; i++)
        {
            spawns[i] = new GameObject();
            Instantiate(prefab, spawns[i].transform);
            Create(Random.Range(0, 100), Random.Range(-4, 4), spawns[i],0, Random.Range(-90, 90));
        }
	}
    void Create(float x_,float y_,GameObject g,float deltaY, float deltaZ)
    {
        g.transform.position = new Vector3(x_, y_, 0);
        g.transform.Rotate(0,deltaY,deltaZ);
        
    }
	// Update is called once per frame
	void Update () {
		
	}
}
