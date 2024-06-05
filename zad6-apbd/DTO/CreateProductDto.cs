using System.ComponentModel.DataAnnotations;

namespace zad6_apbd.DTO
{
    public sealed class CreateProductDto
    {
        [Required(ErrorMessage = "ID Produktu jest wymagane!")]
        public int IdProduct { get; set; }

        [Required(ErrorMessage = "ID magazynu jest wymagane!")]
        public int IdWarehouse { get; set; }

        [Required(ErrorMessage = "Ilość jest wymagana!")]
        [Range(1, int.MaxValue, ErrorMessage = "Ilość powinna być większa od 0!")]
        public int Amount { get; set; }

        [Required(ErrorMessage = "Data jest wymagana!")]
        public DateTime CreatedAt { get; set; }
    }
}