using System;

namespace fishtank
{
    public class GameEvent
    {
        private event Action Event;

        public void Invoke() => Event?.Invoke();

        public void AddListener(Action listener) => Event += listener;

        public void RemoveListener(Action listener) => Event -= listener;
    }

    public class GameEvent<T>
    {
        private event Action<T> Event;
        
        public void Invoke(T arg) => Event?.Invoke(arg);

        public void AddListener(Action<T> listener) => Event += listener;

        public void RemoveListener(Action<T> listener) => Event -= listener;
    }
    
    public class GameEvent<T1, T2>
    {
        private event Action<T1, T2> Event;
        
        public void Invoke(T1 arg1, T2 arg2) => Event?.Invoke(arg1, arg2);

        public void AddListener(Action<T1, T2> listener) => Event += listener;

        public void RemoveListener(Action<T1, T2> listener) => Event -= listener;
    }
}
