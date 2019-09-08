using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using navdi3;
using navdi3.xxi;

public class ShootXXI : BaseTilemapXXI
{

    public override int[] GetSolidTileIds()
    {
        return new int[] { 10, };
    }
    public override int[] GetSpawnTileIds()
    {
        return new int[] { 1, };
    }
    public override void SpawnTileId(int TileId, Vector3Int TilePos)
    {
        var EntPos = tilemap.layoutGrid.GetCellCenterWorld(TilePos);
        switch(TileId)
        {
            case 1: banks["player"].Spawn(GetEntLot("players"), EntPos); break;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(0, 0);
        InitializeTileSystem();
    }

    public void SpawnBullet(Vector3 position, twin dir)
    {
        banks["bullet"].Spawn<ShotBulletScript>(GetEntLot("bullets"), position+dir).ShotSetup(dir);
    }
}
