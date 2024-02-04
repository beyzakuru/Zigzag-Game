using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovementController : MonoBehaviour
{
    //ballDataTransmiter �a�r�ld�
    [SerializeField] private BallDataTransmiter ballDataTransmiter;

    //Topa h�z vermek i�in gerekli
    [SerializeField] private float ballMoveSpeed;

    private void Update()
    {
        SetBallMovement();
    }

    private void SetBallMovement()
    {
        //Topun kendi mevcut pozisyonuna y�n x h�z x time sonucu ile hareket katm�� oluyoruz
        transform.position += ballDataTransmiter.GetBallDirection() * ballMoveSpeed * Time.deltaTime;
    }
}
