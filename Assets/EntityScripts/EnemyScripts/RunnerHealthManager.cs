using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RunnerHealthManager : HealthManager {
    public Light createLight;
    protected override void deathAction()
    {
        Light light = Instantiate(createLight, transform.position, transform.rotation);
        light.transform.SetParent(null);
        base.deathAction();
    }
}
