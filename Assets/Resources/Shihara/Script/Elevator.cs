using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour {
    public float move_y;
    float count;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        //GameManagerなどを作る場合は使ってください
        //count += Manager.GameCount;

        count += Time.deltaTime;
        transform.Translate(0.0f, move_y, 0.0f);

        if (count > 2)
        {
            move_y = move_y * -1;
            count = 0;
        }    
	}
}
