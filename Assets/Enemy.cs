using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject[] rubble = new GameObject[3];
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ThrowRubble()
    {
        int r = Random.Range(0, 3);
        Instantiate(rubble[r], this.transform.position, Quaternion.identity);
    }

    void Movement(float x, float y)
    {
        float flipPoint = Random.Range(x, y);

        //if(this.transform.position )
    }
}
