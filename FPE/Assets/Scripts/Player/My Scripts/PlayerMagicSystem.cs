using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMagicSystem : MonoBehaviour
{
    [SerializeField] private float maxMana = 100f;
    [SerializeField] private float currentMana;
    [SerializeField] private float manaRechargeRate = 2f;
    [SerializeField] private Transform castPoint;

    public GameObject spellToCast;
    public GameObject shootingPoint;

    public GameObject[] spells;


    void Awake() {
        
    }    
    

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GameObject spell = Instantiate(spells[0], transform.position, transform.rotation);
            // currentMana -= spell.GetComponent<SpellManager>().drainMana;
        }


        
        // bool isSpellCastHelddown
    }
}
