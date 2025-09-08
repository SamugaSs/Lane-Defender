/*****************************************************************************
// File Name : RestartScript.cs
// Author : Gabriel Flores-Martinez
// Creation Date : September 7, 2025

// Brief Description : This script allows the restart button to restart the game
*****************************************************************************/
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartScript : MonoBehaviour
{
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
