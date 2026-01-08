using System;
using System.Collections.Generic;
using UnityEngine;
using Random =  UnityEngine.Random;

public class BoardManager : MonoBehaviour
{
    public static BoardManager singleton;
    public  List<Sprite> prefabs = new List<Sprite>();
    public GameObject currentCandy;
    public int xSize, ySize;

    private GameObject[ , ] candies;

    public bool isShifting { get; set;}
    public float paddingX, paddignY;

    private Candy selectedCandy;


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
        //Vector2 offset = currentCandy.GetComponent<BoxCollider2D>().size;
        Vector2 offset = new Vector2(currentCandy.GetComponent<BoxCollider2D>().size.x + paddingX, 
                                    currentCandy.GetComponent<BoxCollider2D>().size.y + paddignY);
        CreateInitialBoard(offset);
    }

    private void CreateInitialBoard(Vector2 offset)
    {
        candies = new GameObject[xSize, ySize];

        float startX = this.transform.position.x;
        float startY = this.transform.position.y;


        int idx = -1;

        for(int x = 0; x < xSize ; x++)
        {
            for(int y =0; y < ySize; y++)
            {
                GameObject newCandy = Instantiate(currentCandy, new Vector3(startX +(offset.x * x), 
                                 startY +(offset.y *y), 0), currentCandy.transform.rotation, transform );
                newCandy.name = String.Format("Candy[{0}][{1}]", x, y);
                do
                {
                    idx = Random.Range(0,prefabs.Count);
                }while((x>0&&idx == candies[x-1,y].GetComponent<Candy>().id)|| 
                       (y>0 && idx == candies[x,y-1].GetComponent<Candy>().id));


                Sprite sprite = prefabs[idx];
                newCandy.GetComponent<SpriteRenderer>().sprite = sprite;
                newCandy.GetComponent<Candy>().id = idx;

                newCandy.transform.parent = transform;
                candies[x,y] = newCandy;

            }
        }

    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
