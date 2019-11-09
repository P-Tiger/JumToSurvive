using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformsScripts : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField]
    private GameObject Food, Food_1, Food_2, Food_3, Food_4, Food_5, Food_6, Food_7, Food_8, Food_9;
    [SerializeField]
    private Transform spawnPoint;
    private float rand;


    void Start()
    {
        GameObject newFood = null;
        rand = Random.Range(0, 35);
        #region Random Food
        if (rand >= 0 && rand <= 5)
        {
            newFood = Instantiate(Food, spawnPoint.position, Quaternion.identity);
        }
        else if (rand > 5 && rand <= 10)
        {
            newFood = Instantiate(Food_1, spawnPoint.position, Quaternion.identity);
        }
        else if (rand > 15 && rand <= 20)
        {
            newFood = Instantiate(Food_2, spawnPoint.position, Quaternion.identity);
        }
        else if (rand > 25 && rand <= 30)
        {
            newFood = Instantiate(Food_3, spawnPoint.position, Quaternion.identity);
        }
        else if (rand > 30 && rand <= 35)
        {
            newFood = Instantiate(Food_4, spawnPoint.position, Quaternion.identity);
        }
        else if (rand > 35 && rand <= 40)
        {
            newFood = Instantiate(Food_5, spawnPoint.position, Quaternion.identity);
        }
        else if (rand > 40 && rand <= 45)
        {
            newFood = Instantiate(Food_6, spawnPoint.position, Quaternion.identity);
        }
        else if (rand > 45 && rand <= 50)
        {
            newFood = Instantiate(Food_7, spawnPoint.position, Quaternion.identity);
        }
        else if (rand > 50 && rand <= 60)
        {
            newFood = Instantiate(Food_8, spawnPoint.position, Quaternion.identity);
        }
        else 
        {
            newFood = Instantiate(Food_9, spawnPoint.position, Quaternion.identity);
        }
        #endregion

        newFood.transform.parent = transform; // spawn in GameObject Parrent
    }
    #region Event Trigger
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("Destroy"))
        {
            Destroy(gameObject);
        }
    }
    #endregion

}
