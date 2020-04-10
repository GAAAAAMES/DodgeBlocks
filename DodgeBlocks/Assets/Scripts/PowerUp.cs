using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public float gravity;

    void start()
    {
        GetComponent<Rigidbody2D>().gravityScale += Time.timeSinceLevelLoad / 25f;
        gravity = GetComponent<Rigidbody2D>().gravityScale;
    }

    private void Update()
    {
        if (transform.position.y <= -5f)
        {
            Destroy(gameObject);
        }
    }
}
