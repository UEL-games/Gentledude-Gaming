﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attribution : Entity {

	public enum Attributes
    {
        None,
        Succubus,
        Ogre,
        Goblin,
        Demon
    }

    public Attributes myAttribute;

    virtual public void Update()
    {
        if (GameManager.instance.PixelMode) return;
    }
}
