using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour {
    public GameObject prefabBullet;
     GameObject ship;
    // Use this for initialization
    private void Start()
    {
        ship = GameObject.FindGameObjectWithTag("Ship");
    }
    // Update is called once per frame
    void Update () {
        if (Input.GetKeyUp(KeyCode.LeftAlt))
        {
          GameObject bullet=  Instantiate(prefabBullet, ship.transform.position, Quaternion.identity);
            bullet.transform.rotation = ship.transform.rotation;
        }
	}
}
