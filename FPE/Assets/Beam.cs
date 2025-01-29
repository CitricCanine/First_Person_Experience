using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.XR;

public class Beam : MonoBehaviour
{
    public GameObject beam;
    public Transform hand;
    void Awake()
    {
        hand = GameObject.Find("FirePoint").transform;
        beam.transform.parent = hand.transform;
    }
}
