using UnityEngine;
using System.Collections;

using navdi3;

[RequireComponent(typeof(BlockFakerMazer))]

public class BlockFakerMazeWanderer : BlockFakerMazer
{
    public bool allowedToPush = false;
}
