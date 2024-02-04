using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundColorController : MonoBehaviour
{
    //Zemin nesnesinin materyalini çaðýrdýr.
    [SerializeField] private Material groundMaterial;

    //Color dizisi oluþturduk. Renkler buraya verilecek.
    [SerializeField] private Color[] colors;

    //Burada her seferinde indexi artýrarak dizi içinde dolaþmamýzý saðlayacak
    private int colorIndex = 0;

    [SerializeField] private float lerpValue;

    //Zamanlayýcý oluþturuldu
    [SerializeField] private float time;

    private float currentTime;

    private void Update()
    {
        SetColorChangeTime();
        SetGroundMaterialSmoothColorChange();
    }

    //Zamanlayýcý
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

        //Arttýrýlan index colors dizisinden fazla veya eþit olursa indexi sýfýrlýyoruz.
        if (colorIndex >= colors.Length)
        {
            colorIndex = 0;
        }
    }

    private void SetGroundMaterialSmoothColorChange()
    {
        groundMaterial.color = Color.Lerp(groundMaterial.color, colors[colorIndex], lerpValue * Time.deltaTime);
    }

    //Varsayýlan olarak atanan renk. Sürekli bu renk ile baþlamasýný saðlýyor.
    private void OnDestroy()
    {
        groundMaterial.color = colors[1];
    }
}
