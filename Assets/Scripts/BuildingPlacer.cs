using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Tilemaps;

public class BuildingPlacer : MonoBehaviour
{
    public GameObject buildingPrefab;
    public Tilemap tilemap;
    public TileBase buildableTile;
    private GameObject buildingGhost;
    private SpriteRenderer buildingRenderer;
    private bool isPlacing = false;
    private FogOfWar fogOfWar; // A�adir esta l�nea

    void Start()
    {
        fogOfWar = FindObjectOfType<FogOfWar>(); // A�adir esta l�nea
    }

    void Update()
    {
        // Manejar clics
        if (Input.GetMouseButtonDown(0))
        {
            if (!isPlacing)
            {
                StartPlacingBuilding();
            }
            else
            {
                PlaceBuilding();
            }
        }

        // Mover el fantasma del edificio si est� en modo colocaci�n
        if (isPlacing)
        {
            MoveBuildingGhost();
        }
    }

    private void StartPlacingBuilding()
    {
        isPlacing = true;

        // Crear el fantasma del edificio
        buildingGhost = Instantiate(buildingPrefab);
        buildingRenderer = buildingGhost.GetComponent<SpriteRenderer>();
        buildingGhost.GetComponent<Collider2D>().enabled = false;
        buildingRenderer.color = new Color(1, 1, 1, 0.5f);  // Fantasma 
    }

    private void MoveBuildingGhost()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;
        buildingGhost.transform.position = mousePos;

        // Convertir la posici�n del mouse a la celda del Tilemap
        Vector3Int cellPosition = tilemap.WorldToCell(mousePos);

        // Verificar el tile
        TileBase selectedTile = tilemap.GetTile(cellPosition);

        // Cambiar el color del fantasma
        if (selectedTile == buildableTile)
        {
            buildingRenderer.color = new Color(0, 1, 0, 0.5f);  // Verde valido
        }
        else
        {
            buildingRenderer.color = new Color(1, 0, 0, 0.5f);  // Rojo ocupado
        }
    }

    private void PlaceBuilding()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePos.z = 0;

        Vector3Int cellPosition = tilemap.WorldToCell(mousePos);

        // Verificar si el tile es v�lido
        TileBase selectedTile = tilemap.GetTile(cellPosition);
        if (selectedTile == buildableTile)
        {
            // Posicionar el edificio real en la celda v�lida
            GameObject building = Instantiate(buildingPrefab, tilemap.CellToWorld(cellPosition), Quaternion.identity);
            building.GetComponent<Collider2D>().enabled = true;  // Habilitar el collider del edificio real

            // Despejar la niebla alrededor del edificio
            fogOfWar.RevealFog(cellPosition); // A�adir esta l�nea
        }

        // Destruir el fantasma del edificio
        Destroy(buildingGhost);
        isPlacing = false;
    }
}
