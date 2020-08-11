using UnityEngine;

public class EnemyHealth : Health
{
    
	// protected override void Start()
    // {
    //     base.Start();
    // }

    public override void Death()
    {
        Destroy(this.gameObject, 2f);
        base.Death();
    }

    
}
