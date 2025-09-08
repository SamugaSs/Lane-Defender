/*****************************************************************************
// File Name : EndScript.cs
// Author : Gabriel Flores-Martinez
// Creation Date : September 7, 2025
//
// Brief Description : This script allows the quit button to exit the game
*****************************************************************************/
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScript : MonoBehaviour
{
    public void QuitGame()
    {
        Application.Quit();
        UnityEditor.EditorApplication.isPlaying = false;
    }
}
