using CollaboratorService.Application.DTOs;
using CollaboratorService.Application.Interfaces;
using System.Net.Http.Json;

namespace CollaboratorService.Infrastructure.Clients
{
    public class UserServiceClient : IUserServiceClient
    {
        private readonly HttpClient _httpClient;

        public UserServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<long?> GetUserIdByEmail(string email)
        {
            var response =
                await _httpClient.GetFromJsonAsync<UserResponseDto>(
                    $"api/User/email/{email}");

            return response?.UserId;
        }
    }
}