using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UIElements;

public class TileBehaviour : MonoBehaviour, IPointerClickHandler
{
    [SerializeField] private SpriteRenderer tileImage;
    private Color _normalColor;
    private PieceBehaviour _occupingPiece;
    private Vector2 _tilePos;
    [SerializeField] private Button tileClick;


    public void OnPointerClick(PointerEventData eventData)
    {
        if (_occupingPiece == null)
        {
            Actions.CheckPieceMove.Invoke(null);
            return;
        }

        _occupingPiece.TryMove(_tilePos);
    }

    public void SetTile(Vector2 pos, Color tileColor)
    {
        _tilePos = pos;
        transform.localPosition = pos;
        _normalColor = tileColor;
        tileImage.color = _normalColor;
    }

    public void SetPiece(PieceBehaviour piece)
    {
        _occupingPiece = piece;
        piece.transform.SetParent(transform, false);
    }

    public void SetHighlight(bool highlight)
    {
        tileImage.color = highlight ? Color.red : _normalColor;
    }
}