﻿using InoDrive.Domain.Contexts;
using InoDrive.Domain.Repositories.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoDrive.Domain.Repositories.Concrete
{
    public class BidsRepository : IBidsRepository
    {
        public BidsRepository(InoDriveContext dataContext)
        {
            _ctx = dataContext;
        }

        private InoDriveContext _ctx;

        //private DataContext _ctx;
        //public BidRepository(DataContext dataContext)
        //{
        //    _ctx = dataContext;
        //}

        //#region Section of requests for updating counters, bids

        ///// <summary>
        ///// Get count of unwatched bids owned current user
        ///// </summary>
        ///// <param name="model">user id</param>
        ///// <returns></returns>
        //public Int32 GetCountOfOwnBids(ShortUserModel model)
        //{
        //    var user = _ctx.Users.FirstOrDefault(u => u.Id == model.UserId);
        //    if (user != null)
        //    {
        //        return user.Bids.Count(b => b.IsAccepted != null && !b.IsWatchedByOwnerUser);
        //    }
        //    else
        //    {
        //        throw new RedirectException("Такого пользователя не существует!");
        //    }
        //}

        ///// <summary>
        ///// Get count of unwatched assigned bids of all trips owned current user
        ///// </summary>
        ///// <param name="model">user id</param>
        ///// <returns></returns>
        //public Int32 GetCountOfAssignedBids(ShortUserModel model)
        //{
        //    var user = _ctx.Users.FirstOrDefault(u => u.Id == model.UserId);
        //    if (user != null)
        //    {
        //        return user.Trips.SelectMany(t => t.Bids).Count(b => b.IsAccepted == null);
        //    }
        //    else
        //    {
        //        throw new RedirectException("Такого пользователя не существует!");
        //    }
        //}

        ///// <summary>
        ///// Get unwatched rejected or accepted bids owned current user
        ///// </summary>
        ///// <param name="model">user id</param>
        ///// <returns></returns>
        //public List<UnwatchedBidModel> GetUpdatedOwnBids(ShortUserModel model)
        //{
        //    var user = _ctx.Users.FirstOrDefault(u => u.Id == model.UserId);
        //    if (user != null)
        //    {
        //        var bids = user.Bids.Where(b => b.IsAccepted != null && !b.IsWatchedByOwnerUser).Select(n => new UnwatchedBidModel
        //        {
        //            BidId = n.BidId,
        //            IsAccepted = n.IsAccepted ?? false
        //        }).ToList<UnwatchedBidModel>();
        //        return bids;
        //    }
        //    else
        //    {
        //        throw new RedirectException("Нет такого пользователя!");
        //    }
        //}

        ///// <summary>
        ///// Get assigned unwatched bids of all trips owned current user
        ///// </summary>
        ///// <param name="model"></param>
        ///// <returns></returns>
        //public List<BidForMyTripModel> GetUpdatedAssignedBids(LoadBidsModel model)
        //{
        //    var user = _ctx.Users.FirstOrDefault(u => u.Id == model.UserId);
        //    if (user != null)
        //    {
        //        IEnumerable<Bid> bids;
        //        if (model.FromId != 0)
        //        {
        //            bids =
        //                user.
        //                Trips.
        //                SelectMany(b => b.Bids).
        //                Where(b => b.IsAccepted == null).
        //                OrderByDescending(b => b.CreationDate).
        //                TakeWhile(b => b.BidId != model.FromId);
        //        }
        //        else
        //        {
        //            bids =
        //                user.
        //                Trips.
        //                SelectMany(b => b.Bids).
        //                Where(b => b.IsAccepted == null).
        //                OrderByDescending(b => b.CreationDate);
        //        }
        //        var result = bids.Select(b => new BidForMyTripModel
        //        {
        //            FirstName = b.User.FirstName,
        //            LastName = b.User.LastName,

        //            BidId = b.BidId,

        //            UserClaimed = new UserModel
        //            {
        //                UserId = b.UserId,
        //                FirstName = b.User.FirstName,
        //                LastName = b.User.LastName
        //            },

        //            TripId = b.TripId,
        //            LeavingDate = b.Trip.LeavingDate,
        //            CreationDate = b.CreationDate,
        //            Pay = b.Trip.PayForOne,

        //            OriginCity = new CityModel
        //            {
        //                CityId = b.Trip.OriginCityId,
        //                CityName = b.Trip.OriginCity.RuCityName,
        //                RegionName = b.Trip.OriginCity.Region.RuRegionName
        //            },

        //            DestinationCity = new CityModel
        //            {
        //                CityId = b.Trip.DestinationCityId,
        //                CityName = b.Trip.DestinationCity.RuCityName,
        //                RegionName = b.Trip.DestinationCity.Region.RuRegionName
        //            },

        //            TotalPlaces = b.Trip.PeopleCount,
        //            FreePlaces = b.Trip.PeopleCount - b.Trip.Bids.Count(bb => bb.IsAccepted == true),

        //            Age = b.User.UserProfile == null ? (Int32?)null : b.User.UserProfile.Age,
        //            CountTrips =
        //                b.User.Trips.Count(
        //                    t => !t.IsDeleted &&
        //                    t.LeavingDate.Date < DateTime.Now.Date &&
        //                    t.Bids.Any(bb => bb.IsAccepted == true)) +
        //                b.User.Bids.Count(bb => bb.IsAccepted == true && bb.Trip.LeavingDate.Date < DateTime.Now.Date),

        //            PublicEmail = b.User.UserProfile == null ? null : b.User.UserProfile.PublicEmail,
        //            Phone = b.User.UserProfile == null ? null : b.User.UserProfile.Phone,
        //            Info = b.User.UserProfile == null ? null : b.User.UserProfile.About,
        //            AvatarImage = b.User.UserProfile == null ? null : b.User.UserProfile.AvatarImage,
        //            Rating =
        //                ((double)b.User.Trips.SelectMany(t => t.Likes).Select(l => l.Vote).Sum()
        //                / (double)b.User.Trips.SelectMany(t => t.Likes).Count() * 5) * 100

        //        }).ToList<BidForMyTripModel>();

        //        return result;
        //    }
        //    else
        //    {
        //        throw new RedirectException("Нет такого пользователя!");
        //    }
        //}

        //#endregion

        //#region Section of main requests for select bids

        ///// <summary>
        ///// Get bids for trips of current user
        ///// </summary>
        ///// <param name="model">user id, page, count per page, sort order</param>
        ///// <returns></returns>
        //public ResultBidsForMyTripsModel GetBidsForMyTrips(BidsForMyTripsPagedOrderModel model)
        //{
        //    var result = new ResultBidsForMyTripsModel();
        //    var countExcluded = Math.Max(model.CountExcluded, 0);

        //    var user = _ctx.Users.FirstOrDefault(u => u.Id == model.UserId);
        //    if (user != null)
        //    {
        //        var page = Math.Max(model.PageModel.Page, 1);
        //        IQueryable<Bid> bids;

        //        if (model.FromId != null)
        //        {
        //            bids =
        //                user.
        //                Trips.
        //                SelectMany(b => b.Bids).
        //                OrderByDescending(b => b.CreationDate).
        //                SkipWhile(b => b.BidId != model.FromId).Where(b => b.IsAccepted == null).AsQueryable();
        //        }
        //        else
        //        {
        //            bids =
        //                user.
        //                Trips.
        //                SelectMany(b => b.Bids).
        //                Where(b => b.IsAccepted == null).
        //                OrderByDescending(b => b.CreationDate).AsQueryable();
        //        }

        //        var totalCount = bids.Count();

        //        if (totalCount != 0)
        //        {
        //            result.TotalCount = totalCount;

        //            var resultBids = bids.Select(b => new BidForMyTripModel
        //            {
        //                FirstName = b.User.FirstName,
        //                LastName = b.User.LastName,
        //                BidId = b.BidId,

        //                UserClaimed = new UserModel
        //                {
        //                    UserId = b.UserId,
        //                    FirstName = b.User.FirstName,
        //                    LastName = b.User.LastName
        //                },

        //                TripId = b.TripId,
        //                LeavingDate = b.Trip.LeavingDate,
        //                CreationDate = b.CreationDate,
        //                Pay = b.Trip.PayForOne,

        //                OriginCity = new CityModel
        //                {
        //                    CityId = b.Trip.OriginCityId,
        //                    CityName = b.Trip.OriginCity.RuCityName,
        //                    RegionName = b.Trip.OriginCity.Region.RuRegionName
        //                },

        //                DestinationCity = new CityModel
        //                {
        //                    CityId = b.Trip.DestinationCityId,
        //                    CityName = b.Trip.DestinationCity.RuCityName,
        //                    RegionName = b.Trip.DestinationCity.Region.RuRegionName
        //                },

        //                TotalPlaces = b.Trip.PeopleCount,
        //                FreePlaces = b.Trip.PeopleCount - b.Trip.Bids.Count(bb => bb.IsAccepted == true),

        //                Age = b.User.UserProfile == null ? (Int32?)null : b.User.UserProfile.Age,
        //                CountTrips =
        //                    b.User.Trips.Count(
        //                        t => !t.IsDeleted &&
        //                        t.LeavingDate.Date < DateTime.Now.Date &&
        //                        t.Bids.Any(bb => bb.IsAccepted == true)) +
        //                    b.User.Bids.Count(bb => bb.IsAccepted == true && bb.Trip.LeavingDate.Date < DateTime.Now.Date),

        //                PublicEmail = b.User.UserProfile == null ? null : b.User.UserProfile.PublicEmail,
        //                Phone = b.User.UserProfile == null ? null : b.User.UserProfile.Phone,
        //                Info = b.User.UserProfile == null ? null : b.User.UserProfile.About,
        //                AvatarImage = b.User.UserProfile == null ? null : b.User.UserProfile.AvatarImage,
        //                Rating = ((double)b.User.Trips.SelectMany(t => t.Likes).Select(l => l.Vote).Sum() /
        //                          (double)(b.User.Trips.SelectMany(t => t.Likes).Count() * 5)) * 100
        //            })
        //            .Skip(model.PageModel.PerPage * (page - 1) - countExcluded).Take(model.PageModel.PerPage)
        //            .ToList<BidForMyTripModel>();

        //            result.BidsForMyTrips = resultBids;
        //        }
        //        return result;
        //    }
        //    else
        //    {
        //        throw new RedirectException("Такого пользователя не существует!");
        //    }
        //}

        ///// <summary>
        ///// Get bids of current user
        ///// </summary>
        ///// <param name="model">user id, page, count per page, sort order</param>
        ///// <returns></returns>
        //public ResultMyBidsModel GetMyBids(MyBidsPagedOrderModel model)
        //{
        //    var result = new ResultMyBidsModel();

        //    var user = _ctx.Users.FirstOrDefault(u => u.Id == model.UserId);
        //    if (user != null)
        //    {
        //        var page = Math.Max(model.PageModel.Page, 1);
        //        List<Bid> waitedBids;
        //        if (model.ShowEnded)
        //        {
        //            waitedBids = user.Bids.ToList<Bid>();
        //        }
        //        else
        //        {
        //            waitedBids = user.Bids.Where(b => b.Trip.LeavingDate >= DateTime.Now.Date).ToList<Bid>();
        //        }
        //        var totalCount = waitedBids.Count();

        //        if (totalCount != 0)
        //        {
        //            result.TotalCount = totalCount;

        //            var resultBids = waitedBids.Select(b => new MyBidModel
        //            {
        //                BidId = b.BidId,

        //                UserOwner = new UserModel
        //                {
        //                    UserId = b.Trip.UserId,
        //                    FirstName = b.Trip.User.FirstName,
        //                    LastName = b.Trip.User.LastName
        //                },

        //                TripId = b.TripId,
        //                LeavingDate = b.Trip.LeavingDate,
        //                CreationDate = b.CreationDate,

        //                OriginCity = new CityModel
        //                {
        //                    CityId = b.Trip.OriginCityId,
        //                    CityName = b.Trip.OriginCity.RuCityName,
        //                    RegionName = b.Trip.OriginCity.Region.RuRegionName
        //                },

        //                DestinationCity = new CityModel
        //                {
        //                    CityId = b.Trip.DestinationCityId,
        //                    CityName = b.Trip.DestinationCity.RuCityName,
        //                    RegionName = b.Trip.DestinationCity.Region.RuRegionName
        //                },

        //                TotalPlaces = b.Trip.PeopleCount,
        //                FreePlaces = b.Trip.PeopleCount - b.Trip.Bids.Count(bb => bb.IsAccepted == true),

        //                IsAccepted = b.IsAccepted,
        //                IsWatched = b.IsWatchedByOwnerUser,
        //                WasTripDeleted = b.Trip.IsDeleted
        //            })
        //            .OrderByDescending(d => d.CreationDate)
        //            .Skip(model.PageModel.PerPage * (page - 1)).Take(model.PageModel.PerPage)
        //            .ToList<MyBidModel>();

        //            result.MyBids = resultBids;
        //        }
        //        return result;
        //    }
        //    else
        //    {
        //        throw new RedirectException("Такого пользователя не существует!");
        //    }
        //}

        //#endregion

        //#region Add or update some bids entities

        //public void AddBid(ManageTripModel model)
        //{
        //    var user = _ctx.Users.FirstOrDefault(u => u.Id == model.UserId);
        //    if (user != null)
        //    {
        //        var trip = _ctx.Trips.FirstOrDefault(t => t.TripId == model.TripId);
        //        if (trip != null)
        //        {
        //            if (trip.IsDeleted)
        //            {
        //                throw new AlertException("Нельзя подать заявку на эту поездку, т.к. она была удалена!");
        //            }
        //            if (trip.LeavingDate.Date < DateTime.Now.Date)
        //            {
        //                throw new AlertException("Нельзя подать заявку на эту поездку, т.к. поездка уже завершена!");
        //            }
        //            if (trip.UserId != model.UserId)
        //            {
        //                var bid = trip.Bids.FirstOrDefault(b => b.UserId == model.UserId);
        //                if (bid == null)
        //                {
        //                    bid = new Bid
        //                    {
        //                        CreationDate = DateTime.Now,
        //                        UserId = model.UserId
        //                    };
        //                    trip.Bids.Add(bid);
        //                    _ctx.SaveChanges();
        //                }
        //                else
        //                {
        //                    throw new AlertException("Вы уже подали заявку на эту поездку!");
        //                }
        //            }
        //            else
        //            {
        //                throw new AlertException("Вы не можете подать заявку на свою же поездку!");
        //            }
        //        }
        //        else
        //        {
        //            throw new RedirectException("Такой поездки не существует!");
        //        }
        //    }
        //    else
        //    {
        //        throw new RedirectException("Такого пользователя не существует!");
        //    }
        //}
        //public void AcceptBid(ManageBidModel model)
        //{
        //    var user = _ctx.Users.FirstOrDefault(u => u.Id == model.UserOwnerId);
        //    if (user != null)
        //    {
        //        var trip = user.Trips.FirstOrDefault(t => t.TripId == model.TripId);
        //        if (trip != null)
        //        {
        //            var bid = trip.Bids.FirstOrDefault(b => b.UserId == model.UserClaimedId);
        //            if (bid != null)
        //            {
        //                var freePlaces = bid.Trip.PeopleCount - bid.Trip.Bids.Count(bb => bb.IsAccepted == true);
        //                if (freePlaces > 0)
        //                {
        //                    bid.IsAccepted = true;
        //                    _ctx.SaveChanges();
        //                }
        //                else
        //                {
        //                    throw new AlertException("Вы не можете принять заявку, т.к. уже не осталось свободных мест!");
        //                }
        //            }
        //            else
        //            {
        //                throw new AlertException("Вы не можете принять несуществующую заявку!");
        //            }
        //        }
        //        else
        //        {
        //            throw new RedirectException("У этого пользователя нет такой поездки!");
        //        }
        //    }
        //    else
        //    {
        //        throw new RedirectException("Такого пользователя не существует!");
        //    }
        //}
        //public void RejectBid(ManageBidModel model)
        //{
        //    var user = _ctx.Users.FirstOrDefault(u => u.Id == model.UserOwnerId);
        //    if (user != null)
        //    {
        //        var trip = user.Trips.FirstOrDefault(t => t.TripId == model.TripId);
        //        if (trip != null)
        //        {
        //            var bid = trip.Bids.FirstOrDefault(b => b.UserId == model.UserClaimedId);
        //            if (bid != null)
        //            {
        //                bid.IsAccepted = false;
        //                _ctx.SaveChanges();
        //            }
        //            else
        //            {
        //                throw new AlertException("Вы не можете отклонить несуществующую заявку!");
        //            }
        //        }
        //        else
        //        {
        //            throw new RedirectException("У этого пользователя нет такой поездки!");
        //        }
        //    }
        //    else
        //    {
        //        throw new RedirectException("Такого пользователя не существует!");
        //    }
        //}
        //public void WatchBid(ManageBidModel model)
        //{
        //    var user = _ctx.Users.FirstOrDefault(u => u.Id == model.UserOwnerId);
        //    if (user != null)
        //    {
        //        var bid = user.Bids.FirstOrDefault(b => b.BidId == model.BidId);
        //        if (bid != null)
        //        {
        //            bid.IsWatchedByOwnerUser = true;
        //            _ctx.SaveChanges();
        //        }
        //        else
        //        {
        //            throw new AlertException("У этого пользователя нет такой заявки!");
        //        }
        //    }
        //    else
        //    {
        //        throw new RedirectException("Такого пользователя не существует!");
        //    }
        //}

        //#endregion
    }
}
