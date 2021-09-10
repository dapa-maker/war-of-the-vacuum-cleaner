using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    

    private Vector2 _startPosition;
    Rigidbody2D _rigidbody2D;
   
    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        
    }

    // Start is called before the first frame update
    void Start()
    {
        _startPosition = _rigidbody2D.position;
        //_rigidbody2D.isKinematic = true;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Goal goal = collision.gameObject.GetComponent<Goal>();
        Goalkeeper goalkeeper = collision.gameObject.GetComponent<Goalkeeper>();
        if (goal != null || goalkeeper != null)
            StartCoroutine(ResetAfterDelay());
    }

    private IEnumerator ResetAfterDelay()
    {
        yield return new WaitForSeconds(1);
        _rigidbody2D.position = _startPosition;
       // _rigidbody2D.isKinematic = true;
        _rigidbody2D.velocity = Vector2.zero;
    }

    
}
