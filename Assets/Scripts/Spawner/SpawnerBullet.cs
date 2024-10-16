public class SpawnerBullet : Spawner<Bullet>
{
    protected override void ActivateInstance(Bullet bullet)
    {
        bullet.transform.rotation = Rotation;
        bullet.Removed += ReleaseInstance;
        base.ActivateInstance(bullet);
    }

    protected override void ReleaseInstance(Bullet bullet)
    {
        bullet.Removed -= ReleaseInstance;
        base.ReleaseInstance(bullet);
    }
}