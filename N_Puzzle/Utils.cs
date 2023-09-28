using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using N_Puzzle.Properties;
using N_Puzzle.Algorithms;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace N_Puzzle
{
    public static class Utils
    {
        public static bool IsGoalState(int[] state, int[] goalState)
        {
            for (int i = 0; i < state.Length && i < goalState.Length; i++)
            {
                if (state[i] != goalState[i])
                {
                    return false;
                }
            }

            return true;
        }

        public static bool TryMove(Node currentNode, MoveDirection direction, out Node nextNode)
        {
            Node node = Move(currentNode, direction);
            if (node != null)
            {
                nextNode = node;
                return true;
            }

            // Can not move
            nextNode = null;
            return false;
        }

        public static Node Move(Node currentNode, MoveDirection direction)
        {
            int[] currentState = (int[])currentNode.state.Clone();
            int[] newState;
            switch (direction)
            {
                case MoveDirection.Up:
                    newState = MoveUp(currentState);
                    break;
                case MoveDirection.Down:
                    newState = MoveDown(currentState);
                    break;
                case MoveDirection.Left:
                    newState = MoveLeft(currentState);
                    break;
                case MoveDirection.Right:
                    newState = MoveRight(currentState);
                    break;
                default:
                    newState = null;
                    break;
            }

            // Can not move
            if (newState == null)
            {
                return null;
            }

            Node nextNode = new Node(newState)
            {
                parent = currentNode,
                depth = currentNode.depth + 1
            };

            return nextNode;
        }

        private static int[] Move(int[] state, MoveDirection direction)
        {
            int[] newState;
            switch (direction)
            {
                case MoveDirection.Up:
                    newState = MoveUp(state);
                    break;
                case MoveDirection.Down:
                    newState = MoveDown(state);
                    break;
                case MoveDirection.Left:
                    newState = MoveLeft(state);
                    break;
                case MoveDirection.Right:
                    newState = MoveRight(state);
                    break;
                default:
                    newState = null;
                    break;
            }

            return newState;
        }

        private static int[] MoveUp(int[] state)
        {
            int x, y;
            (x, y) = FindZeroPos(state);
            if (y <= 0)
            {
                return null;
            }
            int oldPos = y * Settings.Size + x;
            int newPos = (y - 1) * Settings.Size + x;
            SwapInt(ref state[oldPos], ref state[newPos]);
            return state;
        }

        private static int[] MoveDown(int[] state)
        {
            int x, y;
            (x, y) = FindZeroPos(state);
            if (y >= Settings.Size - 1)
            {
                return null;
            }
            int oldPos = y * Settings.Size + x;
            int newPos = (y + 1) * Settings.Size + x;
            SwapInt(ref state[oldPos], ref state[newPos]);
            return state;
        }

        private static int[] MoveLeft(int[] state)
        {
            int x, y;
            (x, y) = FindZeroPos(state);
            if (x == 0)
            {
                return null;
            }
            int oldPos = y * Settings.Size + x;
            int newPos = y * Settings.Size + x - 1;
            SwapInt(ref state[oldPos], ref state[newPos]);
            return state;
        }

        private static int[] MoveRight(int[] state)
        {
            int x, y;
            (x, y) = FindZeroPos(state);
            if (x == Settings.Size - 1)
            {
                return null;
            }
            int oldPos = y * Settings.Size + x;
            int newPos = y * Settings.Size + x + 1;
            SwapInt(ref state[oldPos], ref state[newPos]);
            return state;
        }

        public static void SwapInt(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        public static (int, int) FindZeroPos(int[] state)
        {
            for (int i = 0; i < state.Length; i++)
            {
                if (state[i] == 0)
                {
                    return (i % Settings.Size, i / Settings.Size);
                }
            }
            return (-1, -1);
        }

        public static bool IsValidState(int[] state)
        {
            if (state.Length != Settings.Size * Settings.Size)
            {
                return false;
            }

            int countZero = 0;

            for (int i = 0; i < state.Length; i++)
            {
                if (state[i] == 0)
                {
                    countZero++;
                    if (countZero > 1)
                    {
                        return false;
                    }
                }
            }

            return countZero == 1;
        }

        public static void Print(int[] state, string stateName = "")
        {
            if (state == null)
            {
                return;
            }

            Console.WriteLine($"================{stateName}=================");
            for (int i = 0; i < state.Length; i++)
            {
                Console.Write(state[i] + " ");
                if (i % Settings.Size == Settings.Size - 1)
                {
                    Console.WriteLine();
                }
            }
        }

        public static int[] Shuffle(int[] state, int iterations)
        {
            Random random = new Random();
            int[] currentState = (int[])state.Clone();

            int num = 0;
            while (num < iterations)
            {
                int direction = random.Next(0, 4);
                if(CanMoveTo((MoveDirection)direction, currentState))
                {
                    currentState = Move(currentState, (MoveDirection)direction);
                    num++;
                }
            }

            return currentState;
        }

        private static bool CanMoveTo(MoveDirection direction, int[] state)
        {
            int x, y;
            (x, y) = FindZeroPos(state);
            switch (direction)
            {
                case MoveDirection.Up:
                    return y > 0;
                case MoveDirection.Down:
                    return y < Settings.Size - 1;
                case MoveDirection.Left:
                    return x > 0;
                case MoveDirection.Right:
                    return x < Settings.Size - 1;
                default:
                    return false;
            }
        }

        public static string EncodeNode(int[] state, int depth = -1)
        {
            byte[] data = new byte[(state.Length + 1) * sizeof(int)];
            byte[] depthBytes = BitConverter.GetBytes(depth);
            Buffer.BlockCopy(state, 0, data, 0, state.Length * sizeof(int));
            Buffer.BlockCopy(depthBytes, 0, data, state.Length * sizeof(int), depthBytes.Length);
            return Encoding.ASCII.GetString(data);
        }

        public static void Swap<T>(this List<T> list, int index1, int index2)
        {
            T temp = list[index1];
            list[index1] = list[index2];
            list[index2] = temp;
        }

        public static long GetSizeOfObject(object o)
        {
            long size = 0;
            using (Stream s = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                formatter.Serialize(s, o);
                size = s.Length;
            }

            return size;
        }
    }
}
