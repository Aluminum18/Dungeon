using Cysharp.Threading.Tasks;
using Cysharp.Threading.Tasks.Linq;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    [Header("Reference - Read")]
    [SerializeField]
    private Vector3Variable _direction;
    [SerializeField]
    private FloatVariable _moveSpeed;
    [SerializeField]
    private FloatVariable _moveSpeedFactor;

    [Header("Configs")]
    [SerializeField]
    private CharacterController _chaCon;

    private CancellationTokenSource _updateToken;

    private async UniTaskVoid DetectMovementInput()
    {
        _updateToken?.Cancel();
        _updateToken = new ();
        await foreach (var _ in UniTaskAsyncEnumerable.EveryUpdate().WithCancellation(_updateToken.Token))
        {
            _chaCon.SimpleMove(_direction.Value * _moveSpeed.Value * _moveSpeedFactor.Value);
        }
    }

    private void OnEnable()
    {
        DetectMovementInput().Forget();
    }

    private void OnDisable()
    {
        _updateToken?.Cancel();
    }


}
