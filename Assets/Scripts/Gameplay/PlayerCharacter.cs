using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Character
{
    public override void Move(Vector2 movementVector)
    {
        var camera = Camera.main;
        var fw = camera.transform.forward;
        var forward = new Vector3(fw.x, 0, fw.y).normalized;
        var rt = camera.transform.right;
        var right = new Vector3(rt.x, 0, rt.y).normalized;

        var deltaMove = movementVector.x * right - movementVector.y * forward;
        deltaMove *= Time.fixedDeltaTime * _stats.Speed;
        _rigidBody.MovePosition(transform.position + deltaMove);

        transform.LookAt(transform.position + deltaMove);
    }
}
