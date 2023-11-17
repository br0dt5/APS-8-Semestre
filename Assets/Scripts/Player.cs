using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using Photon.Pun;

public class Player : MonoBehaviour
{
    public float speed;

    PhotonView view;

    private void Start()
    {
        view = GetComponent<PhotonView>();
    }

    void Update()
    {
        if (view.IsMine)
        {
            Vector3 input = new Vector3(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"), 0);
            transform.position += input.normalized * speed * Time.deltaTime;
        }
    }
}


//[SerializeField] private Tilemap tilemap;

//private List<Vector3Int>? positions;

//private void Awake()
//{

//}

//private List<KeyCode> keys = new List<KeyCode>(){
//        KeyCode.A,
//        KeyCode.W,
//        KeyCode.S,
//        KeyCode.D
//    };

//if (Input.GetMouseButtonDown(0))
//{
//    Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
//    Vector3Int coordinate = tilemap.WorldToCell(mouseWorldPos);
//    Vector3Int tilePosition = new Vector3Int(coordinate.x, coordinate.y, 0);

//    bool interactable = GameManager.instance.tileManager.IsInteractable(tilePosition, "interactable");

//    if (interactable)
//    {
//        GameManager.instance.tileManager.SetInteracted(tilePosition);
//    }

//    // Lógica para interagir com os tiles dinâmicos
//    if (positions != null)
//    {
//        foreach (var posi in positions)
//        {
//            GameManager.instance.tileManager.SetHiddenTile(posi);
//        }
//        positions.Clear();
//    }

//    for (int x = -1; x <= 1; x++)
//    {
//        for (int y = -1; y <= 1; y++)
//        {
//            Vector3Int interactableTilePosi = new Vector3Int(
//                tilePosition.x + x,
//                tilePosition.y + y,
//                0
//            );

//            bool isInteractable = GameManager.instance.tileManager.IsInteractable(
//                interactableTilePosi,
//                "interactable"
//            );

//            if (isInteractable)
//            {
//                GameManager.instance.tileManager.setInteractableTile(interactableTilePosi);
//                positions.Add(interactableTilePosi);
//            }

//        }
//    }
//}
