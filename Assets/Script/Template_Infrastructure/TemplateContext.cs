using System;
using UnityEngine;
using UnityEngine.Analytics;
using System.Collections.Generic;


public class TemplateContext {
    public Dictionary<int, MstTM> mst;

    public Dictionary<int, BasesTM> bases;

    public Dictionary<int, HomeTM> homes;


    public TemplateContext() {
        mst = new Dictionary<int, MstTM>();
        bases = new Dictionary<int, BasesTM>();
        homes = new Dictionary<int, HomeTM>();
    }
}
