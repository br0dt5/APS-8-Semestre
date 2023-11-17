using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform target;

    private Vector3 camOffset;

    void Start()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        if (player != null)
        {
            SetTarget(player.transform);
        }
        else
        {
            Debug.LogWarning("Player n�o encontrado para a c�mera seguir.");
        }

        if (target != null)
        {
            camOffset = transform.position - target.position;
        }
    }


    void FixedUpdate()
    {
        if (target != null)
        {
            transform.position = target.position + camOffset;
        }
    }

    // M�todo para definir o alvo da c�mera
    public void SetTarget(Transform newTarget)
    {
        target = newTarget;
        camOffset = transform.position - target.position;
    }
}
