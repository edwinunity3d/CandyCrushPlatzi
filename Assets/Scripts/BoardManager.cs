using System;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public static BoardManager singleton;
    public  List<Sprite> prefabs = new List<Sprite>();
    public GameObject currentCandy;
    public int xSize, ySize;

    private GameObject[ , ] candies;

    public bool isShifting { get; set;}


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(singleton == null)
        {
            singleton =  this;
        }
        else
        {
            Destroy(gameObject);
        }
        Vector2 offset = currentCandy.GetComponent<BoxCollider2D>().size;
        CreateInitialBoard(offset);
    }

    private void CreateInitialBoard(Vector2 offset)
    {
        candies = new GameObject[xSize, ySize];

        float startX = this.transform.position.x;
        float startY = this.transform.position.y;

        for(int x = 0; x < xSize ; x++)
        {
            for(int y =0; y < ySize; y++)
            {
                GameObject newCandy = Instantiate(currentCandy, new Vector3(startX +(offset.x * x), 
                                    startY +(offset.y *y), 0), currentCandy.transform.rotation  );
                newCandy.name = String.Format("Candy[{0}][{1}]", x, y);
                candies[x,y] = newCandy;
            }
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
