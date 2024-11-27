using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamHold : MonoBehaviour
{

    public Transform cameraPostition;

    // Update is called once per frame
    void Update()
    {
        transform.position = cameraPostition.position;
    }
}
