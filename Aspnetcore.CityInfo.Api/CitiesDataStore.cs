using System.Collections.Generic;
using Aspnetcore.CityInfo.Api.ViewModels;

namespace Aspnetcore.CityInfo.Api
{
    public static class CitiesDataStore
    {
        public static List<CityViewModel> Cities { get; set; }

        static CitiesDataStore()
        {
            Cities = new List<CityViewModel>()
            {
                new CityViewModel()
                {
                    Id = 1,
                    Name = "New York City",
                    Description = "The one with that big park.",
                    PointsOfInterest = new List<PointOfInterestViewModel>()
                    {
                        new PointOfInterestViewModel()
                        {
                            Id = 1,
                            Name = "Central Park",
                            Description = "The most visited urban park in the United States."
                        },
                        new PointOfInterestViewModel()
                        {
                            Id = 2,
                            Name = "Empire State Building",
                            Description = "A 102-story skyscraper located in Midtown Manhattan."
                        },
                        new PointOfInterestViewModel()
                        {
                            Id = 7,
                            Name = "Statue of Liberty",
                            Description =
                                "The Statue of Liberty is a colossal neoclassical sculpture on Liberty Island in New York Harbor in New York City, in the United States."
                        }
                    }
                },
                new CityViewModel()
                {
                    Id = 2,
                    Name = "Antwerp",
                    Description = "The one with the cathedral that was never really finished.",
                    PointsOfInterest = new List<PointOfInterestViewModel>()
                    {
                        new PointOfInterestViewModel()
                        {
                            Id = 3,
                            Name = "Cathedral of Our Lady",
                            Description = "A Gothic style cathedral, conceived by architects Jan and Pieter Appelmans."
                        },
                        new PointOfInterestViewModel()
                        {
                            Id = 4,
                            Name = "Antwerp Central Station",
                            Description = "The the finest example of railway architecture in Belgium."
                        }
                    }
                },
                new CityViewModel()
                {
                    Id = 3,
                    Name = "Paris",
                    Description = "The one with that big tower.",
                    PointsOfInterest = new List<PointOfInterestViewModel>()
                    {
                        new PointOfInterestViewModel()
                        {
                            Id = 5,
                            Name = "Eiffel Tower",
                            Description =
                                "A wrought iron lattice tower on the Champ de Mars, named after engineer Gustave Eiffel."
                        },
                        new PointOfInterestViewModel()
                        {
                            Id = 6,
                            Name = "The Louvre",
                            Description = "The world's largest museum."
                        }
                    }
                }
            };
        }
    }
}