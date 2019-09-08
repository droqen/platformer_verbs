namespace navdi3.jump
{

    using System.Collections;
    using System.Collections.Generic;
    using UnityEngine;

    public class JumperExamplePlayer : MonoBehaviour
    {
        public Jumper jumper { get { return GetComponent<Jumper>(); } }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space)) jumper.PinJump();
        }
        private void FixedUpdate()
        {
            jumper.pin = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            if (!Input.GetKey(KeyCode.Space)) jumper.PinJumpRelease();
        }
    }

}