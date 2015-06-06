﻿using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoDrive.Domain.Entities
{
    public class Trip
    {
        public Trip() { }

        public Int32 TripId { get; set; }
        public String UserId { get; set; }
        public DateTimeOffset CreationDate { get; set; }
        public DateTimeOffset LeavingDate { get; set; }
        public DateTimeOffset EndDate { get; set; }
        public Int32 PeopleCount { get; set; }

        public Boolean IsAllowdedDeviation { get; set; }
        public Boolean ISAllowdedPets { get; set; }
        public Boolean IsAllowdedMusic { get; set; }
        public Boolean IsAllowdedEat { get; set; }
        public Boolean IsAllowdedDrink { get; set; }
        public Boolean IsAllowdedSmoke { get; set; }
        public Boolean IsDeleted { get; set; }

        public String About { get; set; }

        public String CarDescription { get; set; }
        public String CarImage { get; set; }
        public String CarImageExtension { get; set; }
        public String CarClass { get; set; }

        [Required]
        [ForeignKey("OriginCity")]
        public Int32 OriginCityId { get; set; }

        [Required]
        [ForeignKey("DestinationCity")]
        public Int32 DestinationCityId { get; set; }

        [Column(TypeName = "Money")]
        public decimal? PayForOne { get; set; }

        public virtual User User { get; set; }
        public virtual Place OriginCity { get; set; }
        public virtual Place DestinationCity { get; set; }

        private ICollection<Like> _likes;
        public virtual ICollection<Like> Likes
        {
            get { return _likes ?? (_likes = new Collection<Like>()); }
            protected set { _likes = value; }
        }

        private ICollection<WayPoint> _wayPoint;
        public virtual ICollection<WayPoint> WayPoints
        {
            get { return _wayPoint ?? (_wayPoint = new Collection<WayPoint>()); }
            set { _wayPoint = value; }
        }

        private ICollection<Bid> _bids;
        public virtual ICollection<Bid> Bids
        {
            get { return _bids ?? (_bids = new Collection<Bid>()); }
            protected set { _bids = value; }
        }

    }
}