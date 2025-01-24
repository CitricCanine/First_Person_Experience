using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestruct : MonoBehaviour
{
    public float timer;
    void Start()
    {
        DestroyObjectDelayed();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void DestroyObjectDelayed()
    {
        // Kills the game object in 5 seconds after loading the object
        Destroy(gameObject, timer);
    }
}
