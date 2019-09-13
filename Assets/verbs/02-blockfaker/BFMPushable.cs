using UnityEngine;
using System.Collections;

using navdi3;

[RequireComponent(typeof(BlockFakerMazer))]

public class BFMPushable : MonoBehaviour
{
	public bool isPushable = true;

    public BlockFakerMazer bfm { get { return GetComponent<BlockFakerMazer>(); } }
    
}
