// GENERATED AUTOMATICALLY FROM 'Assets/NewInput/InputMaster.inputactions'

using System;
using UnityEngine;
using UnityEngine.Experimental.Input;


[Serializable]
public class InputMaster : InputActionAssetReference
{
    public InputMaster()
    {
    }
    public InputMaster(InputActionAsset asset)
        : base(asset)
    {
    }
    private bool m_Initialized;
    private void Initialize()
    {
        // Player1
        m_Player1 = asset.GetActionMap("Player1");
        m_Player1_Dash = m_Player1.GetAction("Dash");
        m_Player1_Movement = m_Player1.GetAction("Movement");
        m_Player1_Skill = m_Player1.GetAction("Skill");
        m_Player1_MoveUp = m_Player1.GetAction("MoveUp");
        m_Player1_MoveDown = m_Player1.GetAction("MoveDown");
        m_Initialized = true;
    }
    private void Uninitialize()
    {
        m_Player1 = null;
        m_Player1_Dash = null;
        m_Player1_Movement = null;
        m_Player1_Skill = null;
        m_Player1_MoveUp = null;
        m_Player1_MoveDown = null;
        m_Initialized = false;
    }
    public void SetAsset(InputActionAsset newAsset)
    {
        if (newAsset == asset) return;
        if (m_Initialized) Uninitialize();
        asset = newAsset;
    }
    public override void MakePrivateCopyOfActions()
    {
        SetAsset(ScriptableObject.Instantiate(asset));
    }
    // Player1
    private InputActionMap m_Player1;
    private InputAction m_Player1_Dash;
    private InputAction m_Player1_Movement;
    private InputAction m_Player1_Skill;
    private InputAction m_Player1_MoveUp;
    private InputAction m_Player1_MoveDown;
    public struct Player1Actions
    {
        private InputMaster m_Wrapper;
        public Player1Actions(InputMaster wrapper) { m_Wrapper = wrapper; }
        public InputAction @Dash { get { return m_Wrapper.m_Player1_Dash; } }
        public InputAction @Movement { get { return m_Wrapper.m_Player1_Movement; } }
        public InputAction @Skill { get { return m_Wrapper.m_Player1_Skill; } }
        public InputAction @MoveUp { get { return m_Wrapper.m_Player1_MoveUp; } }
        public InputAction @MoveDown { get { return m_Wrapper.m_Player1_MoveDown; } }
        public InputActionMap Get() { return m_Wrapper.m_Player1; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled { get { return Get().enabled; } }
        public InputActionMap Clone() { return Get().Clone(); }
        public static implicit operator InputActionMap(Player1Actions set) { return set.Get(); }
    }
    public Player1Actions @Player1
    {
        get
        {
            if (!m_Initialized) Initialize();
            return new Player1Actions(this);
        }
    }
    private int m_KnMSchemeIndex = -1;
    public InputControlScheme KnMScheme
    {
        get

        {
            if (m_KnMSchemeIndex == -1) m_KnMSchemeIndex = asset.GetControlSchemeIndex("KnM");
            return asset.controlSchemes[m_KnMSchemeIndex];
        }
    }
    private int m_XOnePadSchemeIndex = -1;
    public InputControlScheme XOnePadScheme
    {
        get

        {
            if (m_XOnePadSchemeIndex == -1) m_XOnePadSchemeIndex = asset.GetControlSchemeIndex("XOnePad");
            return asset.controlSchemes[m_XOnePadSchemeIndex];
        }
    }
    private int m_GenericPadSchemeIndex = -1;
    public InputControlScheme GenericPadScheme
    {
        get

        {
            if (m_GenericPadSchemeIndex == -1) m_GenericPadSchemeIndex = asset.GetControlSchemeIndex("GenericPad");
            return asset.controlSchemes[m_GenericPadSchemeIndex];
        }
    }
}
