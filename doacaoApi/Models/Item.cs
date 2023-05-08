using System.ComponentModel.DataAnnotations;

namespace doacaoApi.Models
{
	public class Item
	{
		[Key]
		[Required]
		public int Id { get; set; }
		[Required]
		[MaxLength(50, ErrorMessage ="O maximo de carateres possiveis é 50")]
		public string Name { get; set; }

        [MaxLength(200, ErrorMessage = "O maximo de carateres possiveis é 200")]
        public string DescricaoLonga { get; set; }

        [MaxLength(50, ErrorMessage = "O maximo de carateres possiveis é 50")]
        public string Condicao { get; set; }

	}
}
