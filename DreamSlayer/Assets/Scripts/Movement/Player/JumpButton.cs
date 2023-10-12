using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JumpButton : MonoBehaviour
{
    public PlayerController playerController;

    public void Jump()
    {
        playerController.Jump();
    }
}
