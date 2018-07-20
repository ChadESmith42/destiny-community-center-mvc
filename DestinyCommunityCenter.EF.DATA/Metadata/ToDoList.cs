using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DestinyCommunityCenter.EF.DATA//.Metadata
{
    [MetadataType(typeof(ToDoListMetadata))]
    public partial class ToDoList { }

    class ToDoListMetadata
    {   
        [Required]
        [Display(Name ="List Name")]
        public string ListName { get; set; }
    }
}
