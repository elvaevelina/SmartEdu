using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.AspNetCore.Components.Authorization;
using Blazored.LocalStorage;
using SmartEdu.Shared.DTO;


namespace SmartEdu.Shared.Services
{
    public class CustomAuthStateProvider : AuthenticationStateProvider
    {
        private readonly ILocalStorageService _localStorage;
        private const string StorageKey = "UserSession";

        public CustomAuthStateProvider(ILocalStorageService localStorage)
        {
            _localStorage = localStorage;
        }

        public override async Task<AuthenticationState> GetAuthenticationStateAsync()
        {
            try
            {
                // Cek apakah ada data user tersimpan di HP
                var userSession = await _localStorage.GetItemAsync<UserSession>(StorageKey);

                if (userSession == null)
                {
                    // Kalau tidak ada, berarti Logout (Anonymous)
                    return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
                }

                // Kalau ada, buat status Login
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userSession.Username),
                    new Claim(ClaimTypes.Role, userSession.Role)
                };

                var identity = new ClaimsIdentity(claims, "CustomAuth");
                return new AuthenticationState(new ClaimsPrincipal(identity));
            }
            catch
            {
                return new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity()));
            }
        }

        public async Task UpdateAuthenticationState(UserSession? userSession)
        {
            ClaimsPrincipal claimsPrincipal;

            if (userSession != null)
            {
                // LOGIN: Simpan ke storage & Beritahu sistem
                await _localStorage.SetItemAsync(StorageKey, userSession);
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, userSession.Username),
                    new Claim(ClaimTypes.Role, userSession.Role)
                };
                var identity = new ClaimsIdentity(claims, "CustomAuth");
                claimsPrincipal = new ClaimsPrincipal(identity);
            }
            else
            {
                // LOGOUT: Hapus dari storage
                await _localStorage.RemoveItemAsync(StorageKey);
                claimsPrincipal = new ClaimsPrincipal(new ClaimsIdentity());
            }

            NotifyAuthenticationStateChanged(Task.FromResult(new AuthenticationState(claimsPrincipal)));
        }
    }
}

