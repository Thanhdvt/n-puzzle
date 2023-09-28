using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Puzzle
{
    public static class Settings
    {
        public static int Size { get => _size; set {
                _size = value;
                OnSizeChanged?.Invoke(_size);
            }
        }
        private static int _size = 3;
        public static int TypeHeuristic = 0;
        public static int[] DefaultGoalState = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 0 };
        public static int[] GoalState = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 0 };
        public static int[] StartState = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 0 };
        public static int DelayMove = 200; // ms
        public static int MaxDepthDFS = 1000;
        public static int MaxDepthDLS = 30;
        public static int GameViewSize = 400; // pixels
        public static int MaxSize = 20;
        public static int[] DelayMoveArray;

        public static event Action<int> OnSizeChanged;

        static Settings()
        {
            OnSizeChanged += Settings_OnSizeChanged;
            DelayMoveArray = new int[5] { 1000, 500, 200, 100, 50 };
        }

        private static void Settings_OnSizeChanged(int size)
        {
            DefaultGoalState = new int[size * size];
            for(int i = 0; i < DefaultGoalState.Length; i++)
            {
                DefaultGoalState[i] = i + 1;
            }
            DefaultGoalState[DefaultGoalState.Length - 1] = 0;

            GoalState = (int[])DefaultGoalState.Clone();
            StartState = (int[])DefaultGoalState.Clone();
        }
    }
}
