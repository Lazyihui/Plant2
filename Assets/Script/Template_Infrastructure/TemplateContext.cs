using System;
using UnityEngine;
using UnityEngine.Analytics;
using System.Collections.Generic;


public class TemplateContext {
    public Dictionary<int, MstTM> mst;


    public TemplateContext() {
        mst = new Dictionary<int, MstTM>();
    }
}
