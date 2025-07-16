using UnityEngine;
using UnityEngine.SceneManagement;

public class BigDumbbel : MonoBehaviour
{
    public float MoveSpeed = 5.0f;

    void FixedUpdate()
    {
        transform.position = new Vector3(transform.position.x + MoveSpeed * Time.fixedDeltaTime*-1, 4, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
    }

}
