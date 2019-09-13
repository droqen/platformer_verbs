using UnityEngine;
using System.Collections;

using navdi3;

public class BFMWanderer : MonoBehaviour
{
    public BlockFakerMazer bfm { get { return GetComponent<BlockFakerMazer>(); } }

    public float timeBetweenMoves = 0.5f;
    float nextMove = 0;

    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextMove)
        {
            PickAMove();
            nextMove = Time.time + timeBetweenMoves;
        }
    }

    void PickAMove()
    {
        var moves = new ChoiceStack<twin>();
        moves.AddManyThenLock(twin.compass);
        moves.RemoveAll(-bfm.lastMove);
        moves.Add(-bfm.lastMove);
        moves.Lock(shuffle: false);
        twin iMoved = moves.GetFirstTrue(bfm.TryMove);
        
        if (iMoved == twin.zero)
        {
            bfm.facingDir = twin.compass[Random.Range(0, 4)];
        }

        bfm.UpdateHelper_FaceFacingDir();
    }

}
