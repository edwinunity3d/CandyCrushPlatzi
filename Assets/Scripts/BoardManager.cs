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
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
