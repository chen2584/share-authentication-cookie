# share-authentication-cookie

### Test
1. Add these line to C:\Windows\System32\drivers\etc
```
127.0.0.1 chen2584.com
127.0.0.1 api.chen2584.com
```
2. Type dotnet run on `D:\MyWork\DotNet\ShareCookie\src\ShareCookie.Authentication` And `D:\MyWork\DotNet\ShareCookie\src\ShareCookie.WebApi`
3. Visit https://chen2584.com:5001/account/login, Then https://api.chen2584.com:5002/account/info to see claims key and value.