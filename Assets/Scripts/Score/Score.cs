using Palmmedia.ReportGenerator.Core.Parser.Analysis;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    public static int score;
    public Text scoreText;

    
    void Start()
    {
        //Her oyun ba�lad���n 0 olarak ba�lamas� i�in
        score = 0;
    }


    void Update()
    {
        scoreText.text = score.ToString();
    }


}
