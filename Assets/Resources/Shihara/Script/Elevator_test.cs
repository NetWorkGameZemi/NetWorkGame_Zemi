using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator_test: MonoBehaviour
{
    public float move_y;
    float count;

    // Use this for initialization
    void Start()
    {
        StartCoroutine(Loop());
    }

    // Update is called once per frame
    void Update()
    {
        count += Time.deltaTime;
        transform.Translate(0.0f, move_y, 0.0f);
    }

    private IEnumerator Loop()
    {
        while (true)
        {
            //二秒に１回呼び出す
            yield return new WaitForSeconds(2f);
            onMove();
        }
    }

    private void onMove()
    {
        move_y = move_y * -1;
        count = 0;
    }
}
