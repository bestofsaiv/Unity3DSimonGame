using System;
using System.Collections.Generic;
using Debug = UnityEngine.Debug;
using Random = System.Random;

namespace SimonGameApplication
{
    public class SimonGame
    {
        internal Random random;
        internal int currentIndex;
        internal List<int> numberList;
        internal IGameResult gameResult;

        public SimonGame(IGameResult game)
        {
            random = new Random();
            numberList = new List<int>();
            gameResult = game;
        }

        private int GenerateNumber()
        {
            return random.Next(1, 5);
        }

        public void StartGame()
        {
            ResetGame();
            ChallengeEvolute();
        }

        public bool Guess(int check)
        {
            int number = numberList[currentIndex];
            if (check != number)
            {
                Debug.Log("GameFailed! " + check + " and " + number);

                ChallengeEnd();
                return false;
            }

            Debug.Log(check + " is Correct");
            if (++currentIndex >= numberList.Count)
            {
                ChallengeEvolute();
            }
            return true;
        }

        public void ResetGame()
        {
            numberList.Clear();
        }

        private void ChallengeEnd()
        {
            gameResult.GameFailed(numberList.Count);
            ResetGame();
        }

        private void ChallengeEvolute()
        {
            currentIndex = 0;
            numberList.Add(GenerateNumber());
            gameResult.GameSuccessed(numberList);
        }
    }
}