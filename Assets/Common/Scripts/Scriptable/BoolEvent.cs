using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

/// <summary>
/// IntEvent - A simple observer pattern implementation using ScriptableObject.
/// </summary>
[CreateAssetMenu(menuName = "Events/Bool Event")]
public class BoolEvent : ScriptableObjectBase
{
    // Unity Actions allow you to dynamically call multiple functions.
    // They are a simple way to implement delegates in scripting without
    // needing to explicitly define them.
    public UnityAction<bool> OnEventRaised;

    /// <summary>
    /// Raises the event with the specified integer value.
    /// </summary>
    /// <param name="value">The boolean value to pass to subscribers.</param>
    public void RaiseEvent(bool value)
    {
        OnEventRaised?.Invoke(value);
    }

    /// <summary>
    /// Subscribes an object to the event.
    /// </summary>
    /// <param name="listener">The object that wants to subscribe.</param>
    public void Subscribe(UnityAction<bool> listener)
    {
        OnEventRaised += listener;
    }

    /// <summary>
    /// Unsubscribes an object from the event.
    /// </summary>
    /// <param name="listener">The object that wants to unsubscribe.</param>
    public void Unsubscribe(UnityAction<bool> listener)
    {
        OnEventRaised -= listener;
    }
}
