using System.ComponentModel.DataAnnotations;

namespace MicroWms.Api.DTOs;

public class CreateProductRequest
{
    [Required(ErrorMessage = "Артикул обязателен")]
    [MaxLength(50, ErrorMessage = "Артикул не должен превышать 50 символов")]
    public string Article { get; set; } = string.Empty;

    [Required(ErrorMessage = "Название обязательно")]
    [MaxLength(200, ErrorMessage = "Название не должно превышать 200 символов")]
    public string Name { get; set; } = string.Empty;
}
