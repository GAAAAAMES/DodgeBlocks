using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 15f;
    public float mapWidth = 4f;
    private Rigidbody2D rigid;

    // Start is called before the first frame update
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        Vector2 newPosition = rigid.position;
        if (Input.touchCount > 0)
        {
            Vector2 touchPosition = Input.GetTouch(0).position;
            if (touchPosition.x > Screen.width * 0.5f)
            {
                newPosition += Time.fixedDeltaTime * speed * Vector2.right;
            }
            else
            {
                newPosition -= Time.fixedDeltaTime * speed * Vector2.right;
            }
        }
        else { }
        // float x = Input.GetAxis("Horizontal") * Time.fixedDeltaTime * speed;

        //  Vector2 newPosition = rigid.position + Vector2.right * x;

        newPosition.x = Mathf.Clamp(newPosition.x, -mapWidth, mapWidth);

        rigid.MovePosition(newPosition);
    }

}
