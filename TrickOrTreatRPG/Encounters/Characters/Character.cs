﻿namespace TrickOrTreatRPG;

public class Character : ThingToEncounter
{
    public string Name;

    public virtual string Approach()
    {
       throw new NotImplementedException();
    }

    public virtual void React()
    {

    }
}