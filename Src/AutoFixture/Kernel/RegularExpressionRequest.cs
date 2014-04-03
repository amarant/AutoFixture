using System;
using System.Collections.Generic;
using System.Linq;

namespace Ploeh.AutoFixture.Kernel
{
    /// <summary>
    /// Encapsulates a pattern for a regular expression.
    /// </summary>
    public class RegularExpressionRequest : IEquatable<RegularExpressionRequest>
    {
        private readonly IEnumerable<string> _patterns;
        private readonly int? minLength;
        private readonly int? maxLength;

        /// <summary>
        /// Initializes a new instance of the <see cref="RegularExpressionRequest"/> class.
        /// </summary>
        public RegularExpressionRequest()
        {
            _patterns = new List<string>();
        }


        /// <summary>
        /// Initializes a new instance of the <see cref="RegularExpressionRequest"/> class.
        /// </summary>
        /// <param name="pattern">The pattern.</param>
        public RegularExpressionRequest(string pattern)
        {
            if (pattern == null)
            {
                throw new ArgumentNullException("pattern");
            }

            this._patterns = new List<string> { pattern };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RegularExpressionRequest" /> class.
        /// </summary>
        /// <param name="patterns">The patterns.</param>
        /// <param name="minLength">The minimum length.</param>
        /// <param name="maxLength">The maximum length.</param>
        /// <exception cref="System.ArgumentNullException">pattern</exception>
        public RegularExpressionRequest(IEnumerable<string> patterns, int? minLength, int? maxLength)
        {
            if (patterns == null)
            {
                throw new ArgumentNullException("pattern");
            }

            this._patterns = patterns;
            this.minLength = minLength;
            this.maxLength = maxLength;
        }

        /// <summary>
        /// Gets the regular expression pattern.
        /// </summary>
        public string Pattern
        {
            get
            {
                return this._patterns.FirstOrDefault();
            }
        }

        /// <summary>
        /// Gets the regular expression pattern.
        /// </summary>
        public IEnumerable<string> Patterns
        {
            get
            {
                return this._patterns;
            }
        }

        /// <summary>
        /// Gets or sets the minimum length.
        /// </summary>
        /// <value>
        /// The minimum length.
        /// </value>
        public int? MinLength
        {
            get
            {
                return minLength;
            }
        }

        /// <summary>
        /// Gets or sets the maximum length.
        /// </summary>
        /// <value>
        /// The maximum length.
        /// </value>
        public int? MaxLength
        {
            get
            {
                return maxLength;
            }
        }

        /// <summary>
        /// Determines whether the specified <see cref="System.Object"/> is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="System.Object"/> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="System.Object"/> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        /// <exception cref="T:System.NullReferenceException">
        /// The <paramref name="obj"/> parameter is null.
        ///   </exception>
        public override bool Equals(object obj)
        {
            var other = obj as RegularExpressionRequest;
            if (other != null)
            {
                return this.Equals(other);
            }

            return base.Equals(obj);
        }

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode()
        {
            return this.Pattern.GetHashCode();
        }

        /// <summary>
        /// Indicates whether the current object is equal to another object of the same type.
        /// </summary>
        /// <param name="other">An object to compare with this object.</param>
        /// <returns>
        /// true if the current object is equal to the <paramref name="other"/> parameter; otherwise, false.
        /// </returns>
        public bool Equals(RegularExpressionRequest other)
        {
            if (other == null)
            {
                return false;
            }

            return this.Patterns == other.Patterns
                && this.MaxLength == other.MaxLength
                && this.minLength == other.MinLength;
        }
    }
}