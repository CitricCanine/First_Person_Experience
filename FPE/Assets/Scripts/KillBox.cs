using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class KillBox : MonoBehaviour
{

    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
            if (other.gameObject.CompareTag("Player")) 
        {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Destroy(player);
        }
    }

}
