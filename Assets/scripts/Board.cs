using UnityEngine;
using UnityEngine.Tilemaps;

public class Board : MonoBehaviour
{
    public Tilemap tilemap { get; private set; }
    public Piece ActivePiece { get; private set; }
    public TetraminoData[] Tetrominos;
    public Vector3Int SpawnPosition;
    public Vector2Int BoardSize = new Vector2Int(10, 20);
    public RectInt Bounds 
    {
        get 
        {
            Vector2Int position = new Vector2Int(-this.BoardSize.x / 2, -this.BoardSize.y / 2);
            return new RectInt(position, this.BoardSize);
        }
    }

    private void Awake()
    {
        this.tilemap = GetComponentInChildren<Tilemap>();
        for (int i = 0; i < Tetrominos.Length; i++)
        {
            this.Tetrominos[i].Initialize();
        }
    }

    private void Start()
    {
        SpawnPiece();
    }

    public void SpawnPiece()
    {
        int random = Random.Range(0, this.Tetrominos.Length);
        TetraminoData data = this.Tetrominos[random];
        ActivePiece.Initialize(this, SpawnPosition, data);
        Set(ActivePiece);
    }

    public void Set(Piece piece)
    {
        for (int i = 0; i < piece.Cells.Length; i++)
        {
            Vector3Int tilePosition = piece.Cells[i] + piece.Position;
            tilemap.SetTile(tilePosition, piece.Data.tile);
        }
    }

    public bool IsValidPosition(Piece piece, Vector3Int position)
    {
        for (int i = 0; i < piece.Cells.Length; i++)
        {
            Vector3Int tilePosition = piece.Cells[i] + position;
            if (!Bounds.Contains((Vector2Int)tilePosition))
            {
                return false;
            }

            if (this.tilemap.HasTile(tilePosition))
            {
                return false;
            }
        }
        return true;
    }
}
