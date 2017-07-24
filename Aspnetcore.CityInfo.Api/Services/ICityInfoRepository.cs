using System.Collections.Generic;
using System.Linq;
using Aspnetcore.CityInfo.Api.Entities;

namespace Aspnetcore.CityInfo.Api.Services
{
    public interface ICityInfoRepository
    {
        bool CityExists(int cityId);
        IQueryable<City> GetCities();
        City GetCity(int cityId, bool includePointsofInterest);
        IQueryable<PointOfInterest> GetPointsOfInterestForCity(int cityId);
        PointOfInterest GetPointOfInterestForCity(int cityId, int pointOfInterestId);
        void AddPointOfInterestForCity(int cityId, PointOfInterest pointOfInterest);
        void DeletePointOfInterest(PointOfInterest pointOfInterest);
        bool Save();
    }
}
