using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpellManager : MonoBehaviour
{
    public float drainMana;

    public bool[] currentSpell;

    public float manaCost;
    public void Update() {
        BoolValues();
        currentSpell[] = GetComponent<PlayerMagicSystem>().selectedSpell;

        manaCost = drainMana;

    }

    public void BoolValues()
    {
        if (currentSpell[0])
        {
            manaCost = 20;
        }
        if (currentSpell[1])
        {
            manaCost = 50;
        }
    }
}
