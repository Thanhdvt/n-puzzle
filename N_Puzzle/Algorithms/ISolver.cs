using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Puzzle.Algorithms
{
    public interface ISolver
    {
        Node GoalNode { get; }
        SolvingStatus Status { get; }
        int SolvingTime { get; }
        void Solve(int[] start, int[] goal);
        event Action OnSolvingCompleted;
        event Action OnSolvingFailed;
    }
}
