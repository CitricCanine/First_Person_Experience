using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastWeapon : MonoBehaviour
{

    public int damage;
    public float shootDistance;
    public LayerMask layerMask;
    public GameObject cam;
    RaycastHit hit;

    public GameObject muzzleFlash;
    public GameObject bullet;
    //public GameObject shootPoint;
    public ParticleSystem particleFlash;
    bool active;

    void Start()
    {
       muzzleFlash.SetActive(false);
        active = false;
    }


    void Update()
    {
        if (transform.parent != null)
        {
            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, shootDistance, layerMask))
                    {
                        muzzleFlash.SetActive(true);
                        particleFlash.Play();
                        hit.collider.gameObject.GetComponent<Health>().hp -= damage;
                    }
            }
            if (muzzleFlash.activeSelf && !active)
            {
                StartCoroutine(Flash());
            }
        
        }

                Debug.DrawRay(cam.transform.position, cam.transform.forward * shootDistance, Color.yellow);
    }


    IEnumerator Flash()
    {
        active = true;
        yield return new WaitForSeconds(0.1f);

        active = false;

        muzzleFlash.transform.localRotation = Quaternion.Euler(0, Random.Range(0, 90f), 90);

        muzzleFlash.SetActive(false);
    }
}
