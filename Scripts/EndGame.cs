using UnityEngine;
using UnityEngine.SceneManagement;

namespace Something
{
    public class EndGame
    {
        public void WinGame(int count)
        {
            if (count == 9)
            {
                //экран победы
                SceneManager.LoadScene(1); //главное меню
            }
        }

        public void CharacterDeath(int hpCount)
        {
            if (hpCount < 0)
                hpCount = 0;
            if (hpCount == 0)
            {
                //player.gameObject.SetActive(false);
                //экран поражения
                SceneManager.LoadScene(1); //главное меню
            }

        }
    }
}