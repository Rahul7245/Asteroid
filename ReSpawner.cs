using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReSpawner : MonoBehaviour {
    public GameObject prefabShip;
    float ElaspedTime = 0;
    float TotalTime = 2f;
    // Use this for initialization

   
    void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {
        if (!GameObject.FindGameObjectWithTag ("Ship"))
        {
            ElaspedTime += Time.deltaTime;
            if (ElaspedTime >= TotalTime)
            {
                Instantiate(prefabShip);
                ElaspedTime = 0;
            }
        }


        
    }
}
