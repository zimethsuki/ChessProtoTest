using System.Collections.Generic;
using UnityEngine;

public class PieceBehaviour : MonoBehaviour
{
    public virtual void TryMove(Vector2 pos)
    {
    }

    protected virtual void SendPosToCheck(List<Vector2Int> pos)
    {
        print("send post to check");
        Actions.CheckPieceMove.Invoke(pos);
    }
}