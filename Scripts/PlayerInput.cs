using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public enum ActionEventType
{
    Performed,
    Cancelled,
    Started
}

public class PlayerInput : MonoBehaviour
{
    public InputActionAsset actionAsset;
    public string defaultMap = "PlayerControl";

    public void RegisterBind(Action<InputAction.CallbackContext> method, string bindName, ActionEventType eventType)
    {
        InputAction action = actionAsset.FindActionMap(defaultMap).FindAction(bindName);

        switch (eventType)
        {
            case ActionEventType.Performed:
                action.performed += method;
                break;
            case ActionEventType.Cancelled:
                action.canceled += method;
                break;
            case ActionEventType.Started:
                action.started += method;
                break;
            default:
                action.performed += method;
                break;
        }

        action.Enable();
    }

    public void UnregisterBind(Action<InputAction.CallbackContext> method, string bindName, ActionEventType eventType)
    {
        InputAction action = actionAsset.FindActionMap(defaultMap).FindAction(bindName);

        switch (eventType)
        {
            case ActionEventType.Performed:
                action.performed -= method;
                break;
            case ActionEventType.Cancelled:
                action.canceled -= method;
                break;
            case ActionEventType.Started:
                action.started -= method;
                break;
            default:
                Debug.Log("Something went wrong with unbinding the method to the action " + bindName, gameObject);
                break;
        }
    }

    public void CreateAction(Action<InputAction.CallbackContext> method, string actionName, InputActionType actionType)
    {
        InputActionMap map = actionAsset.FindActionMap(defaultMap);
        InputAction newAction = map.AddAction(actionName, actionType);
        newAction.AddBinding();
    }
}
