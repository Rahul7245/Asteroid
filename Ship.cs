using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// A ship
/// </summary>
public class Ship : MonoBehaviour
{
    // thrust and rotation support
    Rigidbody2D rb2D;
    Vector2 thrustDirection = new Vector2(1, 0);
    const float ThrustForce = 10;
    const float RetardForce = -10;
    const float RotateDegreesPerSecond = 180;

    // screen wrapping support
    float colliderRadius;

    /// <summary>
    /// Use this for initialization
    /// </summary>
    void Start()
    {
        // saved for efficiency
        rb2D = GetComponent<Rigidbody2D>();
        colliderRadius = GetComponent<CircleCollider2D>().radius;
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        // check for rotation input
        float rotationInput = Input.GetAxis("Rotate");
        if (rotationInput != 0)
        {

            // calculate rotation amount and apply rotation
            float rotationAmount = RotateDegreesPerSecond * Time.deltaTime;
            if (rotationInput < 0)
            {
                rotationAmount *= -1;
            }
            transform.Rotate(Vector3.forward, rotationAmount);

            // change thrust direction to match ship rotation
            float zRotation = transform.eulerAngles.z * Mathf.Deg2Rad;
            thrustDirection.x = Mathf.Cos(zRotation);
            thrustDirection.y = Mathf.Sin(zRotation);

        }

    }
    
    /// <summary>
    /// FixedUpdate is called 50 times per second
    /// </summary>
    void FixedUpdate()
    {
        // thrust as appropriate
        if (rb2D.velocity.magnitude <= 10)
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                rb2D.AddForce(ThrustForce * thrustDirection,
                    ForceMode2D.Force);
            }
       
          if(Input.GetAxis("Vertical") == 0)
            {
                
                rb2D.velocity = Vector3.ClampMagnitude(rb2D.velocity, 0f)*Time.deltaTime*0.05f;
            }
            
        }
        if (rb2D.velocity.magnitude > 10)
        {
            rb2D.velocity = Vector3.ClampMagnitude(rb2D.velocity, 10f);
        }
    }

    /// <summary>
    /// Called when the game object becomes invisible to the camera
    /// </summary>
    /*  void OnBecameInvisible()
      {
          Vector2 position = transform.position;

          // check left, right, top, and bottom sides
          if (position.x + colliderRadius < ScreenUtils.ScreenLeft ||
              position.x - colliderRadius > ScreenUtils.ScreenRight)
          {
              position.x *= -1;
          }
          if (position.y - colliderRadius > ScreenUtils.ScreenTop ||
              position.y + colliderRadius < ScreenUtils.ScreenBottom)
          {
              position.y *= -1;
          }

          // move ship
          transform.position = position;
      }*/
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Astroid")
        {
            HUDLIfe hUDLIfe = new HUDLIfe();
            GameObject gameManager = GameObject.FindGameObjectWithTag("GameManager");
            hUDLIfe = gameManager.GetComponent<HUDLIfe>();
            hUDLIfe.Decrement();
            Destroy(collision.gameObject);
            Destroy(gameObject);
         }
    }
}
