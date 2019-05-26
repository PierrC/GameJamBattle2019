using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatternHolder : MonoBehaviour
{
    private void Awake()
    {
        #region SortedList
        startingPattern = new SortedList<float, int[]>()
     {
        {0.5f, new int [6] {0,1,2,3,4,5}},
        {1f, new int [6] {0,1,2,3,4,5}},
        {1.5f, new int [6] {0,1,2,3,4,5}},
        {2f, new int [6] {0,1,2,3,4,5}},
     };
        easy1 = new SortedList<float, int[]>()
    {
        {0.5f, new int [2] {3,4}},
        {1f, new int [0] {}},
        {1.5f, new int [3] {1,2,3}},
        {2f, new int [0] {}},
        {2.5f, new int [3] {1,4,5}},
    };
        easy2 = new SortedList<float, int[]>()
    {
        {0.5f, new int [0] {}},
        {1f, new int [3] {0,3,5}},
        {1.5f, new int [0] {}},
        {2f, new int [2] {1,4}},
        {2.5f, new int [0] {}},
    };
        easy3 = new SortedList<float, int[]>()
    {
        {0.5f, new int [3] {0,1,2}},
        {1f, new int [0] {}},
        {1.5f, new int [3] {3,4,5}},
        {2f, new int [0] {}},
        {2.5f, new int [2] {2,5}},
    };
        easy4 = new SortedList<float, int[]>()
    {
        {0.5f, new int [3] {0,1,5}},
        {1f, new int [2] {0,1}},
        {1.5f, new int [0] {}},
        {2f, new int [3] {0,1,3}},
        {2.5f, new int [1] {3}},
    };
        easy5 = new SortedList<float, int[]>()
    {
        {0.5f, new int [2] {1,4}},
        {1f, new int [3] {0,4,5}},
        {1.5f, new int [3] {1,3,4}},
        {2f, new int [3] {0,2,4}},
        {2.5f, new int [4] {1,3,4,5}},
    };

        medium1 = new SortedList<float, int[]>()
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
        medium2 = new SortedList<float, int[]>()
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
        medium3 = new SortedList<float, int[]>()
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
        medium4 = new SortedList<float, int[]>()
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
        medium5 = new SortedList<float, int[]>()
    {
        {0.5f, new int [3] {0,1,5}},
        {1f, new int [3] {3,4,2}},
        {1.5f, new int [3] {3,1,2}},
        {2f, new int [3] {0,4,5}},
        {2.5f, new int [3] {0,1,5}},
        {3f, new int [3] {3,4,5}},
        {3.5f, new int [3] {3,1,2}},
        {4f, new int [3] {0,4,5}},
    };

        Hard1 = new SortedList<float, int[]>()
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
        Hard2 = new SortedList<float, int[]>()
    {
        {0.5f, new int [4] {0,1,3, 4}},
        {1f, new int [4] {0,2,3, 5}},
        {1.5f, new int [4] {0,1,2, -2}},
        {2f, new int [4] {3,4,5, -1}},
        {2.5f, new int [4] {0,1,2, -2}},
        {3f, new int [4] {3,4,5, -1}},
        {3.5f, new int [4] {0,1,2, -2}},
        {4f, new int [4] {3,4,5, -1}},
        {4.5f, new int [4] {0,1,2, -2}},
        {5f, new int [4] {3,4,5, -1}},
    };
        Hard3 = new SortedList<float, int[]>()
    {
        {0.75f, new int [5] {0,1,2,3,4}},
        {1.5f, new int [5] {0,1,2,4,5}},
        {2.25f, new int [5] {0,2,3,4,5}},
        {3f, new int [5] {0,1,2,3,5} },
        {3.75f, new int [5] {1,2,3,4,5}},
        {4.5f, new int [5] {0,1,3,4,5}},

    };
        VeryHard = new SortedList<float, int[]>()
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
        #endregion 


        #region PatternData
        startPattern = new PatternData(startingPattern);

        P_easy1 = new PatternData(easy1, true, true);
        P_easy2 = new PatternData(easy2, true, true);
        P_easy3 = new PatternData(easy3, true, true);
        P_easy4 = new PatternData(easy4, true, true);
        P_easy5 = new PatternData(easy5, true, true);

        P_medium1 = new PatternData(medium1);
        P_medium2 = new PatternData(medium2, true, true);
        P_medium3 = new PatternData(medium3, true, true);
        P_medium4 = new PatternData(medium4, false, true);
        P_medium5 = new PatternData(medium5, true, true);

        P_Hard1 = new PatternData(Hard1, true, false);
        P_Hard2 = new PatternData(Hard2, true, false);
        P_Hard3 = new PatternData(Hard3, true, false);
        P_VeryHard = new PatternData(VeryHard, true, false);
        #endregion

        easyPatterns = new PatternData[] { P_easy1, P_easy2,P_easy3,P_easy4,P_easy5 };
        mediumPatterns = new PatternData[] { P_medium1, P_medium2, P_medium3, P_medium4, P_medium5 };
        hardPatterns = new PatternData[] { P_Hard1, P_Hard2, P_Hard3, P_VeryHard };
    }


    public static PatternData[] easyPatterns;
    
    public static PatternData[] mediumPatterns;

    public static PatternData[] hardPatterns;

    public static PatternData startPattern;

    public static PatternData P_easy1;
    public static PatternData P_easy2;
    public static PatternData P_easy3;
    public static PatternData P_easy4;
    public static PatternData P_easy5;

    public static PatternData P_medium1;
    public static PatternData P_medium2;
    public static PatternData P_medium3;
    public static PatternData P_medium4;
    public static PatternData P_medium5;

    public static PatternData P_Hard1;
    public static PatternData P_Hard2;
    public static PatternData P_Hard3;
    public static PatternData P_VeryHard;
    /* -1 => {0,1,2}
     * -2 => {3,4,5}
     * -3 => {0,1,2,3,4,5}
     */
    public static SortedList<float, int[]> startingPattern;

    public static SortedList<float, int[]> easy1;
    public static SortedList<float, int[]> easy2;
    public static SortedList<float, int[]> easy3;
    public static SortedList<float, int[]> easy4;
    public static SortedList<float, int[]> easy5;

    public static SortedList<float, int[]> medium1;
    public static SortedList<float, int[]> medium2;
    public static SortedList<float, int[]> medium3;
    public static SortedList<float, int[]> medium4;
    public static SortedList<float, int[]> medium5;

    static SortedList<float, int[]> Hard1;
    static SortedList<float, int[]> Hard2;
    static SortedList<float, int[]> Hard3;
    static SortedList<float, int[]> VeryHard;


}
