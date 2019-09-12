using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabTossThrowableItem : MonoBehaviour
{
    Rigidbody2D body { get { return GetComponent<Rigidbody2D>(); } }

    public Sprite mySprite { get { return GetComponent<SpriteRenderer>().sprite; } }
    public void SetupThrow(Vector2 force)
    {
        body.velocity = force;
    }
}
