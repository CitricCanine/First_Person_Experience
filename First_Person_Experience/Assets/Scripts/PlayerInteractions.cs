using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteractions : MonoBehaviour
{
    public GameObject hand;
    public GameObject cam;
    public float lookDistance;
    public LayerMask layerMask;
    RaycastHit hit;

    public Collider triggerColl;
    GameManager gmSc;



    
    // Start is called before the first frame update
    void Start()
    {
        gmSc = GameObject.Find("GameManager").GetComponent<GameManager>();
        gmSc.infoText.text = " ";
    }

    // Update is called once per frame
    void Update()
    {
        if (triggerColl == null)
        {
            gmSc.infoText.text = " ";
        }
        if (triggerColl != null && Input.GetKeyDown(KeyCode.F))
        {
            if(triggerColl.gameObject.CompareTag("Lock") && gmSc.hasKey)
            {
                gmSc.hasKey = false;
                gmSc.infoText.text = " ";
                Destroy(triggerColl.gameObject);
            }
            if (triggerColl.gameObject.CompareTag("Lever"))
            {
                Lever leverSC = triggerColl.gameObject.GetComponent<Lever>();
                leverSC.isOn = !leverSC.isOn;
            }
        }

        // WEAPON CAST
        if (hand.transform.childCount == 1 && Input.GetKeyDown(KeyCode.Q))
        {
            GameObject currentObject;
            currentObject = hand.transform.GetChild(0).gameObject;
            currentObject.GetComponent<Rigidbody>().isKinematic = false;
            currentObject.GetComponent<Rigidbody>().AddForce(-currentObject.transform.up * 10, ForceMode.Impulse);
            hand.transform.GetChild(0).gameObject.transform.parent = null;
        }
        else if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, lookDistance, layerMask))
        {
            gmSc.infoText.text = "Press F To Pick Up";

            if (hand.transform.childCount == 0 && Input.GetKeyDown(KeyCode.F))
            {
                hit.collider.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                hit.collider.gameObject.transform.parent = hand.transform;
                hit.collider.gameObject.transform.position = hand.transform.position;
                hit.collider.gameObject.transform.rotation = hand.transform.rotation;

            }
        }

        else
        {
        if (triggerColl == null)
            {
                gmSc.infoText.text = " ";
            }
        }


    }

    void OnTriggerEnter(Collider other)
    {
        triggerColl = other;
        if (other.gameObject.CompareTag("Key"))
        {
            gmSc.hasKey = true;
            Destroy(other.gameObject);
        }
    
        if (other.gameObject.CompareTag("Lock"))
        {
            if (gmSc.hasKey)
            {
                gmSc.infoText.text = "Press F To Interact";
            }
            else
            {
                gmSc.infoText.text = "You Need A Key To Open This";
            }
        }
    
        if (other.gameObject.CompareTag("Lever"))
        {
            gmSc.infoText.text = "Press F To Switch";
        }
    }

    void OnTriggerExit(Collider other)
    {
        triggerColl = null;
    }
}
