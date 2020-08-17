using MedicalClinic.API;
using MedicalClinic.Models.DTOs;
using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Xunit;

namespace MedicalClinic.IntegrationTest.API
{
    public class AppointmentTests : IClassFixture<TestFixture<Startup>>
    {
        private HttpClient Client;

        public AppointmentTests(TestFixture<Startup> fixture)
        {
            Client = fixture.Client;
        }

        [Fact]
        public async Task TestGetAppointmentsAsync()
        {
            // Arrange
            var request = "/api/appointments";

            // Act
            var response = await Client.GetAsync(request);

            // Assert
            response.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestPostAppointmentsAsync()
        {
            // Arrange
            var request = new
            {
                Url = "/api/appointments",
                Body = new
                {
                    Date = DateTime.Now.AddYears(4),
                    IsCancelled = false,
                    PatientId = 1,
                    Notes = "Test",
                    AppointmentTypeId = 1
                }
            };

            // Act
            var response = await Client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var value = await response.Content.ReadAsStringAsync();
            var appointmentResponse = JsonConvert.DeserializeObject<AppointmentDTO>(value);

            var deleteResponse = await Client.DeleteAsync(string.Format("/api/appointments/{0}", appointmentResponse.Id));

            // Assert
            response.EnsureSuccessStatusCode();
            deleteResponse.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestPostAppointmentsInSameDayAsync()
        {
            // Arrange
            var request = new
            {
                Url = "/api/appointments",
                Body = new
                {
                    Date = DateTime.Now.AddYears(4),
                    IsCancelled = false,
                    PatientId = 1,
                    Notes = "Test",
                    AppointmentTypeId = 1
                }
            };

            var request2= new
            {
                Url = "/api/appointments",
                Body = new
                {
                    Date = DateTime.Now.AddYears(4),
                    IsCancelled = false,
                    PatientId = 1,
                    Notes = "Test",
                    AppointmentTypeId = 1
                }
            };

            // Act
            var response = await Client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));
            var value = await response.Content.ReadAsStringAsync();
            var appointmentResponse1 = JsonConvert.DeserializeObject<AppointmentDTO>(value);

            var response2 = await Client.PostAsync(request.Url, ContentHelper.GetStringContent(request.Body));

            var deleteResponse = await Client.DeleteAsync(string.Format("/api/appointments/{0}", appointmentResponse1.Id));

            // Assert
            response.EnsureSuccessStatusCode();
            Assert.Equal("BadRequest", response2.StatusCode.ToString());
            deleteResponse.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestCancelAppointmentAsync()
        {
            // Arrange
            var postRequest = new
            {
                Url = "/api/appointments",
                Body = new
                {
                    Date = DateTime.Now.AddYears(4),
                    IsCancelled = false,
                    PatientId = 1,
                    Notes = "Test",
                    AppointmentTypeId = 1
                }
            };

            // Act
            var postResponse = await Client.PostAsync(postRequest.Url, ContentHelper.GetStringContent(postRequest.Body));
            var jsonFromPostResponse = await postResponse.Content.ReadAsStringAsync();
            var appointmentResponse = JsonConvert.DeserializeObject<AppointmentDTO>(jsonFromPostResponse);

            var cancelResponse = await Client.PostAsync(string.Format("/api/appointments/{0}/cancel", appointmentResponse.Id), null);
            var deleteResponse = await Client.DeleteAsync(string.Format("/api/appointments/{0}", appointmentResponse.Id));

            // Assert
            postResponse.EnsureSuccessStatusCode();
            cancelResponse.EnsureSuccessStatusCode();
            deleteResponse.EnsureSuccessStatusCode();
        }

        [Fact]
        public async Task TestInvalidCancelAppointmentAsync()
        {
            // Arrange
            var postRequest = new
            {
                Url = "/api/appointments",
                Body = new
                {
                    Date = DateTime.Now,
                    IsCancelled = false,
                    PatientId = 2,
                    Notes = "Test",
                    AppointmentTypeId = 1
                }
            };

            // Act
            var postResponse = await Client.PostAsync(postRequest.Url, ContentHelper.GetStringContent(postRequest.Body));
            var jsonFromPostResponse = await postResponse.Content.ReadAsStringAsync();
            var appointmentResponse = JsonConvert.DeserializeObject<AppointmentDTO>(jsonFromPostResponse);

            var cancelResponse = await Client.PostAsync(string.Format("/api/appointments/{0}/cancel", appointmentResponse.Id), null);
            var deleteResponse = await Client.DeleteAsync(string.Format("/api/appointments/{0}", appointmentResponse.Id));

            // Assert
            postResponse.EnsureSuccessStatusCode();
            Assert.Equal("BadRequest", cancelResponse.StatusCode.ToString());
            deleteResponse.EnsureSuccessStatusCode();
        }

    }

}
