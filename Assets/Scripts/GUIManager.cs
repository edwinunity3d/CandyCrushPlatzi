using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Collections;

public class GUIManager : MonoBehaviour
{

    private int moveCounter;
    public TextMeshProUGUI movesText, scoreText; 
    private int score;
    public int Score
    {
        get
        {
            return score;
        }
        set
        {
            score = value;
            scoreText.text ="Score :" + score;
        }
    }
    public int MoveCounter
    {
        get
        {
            return moveCounter;
        }
        set
        {
            moveCounter = value;
            movesText.text = "Moves: " + moveCounter;

            if(moveCounter >= 0)
            {
                moveCounter = 0;
                StartCoroutine(GameOver());

            }
        }
    }

    public static GUIManager singleton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(singleton == null)
        {
            singleton = this;
        }
        else
        {
            Destroy(gameObject);
        }
        score =0;
        moveCounter =30;
        movesText.text = "Moves: " + moveCounter;
        scoreText.text = "Score: " + score;
    }




    private IEnumerator GameOver()
    {
        yield return new WaitUntil(()=> !BoardManager.singleton.isShifting);

        yield return new WaitForSeconds(0.25f);


    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
