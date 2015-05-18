using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    public class RollingStock : ICollection<ITrainItem>
    {
        ICollection<ITrainItem> trainItem = new List<ITrainItem>();

        private Nullable<long> GetWagonCount()
        {
            Nullable<long> wagonCount =
            (from train in trainItem
             where !(train is ILocomotive)
             select train)
                .Count();

            return wagonCount;
        }

        private Nullable<long> GetLocomotiveCount()
        {
            Nullable<long> passengerCarsCount =
            (from train in trainItem
             where train is ILocomotive
             select train)
                .Count();

            return passengerCarsCount;
        }

        private Nullable<long> GetPassengerCarsCount()
        {
            Nullable<long> passengerCarsCount =
            (from train in trainItem
             where train is IPassengerCars
             select train)
                .Count();

            return passengerCarsCount;
        }

        private Nullable<long> GetFreightCarsCount()
        {
            Nullable<long> freightCarsCount =
            (from train in trainItem
             where train is IFreightCars
             select train)
                .Count();

            return freightCarsCount;
        }

        public void Add(ITrainItem item)
        {
            if (item is ILocomotive)
            {
                if (GetWagonCount() == 0)
                {
                    trainItem.Add(item);
                }
                else
                {
                    throw new System.ArgumentException();
                }
            }
            else if (item is IPassengerCars)
            {
                if ((GetLocomotiveCount() >0 ) && ((GetWagonCount() == 0) || (GetPassengerCarsCount() > 0)))
                {
                    trainItem.Add(item);
                }
                else
                {
                    throw new System.ArgumentException();
                }
            }
            else if (item is IFreightCars)
            {
                if ((GetLocomotiveCount() >0 ) && ((GetWagonCount() == 0) || (GetFreightCarsCount() > 0)))
                {
                    Console.WriteLine("{0},{1}", GetWagonCount().ToString(), GetFreightCarsCount().ToString());
                    trainItem.Add(item);
                }
                else
                {
                    throw new System.ArgumentException();
                }
            }
            else 
            {
                throw new System.ArgumentException();
            }
    
            
        
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
