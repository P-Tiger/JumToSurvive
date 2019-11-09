using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptsBoom : MonoBehaviour
{
    [SerializeField] 
    private GameObject explosion;
    // Start is called before the first frame update
    #region Event Trigger
    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.gameObject.CompareTag("player"))
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (target.gameObject.CompareTag("Destroy"))
        {
            Destroy(gameObject);
        }
    }
    #endregion
}
