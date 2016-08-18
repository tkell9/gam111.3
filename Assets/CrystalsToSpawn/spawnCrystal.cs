using UnityEngine;
using System.Collections;


public class spawnCrystal : MonoBehaviour
{





    public int randomNumber;

    public Transform fireCrystal;
    public Transform waterCrystal;
    public Transform earthCrystal;
    public Transform magicCrystal;



    // Use this for initialization
    void Start()
    {

        randomNumber = Random.Range(1, 5);
    }

    // Update is called once per frame
    void Update()
    {

        switch (randomNumber)
        {
            case 1:
                Instantiate(fireCrystal, new Vector3(), Quaternion.identity);
                break;

            case 2:
                Instantiate(waterCrystal, new Vector3(), Quaternion.identity);
                break;

            case 3:
                Instantiate(earthCrystal, new Vector3(), Quaternion.identity);
                break;

            case 4:
                Instantiate(magicCrystal, new Vector3(), Quaternion.identity);
                break;
        }

    }
}
