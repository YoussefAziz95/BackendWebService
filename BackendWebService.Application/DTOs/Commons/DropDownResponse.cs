using Application.Contracts.Persistences;

using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Common
{
    /// <summary>
    /// Represents a response model for dropdown items.
    /// </summary>
    public class DropDownResponse
    {
        /// <summary>
        /// Gets or sets the list of dropdown items.
        /// </summary>
        [Required]
        public Dictionary<int,string> items { get; set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="DropDownResponse"/> class.
        /// </summary>
        public DropDownResponse()
        {
            this.items = new Dictionary<int, string>();
        }
        public DropDownResponse(string[] options)
        {
            this.items = new Dictionary<int, string>();
            for (int i = 0; i < options.Length; i++)
            {
                this.items.Add(i, options[i]);
            }
        }


    }
}

