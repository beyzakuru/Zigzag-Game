using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovementController : MonoBehaviour
{
    //ballDataTransmiter çaðrýldý
    [SerializeField] private BallDataTransmiter ballDataTransmiter;

    //Topa hýz vermek için gerekli
    [SerializeField] private float ballMoveSpeed;

    private void Update()
    {
        SetBallMovement();
    }

    private void SetBallMovement()
    {
        //Topun kendi mevcut pozisyonuna yön x hýz x time sonucu ile hareket katmýþ oluyoruz
        transform.position += ballDataTransmiter.GetBallDirection() * ballMoveSpeed * Time.deltaTime;
    }
}
