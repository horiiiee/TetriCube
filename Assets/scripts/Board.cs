using UnityEngine;
using UnityEngine.Tilemaps;

public class Board : MonoBehaviour
{
    public Tilemap tilemap { get; private set; }
    public Piece ActivePiece { get; private set; }
    public TetraminoData[] Tetrominos;
    public Vector3Int SpawnPosition;

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
        ActivePiece = GetComponentInChildren<Piece>();
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
}
