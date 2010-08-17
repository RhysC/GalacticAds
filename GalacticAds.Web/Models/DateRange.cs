using System;
using System.Globalization;
using Castle.ActiveRecord;

namespace GalacticAds.Web.Models
{
    /// <summary>
    /// Provides a strucutre for ranges of <see cref="T:System.IComparable"/> values.
    /// </summary>
    /// <typeparam name="T">The type of elements in the range. </typeparam>
    [System.Diagnostics.DebuggerDisplay("Start={Start}; End={End}")]
    public class DateRange
    {
        protected DateRange() { }
        /// <summary>
        /// Initializes a new instance of the <see cref="T:ArtemisWest.Range`1"/> class.
        /// </summary>
        /// <param name="start">The start of the range.</param>
        /// <param name="end">The end of the range.</param>
        /// <exception cref="T:System.ArgumentNullException">Thrown when either parameters are null.</exception>
        /// <exception cref="T:System.ArgumentException">Thrown when <paramref name="start"/> is not less than <paramref name="end"/>.</exception>
        public DateRange(DateTime start, DateTime end)
        {
            if (0 < start.CompareTo(end))
                throw new ArgumentOutOfRangeException("end", "End date must be after the start date");
            StartDate = start;
            EndDate = end;
        }

        /// <summary>
        /// Gets the start value.
        /// </summary>
        /// <value>The start value.</value>
        [Property]
        public DateTime StartDate { get; protected set; }

        /// <summary>
        /// Gets the end value.
        /// </summary>
        /// <value>The end value.</value>
        [Property]
        public DateTime EndDate { get; protected set; }

        /// <summary>
        /// Determines whether the <paramref name="value"/> is contained in this range.
        /// </summary>
        /// <param name="value">The value.</param>
        /// <returns>
        /// 	<c>true</c> if the <paramref name="value"/> exists within this range; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="T:System.ArgumentNullException">Thrown when either the <paramref name="value"/> parameter is null.</exception>
        public bool Contains(DateTime value)
        {
            if (StartDate.CompareTo(value) <= 0 && 0 <= EndDate.CompareTo(value))
                return true;

            return false;
        }

        /// <summary>
        /// Determines whether the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <param name="obj">The <see cref="T:System.Object"/> to compare with the current <see cref="T:System.Object"/>.</param>
        /// <returns>
        /// true if the specified <see cref="T:System.Object"/> is equal to the current <see cref="T:System.Object"/>; otherwise, false.
        /// </returns>
        /// <exception cref="T:System.NullReferenceException">
        /// The <paramref name="obj"/> parameter is null.
        /// </exception>
        public override bool Equals(object obj)
        {
            DateRange value = obj as DateRange;
            if (value == null)
            {
                return false;
            }
            else
            {
                //requires the guard clauses in the ctor.
                return (this.StartDate.Equals(value.StartDate)) && (this.EndDate.Equals(value.EndDate));
            }
        }

        /// <summary>
        /// Serves as a hash function for a particular type.
        /// </summary>
        /// <returns>
        /// A hash code for the current <see cref="T:System.Object"/>.
        /// </returns>
        public override int GetHashCode()
        {
            int startHash = this.StartDate.GetHashCode();
            int endHash = this.EndDate.GetHashCode();
            return startHash ^ endHash;
        }

        /// <summary>
        /// Returns a <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </summary>
        /// <returns>
        /// A <see cref="T:System.String"/> that represents the current <see cref="T:System.Object"/>.
        /// </returns>
        public override string ToString()
        {
            return string.Format(
                CultureInfo.InvariantCulture,
                "{0}{1}Start={2}; End={3};{4}",
                base.ToString(), "{", StartDate, EndDate, "}"
                );
        }
    }
}