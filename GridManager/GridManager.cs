using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridManager : MonoBehaviour
{
    public static GridManager instance {get; private set;}
    private void Awake() {
        instance = this;
    }
    [SerializeField] private Vector2 scale;
    public Sprite gridSprite;
    public GridController prefabGrid;
    public List<GridController> allGrids;
    public Vector2 firstPos;
    public Vector2 currPos;
    public int kacakac;
    public float distance;    
    public Vector2Int index = new Vector2Int(0,0);

    // public void CreateRandomNumber()
    // {
    //     Vector2 newPos;
    //     System.Random random = new System.Random();
    //     int rndX = random.Next(0,kacakac); 
    //     int rndY = random.Next(0,kacakac); 
    //     var thisIndex = new Vector2(rndX,rndY);
    //     for (int i = 0; i < allGrids.Count; i++)
    //     {
    //         if(allGrids[i].index == thisIndex)
    //         {
    //             newPos = allGrids[i].transform.position;
    //             GridController buttonController = Instantiate(prefabGrid,newPos,Quaternion.identity);
    //         }
    //     }
    // }
   
    public void CreateGrid()
    {
        var prefab = new GameObject(
            "Grid " + index
        );
        GridController qwe = prefab.AddComponent(typeof(GridController)) as GridController;
        // SpriteRenderer spriteRenderer = prefab.AddComponent(typeof(SpriteRenderer)) as SpriteRenderer;
        GameObject parent = new GameObject("Parent");
        for (int i = 0; i < kacakac; i++)
        {
            for (int j = 1; j < kacakac; j++)
            {
                index.x ++;
                currPos.x += distance;
                GridController gridController;
                gridController = Instantiate(qwe,currPos,Quaternion.identity,parent.transform);
                gridController.name = "Cube " + index;
                gridController.index = index;
                gridController.GetComponent<SpriteRenderer>().sprite = gridSprite;
                allGrids.Add(gridController);
                gridController.transform.localScale = scale;
            }
            index.x = 0;
            currPos.x = firstPos.x;

            GridController gridController1;
            gridController1 = Instantiate(qwe,currPos,Quaternion.identity,parent.transform);
            gridController1.index = index;
            gridController1.name = "Cube " + index;
            gridController1.GetComponent<SpriteRenderer>().sprite = gridSprite;
            index.y ++;
            currPos.y -= distance;
            allGrids.Add(gridController1);
            gridController1.transform.localScale = scale;
        }
    }
    private void Start() 
    {
        CreateGrid();
    }
}
