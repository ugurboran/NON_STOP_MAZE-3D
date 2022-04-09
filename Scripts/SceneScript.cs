using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneScript : MonoBehaviour
{

    //public GameObject door;
    // Start is called before the first frame update
    void Start()
    {
        //door = GameObject.Find("door");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*
    private void SpawnDoor()
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-10, 11), 0, Random.Range(-10, 11));
        Instantiate(door, randomSpawnPosition, Quaternion.identity);
    }
    

    public void CreateGameObject()
    {
        Vector3 randomSpawnPosition = new Vector3(Random.Range(-10, 11), 0, Random.Range(-10, 11));
        Instantiate(door, randomSpawnPosition, Quaternion.identity);
    }
    */

    public void StartGame()
    {

        //CreateGameObject();
        SceneManager.LoadScene(1);
        

    }

    public void PlayAgain()
    {
        //CreateGameObject();
        SceneManager.LoadScene(1);

    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
}
