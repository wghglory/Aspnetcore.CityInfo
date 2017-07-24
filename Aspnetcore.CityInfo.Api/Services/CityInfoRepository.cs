using System.Collections.Generic;
using System.Linq;
using Aspnetcore.CityInfo.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Aspnetcore.CityInfo.Api.Services
{
    public class CityInfoRepository : ICityInfoRepository
    {
        private readonly AppDbContext _context;

        public CityInfoRepository(AppDbContext context)
        {
            _context = context;
        }

        public void AddPointOfInterestForCity(int cityId, PointOfInterest pointOfInterest)
        {
            var city = GetCity(cityId, false);
            city.PointsOfInterest.Add(pointOfInterest);
        }

        public bool CityExists(int cityId)
        {
            return _context.Cities.Any(c => c.Id == cityId);
        }

        public IQueryable<City> GetCities()
        {
            return _context.Cities.OrderBy(c => c.Name);
        }

        public City GetCity(int cityId, bool includePointsOfInterest)
        {
            if (includePointsOfInterest)
            {
                return _context.Cities.Include(c => c.PointsOfInterest).FirstOrDefault(c => c.Id == cityId);
            }

            return _context.Cities.FirstOrDefault(c => c.Id == cityId);
        }

        public PointOfInterest GetPointOfInterestForCity(int cityId, int pointOfInterestId)
        {
            return _context.PointsOfInterest.FirstOrDefault(p => p.CityId == cityId && p.Id == pointOfInterestId);
        }

        public IQueryable<PointOfInterest> GetPointsOfInterestForCity(int cityId)
        {
            return _context.PointsOfInterest.Where(p => p.CityId == cityId);
        }

        public void DeletePointOfInterest(PointOfInterest pointOfInterest)
        {
            _context.PointsOfInterest.Remove(pointOfInterest);
        }

        public bool Save()
        {
            return (_context.SaveChanges() >= 0);
        }
    }
}