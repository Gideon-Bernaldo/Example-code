using System;
using UnityEngine;

namespace PixKeeper.Events
{
    public class EventsOfWorld
    {
        public static event Action<int, int> setCorrectHealth, setCorrectLevel;
        public static event Action<int> setCorrectArmor;

        public static void OnSetCorrectHealth(int value, int maxValue) => setCorrectHealth?.Invoke(value, maxValue);
        public static void OnSetCorrectLevel(int value, int maxValue) => setCorrectLevel?.Invoke(value, maxValue);
        public static void OnSetCorrectArmor(int value) => setCorrectArmor?.Invoke(value);

        public static event Action<int> playLevelUp;
        public static event Action<int> LevelScore;

        public static void OnPlayLevelUp(int level) => playLevelUp?.Invoke(level);
        public static void AddLevelScore(int score) => LevelScore?.Invoke(score);

        public static event Action<bool> satDown;

        public static void OnSatDown(bool status) => satDown?.Invoke(status);
    }

    public class EventsOfMouse
    {
        public static event Action<Vector3, bool> goalAccessStatus;

        public static void OnGoalAccessStatus(Vector3 pos, bool status) => goalAccessStatus?.Invoke(pos, status);
    }
}

