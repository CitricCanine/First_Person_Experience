using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spell : MonoBehaviour
{
    public float manaCost;
    public float shootingForce;
    public float damage;

    public float randA;
    public float randB;

    private void Start() {
        RandomDamage();
    }

    public void RandomDamage()
    {
        damage = Random.Range(randA, randB);
    }
}
