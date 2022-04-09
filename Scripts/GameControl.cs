using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    public TMP_Text countDownText;
    public bool gamePlaying { get; private set; }
    public int countDownTime = 3;
    


    private float startTime;
    

    private void Awake()
    {
        instance = this;
    }


    public GameObject Warning;
    public GameObject Enemy;
    /*
    public GameObject Enemy1;
    public GameObject Enemy2;
    public GameObject Enemy3;
    public GameObject Enemy4;
    public GameObject Enemy5;
    public GameObject Enemy6;
    */

    public GameObject Player;
    public GameObject Cam;

    


    //public GameObject Run_Command;
    // Start is called before the first frame update
    void Start()
    {
        //gamePlaying = false;
        //Time.timeScale = 0;
        EnemyInactive();
        /*
        Enemy1Inactive();
        Enemy2Inactive();
        Enemy3Inactive();
        Enemy4Inactive();
        Enemy5Inactive();
        Enemy6Inactive();
        */
        PlayerInactive();

        

        StartCoroutine(CountDownToStart());
    }

    // Update is called once per frame
    void Update()
    {
        

    }

    
    public void SetWarning()
    {
        Warning.SetActive(true);
    }

    public void UnSetWarning()
    {
        Warning.SetActive(false);
    }


    public void EnemyActive()
    {
        Enemy.SetActive(true);
    }

    public void EnemyInactive()
    {
        Enemy.SetActive(false);
    }
    /*
    public void Enemy1Active()
    {
        Enemy1.SetActive(true);
    }

    public void Enemy1Inactive()
    {
        Enemy1.SetActive(false);
    }

    public void Enemy2Active()
    {
        Enemy2.SetActive(true);
    }

    public void Enemy2Inactive()
    {
        Enemy2.SetActive(false);
    }

    public void Enemy3Active()
    {
        Enemy3.SetActive(true);
    }

    public void Enemy3Inactive()
    {
        Enemy3.SetActive(false);
    }

    public void Enemy4Active()
    {
        Enemy4.SetActive(true);
    }

    public void Enemy4Inactive()
    {
        Enemy4.SetActive(false);
    }

    public void Enemy5Active()
    {
        Enemy5.SetActive(true);
    }

    public void Enemy5Inactive()
    {
        Enemy5.SetActive(false);
    }

    public void Enemy6Active()
    {
        Enemy6.SetActive(true);
    }

    public void Enemy6Inactive()
    {
        Enemy6.SetActive(false);
    }
    */


    public void PlayerActive()
    {
        Player.SetActive(true);
    }

    public void PlayerInactive()
    {
        Player.SetActive(false);
    }

    public void CameraActive()
    {
        Cam.SetActive(true);
    }

    public void CameraInactive()
    {
        Cam.SetActive(false);
    }








    IEnumerator CountDownToStart()
    {
        


        while (countDownTime > 0)
        {
            countDownText.text = countDownTime.ToString();

            yield return new WaitForSeconds(1f);

            countDownTime--;
        }

        /*if(countDownTime == 1)
        {
            gamePlaying = true;
            Time.timeScale = 1;
        }
        */
        countDownText.text = "RUN!";

        

        yield return new WaitForSeconds(1f);

        countDownText.gameObject.SetActive(false);
        EnemyActive();

        /*
        Enemy1Active();
        Enemy2Active();
        Enemy3Active();
        Enemy4Active();
        Enemy5Active();
        Enemy6Active();
        */
        PlayerActive();
        CameraInactive();

        

        //gamePlaying = true;
        //Time.timeScale = 1;
    }

    
}
