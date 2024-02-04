using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowController : MonoBehaviour
{
    [SerializeField] private Transform ballTransform;

    private Vector3 offset; //Aras�ndaki mesafeyi tutacak.

    [SerializeField] [Range(0,3)] private float lerpValue;

    private Vector3 newPosition;


    void Start()
    {
        //Kameran�n pozisyonundan topun pozisyonu ��kar�larak offset de�i�kenine aktar�l�yor.
        offset = transform.position - ballTransform.position;
    }

    //Kamera takip gibi olaylarda LateUpdate tavsiye edilir.
    void LateUpdate()
    {
        SetCameraSmoothFollow();
    }

    private void SetCameraSmoothFollow()
    {
        //��ine 3 parametre al�yor. �lk parametre mecvut poziyon de�eri, hedef pozisyon, 
        newPosition = Vector3.Lerp(transform.position, ballTransform.position + offset, lerpValue * Time.deltaTime);
        transform.position = newPosition;
    }
}
