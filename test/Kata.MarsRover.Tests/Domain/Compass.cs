using System.ComponentModel.DataAnnotations;

namespace Kata.MarsRover.Tests.Domain
{
    public enum Compass {
        /// <summary>
        /// North
        /// </summary>
        [Display(Name = "North")]
        N,
        /// <summary>
        /// East
        /// </summary>
        [Display(Name = "East")]
        E,
        /// <summary>
        /// South
        /// </summary>
        [Display(Name = "South")]
        S,
        /// <summary>
        /// West
        /// </summary>
        [Display(Name = "West")]
        W
    }
}