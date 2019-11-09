using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scrolling : MonoBehaviour
{

    public GameObject stopPanel;
    // Start is called before the first frame update
    public float speed;
    // Update is called once per frame
    void FixedUpdate()
    {
        if (transform.position.y - stopPanel.transform.position.y < 0f)
        {
            Vector3 temp = transform.position;
            temp.y = temp.y + speed * Time.deltaTime;
            transform.position = temp;
        }
    }
}
