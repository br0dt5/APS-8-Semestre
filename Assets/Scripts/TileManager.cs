using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Tilemaps;

public class TileManager : MonoBehaviour
{
    [SerializeField] private Tilemap interactableMap;
    [SerializeField] private Tile hiddenInteractableTile;
    [SerializeField] private Tile interactableTile;
    [SerializeField] private Tile interactedTile;
    
    void Start()
    {        
        foreach(var position in interactableMap.cellBounds.allPositionsWithin)
        {     
            bool interactable = IsInteractable(position, "interactable-visible");
            if(interactable)
            {
                SetHiddenTile(position);
            }
        }                
    }

    public Tilemap CurrentTileMap()
    {
        return interactableMap;
    }

    public bool IsInteractable(Vector3Int position, string objectName)
    {
        TileBase tile = interactableMap.GetTile(position);
        if(tile != null)
        {
            if(tile.name == objectName)
            {             
                return true;                 
            }
        }
        return false;
    }

 
    void Update()
    {
        
    }

    public void setInteractableTile(Vector3Int position)
    {
        interactableMap.SetTile(position, interactableTile);
    }
    public void SetHiddenTile(Vector3Int position)
    {
        interactableMap.SetTile(position, hiddenInteractableTile);
    }
    public void SetInteracted(Vector3Int position)
    {
        interactableMap.SetTile(position, interactedTile);
    }
}
