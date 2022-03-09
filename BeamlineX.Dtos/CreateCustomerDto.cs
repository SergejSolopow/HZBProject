using System.ComponentModel.DataAnnotations;

namespace BeamlineX.Dtos
{
    public struct CreateCustomerDto
    {
        [Required(ErrorMessage = "Bitte Name angeben!")]
        public string Name { get; set; }
    }
}
