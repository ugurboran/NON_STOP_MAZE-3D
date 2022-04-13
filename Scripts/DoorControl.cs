using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorControl : MonoBehaviour
{

    GameObject player;
    

    

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Jammo_Player");
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject == player)
        {
            print("lahana");
            SceneManager.LoadScene(3);
            Cursor.lockState = CursorLockMode.None;
            
            
        }
    }

    
}
