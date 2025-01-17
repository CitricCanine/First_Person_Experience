using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManager : MonoBehaviour
{
    public float drainMana;
    public float manaCost;

    public List<GameObject> spells;
    public int spellID;

    // public float manaCost;





    void Start()
    {
        spellID = 1;
    }

    public void Update() {
        // BoolValues();
        // currentSpell[0].gameObject = GetComponent<PlayerMagicSystem>().selectedSpell;
        // currentSpell[GetComponent<PlayerMagicSystem>().selectedSpell];
        // manaCost = drainMana;

    }

    public void SpellValues()
    {
        if (spellID == 1)
        {
            spells[0];
        }
        if (spellID == 2)
        {
            spells[1];
        }
    }
}
