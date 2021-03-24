

using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineBookstore.Data.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OnlineBookstore.Models
{
    public class BookViewModel
    {
        //Book Data
        public int BookID { get; set; }

        [StringLength(350)]
        public string Title { get; set; }
        public DateTime YearOfIssue { get; set; }
        [StringLength(150)]
        public int NumberOfPages { get; set; }

        public int UserId { get; set; }
        [StringLength(100)]
        public string Genre { get; set; }

        public double Price { get; set; }
        [StringLength(150)]
        public string BookType { get; set; }
        [StringLength(350)]
        public string Description { get; set; }
        [StringLength(100)]
        public string Language { get; set; }
        [StringLength(100)]
        public string Country { get; set; }

        public int Edition { get; set; }
        [StringLength(350)]
        public string Dimensions { get; set; }

        public double Weight { get; set; }

        public int Copies { get; set; }
        [StringLength(50)]
        public string Shipping { get; set; }

        public string MainPhotoURL { get; set; }

        public List<Photo> Photos { get; set; }


        // Author Data

        [StringLength(350)]
        public string AuthorName { get; set; }

        public int AuthorID { get; set; }

        public Author Author { get; set; }

        public IEnumerable<SelectListItem> Authors { get; set; }
        public string CreateAuthorName { get; set; }
        public string CreateAuthorShortDescription { get; set; }


        // Publisher Data

        [StringLength(150)]
        public string PublisherName { get; set; }
        public int PublisherID { get; set; }
        public Publisher Publisher { get; set; }
        [StringLength(350)]
        public string PublisherCountry { get; set; }

        public string CreatePublisherName { get; set; }
        public string CreatePublisherCountry { get; set; }
        public IEnumerable<SelectListItem> Publishers { get; set; }


        // Category Data

        [StringLength(150)]
        public string CategoryName { get; set; }

        public int CategoryID { get; set; }

        public Category Category { get; set; }

        public string CreateCategoryName { get; set; }

        public IEnumerable<SelectListItem> Categories { get; set; }


        // Photos Data

        public string PhotoURL { get; set; }

        public bool IsMainPhoto { get; set; }

        public string DescriptionPhoto { get; set; }

    }
}
