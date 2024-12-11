using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Move : MonoBehaviour
{
    public void Moving(float moveSpeed, float direction)
    {
        transform.position = (transform.position + transform.forward * (direction * moveSpeed) * Time.deltaTime);
    }
}
