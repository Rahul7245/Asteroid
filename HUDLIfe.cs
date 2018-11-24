using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public  class HUDLIfe : MonoBehaviour {
    public Text lifeText;
   public static int life = 5;
    public static float Life
    {
        get { return life; }
    }
    // Use this for initialization
    void Awake () {
        lifeText.text = "LIFE_LEFT: " + life;
	}
	
	// Update is called once per frame
	public  void Decrement()
    {
        life -= 1;
        lifeText.text = "LIFE_LEFT: " + life;
        
    }
    
}
