using System.Collections.Generic;
using UnityEngine;

public class BentengBehaviour : PieceBehaviour
{
    public override void TryMove(Vector2 pos)
    {
        var tempPos = new Vector2Int((int)pos.x, (int)pos.y);
        //keatas
        var targetPos = new List<Vector2Int>();
        for (var i = 1; i < 10; i++)
        {
            targetPos.Add(tempPos + new Vector2Int(i, 0));
            targetPos.Add(tempPos + new Vector2Int(i * -1, 0));
            targetPos.Add(tempPos + new Vector2Int(0, i));
            targetPos.Add(tempPos + new Vector2Int(0, i * -1));
        }


        SendPosToCheck(targetPos);
    }
}