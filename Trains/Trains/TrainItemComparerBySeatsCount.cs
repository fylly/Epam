using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    public class TrainItemComparerBySeatsCount : IComparer<ITrainItem>
    {
        public int Compare(ITrainItem x, ITrainItem y)
        {
            if (x != null && y != null)
            {
                
                if (!(x is ICoach) && (y is ICoach))
                {                     
                        return 2;
                }
                else if ((x is ICoach) && !(y is ICoach))
                {
                    return -2;
                }
                else if (!(x is ICoach) && !(y is ICoach))
                {
                    return 0;
                }else
                {
                    if (((ICoach)x).CoachType > ((ICoach) y).CoachType)
                    {
                        return 1;
                    }
                    else
                    {
                        return (((ICoach)x).CoachType == ((ICoach)y).CoachType) ? 0 : -1;
                    }
                }
            }
            else
            {
                return (y == null && x == null) ? 0 : (x != null) ? 1 : -1;
            }
        }
    }
}
