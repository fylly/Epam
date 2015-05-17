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
            IEnumerable<ITrainItem> coachItemByNumberQuery =
            from train in trainItem
            where train is ICoach && (train as ICoach).CoachSeats >= startNumber && (train as ICoach).CoachSeats <= endNumber
            select train;

            foreach (var i in coachItemByNumberQuery)
            {
                yield return i;
            }
        }

        public Nullable<long> GetCoachSeatsSum()
        {
            Nullable<long> coachSeatsSum =
            (from train in trainItem
             where train is ICoach
             select (train as ICoach).CoachSeats)
                .Sum();

            return coachSeatsSum;            
        }

        public Nullable<long> GetBaggageQuantitySum()
        {
            Nullable<long> baggageQuantitySum =
            (from train in trainItem
             where train is IBaggageCar
             select (train as IBaggageCar).BaggageQuantity)
                .Sum();

            return baggageQuantitySum;
        }

        public void SortByCoachType()
        {
            IEnumerable<ITrainItem> coachItemByNumberQuery =


            (from train in trainItem
             where !(train is ICoach)
             select train).Concat(
            from train in trainItem
            where train is ICoach
            orderby (train as ICoach).CoachType
            select train
            );

            trainItem = coachItemByNumberQuery.ToList();
        }

    }
}
