using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DestinyCommunityCenter.EF.DATA//.Metadata
{
    [MetadataType(typeof(ToDoMetadata))]
    public partial class ToDo { }

    class ToDoMetadata
    {
        [Required]
        public string Title { get; set; }
        public string Description { get; set; }
        [Required]
        [DisplayFormat(DataFormatString ="{0:d}")]
        [Display(Name ="Date Added")]
        public System.DateTime DateAdded { get; set; }
        [Required]
        [Display(Name ="Completed?")]
        public bool IsComplete { get; set; }
    }
}
