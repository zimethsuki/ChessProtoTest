using System.Collections.Generic;
using UnityEngine;

public class KudaBehaviour : PieceBehaviour
{
    public override void TryMove(Vector2 pos)
    {
        var tempPos = new Vector2Int((int)pos.x, (int)pos.y);
        //keatas
        var targetPos = new List<Vector2Int>
        {
            tempPos + new Vector2Int(3, 1),
            tempPos + new Vector2Int(3, -1),
            tempPos + new Vector2Int(-3, 1),
            tempPos + new Vector2Int(-3, -1),
            tempPos + new Vector2Int(1, 3),
            tempPos + new Vector2Int(1, -3),
            tempPos + new Vector2Int(-1, 3),
            tempPos + new Vector2Int(-1, -3)
        };

        SendPosToCheck(targetPos);
    }
}