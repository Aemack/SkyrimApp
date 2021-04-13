using NUnit.Framework;
using SkyrimGuide.Models;
using SkyrimGuide.Services;
using System.Collections.Generic;

namespace SkyrimGuideTests
{
    public class MapServiceTests
    {
        MapService _sut;
        [SetUp]
        public void Setup()
        {
            _sut = new MapService();
        }

        [Test]
        public void GivenAValidLocation_SetUpMapReturns_AListofMapRows()
        {
            var testLocation = new Location() { LocationName = "TestName", Coordinates = "[A1]" };
            var result = _sut.SetUpMap(testLocation);
            Assert.That(result, Is.TypeOf(typeof(List<MapRow>)));
        }

        [TestCase ("[A1]", 0,0)]
        [TestCase("[L8]", 7, 11)]
        public void GivenAValidLocation_SetUpMapReturns_AListofMapRows_WithTheCorrectCellOpacity(string coordinates, int row, int columnm)
        {
            var testLocation = new Location() { LocationName = "TestName", Coordinates = coordinates };
            var result = _sut.SetUpMap(testLocation);
            Assert.That(result[row].RowData[columnm].Opacity, Is.EqualTo(0.5));
        }

        [TestCase("[A1]", "MapImage0.png")]
        [TestCase("[L8]", "MapImage95.png")]
        public void GivenAValidLocation_GetMapImageFromCoord_ReturnsTheCorrectImageString(string coordinates, string imageString)
        {
            var result = _sut.GetMapImageFromCoord(coordinates);
            Assert.That(result, Is.EqualTo(imageString));
        }


    }
}