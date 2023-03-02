using OnlineMuhasebe.Application.Messaging;

namespace OnlineMuhasebe.Application.Features.AppFeatures.AppUserFeatures.Login;

public sealed record LoginCommand(
    string EmailOrUserName,
    string Password) : ICommand<LoginCommandResponse>;
