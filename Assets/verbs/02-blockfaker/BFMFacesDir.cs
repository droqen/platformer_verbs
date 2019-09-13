using UnityEngine;
using System.Collections;

using navdi3;

[RequireComponent(typeof(BlockFakerMazer))]

public class BFMFacesDirs : MonoBehaviour
{
    public BlockFakerMazer bfm { get { return GetComponent<BlockFakerMazer>(); } }
    void Update()
    {
        bfm.UpdateHelper_FaceFacingDir();
    }
}
