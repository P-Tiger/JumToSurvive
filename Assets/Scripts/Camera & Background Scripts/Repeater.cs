using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Repeater : MonoBehaviour
{
    // Start is called before the first frame update
    private BoxCollider2D groundCollider;
    private float groundHorizontalLenth;


    void Start()
    {
        groundCollider = GetComponent<BoxCollider2D>();
        groundHorizontalLenth = groundCollider.size.y;
    }


    void Update()
    {
        if(transform.position.y < -groundHorizontalLenth)
        {
            Resoposition();
        }
    }


    private void Resoposition()
    {
        Vector2 groundoffset = new Vector2(transform.position.x, groundHorizontalLenth);
        transform.position = (Vector2)transform.position + groundoffset;
    }
}
