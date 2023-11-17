using System.Collections;
using System.Collections.Generic;

using UnityEngine.Tilemaps;
using UnityEngine;

public class InteractableTile : MonoBehaviour
{
    public Tilemap tilemap;
     public TileBase tileIndicadorInteracao;
    public int alcanceInteracao = 1;    
    
    void Update()
    {
        // Obtém a posição atual do personagem no tilemap
        Vector3Int posicaoPersonagem = tilemap.WorldToCell(transform.position);

        // Itera sobre as células ao redor do personagem
        for (int x = -alcanceInteracao; x <= alcanceInteracao; x++)
        {
            for (int y = -alcanceInteracao; y <= alcanceInteracao; y++)
            {
                // Calcula a posição do tile adjacente
                Vector3Int posicaoAdjacente = new Vector3Int(posicaoPersonagem.x + x, posicaoPersonagem.y + y, posicaoPersonagem.z);

                // Verifica se a célula está dentro do alcance
                if (Vector3Int.Distance(posicaoPersonagem, posicaoAdjacente) <= alcanceInteracao)
                {
                    // Obtém o tile atual na posição
                    TileBase tileAtual = tilemap.GetTile(posicaoAdjacente);

                    // Verifica se o tile é válido e não está bloqueado por outros elementos do jogo
                    if (tileAtual != null && PodeInteragirComTile(posicaoAdjacente))
                    {
                        // Define o novo tile indicador de interação
                        tilemap.SetTile(posicaoAdjacente, tileIndicadorInteracao);
                    }
                }
            }
        }
    }

     bool PodeInteragirComTile(Vector3Int posicaoTile)
    {
        // Adicione aqui lógica adicional conforme necessário
        // Por exemplo, verifique se o tile não está bloqueado por obstáculos ou outros elementos do jogo

        return true; // Retorna true se for possível interagir com o tile na posição especificada
    }
}
