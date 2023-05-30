using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public int boardWidth, boardLenght;
    public Color blackColor, whiteColor, canMoveHighlight;
    [SerializeField] private TileBehaviour tilePrefab;
    [SerializeField] private PieceBehaviour[] piece;
    private TileBehaviour[,] _tileMap;

    private void Start()
    {
        TileBehaviour tile;
        var tileCounter = 0;
        _tileMap = new TileBehaviour[boardWidth, boardLenght];
        var pos = Vector2.zero;
        var randomPosSpawnPiece1 = new Vector2(Random.Range(0, boardWidth), Random.Range(0, boardLenght));
        var randomPosSpawnPiece2 = new Vector2(Random.Range(0, boardWidth), Random.Range(0, boardLenght));
        for (var i = 0; i < boardWidth; i++)
        {
            tileCounter++;
            for (var j = 0; j < boardLenght; j++)
            {
                pos.x = i;
                pos.y = j;

                tile = Instantiate(tilePrefab, transform);
                tile.name = $"Tile {j},{i}";
                tile.SetTile(pos, tileCounter % 2 == 0 ? blackColor : whiteColor);
                if (pos == randomPosSpawnPiece1)
                    tile.SetPiece(Instantiate(piece[0]));
                if (pos == randomPosSpawnPiece2)
                    tile.SetPiece(Instantiate(piece[1]));
                _tileMap[i, j] = tile;
                tileCounter++;
            }
        }
    }

    private void OnEnable()
    {
        Actions.CheckPieceMove += CheckMovePos;
    }

    private void OnDisable()
    {
        Actions.CheckPieceMove -= CheckMovePos;
    }

    private void CheckMovePos(List<Vector2Int> positions)
    {
        for (var i = 0; i < boardWidth; i++)
        for (var j = 0; j < boardLenght; j++)
            _tileMap[i, j].SetHighlight(false);

        if (positions == null) return;

        foreach (var pos in positions)
            if (pos.x < boardWidth && pos.y < boardLenght && pos is { x: >= 0, y: >= 0 })
                _tileMap[pos.x, pos.y].SetHighlight(true);
    }
}