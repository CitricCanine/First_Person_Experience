using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMagicSystem : MonoBehaviour
{
    [SerializeField] private float maxMana = 100f;
    [SerializeField] private float currentMana;
    [SerializeField] private float manaRechargeRate = 2f;

    public int spellToCast;
    public Transform castPoint;

    public Rotate castPointRotate;
    public GameObject[] spells;

    


    void Awake() 
    {
        
    }    
    

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Alpha1) && currentMana > GetComponent<SpellManager>().drainMana)
        {
            GameObject spell = Instantiate(spells[0], castPoint.position, castPoint.rotation);
            spell.GetComponent<Rigidbody>().AddForce(transform.forward * 10, ForceMode.Impulse);
            currentMana -= spell.GetComponent<SpellManager>().drainMana;
            if (currentMana < GetComponent<SpellManager>().drainMana)
            {
                print("NO MANA");
            }
        }


        
        // bool isSpellCastHelddown
    }
}
