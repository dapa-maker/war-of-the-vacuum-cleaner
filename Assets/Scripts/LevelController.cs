using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    [SerializeField] string _nextLevelName;

    private Monster[] _monsters;
    private BigMonster[] _bigMonsters;

    private void OnEnable()
    {
        _monsters = FindObjectsOfType<Monster>();
        _bigMonsters = FindObjectsOfType<BigMonster>();
    }

    // Update is called once per frame
    void Update()
    {
       
        if (MonstersAreAllDead())
        {
            if (SceneManager.GetActiveScene().buildIndex != 6)
                GoToNextLevel();
            if (Time.timeSinceLevelLoad >= 16 && SceneManager.GetActiveScene().buildIndex == 6)
                Debug.Log("Now go to next f***ing Level");
                GoToNextLevel();
        }

    }
    

  

    private void GoToNextLevel()
    {
        Debug.Log("Go to level " + _nextLevelName);
        SceneManager.LoadScene(_nextLevelName);
    }

    private bool MonstersAreAllDead()
    {
        foreach (var monster in _monsters)
        {
            if (monster.gameObject.activeSelf)
            {
                return false;
            }
        }

        foreach (var bigMonster in _bigMonsters)
        {
            if (bigMonster.gameObject.activeSelf)
            {
               return false;
            }
        }
        return true;
    }
}
