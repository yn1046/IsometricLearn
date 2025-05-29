using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacterController : CharacterController
{
    private Vector2 GetMovementInput()
    {
        int x = 0, y = 0;
        if (Input.GetKey(KeyCode.W))
        {
            y++;
        }
        if (Input.GetKey(KeyCode.A))
        {
            x--;
        }
        if (Input.GetKey(KeyCode.S))
        {
            y--;
        }
        if (Input.GetKey(KeyCode.D))
        {
            x++;
        }

        return new Vector2(x, y);
    }

    protected override void ProcessInput(Character target)
    {
        target.Move(GetMovementInput());
        if (Input.GetKey(KeyCode.Mouse0))
        {
            target.Attack();
        }
    }

    public void Awake()
    {
        Game.Instance.Player.AttachCharacter(this);
    }
}
