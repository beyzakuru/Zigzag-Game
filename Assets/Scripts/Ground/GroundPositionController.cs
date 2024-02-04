using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundPositionController : MonoBehaviour
{
    private GroundSpawnController groundSpawnController;

    private Rigidbody rb;

    [SerializeField] private float endYValue;

    

    private int groundDirection;

    void Start()
    {
        groundSpawnController = FindObjectOfType<GroundSpawnController>();
        rb = GetComponent<Rigidbody>();
    }

    
    void Update()
    {
        CheckGroundVerticalPosition();
    }

    //K�p a�a�� d��erken belirli bir y konumuna ula�t� m� konrtol�
    private void CheckGroundVerticalPosition()
    {
        if (transform.position.y <= endYValue)
        {
            SetRigidBodyValues();

            SetGroundNewPosition();
        }
    }

    private void SetGroundNewPosition()
    {
        groundDirection = Random.Range(0, 2);

        // sola ekleme
        if (groundDirection == 0)
        {
            transform.position = new Vector3(groundSpawnController.lastGroundObject.transform.position.x - 1f, groundSpawnController.lastGroundObject.transform.position.y, groundSpawnController.lastGroundObject.transform.position.z);
        }
        //ileri ekleme
        else
        {
            transform.position = new Vector3(groundSpawnController.lastGroundObject.transform.position.x, groundSpawnController.lastGroundObject.transform.position.y, groundSpawnController.lastGroundObject.transform.position.z + 1f);
        }

        groundSpawnController.lastGroundObject = gameObject;
    }

    //Tekrardan k�p�n havada kalmas�n� sa�lad�k
    private void SetRigidBodyValues()
    {
        rb.isKinematic = true;
        rb.useGravity = false;
    }

}
