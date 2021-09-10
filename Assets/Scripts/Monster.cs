using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    [SerializeField] Sprite _deadSprite;
    [SerializeField] ParticleSystem _particelSystem;
    
    private bool hasDied;

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
            return true;

        if (collision.contacts[0].normal.y < -0.5) 
            return true;

        return false;

    }

    private IEnumerator Die()
    {
        hasDied = true;
        GetComponent<SpriteRenderer>().sprite = _deadSprite;
        _particelSystem.Play();
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}
