using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] private float health = 30;
    [SerializeField] private SpriteGraphics graphics;

    Rigidbody2D enemyBody;

    void Start() {
        enemyBody = GetComponent<Rigidbody2D>();
    }

    public void GetHurt(float damage) {
        graphics.Flash(0.1f, ColorTheme.Instance.enemyHurt);
        health -= damage; 
        if (health <= 0) Die();
    }

    public void Die() {
        FollowCam.Instance.ScreenShake(0.1f, 0.1f);
        ParticleManager.Instance.Play(ParticleManager.Instance.explosion, transform.position);
        
        XPManager.Instance.CreateXP(transform.position);
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D trigger) {
        if (trigger.CompareTag("Bullet"))
        {
            enemyBody.AddForce(trigger.GetComponent<Rigidbody2D>().velocity.normalized * PlayerShooting.Instance.enemyKnockback, ForceMode2D.Impulse);
            GetHurt(PlayerShooting.Instance.damage);
        }
    }

}
