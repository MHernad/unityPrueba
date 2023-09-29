using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        EnemyController other = collision.gameObject.GetComponent<EnemyController>();
        if (other)
        {
            Destroy(gameObject);
        }
    }
}
