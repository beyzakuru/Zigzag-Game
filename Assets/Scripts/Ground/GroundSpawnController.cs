using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class GroundSpawnController : MonoBehaviour
{
    public GameObject lastGroundObject;

    [SerializeField] private GameObject groundPrefab;

    private GameObject newGroundObject;

    //Sola m�, ileri mi random olarak tutabilmek i�in olu�turduk
    private int groundDirection;


    void Start()
    {
        GenerateRandomNewGrounds();
    }

    //for d�ng�s� kadar k�p do�mas� sa�lan�yor
    public void GenerateRandomNewGrounds()
    {
        for (int i = 0; i < 75; i++)
        {
            CreateNewGround();
        }
    }

    private void CreateNewGround()
    {
        groundDirection = Random.Range(0,2);

        //son nesnenin soluna do�ru k�p olu�ur. Rasatgele belirledik
        if (groundDirection == 0 )
        {
            newGroundObject = Instantiate(groundPrefab, new Vector3(lastGroundObject.transform.position.x - 1f, lastGroundObject.transform.position.y, lastGroundObject.transform.position.z),Quaternion.identity);
            lastGroundObject = newGroundObject;
        }
        //son nesnenin ilerisine do�ru k�p olu�ur
        else
        {
            newGroundObject = Instantiate(groundPrefab, new Vector3(lastGroundObject.transform.position.x, lastGroundObject.transform.position.y, lastGroundObject.transform.position.z + 1f), Quaternion.identity);
            lastGroundObject = newGroundObject; //yeni olu�an obje son nesnemiz olur
        }
    }



}
