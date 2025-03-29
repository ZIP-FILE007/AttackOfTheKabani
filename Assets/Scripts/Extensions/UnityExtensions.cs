using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public static class UnityExtensions
{
    public static List<Vector2> TilesToAbsolutePositions(this Tilemap tilemap)
    {
        var vector3s = new List<Vector3>();

        foreach (var pos in tilemap.cellBounds.allPositionsWithin)
        {   
            Vector3Int localPlace = new Vector3Int(pos.x, pos.y, pos.z);
            Vector3 place = tilemap.CellToWorld(localPlace);
            if (tilemap.HasTile(localPlace))
            {
                vector3s.Add(place);
            }
        }

        List<Vector2> vector2s = vector3s.Select(v3 => new Vector2(v3.x, v3.y)).ToList();
        return vector2s;
    }

    public static Vector2 GetPositionInTilemap(this GameObject @object)
    {
        return new Vector2(MathF.Round(@object.transform.position.x), MathF.Round(@object.transform.position.y));
    }
}
