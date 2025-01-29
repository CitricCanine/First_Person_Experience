using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MagicOrb : MonoBehaviour
{
    public GameObject orb;
    public float lightSpeed;
    public Light orbLight;
    public float shrinkSpeed;

    bool active;
    bool scaleActive;
    bool orbEnd;
    bool lightOff;

    void Start()
    {
        orbEnd = false;
        scaleActive = true;
        active = false;
        StartCoroutine(LightUp());
        orbLight.intensity = 0f;
        StartCoroutine(Shrink());
        
        gameObject.transform.rotation = Quaternion.Euler(Random.Range(360, -360), Random.Range(360, -360), Random.Range(360, -360));
    }

    void Update()
    {
        if (scaleActive == true)
        {
        orb.transform.localScale += new Vector3(1f, 1f, 1f) * Time.deltaTime;
        }

        if (orb.transform.localScale == new Vector3(5f, 5f, 5f))
        {
            scaleActive = false;
        }

        if (active == true)
        {
        orbLight.intensity += Time.deltaTime * lightSpeed;
        }

        if (orbEnd == true)
        {
        orb.transform.localScale -= new Vector3(1f, 1f, 1f) * (Time.deltaTime * shrinkSpeed);
        }
        if (lightOff == true && active == false)
        {
        orbLight.intensity += Time.deltaTime * (-lightSpeed * 3);
        }
    }

    IEnumerator LightUp()
    {
        yield return new WaitForSeconds(1.13f);
        active = true;
        yield return new WaitForSeconds(2.87f);
        active = false;
        lightOff = true;
        
    }

        IEnumerator Shrink()
    {
        yield return new WaitForSeconds(4f);
         orbEnd = true;
        yield return new WaitForSeconds(1f);
        Destroy(this);
        
    }
}
