using UnityEngine;

[CreateAssetMenu(fileName = "PowerUp", menuName = "Scriptable Objects/PowerUp")]
public class PowerUp : ScriptableObject
{
    [SerializeField] string powerupType;
    [SerializeField] float valueChange;
    [SerializeField] float time;

    public string GetPowerUpType()
    {
        return powerupType;
    }
    public float GetValueChange()
    {
        return valueChange;
    }
    public float GetTime()
    {
        return time;
    }
}
