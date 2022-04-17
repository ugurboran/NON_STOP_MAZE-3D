using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LavaControl : MonoBehaviour
{

    GameObject player;
    //GameObject Lava;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Jammo_Player");
        //Lava = GameObject.FindWithTag("Lava");
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject == player)
        {

            
            SceneManager.LoadScene(2);
            Cursor.lockState = CursorLockMode.None;
        }
    }
}

