using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapper : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (gameObject.transform.position.x > ScreenUtils.ScreenRight)
        {
            gameObject.transform.position = new Vector3(ScreenUtils.ScreenLeft, 
               - gameObject.transform.position.y, 0);
        }
        if (gameObject.transform.position.x < ScreenUtils.ScreenLeft)
        {
            gameObject.transform.position = new Vector3(ScreenUtils.ScreenRight,
                -gameObject.transform.position.y, 0);
        }
        if (gameObject.transform.position.y < ScreenUtils.ScreenBottom)
        {
            gameObject.transform.position = new Vector3(- gameObject.transform.position.x, ScreenUtils.ScreenTop, 0);
        }
        if (gameObject.transform.position.y > ScreenUtils.ScreenTop)
        {
            gameObject.transform.position = new Vector3(-gameObject.transform.position.x, ScreenUtils.ScreenBottom, 0);
        }
    }
}
