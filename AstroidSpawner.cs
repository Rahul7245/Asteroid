using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AstroidSpawner : MonoBehaviour {

    // Use this for initialization
    public GameObject prefabSamllAstroid;
    public GameObject prefabMediumAstroid;
    public GameObject prefabLargeAstroid;
    Vector3 spawnPosition;
    float TotalTime = 5f;
    float ElaspedTime=0f;
    
    // Update is called once per frame
	void FixedUpdate () {
        if (ElaspedTime < TotalTime)
        {
            ElaspedTime += Time.fixedDeltaTime;
        }
        if(ElaspedTime>= TotalTime)
        {
            SpawnAstroid();
            ElaspedTime = 0;
        }
        
    }

    void SpawnAstroid()
    {
           spawnPosition = new Vector3(Random.Range(ScreenUtils.ScreenLeft, ScreenUtils.ScreenRight),
            Random.Range(ScreenUtils.ScreenBottom, ScreenUtils.ScreenTop), 0);
        ChooseAstroid();
    }
    void ChooseAstroid()
    {
        int randomNumber = Random.Range(1, 3);
        if (randomNumber == 1)
        {
            GameObject Astroid = Instantiate(prefabSamllAstroid, spawnPosition, Quaternion.identity);
         }
        if (randomNumber == 2)
        {
            GameObject Astroid = Instantiate(prefabMediumAstroid, spawnPosition, Quaternion.identity);
        }
        if (randomNumber == 3)
        {
            GameObject Astroid = Instantiate(prefabLargeAstroid, spawnPosition, Quaternion.identity);
        }
    }

}
