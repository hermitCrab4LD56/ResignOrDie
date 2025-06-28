using UnityEngine;

public class LaserBullet : MonoBehaviour
{
    public float speed = 10f;
    public float lifeTime = 3f;
    private Vector2 direction;

    public void SetDirection(Vector2 dir)
    {
        direction = dir.normalized;
        Destroy(gameObject, lifeTime);  // 自动销毁
    }

    void Update()
    {
        transform.Translate(direction * speed * Time.deltaTime);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // 播放音效 + 蹦出特效
            FXManager.Instance.PlayHitFeedback(collision.transform.position);

            // 你可以加上玩家受伤逻辑，例如：
            // collision.GetComponent<PlayerHealth>()?.TakeDamage(10);

            Destroy(gameObject); // 子弹消失
        }
    }
}
