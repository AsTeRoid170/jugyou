using System.Collections.Generic;
using UnityEngine;

public class BeltConveyor : MonoBehaviour
{
    private float speed = 3.0f;

    float diffX = 0.0f;
    readonly List<GameObject> gameObjects = new();

    void Start()
    {
        Vector3 scale = transform.localScale;
        Debug.Log("X軸スケール: " + scale.x);
        if (scale.x < 0)
        {
            speed = speed * -1;
            Debug.Log("スピード: " + speed);
        }
        diffX = speed * Time.fixedDeltaTime;
    }

    private void FixedUpdate()
    {
        foreach (GameObject gameObject in gameObjects)
        {
            Vector2 speed = new Vector3(diffX, 0);
            Vector2 newPos = gameObject.GetComponent<Rigidbody2D>().position + speed;
            gameObject.GetComponent<Rigidbody2D>().position = newPos;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Rigidbody2D>() != null)
        {
            gameObjects.Add(collision.gameObject);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (gameObjects.Contains(collision.gameObject))
        {
            gameObjects.Remove(collision.gameObject);
        }
    }

}
