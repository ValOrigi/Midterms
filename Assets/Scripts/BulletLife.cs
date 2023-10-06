using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletLife : MonoBehaviour
{
    public float TimeToLive = 3f;
    private void Start()
    {
        Destroy(gameObject, TimeToLive);
    }

}
