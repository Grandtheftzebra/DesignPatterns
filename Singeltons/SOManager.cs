using System;
using UnityEngine;
using UnityEngine.SceneManagement;

[CreateAssetMenu(fileName = "GameManager", menuName = "Scriptable Objects/GameManager")]
public class SOManager : ScriptableSingleton<SOManager>
{
    public event Action OnScoreChanged;
    public int Score = 0;
    public int StartingLevel = 1;

    public void StartGame()
    {
        Debug.Log("New game has started with SO Manager!");
        SceneManager.LoadScene(StartingLevel);
    }
    
    public void IncreaseScoreByOne()
    {
        Score++;
        OnScoreChanged?.Invoke();
    }
}
