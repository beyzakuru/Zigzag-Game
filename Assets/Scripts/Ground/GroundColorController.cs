using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundColorController : MonoBehaviour
{
    //Zemin nesnesinin materyalini �a��rd�r.
    [SerializeField] private Material groundMaterial;

    //Color dizisi olu�turduk. Renkler buraya verilecek.
    [SerializeField] private Color[] colors;

    //Burada her seferinde indexi art�rarak dizi i�inde dola�mam�z� sa�layacak
    private int colorIndex = 0;

    [SerializeField] private float lerpValue;

    //Zamanlay�c� olu�turuldu
    [SerializeField] private float time;

    private float currentTime;

    private void Update()
    {
        SetColorChangeTime();
        SetGroundMaterialSmoothColorChange();
    }

    //Zamanlay�c�
    private void SetColorChangeTime()
    {
        if (currentTime <= 0)
        {
            CheckColorIndexValue();
            currentTime = time;
        }
        else
        {
            currentTime -= Time.deltaTime;
        }
    }

    private void CheckColorIndexValue()
    {
        colorIndex++;

        //Artt�r�lan index colors dizisinden fazla veya e�it olursa indexi s�f�rl�yoruz.
        if (colorIndex >= colors.Length)
        {
            colorIndex = 0;
        }
    }

    private void SetGroundMaterialSmoothColorChange()
    {
        groundMaterial.color = Color.Lerp(groundMaterial.color, colors[colorIndex], lerpValue * Time.deltaTime);
    }

    //Varsay�lan olarak atanan renk. S�rekli bu renk ile ba�lamas�n� sa�l�yor.
    private void OnDestroy()
    {
        groundMaterial.color = colors[1];
    }
}
