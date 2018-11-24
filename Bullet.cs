using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
    Rigidbody2D rb2d;
    float ThrustForce=10;
    Vector2 thrustDirection;
    float totalTime = 2f;
    float elaspedTime = 0;
    // Use this for initialization
    void Start () {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        GameObject ship = GameObject.FindGameObjectWithTag("Ship");
        float zRotation = transform.eulerAngles.z * Mathf.Deg2Rad;
        thrustDirection.x = Mathf.Cos(zRotation);
        thrustDirection.y = Mathf.Sin(zRotation);
        rb2d.AddForce(ThrustForce * thrustDirection,
                ForceMode2D.Impulse);
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        elaspedTime += Time.fixedDeltaTime;
        if (elaspedTime >= totalTime)
        {
            Destroy(gameObject);
            
        }
    }
}
