using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hide : MonoBehaviour
{
    

    // Start is called before the first frame update
    IEnumerator Wait15ThenDeactivate()
    {
        yield return new WaitForSeconds(14.5f);
        Debug.Log("time is over");
        gameObject.SetActive(false);
    }
    void Start()
    {
        StartCoroutine(Wait15ThenDeactivate());
    }
    

}
