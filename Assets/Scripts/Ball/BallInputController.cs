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
        //Ba�lang�� y�n� sol olacak. yani top ba�lad���nda ilk �nce sola gidecek
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
    

    // topun platform �zerinde olup olmad���n�n kontrol�
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
        // e�er top platform �zerinde ise t�klama i�lmei gerek�ekle�tirilebilir
        if(onPlatform == true)
        {
            //Ekrana her dokundu�unda bir kere �al��mas�, y�n�n�n de�i�mesi i�in
            if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) //Klavyenin sol click'ine ve space tu�una bas�nca top y�n de�i�tirir.
            {
                Score.score++;
                ChangeBallDirection();
            }
        }
        //top platform �zerinde de�ilse buton ekrana gelir
        else
        {
            gameOverPanel.SetActive(true);
            //Time.timeScale = 0;
        }
    }

    // oyunun tekrardan ba�lamas� i�in retry butonuna atanan fonksiyon
    public void Restart()
    {
        SceneManager.LoadScene(0);
    }

    private void ChangeBallDirection()
    {
        if (ballDirection.x ==-1) //Sola gidiyor demek
        {
            //E�er i�eri girerse d�z devam etmesini sa�l�yoruz.
            ballDirection = Vector3.forward;
        }

        //Topun y�n� ileri
        else
        {
            //De�ilse sola gitsin
            ballDirection = Vector3.left;
        }
    }



}
