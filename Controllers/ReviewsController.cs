using APIProject.Models;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace APIProjectControllers
{
  [Route("api/[controller]")]
  [ApiController]
  public class ReviewController : ControllerBase
  {
    private APIProjectContext _db;
    public ReviewController(APIProjectContext db)
    {
      _db = db;
    }

    [HttpGet]
    public ActionResult <IEnumerable<Review>> Get(int rating, string city, string country, string filter)
    {
      var query = _db.Reviews.AsQueryable();

      if (rating != null)
      {
        query = query.Where(entry => entry.Rating >= rating);
      }
      if (city != null)
      {
        query = query.Where(entry => entry.City == city);
      }
      if (country != null)
      {
        query = query.Where(entry => entry.Country == country);
      }
      if (filter != null)
      {
        if (filter == "overall_ratings")
        {
          query.OrderBy(x => x.OverallRating);
        }
        else if (filter == "number_of_ratings")
        {
          query.OrderBy(x => x.NumberOfRatings);
        }
      }

      return query.ToList();
    }

    [HttpPost]
    public void Post([FromBody]Review review)
    {
      _db.Add(review);
      _db.SaveChanges();

      var query = _db.Reviews.Where(entry => entry.City == review.City);
      float newOverallRating = 0;
      foreach (Review entry in query)
      {
        newOverallRating += entry.Rating;
      }
      newOverallRating /= query.Count();
      int newNumberOfRatings = query.Count();

      foreach (Review entry in query)
      {
        entry.NumberOfRatings = newNumberOfRatings;
        entry.OverallRating = newOverallRating;
        _db.Entry(entry).State = EntityState.Modified;
      }
      _db.SaveChanges();
    }

    [HttpGet("{id}")]
    public ActionResult <Review> Get(int id)
    {
      return _db.Reviews.FirstOrDefault(entry => entry.ReviewId == id);
    }

    [HttpPut("{id}")]
    public void Put(int id, [FromBody]Review review)
    {
      review.ReviewId = id;
      Review targetReview = _db.Reviews.FirstOrDefault(entry => entry.ReviewId == id);
      if (targetReview.UserName == review.UserName)
      {
        _db.Entry(review).State = EntityState.Modified;
        _db.SaveChanges();
      }
    }    
    [HttpDelete]
    public void Delete(int id, string user_name)
    {
      var reviewToDelete = _db.Reviews.FirstOrDefault(entry => entry.ReviewId == id);
      if (reviewToDelete.UserName == user_name)
      {
        _db.Reviews.Remove(reviewToDelete);
        _db.SaveChanges();
      }
    }
  }
}