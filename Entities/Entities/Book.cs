using System;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace Entities.Entities
{
    [Serializable]
    [DataContract]
    public class Book // : PrintEdition
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