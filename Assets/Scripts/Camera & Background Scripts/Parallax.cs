using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Parallax : MonoBehaviour
{
    private float length, startPosition ;
    [SerializeField]
    private Camera cam;
    public float parallaxEffect;
    // Start is called before the first frame update
    void Start()
    {
        startPosition = transform.position.y; 
        length = GetComponent<SpriteRenderer>().bounds.size.y;// get size Background
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Scene currentScene = SceneManager.GetActiveScene ();
        string sceneName = currentScene.name;
        if (sceneName == "GamePlay")
        {
            BackgroundGamePlay();
        }
        else if(sceneName == "GameMenu")
        {
            BackgroundGameMenu();
            
        }
    }

    private void BackgroundGameMenu()
    {
        Vector3 temp = transform.position;
        temp.y = temp.y - parallaxEffect * Time.deltaTime;
        transform.position = temp;
    }

    private void BackgroundGamePlay()
    {
        float temp = cam.transform.position.y * (1 - parallaxEffect);
        float distance = cam.transform.position.y * parallaxEffect; // follow with camera.
        transform.position = new Vector3(transform.position.x, startPosition + distance, transform.position.z);

        if (startPosition + length < temp)
        {
            startPosition += length; // y+
        }   
    }
}
