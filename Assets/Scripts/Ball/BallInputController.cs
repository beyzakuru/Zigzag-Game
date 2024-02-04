using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BallInputController : MonoBehaviour
{

    [HideInInspector] public Vector3 ballDirection;

    public LayerMask platformLayer;
    int occurances;
    public bool onPlatform;

    public GameObject gameOverPanel;


    void Start()
    {
        //Baþlangýç yönü sol olacak. yani top baþladýðýnda ilk önce sola gidecek
        ballDirection = Vector3.left;
    }

    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    void Update()
    {
        HandleBallInputs();
    }
    

    // topun platform üzerinde olup olmadýðýnýn kontrolü
    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.layer == platformLayer)
        {
            occurances++;
            onPlatform = true;
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.layer == platformLayer)
        {
            occurances--;
            if (occurances == 0) onPlatform = false;
        }
    }



    private void HandleBallInputs()
    {
        // eðer top platform üzerinde ise týklama iþlmei gerekçekleþtirilebilir
        if(onPlatform == true)
        {
            //Ekrana her dokunduðunda bir kere çalýþmasý, yönünün deðiþmesi için
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) //Klavyenin sol click'ine ve space tuþuna basýnca top yön deðiþtirir.
            {
                Score.score++;
                ChangeBallDirection();
            }
        }
        //top platform üzerinde deðilse buton ekrana gelir
        else
        {
            gameOverPanel.SetActive(true);
            //Time.timeScale = 0;
        }
    }

    // oyunun tekrardan baþlamasý için retry butonuna atanan fonksiyon
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    private void ChangeBallDirection()
    {
        if (ballDirection.x ==-1) //Sola gidiyor demek
        {
            //Eðer içeri girerse düz devam etmesini saðlýyoruz.
            ballDirection = Vector3.forward;
        }

        //Topun yönü ileri
        else
        {
            //Deðilse sola gitsin
            ballDirection = Vector3.left;
        }
    }



}
