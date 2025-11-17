using System;

namespace AgendaBem.Fase5.Domain.Interfaces
{
    // Contract for generating a message text
    public interface IMessageGenerator
    {
        string Generate(string name, string service, DateTime dateTime);
    }
}
