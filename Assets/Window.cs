using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{

    public Transform fire,player, parent;
    public int[,] fireArray = new int[5, 15];

    void Start()
    {
        for (int x = 0; x < fireArray.GetLength(0); x++)
        {
            for (int y = 0; y < fireArray.GetLength(1); y++)
            {
                fireArray[x, y] = Random.Range(0, 2);
                Instantiate(fire, player.GetComponent<Player>().grid.posArray[x, y], fire.transform.rotation, parent);

                //fire.transform.localScale *= fireArray[x, y];
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
