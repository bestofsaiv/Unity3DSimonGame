using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using SimonGameApplication;

//FIXME directly implement IGameResult is a bad idea
public class GameCenter : MonoBehaviour, IGameResult
{
    public Text Messageboard;
    
    public Punchable ActionPunch;

    public Punchable buttonOne;
    public Punchable buttonTwo;
    public Punchable buttonThree;
    public Punchable buttonFour;

    public Image IndicatorOne;
    public Image IndicatorTwo;
    public Image IndicatorThree;
    public Image IndicatorFour;

	internal List<Image> indicatorList;
	internal SimonGame simonGame;

    void Start()
    {

        ActionPunch.onPunch += delegate { TaskOnClick();  };

        buttonOne.onPunch += delegate { CheckNumber(1); };
        buttonTwo.onPunch += delegate { CheckNumber(2); };
        buttonThree.onPunch += delegate { CheckNumber(3); };
        buttonFour.onPunch += delegate { CheckNumber(4); };

       

        indicatorList = new List<Image>();
        indicatorList.Add(IndicatorOne);
        indicatorList.Add(IndicatorTwo);
        indicatorList.Add(IndicatorThree);
        indicatorList.Add(IndicatorFour);
		simonGame = new SimonGame(this);

        HideIndicator();
    }

    void HideIndicator()
    {
        IndicatorOne.enabled = false;
        IndicatorTwo.enabled = false;
        IndicatorThree.enabled = false;
        IndicatorFour.enabled = false;
    }

    void DisplayIndicator(int number)
    {
        switch (number)
        {
            case 1:
                IndicatorOne.enabled = true;
                break;
            case 2:
                IndicatorTwo.enabled = true;
                break;
            case 3:
                IndicatorThree.enabled = true;
                break;
            case 4:
                IndicatorFour.enabled = true;
                break;
        }
    }

    void Update()
    {
        
    }

    void TaskOnClick()
    {
        Messageboard.text = "Game Start!";
        simonGame.StartGame();
    }


    public void CheckNumber(int number)
	{
		simonGame.Guess(number);
	}

    IEnumerator DisplayIndicators(List<int> numberList)
    {
        foreach (int number in numberList) {
            HideIndicator();
            yield return new WaitForSeconds(.5f);
            DisplayIndicator(number);
            yield return new WaitForSeconds(.5f);
        }
        HideIndicator();
    }

    public void GameFailed(int score)
    {
        Messageboard.text = "Game Over! Your Score: " + score;
    }

    public void GameSuccessed(List<int> numberList)
    {
        Messageboard.text = "New Challenge: " + numberList.Count;

        foreach (int number in numberList)
        {
            Debug.Log("Number :" + number);
            StartCoroutine(DisplayIndicators(numberList));
        }
    }
}
