using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using SimonGameApplication;

//FIXME directly implement IGameResult is a bad idea
public class GameCenter : MonoBehaviour, IGameResult
{
    public Text Messageboard;
	public Button ActionButton;
	public Button buttonOne;
	public Button buttonTwo;
	public Button buttonThree;
	public Button buttonFour;

    public Image IndicatorOne;
    public Image IndicatorTwo;
    public Image IndicatorThree;
    public Image IndicatorFour;

	internal List<Image> indicatorList;
	internal SimonGame simonGame;

    void Start()
    {
        ActionButton.onClick.AddListener(TaskOnClick);
		buttonOne.onClick.AddListener(delegate      { CheckNumber(1); });
		buttonTwo.onClick.AddListener(delegate      { CheckNumber(2); });
		buttonThree.onClick.AddListener(delegate    { CheckNumber(3); });
		buttonFour.onClick.AddListener(delegate     { CheckNumber(4); });

        indicatorList = new List<Image>();
        indicatorList.Add(IndicatorOne);
        indicatorList.Add(IndicatorTwo);
        indicatorList.Add(IndicatorThree);
        indicatorList.Add(IndicatorFour);
		simonGame = new SimonGame(this);

        HideIndicator();
        //StartCoroutine(DisplayIndicators(new List<int> { 1, 2, 3 ,4 , 1, 2, 3, 4, 1, 2, 3, 4, 1, 2, 3, 4, 1, 2, 3, 4, 1, 2, 3, 4, 1, 2, 3, 4, 1, 2, 3, 4, 1, 2, 3, 4, 1, 2, 3, 4, 1, 2, 3, 4, 1, 2, 3, 4, 1, 2, 3, 4, 1, 2, 3, 4, 1, 2, 3, 4, 1, 2, 3, 4, 1, 2, 3, 4, 1, 2, 3, 4, 1, 2, 3, 4, 1, 2, 3, 4, 1, 2, 3, 4, 1, 2, 3, 4, 1, 2, 3, 4, 1, 2, 3, 4, 1, 2, 3, 4, 1, 2, 3, 4, 1, 2, 3, 4, 1, 2, 3, 4, }));
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


    void CheckNumber(int number)
	{
		simonGame.Guess(number);
	}

    IEnumerator DisplayIndicators(List<int> numberList)
    {
        foreach (int number in numberList) {
            HideIndicator();
            yield return new WaitForSeconds(1.5f);
            DisplayIndicator(number);
            yield return new WaitForSeconds(1.5f);
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
