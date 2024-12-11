using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBehaviour : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 500;
    [SerializeField] private GameObject Ship;
    Move move;
    private void Start()
    {
        move = GetComponent<Move>();

    }
    void Update()
    {
        move.Moving(moveSpeed,1f);
    }
}
