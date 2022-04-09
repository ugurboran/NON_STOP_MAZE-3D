using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnObject : MonoBehaviour
{


    public GameObject door;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        

        
    }

    public void SpawnDoor()
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-10, 11), 5, Random.Range(-10, 11));
        Instantiate(door, randomSpawnPosition, Quaternion.Euler(-90, 270, 0));
    }

    
}
