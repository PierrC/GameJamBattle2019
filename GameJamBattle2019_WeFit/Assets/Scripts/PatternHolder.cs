using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PatternHolder
{
    /* -1 => {0,1,2}
     * -2 => {3,4,5}
     * -3 => {0,1,2,3,4,5}
     */ 
    public static SortedList<float, int[]> easy1 = new SortedList<float, int[]>()
    {
        {0.5f, new int [2] {3,4}},
        {1f, new int [0] {}},
        {1.5f, new int [3] {1,2,3}},
        {2f, new int [0] {}},
        {2.5f, new int [3] {1,4,5}},
    };
    public static SortedList<float, int[]> easy2 = new SortedList<float, int[]>()
    {
        {0.5f, new int [0] {}},
        {1f, new int [3] {0,3,5}},
        {1.5f, new int [0] {}},
        {2f, new int [2] {1,4}},
        {2.5f, new int [0] {}},
    };
    public static SortedList<float, int[]> easy3 = new SortedList<float, int[]>()
    {
        {0.5f, new int [3] {0,1,2}},
        {1f, new int [0] {}},
        {1.5f, new int [3] {3,4,5}},
        {2f, new int [0] {}},
        {2.5f, new int [2] {2,5}},
    };
    public static SortedList<float, int[]> easy4 = new SortedList<float, int[]>()
    {
        {0.5f, new int [3] {0,1,5}},
        {1f, new int [2] {0,1}},
        {1.5f, new int [0] {}},
        {2f, new int [3] {0,1,3}},
        {2.5f, new int [1] {3}},
    };
    public static SortedList<float, int[]> easy5 = new SortedList<float, int[]>()
    {
        {0.5f, new int [2] {1,4}},
        {1f, new int [3] {0,4,5}},
        {1.5f, new int [3] {1,3,4}},
        {2f, new int [3] {0,2,4}},
        {2.5f, new int [4] {1,3,4,5}},
    };

    public static SortedList<float, int[]> medium1 = new SortedList<float, int[]>()
    {
        {0.5f, new int [3] {0,1,2}},
        {1f, new int [3] {0,1,2}},

        {1.5f, new int [3] {1,2,5}},
        {2f, new int [3] {1,2,5}},

        {2.5f, new int [3] {2,5,4}},
        {3f, new int [3] {2,5,4}},

        {3.5f, new int [3] {5,4,3}},
        {4f, new int [3] {3,4,5}},

        {4.5f, new int [3] {4,3,0}},
        {5f, new int [3] {4,3,0}},

        {5.5f, new int [3] {3,0,1}},
        {6f, new int [3] {3,0,1}},
    };

    public static SortedList<float, int[]> medium2 = new SortedList<float, int[]>()
    {
        {0.5f, new int [3] {0,4,2}},
        {1f, new int [3] {3,1,5}},

        {1.5f, new int [3] {0,4,2}},
        {2f, new int [3] {3,1,5}},

        {2.5f, new int [3] {0,4,2}},
        {3f, new int [3] {3,1,5}},

        {3.5f, new int [3] {0,4,2}},
        {4f, new int [3] {3,1,5}},

        {4.5f, new int [3] {0,4,2}},
        {5f, new int [3] {3,1,5}},

        {5.5f, new int [3] {0,4,2}},
        {6f, new int [3] {3,1,5}},
    };

    public static SortedList<float, int[]> medium3 = new SortedList<float, int[]>()
    {
        {0.5f, new int [3] {0,1,2}},
        {1f, new int [3] {3,4,5}},
        {1.5f, new int [3] {0,1,2}},
        {2f, new int [3] {3,4,5}},
        {2.5f, new int [3] {0,1,2}},
        {3f, new int [3] {3,4,5}},
        {3.5f, new int [3] {0,1,2}},
        {4f, new int [3] {3,4,5}},

    };
    
    /* -1 => {0,1,2}
     * -2 => {3,4,5}
     * -3 => {0,1,2,3,4,5}
     */

    public static SortedList<float, int[]> Hard1 = new SortedList<float, int[]>()
    {
        {0.5f, new int [4] {0,1,2, -2}},
        {1f, new int [4] {3,4,5, -1}},
        {1.5f, new int [4] {0,1,2, -2}},
        {2f, new int [4] {3,4,5, -1}},
        {2.5f, new int [4] {0,1,2, -2}},
        {3f, new int [4] {3,4,5, -1}},
        {3.5f, new int [4] {0,1,2, -2}},
        {4f, new int [4] {3,4,5, -1}},
        {4.5f, new int [4] {0,1,2, -2}},
        {5f, new int [4] {3,4,5, -1}},
    };

    public static SortedList<float, int[]> VeryHard = new SortedList<float, int[]>()
    {
        {0.5f, new int [5] {0,1,2, -2, -2}},
        {1f, new int [5] {3,4,5, -1, -1}},
        {1.5f, new int [5] {0,1,2, -2, -2}},
        {2f, new int [5] {3,4,5, -1, -1}},
        {2.5f, new int [5] {0,1,2, -2, -2}},
        {3f, new int [5] {3,4,5, -1, -1}},
        {3.5f, new int [5] {0,1,2, -2, -2}},
        {4f, new int [5] {3,4,5, -1, -1}},
        {4.5f, new int [5] {0,1,2, -2, -2}},
        {5f, new int [5] {3,4,5, -1, -1}},
    };

    public static SortedList<float, int[]> Meduim4 = new SortedList<float, int[]>()
    {
        {0.5f, new int [2] {-1,-2}},
        {1f, new int [2] {-1,-2}},
        {1.5f, new int [2] {-1,-2}},
        {2f, new int [2] {-1,-2}},
        {2.5f, new int [2] {-1,-2}},
        {3f, new int [2] {-1,-2}},
        {3.5f, new int [2] {-1,-2}},
        {4f, new int [2] {-1,-2}},
        {4.5f, new int [2] {-1,-2}},
        {5f, new int [2] {-1,-2}},
    };


}
