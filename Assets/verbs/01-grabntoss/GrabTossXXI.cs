using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabTossXXI : navdi3.xxi.BaseTilemapXXI
{
    public override int[] GetSolidTileIds()
    {
        return new int[] { 2, };
    }
    public override int[] GetSpawnTileIds()
    {
        return new int[] { 1,3, };
    }
    public override void SpawnTileId(int TileId, Vector3Int TilePos)
    {
        Vector3 EntPos = tilemap.layoutGrid.GetCellCenterWorld(TilePos);
        switch(TileId)
        {
            case 1: banks["player"].Spawn(GetEntLot("players"), EntPos); break;
            case 3: banks["ball"].Spawn(GetEntLot("items"), EntPos); break;
        }
    }

    public void SpawnThrowItem(Vector3 position, Vector2 throwForce, string throwableName)
    {
        banks[throwableName].Spawn<GrabTossThrowableItem>(GetEntLot("items"), position).SetupThrow(throwForce);
    }

    // Start is called before the first frame update
    void Start()
    {
        Physics2D.IgnoreLayerCollision(0, 0);
        this.InitializeTileSystem();
    }
}
