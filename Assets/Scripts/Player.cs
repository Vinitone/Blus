using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Health lives;
    public GameObject building;
    Grid grid;
    Grid.Coord playerCoord, selectedCoord;
    // Start is called before the first frame update
    void Awake()
    {
        grid = GameObject.Find("Grid").GetComponent<Grid>();
        lives = gameObject.GetComponent<Health>();
        playerCoord = new Grid.Coord(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        SelectingTile();


        if (Input.GetKeyDown(KeyCode.F))
        {
            if (grid.fireGrid[selectedCoord.x, selectedCoord.y])
            {

                HighscoreTable.Instance.AddScore(100);
            }
        }

        if (grid.fireGrid[playerCoord.x, playerCoord.y])
        {
            TakeDamage();
        }
    }

    private void SelectingTile()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
            selectedCoord = playerCoord + new Grid.Coord(0, 1);
        }
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
            selectedCoord = playerCoord + new Grid.Coord(1, 0);
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 270));
            selectedCoord = playerCoord + new Grid.Coord(0, -1);
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 180));
            selectedCoord = playerCoord + new Grid.Coord(-1, 0);
        }
    }

    private void Movement()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            if (playerCoord.y < grid.mapSize.y - 1)
                playerCoord.y++;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            if (playerCoord.x > 0)
                playerCoord.x--;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            if (playerCoord.y > 0)
                playerCoord.y--;
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (playerCoord.x < grid.mapSize.x - 1)
                playerCoord.x++;
        }
        transform.position = grid.CoordToPosition(playerCoord);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("enemy"))
        {
            TakeDamage();
        }
    }
    private void TakeDamage()
    {
        playerCoord = new Grid.Coord(0,0);
        lives.health--;
    }
}
