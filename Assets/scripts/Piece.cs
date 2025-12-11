using UnityEngine;

public class Piece : MonoBehaviour
{
    public Board _Board { get; private set; }
    public TetraminoData Data { get; private set; }
    public Vector3Int Position { get; private set; }
    public Vector3Int[] Cells { get; private set; }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            Move(Vector2Int.left);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            Move(Vector2Int.right);
        }
    }

    public void Initialize(Board board, Vector3Int position, TetraminoData data)
    {
        _Board = board;
        Data = data;
        Position = position;
        if (Cells == null)
        {
            Cells = new Vector3Int[data.cells.Length];
        }

        for (int i = 0; i < Cells.Length; i++)
        {
            Cells[i] = (Vector3Int)data.cells[i]; 
        }
    }

    private void Move(Vector2Int translation)
    {
        Vector3 newPosition = transform.position;
        newPosition.x += translation.x;
        newPosition.y += translation.y;
    }
}
