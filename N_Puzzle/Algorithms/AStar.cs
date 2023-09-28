using System.ComponentModel;
using System.Numerics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace N_Puzzle.Algorithms
{
    public class AStar : ISolver
    {
        public Node GoalNode { get; private set; }

        public SolvingStatus Status { get; private set; }

        public int SolvingTime { get; private set; }

        private HashSet<string> closed;
        PriorityQueue<Node> fringe;


        public AStar()
        {
            closed = new HashSet<string>();
            fringe = new PriorityQueue<Node>();
        }

        public event Action OnSolvingCompleted;
        public event Action OnSolvingFailed;

        public void Solve(int[] start, int[] goal)
        {
            Status = SolvingStatus.Solving;
            var timeStart = DateTime.Now;
            Node startNode = new Node(start);
            fringe = new PriorityQueue<Node>();
            Node.NodesInTree++;
            fringe.Enqueue(startNode);
            Node currentNode;
            closed.Clear();
            while (!fringe.IsEmpty)
            {
                currentNode = fringe.Dequeue();

                if (Utils.IsGoalState(currentNode.state, goal))
                {
                    SolvingTime = (int)(DateTime.Now - timeStart).TotalMilliseconds;
                    GoalNode = currentNode;
                    Status = SolvingStatus.Success;
                    OnSolvingCompleted?.Invoke();
                    return;
                }

                Node.NodesAlreadyEvaluated++;
                closed.Add(Utils.EncodeNode(currentNode.state));
                for (int i = 0; i < 4; i++)
                {
                    if (Utils.TryMove(currentNode, (MoveDirection)i, out Node nextNode) && !CheckIfStateExisted(nextNode.state))
                    {
                        Node.NodesInTree++;
                        fringe.Enqueue(nextNode);
                    }
                }
            }

            SolvingTime = (int)(DateTime.Now - timeStart).TotalMilliseconds;
            GoalNode = null;
            Status = SolvingStatus.Failed;
            OnSolvingFailed?.Invoke();
        }


        private bool CheckIfStateExisted(int[] state)
        {
            return closed.Contains(Utils.EncodeNode(state));
        }
    }
}
