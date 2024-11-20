using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GridPiece_Victory victory;
    public GridEntity_Movible_Player player;

    void LoadVictory()
    {
       SceneManager.LoadScene("VictoryScene");
    }

    void LoadDefeat()
    {
       SceneManager.LoadScene("DefeatScene");
    }
    
    void Update()
    {
        if (victory.isVictoryTriggered == true)
        {
            LoadVictory();
        }

        if (player.hasLost == true)
        {
            LoadDefeat();
        }
    }
}
