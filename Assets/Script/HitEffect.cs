using UnityEngine;

public class HitEffect : MonoBehaviour
{
    public float floatSpeed = 1.5f;
    public float lifeTime = 1f;

    void Start()
    {
        Destroy(gameObject, lifeTime);
    }

    void Update()
    {
        transform.position += Vector3.up * floatSpeed * Time.deltaTime;
    }
}
