using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    //public AudioClip crashsf;
    //public AudioClip coinsf;
    public GameObject player_cam;
    float player_speed = 0.5f;
    float player_rotation_speed = 4f;
    Vector2 temp_rotation;
    Vector2 cam_rotation;
    // Start is called before the first frame update
    void Start()
    {



        temp_rotation = new Vector2(player_cam.transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y);

    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.S))
        {
            GetComponent<AudioSource>().Play();
        }
        */


        float mouse_yatay = Input.GetAxis("Mouse X");
        mouse_yatay *= player_rotation_speed;
        float mouse_dikey = Input.GetAxis("Mouse Y");
        mouse_dikey *= player_rotation_speed;

        float temp_value = temp_rotation.x + mouse_dikey;
        if (Mathf.Abs(temp_value) < 40)
        {
            temp_rotation = new Vector2(temp_rotation.x + mouse_dikey, temp_rotation.y + mouse_yatay);
        }




        //temp_rotation *= player_rotation_speed;
        transform.localRotation = Quaternion.Euler(0, temp_rotation.y, 0);
        //print(temp_rotation.x);


        player_cam.transform.localRotation = Quaternion.Euler(-temp_rotation.x * Vector3.right);



        float yatay = Input.GetAxis("Horizontal");
        float dikey = Input.GetAxis("Vertical");
        Vector2 force = new Vector2(yatay, dikey);
        force = force * player_speed;
        transform.Translate(force.x, 0, force.y);
    }

    /*
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name.Equals("B"))
        {
            Destroy(other.gameObject);
            AudioSource.PlayClipAtPoint(crashsf, Camera.main.transform.position, 1);
        }

        else if (other.gameObject.name.Equals("Y"))
        {
            Destroy(other.gameObject);
            AudioSource.PlayClipAtPoint(coinsf, Camera.main.transform.position, 1);
        }
    }
    */
}

