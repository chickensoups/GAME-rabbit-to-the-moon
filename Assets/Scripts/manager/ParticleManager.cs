using UnityEngine;

public class ParticleManager : MySingleton<ParticleManager>
{

    public GameObject bombNormalParticle;
    public GameObject bombShooterParticle;
    public GameObject bombWaveParticle;
    public GameObject bombTargetParticle;
    public GameObject bombAcidParticle;
    public GameObject wallNormalParticle;
    public GameObject wallContraryParticle;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private GameObject getParticle(Constants.ResourcesName name)
    {
        switch(name)
        {
            case Constants.ResourcesName.bombNormal:
                return bombNormalParticle;
            case Constants.ResourcesName.bombShooter:
                return bombShooterParticle;
            case Constants.ResourcesName.bombWave:
                return bombWaveParticle;
            case Constants.ResourcesName.bombTarget:
                return bombTargetParticle;
            case Constants.ResourcesName.bombAcid:
                return bombAcidParticle;
            case Constants.ResourcesName.wallNormal:
                return wallNormalParticle;
            case Constants.ResourcesName.wallContrary:
                return wallContraryParticle;
            default:
                return bombNormalParticle;
        }
    }

    public void playParticle(Constants.ResourcesName name, Vector3 position)
    {
        GameObject particle = Instantiate(getParticle(name), position, Quaternion.identity);
    }
}
