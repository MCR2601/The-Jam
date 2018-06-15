using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct SimpleCords {

    public int x;
    public int y;
    public int z;

    public SimpleCords(int x, int y)
    {
        this.x = x;
        this.y = y;
        this.z = 0;
    }

    public SimpleCords(int x, int y, int z)
    {
        this.x = x;
        this.y = y;
        this.z = z;
    }

    public SimpleCords(Vector3 vec)
    {
        this.x = (int)vec.x;
        this.y = (int)vec.y;
        this.z = (int)vec.z;
    }

    public static implicit operator Vector3(SimpleCords simple)
    {
        return new Vector3(simple.x,  simple.z, simple.y);
    }

    public static implicit operator SimpleCords(Vector3 vec)
    {
        return new SimpleCords((int)vec.x,  (int)vec.z, (int)vec.y);
    }

    public SimpleCords Offset(int x, int y, int z)
    {
        return new SimpleCords(this.x + x, this.y + y, this.z + z);
    }

    public static SimpleCords operator +(SimpleCords a, SimpleCords b)
    {
        return new SimpleCords(a.x + b.x, a.y + b.y, a.z + b.z);
    }

    public static SimpleCords operator -(SimpleCords a, SimpleCords b)
    {
        return new SimpleCords(a.x - b.x, a.y - b.y, a.z - b.z);
    }
    
}
