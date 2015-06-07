﻿using InoDrive.Domain.Models;
using InoDrive.Domain.Models.InputModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InoDrive.Domain.Repositories.Abstract
{
    public interface ITripsRepository
    {
        #region Select

        CarModel GetCar(ShortUserModel model);
        //DetailsTripModel GetDetailsTrip(ManageTripModel model);
        //EditTripModel GetFullTripInfo(ManageTripModel model);
        //ResultFindTripsModel FindTrips(FindTripsPagedOrderModel model);
        //ResultFindTripsModel ExtendFindTrips(ExtendTripsPagedOrderModel model);
        //ResultMyTripsModel GetMyTrips(MyTripsPagedOrderModel model);

        #endregion

        #region Modifications

        void CreateTrip(InputCreateTripModel model);
        //void EditTrip(EditTripModel model);
        //void DeleteTrip(ManageTripModel model);
        //void RecoverTrip(ManageTripModel model);
        //void VoteForTrip(VoteTripModel model);

        #endregion
    }
}