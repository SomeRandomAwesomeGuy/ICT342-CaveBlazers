using UnityEngine;
using System.Collections;
using System;

/// <summary>
/// GenericWandEventModule is used to send generic inputs to Unity UI.
/// </summary>
/// <remarks>
/// A generic PlayerInputs must be set in order for this class to retrieve the submit button.
/// This is usually set via the VRToolkitChoice script.
/// </remarks>
public class GenericWandEventModule : WandEventModuleBase {

    public PlayerInputs playerInputs {
        get { return m_playerInputs; }
        set { m_playerInputs = value; }
    }

    private PlayerInputs m_playerInputs;

    protected override bool GetSubmitButtonDown()
    {
        return playerInputs != null ? playerInputs.WandButtonDown : false;
    }

    protected override bool GetSubmitButtonUp()
    {
        return playerInputs != null ? playerInputs.WandButtonUp : false;
    }
}
