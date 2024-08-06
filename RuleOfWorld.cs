using System;
using UnityEngine;
using Unity.Mathematics;

namespace PixKeeper
{
    /// <summary>
    /// �������� �� �������� ��������, ������ � ���������.
    /// �� ������ ����� ������������� ����������� ��� �������
    /// </summary>
    public class RuleOfWorld : MonoBehaviour
    {
        /// ��-��, � ������ ��� ������� ���� ���������. ���� ������ �� ����������� ���������� ������. � ��� ������ ������.
        /// � ������ ������� ����� ���� ���������.

        /// <summary>
        /// ���������� ����� ��� ������ (int)/ ����� �� �������� ������� (bool)
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
                var requiredExp = Mathf.CeilToInt(100 * Mathf.Pow(1.25f, level)); // ����������� ���-�� ����� ��� ������ "level"
                return typeof(T) == typeof(int) ? (T)(object)requiredExp : (T)(object)(exp >= requiredExp);
            }
            catch
            {
                throw new InvalidOperationException($"���������������� ��� ������������� ��������: {typeof(T)}. �������������� ������ int ��� bool. ������ ��� �� �����, ����");
            }
        }

        /// ������� ��� ��������� ����.
        /// ��� ���� ��� �����, ����� �������� ������ ��� ������� ���������� � ������ �, � ��� ��� ��� ������, ����� ������� � ����������� � ��� �����. ����.

        /// <summary>
        /// ���� ������� ����� ����� ������� �� ������
        /// </summary>
        /// <param name="value_1"></param>
        /// <param name="value_2"></param>
        /// <returns></returns>
        public int CalculateDifference(int value_1, int value_2) => math.abs(value_1 - value_2);
        /// <summary>
        /// ���� ������� ���������
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <returns></returns>
        public float SqrDistance(Vector3 vector1, Vector3 vector2) => (vector1 - vector2).sqrMagnitude;
        /// <summary>
        /// ���� ������� ���������
        /// </summary>
        /// <param name="vector1"></param>
        /// <param name="vector2"></param>
        /// <returns></returns>
        public float SqrDistance(Transform vector1, Transform vector2) => (vector1.position - vector2.position).sqrMagnitude;
        /// <summary>
        /// ������� ���� �����
        /// </summary>
        /// <param name="number"></param>
        /// <returns></returns>
        public float SqrNumber(float number) => number * number;
        /// <summary>
        /// ������� ����� ����� ������� ��������� � ������������ ���������, ������� �� � �������
        /// </summary>
        /// <param name="sqrDistance"></param>
        /// <param name="maxDistance"></param>
        /// <returns></returns>
        public bool CheckDistanceSqr(float sqrDistance, float maxDistance) => sqrDistance <= SqrNumber(maxDistance);
    }
}
