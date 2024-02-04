using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCollisionController : MonoBehaviour
{
    [SerializeField] private GroundDataTransmitter groundDataTransmitter;



    //top zeminden ��kt�ktan sonra par�alar ayr�lmas�n� istiyoruz.
    private void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("Ball"))
        {
            groundDataTransmitter.SetGroundRigidbodyValues();
        }
    }

  
}
