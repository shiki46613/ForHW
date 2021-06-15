using UnityEngine;
using UnityEngine.SceneManagement;

namespace Something
{
    public class EndGame : IEndGame
    {
        void IEndGame.WinGame()
        {
            if (AllVariables.BonusCount == 9)
            {
                //экран победы
                SceneManager.LoadScene(1); //главное меню
            }
        }

        void IEndGame.CharacterDeath(int hpCount)
        {
            if (hpCount < 0)
                hpCount = 0;
            if (hpCount == 0)
            {
                Starter.player.gameObject.SetActive(false);
                //экран поражения
                SceneManager.LoadScene(1); //главное меню
            }

        }
    }
}