using Grpc.Core;

namespace Lapka.Pet.Application.Exceptions;

internal class NipIsAlreadyTakenException : RpcException
{
    internal NipIsAlreadyTakenException() : base(new Status(StatusCode.InvalidArgument, "Nip is already taken"))
    {
    }
}