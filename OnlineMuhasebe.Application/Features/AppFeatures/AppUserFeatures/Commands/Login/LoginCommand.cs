using OnlineMuhasebe.Application.Messaging;

namespace OnlineMuhasebe.Application.Features.AppFeatures.AppUserFeatures.Commands.Login;

public sealed record LoginCommand(
    string EmailOrUserName,
    string Password) : ICommand<LoginCommandResponse>;
