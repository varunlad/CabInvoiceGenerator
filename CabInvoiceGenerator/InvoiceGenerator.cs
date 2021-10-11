using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CabInvoiceGenerator
{
  public  class InvoiceGenerator
    {
        RideType ridetype;
        private readonly double MIN_COST_PER_KM;
        private readonly double COST_PER_TIME;
        private readonly double MIN_FAIR;
        /// <summary>
        /// Initializes a new instance of the <see cref="InvoiceGenerator"/> class.
        /// </summary>
        /// <param name="ridetype">The ridetype.</param>
        /// <exception cref="CabInvoiceGenerator.CabInvoiceException">Invalid Ride Type</exception>
        public InvoiceGenerator(RideType ridetype)
        {
            this.ridetype = ridetype;
            try
            {   if (this.ridetype.Equals(RideType.NORMAL))
                {
                    this.MIN_COST_PER_KM = 10;
                    this.COST_PER_TIME = 1;
                    this.MIN_FAIR = 5;
                }
                if(this.ridetype.Equals(RideType.PRIMIUM))
                {
                    this.MIN_COST_PER_KM = 15;
                    this.COST_PER_TIME = 2;
                    this.MIN_FAIR = 20;
                }
            }
            catch(CabInvoiceException)
            {
                throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_RIDE_TYPE, "Invalid Ride Type");
            }
        }
        /// <summary>
        /// Calculates the fair.
        /// </summary>
        /// <param name="distance">The distance.</param>
        /// <param name="time">The time.</param>
        /// <returns></returns>
        /// <exception cref="CabInvoiceGenerator.CabInvoiceException">
        /// Invalid Distance
        /// or
        /// Invalid Time
        /// </exception>
        public double CalculateFare(double distance,int time)
        {
            double totalFair = 0;
            try
            {
                totalFair = distance * MIN_COST_PER_KM + time * COST_PER_TIME;
            }
            catch(CabInvoiceException)
            {
                if(distance<=0)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_DISTANCE, "Invalid Distance");                    
                }
                if(time<=0)
                {
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.INVALID_TIME, "Invalid Time");
                }
            }
            return Math.Max(totalFair,MIN_FAIR);
        }
        public InvoiceSummary CalculateFare(Ride[] rides)
        {
            double totalFare = 0;
            try
            {
                foreach(Ride ride in rides)
                {
                    totalFare += this.CalculateFare(ride.distance, ride.time);
                }
            }
            catch(CabInvoiceException)
            {
                if (rides == null)
                    throw new CabInvoiceException(CabInvoiceException.ExceptionType.NULL_RIDE, "no ride found");
            }
            return new InvoiceSummary(rides.Length, totalFare);
        }
    }
}
