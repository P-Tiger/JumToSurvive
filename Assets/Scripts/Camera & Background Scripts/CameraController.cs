using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject Player;
    private bool followPlayer = false;
    void FixedUpdate()
    {
        if (Player.transform.position.y < transform.position.y)
        {
            followPlayer = false;
        }

        if (Player.transform.position.y > transform.position.y)
        {
            followPlayer = true;
        }

        if (followPlayer)
        {
            Vector3 temp = transform.position;
            temp.y = Player.transform.position.y;
            transform.position = temp;
        }
    }
}
