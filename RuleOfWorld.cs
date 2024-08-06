using System;
using UnityEngine;
using Unity.Mathematics;

namespace PixKeeper
{
    /// <summary>
    /// Отвечает за ключевые подсчеты, поиски и сравнения.
    /// От правил будут наследоваться практически все объекты
    /// </summary>
    public class RuleOfWorld : MonoBehaviour
    {
        /// Да-да, я просто так засунул сюда обобщение. Пушт раньше не использовал обобщенные методы. И вот теперь заюзал.
        /// С другой стороны вышло даже прикольно.

        /// <summary>
        /// Количество опыта для уровня (int)/ можем ли получить уровень (bool)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="exp"></param>
        /// <param name="level"></param>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public T CheckLevel<T>(int exp, int level) 
        {
            try
            {
                var requiredExp = Mathf.CeilToInt(100 * Mathf.Pow(1.25f, level)); // необходимое кол-во опыта для уровня "level"
                return typeof(T) == typeof(int) ? (T)(object)requiredExp : (T)(object)(exp >= requiredExp);
            }
            catch
            {
                throw new InvalidOperationException($"Неподдерживаемый тип возвращаемого значения: {typeof(T)}. Поддерживаются только int или bool. Больше так не делай, дядь");
            }
        }

        /// Решения для упрощения кода.
        /// Для меня так проще, можно случайно забыть про квадрат расстояния и прочее Г, а это тот еще геммор, когда хочется в оптимизацию и без жуков. имхо.

        /// <summary>
        /// Ищем разницу между двумя числами по модулю
        /// </summary>
        /// <param name="value_1"></param>
        /// <param name="value_2"></param>
        /// <returns></returns>
        public int CalculateDifference(int value_1, int value_2) => math.abs(value_1 - value_2);
        /// <summary>
        /// Ищем квадрат дистанции
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <returns></returns>
        public float SqrDistance(Vector3 vector1, Vector3 vector2) => (vector1 - vector2).sqrMagnitude;
        /// <summary>
        /// Ищем квадрат дистанции
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <returns></returns>
        public float SqrDistance(Transform vector1, Transform vector2) => (vector1.position - vector2.position).sqrMagnitude;
        /// <summary>
        /// Квадрат двух чисел
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public float SqrNumber(float number) => number * number;
        /// <summary>
        /// Сверяем между собой квадрат дистанции и максимальную дистанцию, возводя ее в квадрат
        /// </summary>
        /// <param name="sqrDistance"></param>
        /// <param name="maxDistance"></param>
        /// <returns></returns>
        public bool CheckDistanceSqr(float sqrDistance, float maxDistance) => sqrDistance <= SqrNumber(maxDistance);
    }
}
