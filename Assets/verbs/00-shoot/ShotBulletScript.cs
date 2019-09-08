using UnityEngine;
using System.Collections;

public class ShotBulletScript : MonoBehaviour
{
    public navdi3.SpriteLot sprlot;

    public float speed = 100;

    float dead = 0;

    Rigidbody2D body { get { return GetComponent<Rigidbody2D>(); } }
    SpriteRenderer spriter { get { return GetComponent<SpriteRenderer>(); } }

    public void ShotSetup(navdi3.twin dir)
    {
        if (dir.x < 0) transform.localScale = new Vector3(-1, 1, 1);
        body.velocity = (Vector2)dir * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (dead <= 0) dead = .1f;
    }

    private void FixedUpdate()
    {
        if (dead > 0)
        {
            dead += .10f;
            
            if (dead < 0.25f) spriter.sprite = sprlot[32];
            else if (dead < 0.50f) spriter.sprite = sprlot[33];
            else if (dead < 0.75f) spriter.sprite = sprlot[34];
            else if (dead < 1.00f) spriter.sprite = sprlot[35];
            else Destroy(gameObject);
        }
    }
}
