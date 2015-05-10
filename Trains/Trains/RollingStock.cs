using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    public class RollingStock : ICollection<ITrainItem>
    {
        ICollection<ITrainItem> trainItem = new List<ITrainItem>();

        public void Add(ITrainItem item)
        {
            trainItem.Add(item);
        }

        public void Clear()
        {
            trainItem.Clear();
        }

        public bool Contains(ITrainItem item)
        {
            return trainItem.Contains(item);
        }

        public void CopyTo(ITrainItem[] array, int arrayIndex)
        {
            trainItem.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return trainItem.Count; }
        }

        public bool IsReadOnly
        {
            get { return trainItem.IsReadOnly; }
        }

        public bool Remove(ITrainItem item)
        {
            return trainItem.Remove(item);
        }

        public IEnumerator<ITrainItem> GetEnumerator()
        {
            return trainItem.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public IEnumerable<ITrainItem> GetCoachItemByNumber(int startNumber, int endNumber)
        {
            foreach (var i in trainItem)
            {
                if (i is ICoach)
                {
                    ICoach temp = i as ICoach;
                    if ((temp.CoachSeats >= startNumber && temp.CoachSeats <= endNumber))
                    {
                        yield return i;
                    }
                }
            }
        }
    }
}
