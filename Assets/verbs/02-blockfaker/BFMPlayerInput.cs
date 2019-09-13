using UnityEngine;
using System.Collections;

using navdi3;

[RequireComponent(typeof(BlockFakerMazer))]

public class BFMPlayerInput : MonoBehaviour
{
    public BlockFakerMazer bfm { get { return GetComponent<BlockFakerMazer>(); } }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        var pin = Pin.GetTwinDown();
        if ((pin.x != 0) != (pin.y != 0))
        {
            bfm.TryMove(pin);
        }

		bfm.UpdateHelper_FaceFacingDir();
    }
}
