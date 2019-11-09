using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptCoins : MonoBehaviour
{
    // Start is called before the first frame update
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
