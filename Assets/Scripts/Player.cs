using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Player : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;

    private List<Vector3Int>? positions;
    
    private void Awake()
    {
        
    }       

    private List<KeyCode> keys = new List<KeyCode>(){
        KeyCode.A,
        KeyCode.W,
        KeyCode.S,
        KeyCode.D
    };

    void Update()
    {        
        
        /*
        if(Input.anyKeyDown)
        {
            Vector3Int playerPosi = tilemap.WorldToCell(transform.position); 
            IsAbleToInteraction(playerPosi);
        }
        */

        //Debug.Log("Posição do player: " + playerPosi);                
        
        
        if (Input.GetMouseButtonDown(0))
        {                                    
            // pegar as coordenadas da posição do player
            // trasnformar essa coordenadas em uma coordenado compatível com grid do tilemap;

            Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3Int coordinate = tilemap.WorldToCell(mouseWorldPos);

            Vector3Int tilePosition = new Vector3Int(coordinate.x, coordinate.y, 0);

            Debug.Log("Posição do tile: " + tilePosition);
            
            bool interactable = GameManager.instance.tileManager.IsInteractable(tilePosition, "interactable");

            if(interactable)
            {
                GameManager.instance.tileManager.SetInteracted(tilePosition);
            }
           
        }
    }

    /*
    void IsAbleToInteraction(Vector3Int position)
    {
        
        if(positions != null)
        {
            foreach(var posi in positions)
            {
                 GameManager.instance.tileManager.SetHiddenTile(posi);
            }
            positions.Clear();
        }
        

        for(int x = -1; x <= 1; x++)
        {
            for(int y = -1; y <= 1; y++)
            {
                //somar com as coordenadas do vector
                Vector3Int interactableTilePosi = new Vector3Int(
                    position.x + x,
                    position.y + y,
                    0
                );
            
                bool interactable = GameManager.instance.tileManager.IsInteractable(
                    position, 
                    "interactable"
                );

                if(interactable)
                {
                    GameManager.instance.tileManager.setInteractableTile(interactableTilePosi);
                    positions.Add(interactableTilePosi);
                }

            }
        }
    }
    */
    
}
