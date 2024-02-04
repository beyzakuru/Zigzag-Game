using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowController : MonoBehaviour
{
    [SerializeField] private Transform ballTransform;

    private Vector3 offset; //Arasýndaki mesafeyi tutacak.

    [SerializeField] [Range(0,3)] private float lerpValue;

    private Vector3 newPosition;


    void Start()
    {
        //Kameranýn pozisyonundan topun pozisyonu çýkarýlarak offset deðiþkenine aktarýlýyor.
        offset = transform.position - ballTransform.position;
    }

    //Kamera takip gibi olaylarda LateUpdate tavsiye edilir.
    void LateUpdate()
    {
        SetCameraSmoothFollow();
    }

    private void SetCameraSmoothFollow()
    {
        //Ýçine 3 parametre alýyor. Ýlk parametre mecvut poziyon deðeri, hedef pozisyon, 
        newPosition = Vector3.Lerp(transform.position, ballTransform.position + offset, lerpValue * Time.deltaTime);
        transform.position = newPosition;
    }
}
