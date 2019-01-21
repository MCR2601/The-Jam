using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct SimpleCords {

    public int x;
    public int y;
    public int h;

    public SimpleCords(int x, int y)
    {
        this.x = x;
        this.y = y;
        this.h = 0;
    }

    public SimpleCords(int x, int y, int h)
    {
        this.x = x;
        this.y = y;
        this.h = h;
    }

    public SimpleCords(SimpleCords cords)
    {
        this.x = cords.x;
        this.y = cords.y;
        this.h = cords.h;
    }


    public static implicit operator Vector3(SimpleCords simple)
    {
        return new Vector3(simple.x,  simple.h, simple.y);
    }

    public static implicit operator SimpleCords(Vector3 vec)
    {
        return new SimpleCords((int)vec.x,  (int)vec.z, (int)vec.y);
    }

    public SimpleCords Offset(int x, int y, int h)
    {
        this.x += x;
        this.y += y;
        this.h += h;
        return this;
    }

    public static SimpleCords operator +(SimpleCords a, SimpleCords b)
    {
        return new SimpleCords(a.x + b.x, a.y + b.y, a.h + b.h);
    }

    public static SimpleCords operator -(SimpleCords a, SimpleCords b)
    {
        return new SimpleCords(a.x - b.x, a.y - b.y, a.h - b.h);
    }

    public SimpleCords GetAbove(int height = 1)
    {
        return new SimpleCords(x, y, h + height);
    }
    public SimpleCords GetBelow(int height = 1)
    {
        return new SimpleCords(x, y, h - height);
    }


    public SimpleCords GetInDirection(Direction dir, int distance = 1)
    {
        switch (dir)
        {
            case Direction.North:
                return new SimpleCords(this).Offset(0, distance, 0);
            case Direction.East:
                return new SimpleCords(this).Offset(distance, 0, 0);
            case Direction.South:
                return new SimpleCords(this).Offset(0, -distance, 0);
            case Direction.West:
                return new SimpleCords(this).Offset(-distance, 0, 0);
            default:
                return new SimpleCords(this).Offset(0, 0, 0);
        }
    }

    public override bool Equals(object obj)
    {
        if (!(obj is SimpleCords))
        {
            return false;
        }

        var cords = (SimpleCords)obj;
        return x == cords.x &&
               y == cords.y &&
               h == cords.h;
    }

    public override int GetHashCode()
    {
        var hashCode = 71122146;
        hashCode = hashCode * -1521134295 + x.GetHashCode();
        hashCode = hashCode * -1521134295 + y.GetHashCode();
        hashCode = hashCode * -1521134295 + h.GetHashCode();
        return hashCode;
    }

    public static bool operator ==(SimpleCords a, SimpleCords b)
    {
        if (a.x != b.x)
        {
            return false;
        }
        if (a.y != b.y)
        {
            return false;
        }
        if (a.h != b.h)
        {
            return false;
        }

        return true;
    }
    public static bool operator !=(SimpleCords a, SimpleCords b)
    {
        if (a.x != b.x)
        {
            return true;
        }
        if (a.y != b.y)
        {
            return true;
        }
        if (a.h != b.h)
        {
            return true;
        }

        return false;
    }
    /// <summary>
    /// this methode returns the direction towards a different <see cref="SimpleCords"/>
    /// </summary>
    /// <param name="other">The other cord</param>
    /// <returns>Direction to that other <see cref="SimpleCords"/></returns>
    public Direction GetDirectionTo(SimpleCords other)
    {
        SimpleCords vector = other - this;

        float angle = (Mathf.Atan2(vector.y, vector.x) + (2 * Mathf.PI)) % (2 * Mathf.PI);

        if (angle < Mathf.PI/4 || angle > Mathf.PI/4 * 7)
        {
            return Direction.East;
        }
        if (angle > Mathf.PI/4 && angle < Mathf.PI/4 * 3)
        {
            return Direction.North;
        }
        if (angle > Mathf.PI/4 * 3 && angle < Mathf.PI/4 * 5)
        {
            return Direction.West;
        }
        if (angle > Mathf.PI/4 * 5 && angle < Mathf.PI/4 * 7)
        {
            return Direction.South;
        }
        return Direction.North;
    }

    public override string ToString()
    {
        return "{"+x+","+y+","+h+"}";
    }

}
