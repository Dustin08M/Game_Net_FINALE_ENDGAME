using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnetCoin : MonoBehaviour
{
    [SerializeField] private float MagnetRange = 25f;
    [SerializeField] private float MagnetStrength = 5f;

    private void FixedUpdate()
    {
        Collider[] collider = Physics.OverlapSphere(transform.position, MagnetRange);
        foreach (Collider coins in collider)
        {
            if (coins.CompareTag("Coin"))
            {
                Vector3 forceDirection = transform.position - coins.transform.position;
                coins.GetComponent<Rigidbody>().AddForce(forceDirection.normalized * MagnetStrength);
            }
        }
    }
}
