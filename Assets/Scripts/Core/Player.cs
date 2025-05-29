using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private PlayerCharacterController _characterController;
    public PlayerCharacterController CharacterController { get { return _characterController; } }
    public Character PlayerCharacter { get { return _characterController.ControlledTarget; } }

    public void AttachCharacter(PlayerCharacterController characterController)
    {
        _characterController = characterController;
    }
}

public enum Team
{
    Humans = 1,
    EnemyBots = 2,
}
