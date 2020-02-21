using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using navdi3;
using navdi3.xxi;
using navdi3.tiled;

public class SadGoldXXI : BaseTilemapXXI
{
    Dictionary<twin, TiledLevelData> worldmap;
    twin currentMapPosition = twin.zero;
    TiledLevelData currentMapLevelData { get { return worldmap[currentMapPosition]; } }

    private void Start()
    {
        worldmap = new Dictionary<twin, TiledLevelData>();
        var levelAssets = Resources.LoadAll<TextAsset>("sadgoldlevels");
        foreach(var levelAsset in levelAssets)
        {
            var map_coords = levelAsset.name.Split(',');
            if (map_coords.Length > 1 && int.TryParse(map_coords[0], out int map_x) && int.TryParse(map_coords[1], out int map_y)) {
                worldmap.Add(new twin(map_x, map_y), loader.Load(levelAsset));
            } else
            {
                Dj.Warnf("SadGoldXXI didn't register level {0}", levelAsset.name);
            }
        }
        //Dj.Tempf("Hi {0} {1}", Resources.Load("sadgoldlevels/0,0") == null, null == null);
        loader.SetupTileset(sprites, GetSolidTileIds(), GetSpawnTileIds());
        //loader.PlaceTiles(loader.Load(firstLevel), tilemap, this.SpawnTileId);
        loader.PlaceTiles(currentMapLevelData, tilemap, this.SpawnTileId);
    }

    public override int[] GetSolidTileIds()
    {
        return new int[] { 10, 11, 12, 13, 14, 15, 16, };
    }

    public override int[] GetSpawnTileIds()
    {
        return new int[] { 1, };
    }

    public override void SpawnTileId(int TileId, Vector3Int TilePos)
    {
        switch(TileId)
        {
            case 1:
                if (GetEntLot("players").IsEmpty())
                {
                    banks["frog"].Spawn(GetEntLot("players"), tilemap.layoutGrid.GetCellCenterWorld(TilePos));
                }
                break;
        }
    }

    private void FixedUpdate()
    {
        foreach(Transform child in (Transform)GetEntLot("players"))
        {
            if (child.transform.position.x >= 384 - 5)
            {
                child.transform.position -= Vector3.right * (384 - 10);
                currentMapPosition += twin.right;
                GetEntLot("ents").Clear();
                loader.PlaceTiles(currentMapLevelData, tilemap, this.SpawnTileId);
            }
            if (child.transform.position.x <= 0 + 5)
            {
                child.transform.position -= Vector3.left * (384 - 10);
                currentMapPosition += twin.left;
                GetEntLot("ents").Clear();
                loader.PlaceTiles(currentMapLevelData, tilemap, this.SpawnTileId);
            }
        }
    }
}
