using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public void LoadVictory()
    {
       SceneManager.LoadScene("VictoryScene");
    }

    public void LoadDefeat()
    {
       SceneManager.LoadScene("DefeatScene");
    }
}
