using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Window : MonoBehaviour
{

    public Transform fire,player, parent;
    public Transform[,] fireArray = new Transform[10, 14];

    void Start()
    {
        for (int x = 0; x < fireArray.GetLength(0); x++)
        {
            for (int y = 0; y < fireArray.GetLength(1); y++)
            {
                int r = Random.Range(0, 3);
                fireArray[x,y] = Instantiate(fire, player.GetComponent<Player>().grid.posArray[x, y] - new Vector3(.3f,0,0), fire.transform.rotation, parent);
                fire.localScale = new Vector3(r *.5f, r * .5f, r * .5f);
                fire.GetComponent<ParticleSystem>().Play();

            }
        }
    }
}
