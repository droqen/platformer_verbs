using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(BoxCollider2D))]

public class GTPlayerGrabScript : MonoBehaviour
{
    BoxCollider2D box { get { return GetComponent<BoxCollider2D>(); } }
    //public GrabTossPlayerScript Player { get { return GetComponentInParent<GrabTossPlayerScript>(); } }

    Collider2D[] colliders = new Collider2D[10];
    ContactFilter2D filter = new ContactFilter2D();

    public GrabTossThrowableItem GetGrabbableItem()
    {
        filter.SetLayerMask(LayerMask.GetMask("Default"));
        var count = box.OverlapCollider(filter,colliders);
        for (var i = 0; i < count; i ++)
        {
            var throwable = colliders[i].GetComponent<GrabTossThrowableItem>();
            if (throwable != null) return throwable;
        }

        return null;
    }

    HashSet<GrabTossThrowableItem> throwableItems;

    private void Start()
    {
        throwableItems = new HashSet<GrabTossThrowableItem>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        var throwitem = collision.GetComponent<GrabTossThrowableItem>();
        if (throwitem != null) throwableItems.Add(throwitem);
    }
}
