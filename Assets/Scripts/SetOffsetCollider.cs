using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetOffsetCollider : MonoBehaviour
{
    // Start is called before the first frame update
    public CapsuleCollider2D CapsuleRight;
    public CapsuleCollider2D CapsuleLeft;
    void Awake()
    {
        Vector3 resolutionScreen = new Vector3(Screen.width, Screen.height, 0); 
        var screensize = Camera.main.ScreenToWorldPoint(resolutionScreen);
        CapsuleLeft.offset = new Vector2(-screensize.x, 0);
        CapsuleRight.offset = new Vector2(screensize.x, 0);
    }
}
