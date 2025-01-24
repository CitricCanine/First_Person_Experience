using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerMagicSystem : MonoBehaviour
{


    /// <summary>
    /// GET RID OF SPELLMANAGER
    /// DONT USE ARRAYS, MAKE LIKE 4 DIFFERENT PUBLIC GAMEOBJECT THINGS FOR SPELL, SPELL1, 2, 3 ECT, ASWELL AS ANOTHER ONE CALLED CURRENTSPELL
    /// MAKE AND IF STATEMENT SOMEWHERE TO ASSIGN THE SPELLS TO AN ID, THEN IF THAT ID MATCHES THAT SPELL, THAT SPELL IS CURRENTSPELL,
    /// (MAKE SURE THEYRE BOTH GAMEOBJECTS OR IT WONT WORK)
    /// </summary>



    [Header("Mana")]

    [SerializeField] private float maxMana = 100f;
    [SerializeField] private float currentMana;
    [SerializeField] private float manaRechargeRate = 2f;

    [Header("Instantiating Miscellaneous")]
    public int spellToCast;
    public Transform castPoint;

    public Rotate castPointRotate;


    // public int currentSpellInUse;
    [Header("Spells")]
    public float spellObjectInUse;
    public GameObject Spell1;
    public GameObject Spell2;
    public GameObject Spell3;
    public GameObject spellInUse;
    
    public void Awake() 
    {
        spellObjectInUse = 1;
        currentMana = maxMana;
    }

    void Update()
    {

        SpellSwap();
        spellSlot();


        for (int i = 0; i < 4; i++)
        {
            // spellToCast = spells[i];
        }

        if (Input.GetButtonDown("Fire1"))
        {
            float cost = transform.GetComponent<PlayerMagicSystem>().spellInUse.gameObject.GetComponent<Spell>().manaCost;
            if (currentMana >= cost)
            {
                currentMana -= cost;
                // run the spawning of it here
                GameObject spell = Instantiate(spellInUse, castPoint.position, castPoint.rotation);
                spell.GetComponent<Rigidbody>().AddForce(castPoint.transform.forward * transform.GetComponent<PlayerMagicSystem>().spellInUse.gameObject.GetComponent<Spell>().shootingForce, ForceMode.Impulse);
            }
            else
            {
                // UI prompt "not enough mana"
            }
        }

        void SpellSwap()
        {
            if (spellObjectInUse == 1)
            {
                spellInUse = Spell1;
            }
            else if (spellObjectInUse == 2)
            {
                spellInUse = Spell2;
            }
            else if (spellObjectInUse == 3)
            {
                spellInUse = Spell3;
            }
        
        }

        void spellSlot()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1))
            {
                spellObjectInUse = 1;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha2))
            {
                spellObjectInUse = 2;
            }
            else if (Input.GetKeyDown(KeyCode.Alpha3))
            {
                spellObjectInUse = 3;
            }
        } 


        // bool isSpellCastHelddown
    }
}
