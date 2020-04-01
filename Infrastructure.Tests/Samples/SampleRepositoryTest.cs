using System.Collections.Generic;
using FleetManager.ApplicationCore.Entities;
using FleetManager.Infrastructure.Data;
using Moq;
using Moq.EntityFrameworkCore;
using Xunit;

namespace FleetManager.Infrastructure.Data.Tests.Samples
{
    public class SampleRepositoryTest
    {
        public class GetSamples
        {
            [Fact]
            public void Should_Return_All_Samples()
            {
                //arrange
                var sampleA = new Sample {Name = "BloodSampleA"};
                var sampleB = new Sample {Name = "BloodSampleB"};
                var samples = new List<Sample> {sampleA, sampleB, null};
                var mockContext = new Mock<FleetManagerDbContext>();
                /*
                    mockContext.Setup(x => x.Samples)
                        .ReturnsDbSet(samples);
                    //var repository = new SampleRepository(mockContext.Object);

                    //act
                    //var result = repository.GetSamples();

                    //assert
                    result.Should()
                        .NotBeNull("We do not want to propagate null")
                        .And
                        .HaveCount(3, "There are two in memory samples")
                        .And
                        .ContainInOrder(sampleA, sampleB, null);
                        */
            }
        }
    }
}