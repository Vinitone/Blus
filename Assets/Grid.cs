using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid : MonoBehaviour
{
    private int heigth = 1;
    private int width = 1;
    private Vector3 originPosition;
    [SerializeField]
    private float cellSizeX, cellSizeY;
    public int[,] gridArray = new int[10, 15];
    public Vector3[,] posArray = new Vector3[10, 15];

    public Grid(int width, int heigth, float cellSizeX, float cellSizeY, Vector3 originPosition)
    {
        this.width = width;
        this.heigth = heigth;
        this.cellSizeX = cellSizeX;
        this.cellSizeY = cellSizeY;
        this.originPosition = originPosition;

        gridArray = new int[width, heigth];

        for (int x = 0; x < gridArray.GetLength(0); x++)
        {
            for (int y = 0; y < gridArray.GetLength(1); y++)
            {
                posArray[x,y] = GetWorldPosition(x, y);  
            }
        }
    }

    //public Vector3 GetNearestPointOnGrid(Vector3 position)
    //{
    //    position -= transform.position;

    //    float xCount = position.x / cellSize;
    //    float yCount = position.y / cellSize;
    //    float zCount = position.z / cellSize;

    //    Vector3 result = new Vector3(
    //         xCount * cellSize,
    //         yCount * cellSize,
    //         zCount * cellSize
    //        );

    //    result += transform.position;

    //    return result;
    //}

    private Vector3 GetWorldPosition(int x, int y)
    {
        return new Vector3(x*cellSizeX, y*cellSizeY) + originPosition;
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.yellow;
    //    for (int x = 0; x < 5; x++)
    //    {
    //        for (int y = 0; y < 15; y++)
    //        {
    //            var point = GetNearestPointOnGrid(new Vector3(x, y, 0f));
    //            Gizmos.DrawSphere(point, 0.3f);
    //        }
    //    }
    //}

}
