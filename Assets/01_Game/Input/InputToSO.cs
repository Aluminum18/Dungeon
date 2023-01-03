using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static UnityEngine.InputSystem.InputAction;

public class InputToSO : MonoBehaviour
{
    [SerializeField]
    private Vector3Variable _direction;

    private Vector3 bufferVector = Vector3.zero;
    public void UpdateMovementInput(CallbackContext input)
    {
        Vector3 readInput = input.ReadValue<Vector2>();
        bufferVector.x = readInput.x;
        bufferVector.z = readInput.y;
        _direction.Value = bufferVector;
    }
}
