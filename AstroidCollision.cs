using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidCollision : MonoBehaviour {
    public GameObject prefabSamllAstroid;
    public GameObject prefabMediumAstroid;
  
    // Use this for initialization
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if (gameObject.name.Contains("SmallAstroid"))
            {
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
            if (gameObject.name.Contains("MediumAstroid"))
            {
                Instantiate(prefabSamllAstroid, gameObject.transform.position, Quaternion.identity);
                Instantiate(prefabSamllAstroid, gameObject.transform.position, Quaternion.identity);
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
            if (gameObject.name.Contains("LargeAstroid"))
            {
                Instantiate(prefabMediumAstroid, gameObject.transform.position, Quaternion.identity);
                Instantiate(prefabMediumAstroid, gameObject.transform.position, Quaternion.identity);
                Destroy(collision.gameObject);
                Destroy(gameObject);
            }
        }
    }
}
