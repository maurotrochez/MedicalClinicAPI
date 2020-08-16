using AutoMapper;
using MedicalClinic.API;
using MedicalClinic.Business.Services.Services;
using MedicalClinic.DataAccess.Interfaces;
using MedicalClinic.Models.DTOs;
using MedicalClinic.Models.Entities;
using Moq;
using System;
using System.Threading.Tasks;
using Xunit;

namespace MedicalClinic.UnitTest.Services
{
    public class AppointmentServiceTests
    {
        [Fact]
        public async Task SaveAppointment_ReturnsAppointment()
        {
            //Arrrange
            var mockRepo = new Mock<IAppointmentRepository>();
            mockRepo.Setup(repo => repo.SaveAsync()).ReturnsAsync(true);

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });
            var mapper = mockMapper.CreateMapper();

            var service = new AppoinmentService(mockRepo.Object, mapper);

            //Act 
            AppointmentDTO dto = new AppointmentDTO
            {
                AppointmentTypeId = 1,
                Date = DateTime.Now,
                IsCancelled = false,
                Notes = "",
                PatientId = 1,

            };
            var result = await service.Add(dto);

            //Assert
            Assert.NotNull(result);
            Assert.IsType<AppointmentDTO>(result);
        }

        [Fact]
        public async Task SaveAppointment_WithPreviousAppointment_ReturnsThrow()
        {
            //Arrrange
            var mockRepo = new Mock<IAppointmentRepository>();
            mockRepo.Setup(repo => repo.HasAppointment(1, It.IsAny<DateTime>())).Returns(true);

            var mockMapper = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AutoMapperProfile());
            });
            var mapper = mockMapper.CreateMapper();

            var service = new AppoinmentService(mockRepo.Object, mapper);

            //Act 
            AppointmentDTO dto = new AppointmentDTO
            {
                AppointmentTypeId = 1,
                Date = DateTime.Now,
                IsCancelled = false,
                Notes = "",
                PatientId = 1,

            };
            Task act() => service.Add(dto);

            //Assert
            var exception = await Assert.ThrowsAsync<Exception>(act);
            Assert.Equal("This patient has already an appointment for this date", exception.Message);
        }


        [Fact]
        public async Task CancelAppointment_ReturnsTrue()
        {
            //Arrrange
            var mockRepo = new Mock<IAppointmentRepository>();
            mockRepo.Setup(repo => repo.IsCancellable(It.IsAny<long>())).Returns(true);
            mockRepo.Setup(repo => repo.GetById(It.IsAny<long>())).Returns(new Appointment { });

            var mockMapper = new Mock<IMapper>();

            var service = new AppoinmentService(mockRepo.Object, mockMapper.Object);

            //Act 
            var result = await service.CancelAppoiment(It.IsAny<int>());

            //Assert
            Assert.True(result);
        }

        [Fact]
        public async Task CancelAppointment_WithBadTime_ReturnsThrow()
        {
            //Arrrange
            var mockRepo = new Mock<IAppointmentRepository>();
            mockRepo.Setup(repo => repo.IsCancellable(It.IsAny<long>())).Returns(false);

            var mockMapper = new Mock<IMapper>();

            var service = new AppoinmentService(mockRepo.Object, mockMapper.Object);

            //Act
            Task act() => service.CancelAppoiment(It.IsAny<int>());

            //Assert
            var exception = await Assert.ThrowsAsync<Exception>(act);
            Assert.Equal("Appointments must be cancelled at least 24 hours in advance", exception.Message);
        }

    }
}
