using System;
using UnityEngine;
using UnityEngine.Analytics;
using System.Collections.Generic;


public class TemplateContext {
    public Dictionary<int, MstTM> mst;

    public Dictionary<int, BasesTM> bases;

    public Dictionary<int, HomeTM> homes;

    public Dictionary<int, PlantTM> plants;

    public Dictionary<int, BulletTM> bullets;

    public GameConfigTM gameConfig;

    public TemplateContext() {
        mst = new Dictionary<int, MstTM>();
        bases = new Dictionary<int, BasesTM>();
        homes = new Dictionary<int, HomeTM>();
        plants = new Dictionary<int, PlantTM>();
        bullets = new Dictionary<int, BulletTM>();
    }
}
