using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyControl : MonoBehaviour
{
    NavMeshAgent navAgent;
    GameObject player;
    public float enemyDistance;

    public AudioClip explosion;
    public AudioClip heart_beat;

    private bool isCoroutineExecuting = false;
    private bool isplaying = false;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Jammo_Player");
        navAgent = GetComponent<NavMeshAgent>();
       
    }

    // Update is called once per frame
    void Update()
    {

        navAgent.destination = player.transform.position;
        //print(Vector3.Distance(transform.position, player.transform.position));
        if (Vector3.Distance(transform.position, player.transform.position) < enemyDistance)
        {
            GameObject.Find("Scripts").GetComponent<GameControl>().SetWarning();
            PlaySound();
            isplaying = true;
        }
        else
        {
            GameObject.Find("Scripts").GetComponent<GameControl>().UnSetWarning();
            StopSound();
            isplaying = false;
        }

        
    }

    private void PlaySound()
    {
        if(isplaying == false)
        {
            AudioSource.PlayClipAtPoint(heart_beat, player.transform.position, 1f);
            GameObject.Find("Sounds").GetComponent<AudioSource>().Stop();
        }
    }

    private void StopSound()
    {
        if (isplaying == true)
        {
            GameObject.Find("Sounds").GetComponent<AudioSource>().Play();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject == player)
        {
            AudioSource.PlayClipAtPoint(explosion, player.transform.position, .5f);

            StartCoroutine(ExecuteAfterTime(0.5f));

            
            Cursor.lockState = CursorLockMode.None;
        }
    }

    void LoadScene()
    {
        SceneManager.LoadScene(2);
    }

    IEnumerator ExecuteAfterTime(float time)
    {
        if (isCoroutineExecuting)
            yield break;
        isCoroutineExecuting = true;
        yield return new WaitForSeconds(time);
        LoadScene();
        isCoroutineExecuting = false;
    }
}
