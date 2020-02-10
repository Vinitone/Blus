using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rubble : MonoBehaviour
{
    public GameObject[] rubbles = new GameObject[3];
    public float spawnRangeRubble = 1;
    void Start()
    {
        InvokeRepeating("ThrowRubble", 0, Random.Range(0, 2));
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ThrowRubble()
    {
        int r = Random.Range(0, 3);
        Instantiate(rubbles[r], new Vector3(Random.Range(-spawnRangeRubble,spawnRangeRubble),this.transform.position.y,this.transform.position.z), Quaternion.identity);
    }
}
