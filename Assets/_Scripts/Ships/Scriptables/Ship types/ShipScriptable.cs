using UnityEngine;

[CreateAssetMenu(fileName = "Ship", menuName = "ScriptableObjects/Ship properties", order = 0)]
public class ShipScriptable : ScriptableObject
{
    [Header("Custom")]
    [ColorUsage(false, true)] public Color color = Color.white;

    [Header("Parameters")]
    public float speed = 4;
    public float bulletSpeed = 10;
    public float coolDown = 0.1f;

    [Space]
    public int health = 100;

    [Header("Enemy")]
    public Sprite sprite;
    public enum Behaviour { linear, direct, waves, wavesDirect, diagonal, wave8 }
    public Behaviour behaviour;
    public float behaviourMathfSin = 1.5f;
    public enum Attack { continuous, continuousDouble, none }
    public Attack attack;
}