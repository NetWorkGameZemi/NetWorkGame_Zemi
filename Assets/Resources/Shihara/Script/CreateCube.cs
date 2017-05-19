using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateCube : MonoBehaviour {
    public GameObject ItemCube;
    //public GameObject ItemCube2;
          
	// Use this for initialization
	void Start () {
        StartCoroutine(Create());
    }
	
	// Update is called once per frame
	void Update () {
        
	}

    private IEnumerator Create()
    {
        while(true){
            yield return new WaitForSeconds(5f);
            Item();
        }
    }

    void Item()
    {
        for (int i = 0; i < 10; i++)
        {
            Vector3 Position = 
                new Vector3(Random.Range(-10.0f, 10.0f), Random.Range(0,5.0f), Random.Range(-10.0f, 10.0f));
            Instantiate(ItemCube, Position, Quaternion.identity);
            //Instantiate(ItemCube2, Position, Quaternion.LookRotation(Position));

        }
    }
}
