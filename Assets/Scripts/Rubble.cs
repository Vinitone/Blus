using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rubble : MonoBehaviour
{
    public GameObject[] rubbles = new GameObject[3];

     public void SpawnRubble(Vector3 position, Quaternion rotation)
    {
        int r = Random.Range(0, 3);
        Instantiate(rubbles[r], position, rotation);
    }
}
