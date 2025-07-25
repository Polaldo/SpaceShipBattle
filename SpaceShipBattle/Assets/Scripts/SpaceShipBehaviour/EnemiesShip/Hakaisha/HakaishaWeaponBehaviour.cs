using UnityEngine;

public class HakaishaWeaponBehaviour : EnemyWeaponBehaviour
{
    public Transform[] spawnPoints;

    public override void Shoot()
    {
        if (ApplyFireRate())
        {
            for (int i = 0; i < spawnPoints.Length; i++)
            {
                GameObject tempBullet = GameObject.Instantiate(weaponData.bullet);
                if (tempBullet != null)
                {
                    SetBulletData(tempBullet, PlayerManager.Instance.GetPlayer().transform.position, spawnPoints[i].position);
                    AudioManager.instance.PlayOneShot(weaponData.sfxBullet);
                }
            }
            time = 0;
        }
    }
}
