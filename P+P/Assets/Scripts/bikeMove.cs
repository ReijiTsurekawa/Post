using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bikeMove : MonoBehaviour
{
    float speed = 0;
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (speed < 0)
            speed = 0;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            speed = speed + 0.1f;
        }
        else
        {
            if (speed != 0)
                speed = speed - 0.1f;
        }
        this.transform.Translate(1f + speed, 0, 0);
        if (Input.GetKey(KeyCode.RightArrow))
            this.transform.Rotate(new Vector3(0, -1f, 0));
        if (Input.GetKey(KeyCode.LeftArrow))
            this.transform.Rotate(new Vector3(0, 1f, 0));

    }
}
