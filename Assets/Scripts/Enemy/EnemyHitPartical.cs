using Unity.VisualScripting;
using UnityEngine;

public class EnemyHitPartical : MonoBehaviour
{
    public ParticleSystem particles;
    
    public void activate(Vector2 hitFrom){
        float angle = Mathf.Rad2Deg * Mathf.Atan2(hitFrom.y, hitFrom.x);
        transform.rotation = Quaternion.Euler(0, 0, angle);
        particles.Play();
    }

    public void Explode(){
        var shape = particles.shape;
            shape.arc = 360f;
            particles.Play();
    }
}
