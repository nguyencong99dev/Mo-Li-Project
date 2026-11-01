using System;
using System.Collections.Generic;

public static class EventBus<T> where T : struct
{
    private static T _lastData;
    private static bool _hasData = false;
    static event Action<T> _onEvent;
    public static void Subscribe(Action<T> listener)
    {
        _onEvent += listener;
        if (_hasData)
        {
            listener?.Invoke(_lastData);
        }
    }
    public static void Unsubscribe(Action<T> listener)
    {
        _onEvent -= listener;
    }
    public static void Publish(T eventData)
    {
        _lastData = eventData;
        _hasData = true;
        _onEvent?.Invoke(eventData);
    }
    public static void Clear()
    {
        _lastData = default;
        _hasData = false;
        _onEvent = null;
    }

}