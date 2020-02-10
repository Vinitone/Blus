using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Health lives;
    private int score = 0;
    public GameObject building;
    private Window fires;
    public Grid grid;
    private int x = 0, y = 0;
    private bool triggered = false;
    // Start is called before the first frame update
    void Awake()
    {
        grid = new Grid(10, 15, 1.25f,2.25f, this.transform.position);
        lives = gameObject.GetComponent<Health>();
        fires = building.GetComponent<Window>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (y < grid.gridArray.GetLength(1) - 1)
                y++;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (x > 0)
                x--;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (y > 0)
                y--;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (x < grid.gridArray.GetLength(0) - 1)
                x++; 
        }
            transform.position = grid.posArray[x, y];

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (fires.fireArray[x, y].localScale.x > 0.1f || fires.fireArray[x, y].localScale.x > 0.1f || fires.fireArray[x, y].localScale.x > 0.1f)
            {
                fires.fireArray[x, y].localScale *= .5f;
                HighscoreTable.Instance.AddScore(100);
            }
            else
            {
                fires.fireArray[x, y].localScale = Vector3.zero;
            }
        }
    }

    //private void OnCollisionEnter(Collision collision)
    //{
    //    if (collision.transform.tag == "enemy")
    //        TakeDamage();
    //}

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "enemy" && !triggered)
        {
            triggered = true;
            TakeDamage();
        }
    }
    private void TakeDamage()
    {
        x = 0; y = 0;
        lives.health--;
        triggered = false;
    }
}
