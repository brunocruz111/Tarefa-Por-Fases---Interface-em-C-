using System;

namespace AgendaBem.Fase5.Domain.Interfaces
{
    // Interface responsável por gerar o texto final de uma mensagem.
    // Esta é a capacidade principal das classes de mensagem.
    public interface IMessageGenerator
    {
        string Generate(string name, string service, DateTime dateTime);
    }
}
