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

    //Küp aþaðý düþerken belirli bir y konumuna ulaþtý mý konrtolü
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

    //Tekrardan küpün havada kalmasýný saðladýk
    private void SetRigidBodyValues()
    {
        rb.isKinematic = true;
        rb.useGravity = false;
    }

}
