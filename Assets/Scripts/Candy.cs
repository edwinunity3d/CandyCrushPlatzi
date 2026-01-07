using UnityEngine;

public class Candy : MonoBehaviour
{

    private static Color selectedColor = new Color(0.5f,0.5f, 0.5f,1);
    private static Candy previousSelected = null;

    private SpriteRenderer spriteRenderer;
    public int id;
    private Vector2[] adjacentDirections =  new Vector2[]
    {
      Vector2.up,
      Vector2.down,
      Vector2.left,
      Vector2.right  
    };
    private bool isSelected = false;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
