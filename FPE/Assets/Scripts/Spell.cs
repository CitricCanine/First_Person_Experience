using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Spell : MonoBehaviour
{
    public int manaCost;
    EnemyAi enemyAi;
    public float shootingForce;
    public float damage;

    private float randA;
    private float randB;

    private void Start() {
        RandomDamage();
        randA = (damage / 0.7f);
        randB = (damage / 1.3f);
    }

    public void RandomDamage()
    {
        // damage = Random.Range(randA, randB);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Enemy")
        {
            enemyAi = other.GetComponent<EnemyAi>();
            enemyAi.health -= damage;
            Destroy(gameObject);
            Debug.Log("THIS SHIT HITS");
            // grab the health and minus
            // destroy the bullet instantly
        }
        
    }
}
