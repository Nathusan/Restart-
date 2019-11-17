using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomHit : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEvent(Collider other)
    {
        if(other.gameObject.Compare("Player"))
        {
            if(gameObject.tag == Round)
            {
                other.
            }
        }
    }
}
