using UnityEngine;
using System.Collections;

using navdi3;
using navdi3.maze;

public class BlockFakerMazer : MazeBody
{
	public bool allowedToPush = true;

    override public bool CanMoveTo(twin target_pos) {
        if (IsSolid(target_pos)) return false;
        twin dir = target_pos - my_cell_pos;
        if (dir == twin.zero) return false;
        foreach(var body in master.GetBodiesAt(target_pos))
        {
            var pushable = body.gameObject.GetComponent<BFMPushable>();
            if (pushable != null) return pushable.isPushable && allowedToPush && body.CanMoveTo(target_pos + dir); // first pushable can be pushed? great! push it.
        }

        return true; // no pushables in the way
    }
    override public void OnMoved(twin prev_pos, twin target_pos)
    {
        twin dir = target_pos - prev_pos;
        foreach (var body in master.GetBodiesAt(target_pos))
        {
            var pushable = body.gameObject.GetComponent<BFMPushable>();
            if (body != this && pushable != null) body.TryMove(dir);
        }
    }

    public twin facingDir { get { return lastMove; } set { lastMove = value; } }

    public void MazerSetup(MazeMaster master, twin cell_pos)
    {
        this.Setup(master, cell_pos);
    }

    private void FixedUpdate()
    {
        transform.position += ToCentered() * 0.5f;
    }




    public void UpdateHelper_FaceFacingDir()
	{
		if (facingDir != twin.zero)
		{
			transform.rotation = Quaternion.Euler(0, 0, Vector2.SignedAngle(Vector2.right, facingDir));
		}
	}
}
