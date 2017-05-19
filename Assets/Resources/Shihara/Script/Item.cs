using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour {
    public float Destroytime;


	// Use this for initialization
	void Start () {
       
    }
	
	// Update is called once per frame
	void Update () {

	}

    void OnCollisionEnter(Collision otherObj){
        if(otherObj.gameObject.tag == "Player")
        {
            //player.Point++;
            Destroy(gameObject);
        }

        Destroy(gameObject, Destroytime);
    }
}
