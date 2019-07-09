using System.Collections.Generic;

namespace SimonGameApplication {

    public interface IGameResult
    {
        void GameFailed(int score);
        void GameSuccessed(List<int> numberList);
    }
}