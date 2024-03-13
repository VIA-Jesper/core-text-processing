using System.ComponentModel.DataAnnotations;

namespace DistinctWebAPI.Models.Entities;

public class DistinctWord
{
    [Key] public string Text { get; set; }
}