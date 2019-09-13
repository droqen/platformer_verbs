using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using navdi3;
using navdi3.maze;
using navdi3.xxi;

public class BlockFakerXXI : navdi3.xxi.BaseTilemapXXI
{
    private void Start()
    {
        InitializeTileSystem();
    }

    public MazeMaster mazeMaster;

    public override int[] GetSolidTileIds()
    {
        return new int[] { 10, };
    }

    public override int[] GetSpawnTileIds()
    {
        return new int[] { 1,2,3, };
    }

    public override void SpawnTileId(int TileId, Vector3Int TilePos)
    {
        Vector3 EntPos = tilemap.layoutGrid.GetCellCenterWorld(TilePos);
        switch(TileId)
        {
            case 1: banks["player"].Spawn<BlockFakerMazer>(GetEntLot("BFMs"), EntPos).Setup(this.mazeMaster, new twin(TilePos)); break;
            case 2: banks["block"].Spawn<BlockFakerMazer>(GetEntLot("BFMs"), EntPos).Setup(this.mazeMaster, new twin(TilePos)); break;
            case 3: banks["redboy"].Spawn<BlockFakerMazer>(GetEntLot("BFMs"), EntPos).Setup(this.mazeMaster, new twin(TilePos)); break;
		}
    }
}
