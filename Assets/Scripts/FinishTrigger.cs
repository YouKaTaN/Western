using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]

public class FinishTrigger : MonoBehaviour
{
    public static Action PlayerFinished;

    [SerializeField] private BoxCollider finishLine;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Player>())
        {
            PlayerFinished?.Invoke();
        }
    }
}
