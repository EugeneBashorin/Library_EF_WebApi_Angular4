using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace Entities.Entities
{
    [Serializable]
    [DataContract]
    public class Buklet// : PrintEdition
    {
        [DataMember]
        [Required(ErrorMessage = "Please enter a name")]
        public string Name { get; set; }

        [DataMember]
        [Required(ErrorMessage = "Incorrect value")]
        public int Price { get; set; }

        [DataMember]
        [UIHint("String")]
        [Required(ErrorMessage = "Please enter a publisher")]
        public string Publisher { get; set; }

        [DataMember]
        public int? Id { get; set; }

        [DataMember]
        public string Author { get; set; }
    }
}