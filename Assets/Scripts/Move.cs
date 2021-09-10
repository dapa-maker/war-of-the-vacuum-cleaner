using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] float speed;

    public void Update()
    {
        float y = Mathf.PingPong(Time.time * speed, 1) * 6 - 3;
       this.transform.position = new Vector3(0, y, 0);
    }
}