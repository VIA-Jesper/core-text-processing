using System.ComponentModel.DataAnnotations;

namespace DistinctWebAPI.Models.Entities;

public class WatchlistWord
{
    [Key] public string Word { get; set; }
}