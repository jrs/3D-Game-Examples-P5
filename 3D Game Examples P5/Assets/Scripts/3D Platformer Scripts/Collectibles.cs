using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectibles : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            GameObject.Find("Game Session").GetComponent<UIComponents>().UpdateCoinCount();
            Destroy(this.gameObject);
        }
    }
}
