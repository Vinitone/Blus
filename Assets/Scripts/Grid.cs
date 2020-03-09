using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Grid : MonoBehaviour
{
    public Transform tilePrefab;
    public Transform firePrefab;
    public Transform explosivePrefab;
    public Vector2 mapSize;
    public int seed = 10;
    [HideInInspector]
    public bool[,] fireGrid;

    [Range(0, 1)]
    public float outlinePercent;
    [Range(0, 1)]
    public float firePercent;
    [Range(0, 1)]
    public float explosivePercent;

    List<Coord> allTileCoords;
    Queue<Coord> shuffledTileCoords;
    Coord playerSpawnPosition = new Coord(0, 0);
    private void Start()
    {
        GenerateGrid();
    }

    public void GenerateGrid()
    {

        allTileCoords = new List<Coord>();
        fireGrid = new bool[(int)mapSize.x, (int)mapSize.y];

        string holderName = "Generated Grid";

        if (transform.Find(holderName))
        {
            DestroyImmediate(transform.Find(holderName).gameObject);
        }

        Transform gridHolder = new GameObject(holderName).transform;
        gridHolder.parent = transform;

        for (int x = 0; x < mapSize.x; x++)
        {
            for (int y = 0; y < mapSize.y; y++)
            {
                Coord objPos = new Coord(x, y);
                fireGrid[x, y] = false;
                allTileCoords.Add(objPos);
                Vector3 tilePosition = CoordToPosition(objPos);
                Transform newTile = Instantiate(tilePrefab, tilePosition, Quaternion.identity) as Transform;

                newTile.localScale = Vector3.one * (1 - outlinePercent);
                newTile.parent = gridHolder;

            }
        }
        shuffledTileCoords = new Queue<Coord>(Utility.ShuffleArray(allTileCoords.ToArray(), seed));

        int fireCount = (int)(mapSize.x * mapSize.y * firePercent);
        for (int i = 0; i < fireCount; i++)
        {
            Coord randomCoord = GetRandomCoord();
            if (randomCoord != playerSpawnPosition)
            {
                Vector3 firePosition = CoordToPosition(randomCoord);
                fireGrid[randomCoord.x, randomCoord.y] = true;
                Transform newFire = Instantiate(firePrefab, firePosition + Vector3.back * .1f, Quaternion.Euler(Vector3.right * -90)) as Transform;
                newFire.parent = gridHolder;
            }
        }

        int explosiveCount = (int)(mapSize.x * mapSize.y * explosivePercent);
        for (int i = 0; i < explosiveCount; i++)
        {
            Coord randomCoord = GetRandomCoord();
            if (randomCoord != playerSpawnPosition)
            {

                Vector3 explosivePosition = CoordToPosition(randomCoord);

                Transform newExplosive = Instantiate(explosivePrefab, explosivePosition + Vector3.back * .1f, Quaternion.identity) as Transform;
                newExplosive.localScale = Vector3.one * (1 - outlinePercent);
                newExplosive.parent = gridHolder;
            }
        }
    }

    public Vector3 CoordToPosition(Coord c)
    {
        return new Vector3(-mapSize.x / 2 + 0.5f + c.x, -mapSize.y / 2 + 0.5f + c.y, 0);
    }
    public Coord GetRandomCoord()
    {
        Coord randomCoord = shuffledTileCoords.Dequeue();
        shuffledTileCoords.Enqueue(randomCoord);
        return randomCoord;
    }

    public struct Coord
    {
        public int x;
        public int y;

        public Coord(int _x, int _y)
        {
            x = _x;
            y = _y;
        }

        public static bool operator ==(Coord c1, Coord c2)
        {
            return c1.x == c2.x && c1.y == c2.y;
        }
        public static bool operator !=(Coord c1, Coord c2)
        {
            return !(c1 ==c2);
        }

        public static Coord operator +(Coord c1, Coord c2)
        {
            Coord sum;
            sum.x = c1.x + c2.x;
            sum.y = c1.y + c2.y;
            return sum;
        }
    }
}
