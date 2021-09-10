using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BigMonster : MonoBehaviour
{
    [SerializeField] Sprite _deadSprite;
    [SerializeField] ParticleSystem _particelSystem;
    [SerializeField] ParticleSystem _particelSystem2;

    public HealthBar healthBar;
    private bool hasDied;
    private int monsterHealth = 4;

    private void Update()
    {
       if (Time.timeSinceLevelLoad >= 14.5f)
        {
            _particelSystem2.Play();
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (SchouldDieFromCollision(collision))
        {
            StartCoroutine(Die());

        }
    }

    private bool SchouldDieFromCollision(Collision2D collision)
    {
        if (hasDied)
            return false;
        Bird bird = collision.gameObject.GetComponent<Bird>();
        if (bird != null)
        {
            monsterHealth--;
            Debug.Log("Health: " + monsterHealth);
            healthBar.SetHealth(monsterHealth);
            StartCoroutine(changeColor());
        }
        if (monsterHealth <= 0)
            return true;
        return false;

    }

    private IEnumerator changeColor()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSeconds(1);
        GetComponent<SpriteRenderer>().color = Color.white; ;
    }

    private IEnumerator Die()
    {
        hasDied = true;
        GetComponent<SpriteRenderer>().sprite = _deadSprite;
        _particelSystem.Play();
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
        yield return new WaitForSeconds(1);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
