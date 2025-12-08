using UnityEngine;

public class Piece : MonoBehaviour
{
    public Board _Board { get; private set; }
    public TetraminoData Data { get; private set; }
    public Vector3Int Position { get; private set; }
    public Vector3Int[] Cells { get; private set; }

    public void Initialize(Board board, Vector3Int position, TetraminoData data)
    {
        _Board = board;
        Data = data;
        Position = position;
        if (Cells == null)
        {
            Cells = new Vector3Int[data.cells.Length];
        }

        for (int i = 0; i < data.cells.Length; i++)
        {
            Cells[i] = (Vector3Int)data.cells[i]; 
        }
    }
}
