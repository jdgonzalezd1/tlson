using UnityEngine;
using UnityEngine.Tilemaps;

public class FogOfWar : MonoBehaviour
{
    public Tilemap fogTilemap; // Tilemap de la niebla
    public TileBase fogTile; // Tile de niebla
    public TileBase buildableTile; // Tile construible
    public int revealRadius = 2; // Radio de despeje alrededor del edificio

    private void Start()
    {
        // Rellenar el Tilemap de niebla al inicio
        foreach (var position in fogTilemap.cellBounds.allPositionsWithin)
        {
            if (fogTilemap.HasTile(position))
            {
                fogTilemap.SetTile(position, fogTile);
            }
        }
    }

    public void RevealFog(Vector3Int position)
    {
        for (int x = -revealRadius; x <= revealRadius; x++)
        {
            for (int y = -revealRadius; y <= revealRadius; y++)
            {
                Vector3Int tilePosition = new Vector3Int(position.x + x, position.y + y, position.z);
                if (fogTilemap.HasTile(tilePosition) && fogTilemap.GetTile(tilePosition) == fogTile)
                {
                    fogTilemap.SetTile(tilePosition, null); // Despejar la niebla
                }
            }
        }
    }
}
