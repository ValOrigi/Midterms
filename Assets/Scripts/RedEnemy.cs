using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedEnemy : MonoBehaviour
{
    public float speed = 1.5f;
    public Transform pointB;

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, pointB.position, speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("RedBullet"))
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }

        else
        {
            Destroy(other.gameObject);
        }
    }
}
