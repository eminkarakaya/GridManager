using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(SpriteRenderer))]
public class GridController : MonoBehaviour
{
    // public ButtonController buttonController;
    public Vector2Int index;
    public Vector2 position;
    public bool isFull;
    public int value;
    private GridController topLeft;
    private GridController topRight;
    private GridController botLeft;
    private GridController botRight;
    private GridController top;
    private GridController bot;
    private GridController right;
    private GridController left;

    public GridController GetNeighbor(KeyCode code)
    {
        if(code == KeyCode.W)
        {
            return top;
        }
        else if(code == KeyCode.S)
        {
            return bot;
        }
        else if(code == KeyCode.D)
        {
            return right;
        }
        else if(code == KeyCode.A)
        {
            return left;
        }
        return null;
    }
    [SerializeField] GridManager gridManeger;
    void Start()
    {
        gridManeger = FindObjectOfType<GridManager>();
        position = this.transform.position;
        SetNeighbor();
    }
    void Update()
    {
        if(!isFull)
        {
            value =0;
            //buttonController = null;
        }
    }
    private void SetNeighbor()
    {
        for (int i = 0; i < gridManeger.allGrids.Count; i++)
        {
            if(this.index.y == gridManeger.allGrids[i].index.y)
            {
                if(this.index.x +1 == gridManeger.allGrids[i].index.x)
                {
                    right = gridManeger.allGrids[i];
                }
                else if(this.index.x -1 == gridManeger.allGrids[i].index.x)
                {
                    left = gridManeger.allGrids[i];
                }
            }
            else if(this.index.x == gridManeger.allGrids[i].index.x)
            {
                if(this.index.y +1 == gridManeger.allGrids[i].index.y)
                {
                    bot = gridManeger.allGrids[i];
                }
                else if(this.index.y -1 == gridManeger.allGrids[i].index.y)
                {
                    top = gridManeger.allGrids[i];
                }
            }
            else if(this.index.x+1 == gridManeger.allGrids[i].index.x && this.index.y -1 == gridManeger.allGrids[i].index.y)
            {
                topRight = gridManeger.allGrids[i];
            }
            else if(this.index.x-1 == gridManeger.allGrids[i].index.x && this.index.y -1 == gridManeger.allGrids[i].index.y)
            {
                topLeft = gridManeger.allGrids[i];
            }
            else if(this.index.x-1 == gridManeger.allGrids[i].index.x && this.index.y +1 == gridManeger.allGrids[i].index.y)
            {
                botLeft = gridManeger.allGrids[i];
            }
            else if(this.index.x+1 == gridManeger.allGrids[i].index.x && this.index.y +1 == gridManeger.allGrids[i].index.y)
            {
                botRight = gridManeger.allGrids[i];
            }
        }
    }
    public GridController GetNeighborTop()
    {
        return top;
    }
    public GridController GetNeighborTopLeft()
    {
        return topLeft;
    }
    public GridController GetNeighborTopRight()
    {
        return topRight;
    }
    public GridController GetNeighborRight()
    {
        return right;
    }
    public GridController GetNeighborLeft()
    {
        return left;
    }
    public GridController GetNeighborBot()
    {
        return bot;
    }
    public GridController GetNeighborBotRight()
    {
        return topRight;
    }
    public GridController GetNeighborBotLeft()
    {
        return botLeft;
    }
}
