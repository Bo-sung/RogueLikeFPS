using System.Collections.Generic;
using Unity.FPS.Game;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Events;
using Unity.FPS.Data;
using Unity.FPS.Gameplay;

namespace Unity.FPS
{
    public class IController
    {
        Health m_Health;
        PlayerInputHandler m_InputHandler;
        PlayerWeaponsManager m_WeaponsManager;
        Actor m_Actor;
    }
}
