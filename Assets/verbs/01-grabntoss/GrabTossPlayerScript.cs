using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using navdi3.jump;
using navdi3;

public class GrabTossPlayerScript : MonoBehaviour
{
    public GrabTossXXI xxi;
    public SpriteLot spriteLot;
    public string carryingItem;

    public SpriteRenderer carriedItemSpriter;
    public GTPlayerGrabScript grabScript;

    public Jumper jumper { get { return GetComponent<Jumper>(); } }
    public SpriteRenderer spriter { get { return GetComponent<SpriteRenderer>(); } }

    float anim = 0;
    int[] walkFrames = { 1,2,3,4 };
    bool pinDoThrow = false;
    int stunbuffer = 0;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.X)) pinDoThrow = true;
    }

    private void FixedUpdate()
    {
        if (stunbuffer > 0) { stunbuffer--; GetComponent<JumperExamplePlayer>().enabled = (stunbuffer <= 0); return; }

        if (carryingItem != "")
        {
            if (xxi.banks.ContainsBank(carryingItem))
            {
                carriedItemSpriter.sprite = xxi.banks[carryingItem].Prefab.GetComponent<GrabTossThrowableItem>().mySprite;
            } else
            {
                carriedItemSpriter.sprite = null;
                carryingItem = "";
            }
        } else
        {
            carriedItemSpriter.sprite = null;
        }

        bool moving = (Mathf.Abs(jumper.pin.x) > float.Epsilon);
        int frame = 0;
        bool spriteIsUp = false;
        if (jumper.IsFloored())
        {
            var grabItem = grabScript.GetGrabbableItem();

            if (pinDoThrow && carryingItem != "")
            {
                twin throwDir = jumper.faceleft ? twin.left : twin.right;
                xxi.SpawnThrowItem(transform.position, (Vector2)throwDir * jumper.x_MaxMoveSpeed * 2, this.carryingItem);

                stunbuffer = 20;
                carriedItemSpriter.sprite = null;
                carryingItem = "";
                jumper.pin.x = 0;
                frame = 5;
            } else if (pinDoThrow && grabItem != null) {
                carryingItem = grabItem.gameObject.name;
                Object.Destroy(grabItem.gameObject);
            } else if (moving)
            {
                anim = (anim + .175f) % 4;
                frame = walkFrames[(int)anim];
            } else
            {
                anim = 0;
                //frame = 0;
            }
        } else
        {
            anim = 3;
            frame = 1;
        }
        if (moving) spriter.flipX = jumper.pin.x < 0;
        if (frame == 1 || frame == 3) spriteIsUp = true;
        if (carryingItem != "") frame += 10;

        carriedItemSpriter.transform.localPosition = Vector3.up * (spriteIsUp ? 11 : 10);
        spriter.sprite = spriteLot[frame];

        pinDoThrow = false;
    }
}
