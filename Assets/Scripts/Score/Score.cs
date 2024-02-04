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
        //Her oyun baþladýðýn 0 olarak baþlamasý için
        score = 0;
    }


    void Update()
    {
        scoreText.text = score.ToString();
    }


}
