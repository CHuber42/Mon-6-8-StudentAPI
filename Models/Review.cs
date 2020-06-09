using System.ComponentModel.DataAnnotations;

namespace Destination.Models
{
  public class Review
  {
    public int ReviewId {get; set;}
    [Required]
    [Range(0, 5)]
    public float Rating {get; set;}
    [Required]
    public string City {get; set;}
    [Required]
    public string Country {get; set;}
    [Required]
    public string UserName {get; set;}
    public float? OverallRating {get;set;}
    public int? NumberOfRatings {get;set;}
  }
}