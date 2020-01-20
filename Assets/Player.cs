using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Health lives;
    private int score = 0;
    public Grid grid;
    private int x = 0, y = 0;
    // Start is called before the first frame update
    void Awake()
    {
        grid = new Grid(10, 15, 1.25f,2.25f, this.transform.position);
        lives = new Health(3);
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

        if(Input.GetKeyDown(KeyCode.Space))
        {

        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.tag == "enemy")
            TakeDamage();
    }

    private void TakeDamage()
    {
        x = 0; y = 0;
        transform.position = grid.posArray[x, y];
        lives.health--;
    }
}
