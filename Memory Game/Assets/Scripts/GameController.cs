using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public List<Button> btns = new List<Button>();
    [SerializeField] Sprite bgImage;
    public Sprite[] puzzles;
    public List<Sprite> gamePuzzles = new List<Sprite>();

    private bool firstGuess,secondGuess;
    private int countGuesses;
    private int countCorrectGuesses;
    private int gameGuesses;
    private int firstGuessIndex,secondGuessIndex;

    private string firstGuessPuzzle,secondGuessPuzzle;

   
    void Awake() 
    {
    puzzles = Resources.LoadAll<Sprite>("Sprites/Candy");    
    }

    void Start()
    {
       GetButtons(); 
       AddListeners();
       AddGamePuzzle();
       Shuffle(gamePuzzles);
       gameGuesses = gamePuzzles.Count/2 ;
    }

    void GetButtons()
    {
        GameObject[] objects = GameObject.FindGameObjectsWithTag ("PuzzleButton");

        for (int i = 0 ; i< objects.Length; i ++)
        {
        btns.Add(objects[i].GetComponent<Button>());
        btns[i].image.sprite = bgImage ;
        }
    }

    void AddGamePuzzle()
    {
        int looper = btns.Count;
        int index = 0;

        for(int i = 0 ; i< looper; i++) 
        {
           
           if(index == looper/2)
                {
                    index = 0 ;
                }
            gamePuzzles.Add(puzzles[index]);
            index++;
        }   
    }

    void AddListeners()
    {
        foreach (Button btn in btns)
        {
            btn.onClick.AddListener(() =>PickAPuzzle());
        }
    }
    
    public void PickAPuzzle()
    {
        string name = UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name ; 
        Debug.Log("you are clicking a button named "+ name );

        if(!firstGuess)
        {
            firstGuess = true;
            firstGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            firstGuessPuzzle = gamePuzzles[firstGuessIndex].name;
            btns[firstGuessIndex].image.sprite = gamePuzzles[firstGuessIndex];
            

        }else if(!secondGuess)
        {
            secondGuess = true;
            secondGuessIndex = int.Parse(UnityEngine.EventSystems.EventSystem.current.currentSelectedGameObject.name);
            secondGuessPuzzle = gamePuzzles[secondGuessIndex].name;
            btns[secondGuessIndex].image.sprite = gamePuzzles[secondGuessIndex];

            countGuesses++;
            StartCoroutine(CheckIfPuzzlesMatch());
            

        }

    }
    IEnumerator CheckIfPuzzlesMatch()
    {

        yield return new WaitForSeconds(1f);
        
        if(firstGuessPuzzle == secondGuessPuzzle)
        {
            yield return new WaitForSeconds(.5f);
            btns[firstGuessIndex].interactable = false;
            btns[secondGuessIndex].interactable = false;

            btns[firstGuessIndex].image.color = new Color(0,0,0,0);
            btns[secondGuessIndex].image.color = new Color(0,0,0,0);

            ChekIfTheGameIsFinished();
            
        } else
        {
            yield return new WaitForSeconds(.5f);
            btns[firstGuessIndex].image.sprite = bgImage;
            btns[secondGuessIndex].image.sprite = bgImage;
               
        }
        yield return new WaitForSeconds(.5f);

        firstGuess = secondGuess = false ;

    }

    void ChekIfTheGameIsFinished()
    {
        countCorrectGuesses++;
        if(countCorrectGuesses == gameGuesses)
        {
            
            Debug.Log("game Finished");
            Debug.Log("it took you " + countGuesses);
        }
    }

    void Shuffle(List<Sprite> list)
    {

        for(int i = 0 ; i <list.Count; i++)
        {
            Sprite temp = list[i];
            int rondomIndex = Random.Range(i,list.Count);
            list[i] = list[rondomIndex];
            list[rondomIndex] = temp;
        }
    }
}
