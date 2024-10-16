public class SpawnerExplosion : Spawner<Explosion>
{
    protected override void ActivateInstance(Explosion explosion)
    {
        explosion.Removed += ReleaseInstance;
        base.ActivateInstance(explosion);
    }

    protected override void ReleaseInstance(Explosion explosion)
    {
        explosion.Removed -= ReleaseInstance;
        base.ReleaseInstance(explosion);
    }
}