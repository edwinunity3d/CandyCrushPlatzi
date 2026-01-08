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

    private void SelectCandy()
    {
      isSelected = true;
      spriteRenderer.color = selectedColor;
      previousSelected = gameObject.GetComponent<Candy>();

    }
     private void DeselectCandy()
    {
      isSelected = false;
      spriteRenderer.color = Color.white;
      previousSelected = null;
    }

    private  void OnMouseDown() 
    {
      if(spriteRenderer.sprite == null || BoardManager.singleton.isShifting)
       {
         return;
       }
    if (isSelected)
       {
         DeselectCandy();
        }
        else
        {
          if(previousSelected == null)
           {
              SelectCandy();
            }
            else
            {
              previousSelected.DeselectCandy();
              SelectCandy();
            }
        }

    }



}
