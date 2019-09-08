using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using navdi3;
using navdi3.jump;

public class ShootPlayer : MonoBehaviour
{

    public ShootXXI xxi;
    public Jumper jumper { get { return GetComponent<Jumper>(); } }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.X))
        {
            xxi.SpawnBullet(transform.position, jumper.faceleft?twin.left:twin.right);
        }
    }
}
