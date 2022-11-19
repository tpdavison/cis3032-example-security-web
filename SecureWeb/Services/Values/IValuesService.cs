using System;

namespace SecureWeb.Services.Values;

public interface IValuesService
{
    Task<ValuesGetDto> Get();
}
