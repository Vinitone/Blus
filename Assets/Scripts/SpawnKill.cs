using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnKill : MonoBehaviour
{
    public float fallSpeed = 1;
    private void Start()
    {
        Destroy(this.gameObject, 20f);
    }

    private void Update()
    {
        gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0, Random.Range(-1,-fallSpeed), 0);
    }
}
