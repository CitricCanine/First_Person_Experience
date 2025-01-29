using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
// using UnityEngine.UIElements;

public class PlayerMagicSystem : MonoBehaviour
{
    //sumary
    //okay so you got overall cooldowns working, next up, make boolians to check WHICH spellslot is shooting, and make seperate couroutines for shooting like, ShootSpell1, and then have 
    //boolians like IsSpell1Firing which then lets you have individual spell cooldowns
    //summary

    [Header("Mana")]

    [SerializeField] private int maxMana = 100;
    [SerializeField] private float currentMana;
    [SerializeField] private float manaRechargeRate = 0.2f;

    public Slider slider;

    [Space(10)]
    
    [Header("Instantiating Miscellaneous")]
   
    public Transform castPoint;

    [Space(10)]
    
    [Header("Spells")]
    public float spellObjectInUse;

    public GameObject Spell1;
    public GameObject Spell2;
    public GameObject Spell3;

    [Space(15)]
    public bool firing;
    [Space(15)]
    public GameObject spellInUse;
    public float cooldownTimer;
    
    [Space(10)]
    public float tim;
    
    
    public void Awake() 
    {
        spellObjectInUse = 1;
        currentMana = maxMana;
        firing = false;
        slider.maxValue = maxMana;
    }

    void Update()
    {
        spellSlot();
        SpellSwap();
        SpellShoot();    
        
        tim = tim += Time.deltaTime;

        slider.value = currentMana;
    }
        void SpellShoot()
        {
            int cost = transform.GetComponent<PlayerMagicSystem>().spellInUse.gameObject.GetComponent<Spell>().manaCost;

            if (Input.GetButtonDown("Fire1") && firing == false) if (currentMana >= cost && firing == false) StartCoroutine(shoot());
            if (currentMana <= maxMana)
            {
                Debug.Log("THIS WORKS SOMEHOW");
                if (tim >= 2.5f)
                {
                    firing = true;
                    currentMana += manaRechargeRate;
                        if (currentMana >= maxMana)
                        {
                            tim = 0;
                            currentMana = maxMana;
                            firing = false;
                        }
                    }
                }
        }
        void SpellSwap()
        {
            if (spellObjectInUse == 1)
            {
                spellInUse = Spell1;
                cooldownTimer = 1.5f;
            }
            else if (spellObjectInUse == 2)
            {
                spellInUse = Spell2;
                cooldownTimer = 5f;
            }
            else if (spellObjectInUse == 3) 
            {
                spellInUse = Spell3;
                cooldownTimer = 10.00f;
            }
        }
        void spellSlot()
        {
            if (Input.GetKeyDown(KeyCode.Alpha1) && firing == false) spellObjectInUse = 1;
            else if (Input.GetKeyDown(KeyCode.Alpha2) && firing == false) spellObjectInUse = 2;
            else if (Input.GetKeyDown(KeyCode.Alpha3) && firing == false) spellObjectInUse = 3;
        }
        public IEnumerator shoot()
        {
            yield return new WaitForSeconds(0.01f);
            
                firing = true;

                int cost = transform.GetComponent<PlayerMagicSystem>().spellInUse.gameObject.GetComponent<Spell>().manaCost;
                
                currentMana -= cost;
                GameObject spell = Instantiate(spellInUse, castPoint.position, castPoint.rotation);
                spell.GetComponent<Rigidbody>().AddForce(castPoint.transform.forward * transform.GetComponent<PlayerMagicSystem>().spellInUse.gameObject.GetComponent<Spell>().shootingForce, ForceMode.Impulse);

                tim = 0;
                yield return new WaitForSeconds(0.01f);
                yield return new WaitForSeconds(cooldownTimer);
                firing = false;

        }

}
