using UnityEngine;
using UnityEngine.U2D;

public class Hit_Detection : MonoBehaviour
{
    public int damage = 20;
    public ParticleSystem ps;
    public GameObject hitEffect;

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        E_Health enemyHealth = hitInfo.GetComponent<E_Health>();
        if (enemyHealth != null) 
        {
            GameObject effect = Instantiate(hitEffect, gameObject.transform.position, gameObject.transform.rotation);
            enemyHealth.TakeDamage(damage);
            Destroy(gameObject);
            Destroy(effect, 2f);
        }
        if (hitInfo.CompareTag("Environment"))
        {
            Destroy(gameObject);
        }
    }
}
