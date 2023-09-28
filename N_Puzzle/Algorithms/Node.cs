using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Puzzle.Algorithms
{
    [Serializable]
    public class Node: IComparable<Node>
    {
        public static int NodesAlreadyEvaluated = 0;
        public static int NumGeneratedNode = 0;
        public static int NodesInTree = 0;
        public int[] state { get; set; }
        public Node parent { get; set; }
        public int depth { get; set; }
        public int CostH { get => depth; }
        public int CostG { get => Settings.TypeHeuristic == 0 ? manhattanDistance(Settings.GoalState) : numWrongTiles(Settings.GoalState); }
        public int CostF { get => CostH + CostG; }

        public Node(int[] state)
        {
            this.state = state;
            NumGeneratedNode++;
        }

        public Node Clone()
        {
            return new Node(state)
            {
                parent = parent,
                depth = depth
            };
        }

        public void SetParent(Node parent)
        {
            this.parent = parent;
        }

        public static void Reset()
        {
            NumGeneratedNode = 0;
            NodesAlreadyEvaluated = 0;
            NodesInTree = 0;
        }

        public int numWrongTiles(int[] goalState)
        {
            int count = 0;
            for (int i = 0; i < state.Length; i++)
            {
                if (state[i] != goalState[i])
                {
                    count++;
                }
            }
            return count;
        }

        public int manhattanDistance(int[] goalState)
        {
            int result = 0;
            int[] goalIndex = new int[goalState.Length];
            int[] stateIndex = new int[goalState.Length];

            for (int i = 0; i < state.Length; i++)
            {
                goalIndex[goalState[i]] = i;
                stateIndex[state[i]] = i;
            }

            for (int i = 0; i < stateIndex.Length; i++)
            {
                int goalX = goalIndex[i] % Settings.Size;
                int goalY = goalIndex[i] / Settings.Size;
                int stateX = stateIndex[i] % Settings.Size;
                int stateY = stateIndex[i] / Settings.Size;

                result += Math.Abs(goalX - stateX) + Math.Abs(goalY - stateY);
            }

            return result;
        }

        public int CompareTo(Node other)
        {
            int compare1 = other.CostF.CompareTo(this.CostF);
            if(compare1 != 0)
            {
                return compare1;
            }

            return other.CostH.CompareTo(this.CostH);
        }
    }
}
