namespace navdi3
{

    using UnityEngine;
    using System.Collections;

    [RequireComponent(typeof(Rigidbody2D))]
    [ExecuteAlways]

    public class SmartSetupRigidbody2D : MonoBehaviour
    {

        public Rigidbody2D body { get { return GetComponent<Rigidbody2D>(); } }

        // Update is called once per frame
        void Update()
        {
            if (body != null)
            {
                body.freezeRotation = true;
                body.bodyType = RigidbodyType2D.Dynamic;
                body.gravityScale = 0;
                body.collisionDetectionMode = CollisionDetectionMode2D.Continuous;

                Object.DestroyImmediate(this);
            }
        }
    }

}