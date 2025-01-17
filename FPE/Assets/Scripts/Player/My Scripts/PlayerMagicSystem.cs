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



















    public int currentSpellInUse;

    public float shootingForce;

    [SerializeField] private float maxMana = 100f;
    [SerializeField] private float currentMana;
    [SerializeField] private float manaRechargeRate = 2f;

    public int spellToCast;
    public Transform castPoint;

    public Rotate castPointRotate;
    public GameObject[] spells;

    public int selectedSpell;
    
    public void Awake() 
    {
        selectedSpell = 0;
    }

    void Update()
    {
        for (int i = 0; i < 4; i++)
        {
            // spellToCast = spells[i];
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            float cost = transform.GetComponent<PlayerMagicSystem>().spells[currentSpellInUse].gameObject.GetComponent<Spell>().manaCost;
            if (currentMana >= cost)
            {
                currentMana -= cost;
                // run the spawning of it here
                GameObject spell = Instantiate(spells[selectedSpell], castPoint.position, castPoint.rotation);
                spell.GetComponent<Rigidbody>().AddForce(castPoint.transform.forward * shootingForce, ForceMode.Impulse);
            }
            else
            {
                // UI prompt "not enough mana"
            }
        }


        
        // bool isSpellCastHelddown
    }
}
