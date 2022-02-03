using UnityEngine;

public class ParticleStart : Singleton<ParticleStart>
{
    public enum ParticleStatus
    {
        ONARA, TOUKAI,JET
    }
    /// <summary>
    /// パーティクルシステムを再生させる
    /// </summary>
    /// <param name="origin">再生させる地点場所</param>
    /// <param name="status">なんの効果か？</param>
    public void StartParticle(Transform origin, ParticleStatus status)
    {
        string name = null;
        switch (status)
        {
            case ParticleStatus.ONARA:
                name = "Onara_Shooting";
                break;
            case ParticleStatus.TOUKAI:
                name = "Cloud_of_Dust";
                break;
            case ParticleStatus.JET:
                name = "playerOnaraJetParticle";
                break;
        }
        origin = Instantiate((GameObject)Resources.Load($"Prefabs/{name}"), origin.transform.position, Quaternion.identity).transform;
        origin.parent = transform;
    }
}
