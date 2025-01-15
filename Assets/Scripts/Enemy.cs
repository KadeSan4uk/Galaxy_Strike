using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject destroyVFX;
    [SerializeField] int hitPoint = 3;

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();

    }

    private void ProcessHit()
    {
        hitPoint--;

        if (hitPoint <= 0)
        {
            Instantiate(destroyVFX, transform.position, Quaternion.identity);
            Destroy(this.gameObject);
        }
    }
}
