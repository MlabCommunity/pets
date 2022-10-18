using Grpc.Core;

namespace Lapka.Pet.Application.Exceptions;

internal class KrsIsAlreadyTakenException : RpcException
{
    internal KrsIsAlreadyTakenException() : base(new Status(StatusCode.InvalidArgument,"Krs is already taken"))
    {
    }
}