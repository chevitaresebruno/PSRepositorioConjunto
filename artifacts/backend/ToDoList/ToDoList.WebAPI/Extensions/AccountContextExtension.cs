
using MediatR;
using Microsoft.AspNetCore.Mvc;
using RequestAuth = ToDoList.Application.Security.Account.UseCases.Authenticate.Request;
using RequestChangePassword = ToDoList.Application.Security.Account.UseCases.ChangePassword.Request;
using RequestRefreshToken = ToDoList.Application.Security.Account.UseCases.RefreshToken.Request;
using RequestResetPasswordCode = ToDoList.Application.Security.Account.UseCases.SendResetPassword.Request;
using RequestSaveRefreshToken = ToDoList.Application.Security.Account.UseCases.SaveRefreshToken.Request;
using RequestToken = ToDoList.Application.Security.Account.UseCases.Verify.Request;
using RequestUser = ToDoList.Application.Security.Account.UseCases.Create.Request;
using ResponseAuth = ToDoList.Application.Security.Account.UseCases.Authenticate.Response;
using ResponseChangePassword = ToDoList.Application.Security.Account.UseCases.ChangePassword.Response;
using ResponseResetPasswordCode = ToDoList.Application.Security.Account.UseCases.SendResetPassword.Response;
using ResponseSaveRefreshToken = ToDoList.Application.Security.Account.UseCases.SaveRefreshToken.Response;
using ResponseUser = ToDoList.Application.Security.Account.UseCases.Create.Response;

namespace ToDoList.WebApi.Extensions
{
    public static class AccountContextExtension
    {
        // Registra os endpoints
        public static void MapAccountEndpoints(this WebApplication app)
        {
            #region Create
            app.MapPost("api/users", async ([FromBody] RequestUser request, IRequestHandler<RequestUser, ResponseUser> handler) =>
            {
                var result = await handler.Handle(request, new CancellationToken());
                return result.IsSuccess
                    ? Results.Created($"api/users/{result.Data?.id}", result)
                    : Results.Json(result, statusCode: result.Status);
            });
            #endregion

            #region Authenticate
            app.MapPost("api/authenticate", async ([FromBody] RequestAuth request, IRequestHandler<RequestAuth, ResponseAuth> handler,
                 IRequestHandler<RequestSaveRefreshToken, ResponseSaveRefreshToken> handlerRefreshToken) =>
            {
                var result = await handler.Handle(request, new CancellationToken());
                if (!result.IsSuccess)
                    return Results.Json(result, statusCode: result.Status);

                if (result.Data is null)
                    return Results.Json(result, statusCode: 500);

                result.Data.Token = JwtExtension.Generate(result.Data);
                result.Data.RefreshToken = JwtExtension.GenerateRefreshToken();
                result.Data.TokenExpires = DateTime.UtcNow.AddMinutes(110);

                var requestRefreshToken = new RequestSaveRefreshToken(result.Data.Id, result.Data.RefreshToken);
                handlerRefreshToken.Handle(requestRefreshToken, new CancellationToken());

                return Results.Ok(result);
            });
            #endregion

            #region Validate Token
            app.MapPost("api/validate", async ([FromBody] RequestToken request, IRequestHandler<RequestToken, ResponseAuth> handler) =>
            {
                var result = await handler.Handle(request, new CancellationToken());
                if (!result.IsSuccess)
                    return Results.Json(result, statusCode: result.Status);

                if (result.Data is null)
                    return Results.Json(result, statusCode: 500);

                result.Data.Token = JwtExtension.Generate(result.Data);
                return Results.Ok(result);
            });
            #endregion

            #region Refresh Token
            app.MapPost("api/refresh", async ([FromBody] RequestRefreshToken request, IRequestHandler<RequestRefreshToken, ResponseAuth> handler,
                IRequestHandler<RequestSaveRefreshToken, ResponseSaveRefreshToken> handlerRefreshToken) =>
            {
                var result = await handler.Handle(request, new CancellationToken());
                if (!result.IsSuccess)
                    return Results.Json(result, statusCode: result.Status);

                if (result.Data is null)
                    return Results.Json(result, statusCode: 500);

                result.Data.Token = JwtExtension.Generate(result.Data);
                result.Data.RefreshToken = JwtExtension.GenerateRefreshToken();
                result.Data.TokenExpires = DateTime.UtcNow.AddMinutes(110);

                var requestRefreshToken = new RequestSaveRefreshToken(result.Data.Id, result.Data.RefreshToken);
                handlerRefreshToken.Handle(requestRefreshToken, new CancellationToken());

                return Results.Ok(result);
            });
            #endregion

            #region Request Reset Password
            app.MapPost("api/reset/password", async ([FromBody] RequestResetPasswordCode request, IRequestHandler<RequestResetPasswordCode, ResponseResetPasswordCode> handler) =>
            {
                var result = await handler.Handle(request, new CancellationToken());
                return Results.Ok(result);
            });
            #endregion

            #region Change Password
            app.MapPost("api/change/password", async ([FromBody] RequestChangePassword request, IRequestHandler<RequestChangePassword, ResponseChangePassword> handler) =>
            {
                var result = await handler.Handle(request, new CancellationToken());
                return Results.Ok(result);
            });
            #endregion
        }

    }
}