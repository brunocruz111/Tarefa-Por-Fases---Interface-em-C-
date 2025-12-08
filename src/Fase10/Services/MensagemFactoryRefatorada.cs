using System;
using System.Collections.Generic;

namespace Fase10.Services;

public interface IMensagem { string Format(string nome, string servico); }

public class MsgConfirmacao : IMensagem 
{ 
    public string Format(string n, string s) => $"Olá {n}, o serviço {s} está confirmado!"; 
}
public class MsgLembrete : IMensagem 
{ 
    public string Format(string n, string s) => $"Lembrete: {n}, tens {s} hoje."; 
}
public class MsgPadrao : IMensagem 
{ 
    public string Format(string n, string s) => $"Olá {n}, contato sobre {s}."; 
}

public class MensagemFactoryRefatorada
{
    private readonly Dictionary<string, Func<IMensagem>> _catalogo = new();

    public MensagemFactoryRefatorada()
    {
        Registrar("confirmacao", () => new MsgConfirmacao());
        Registrar("lembrete", () => new MsgLembrete());
    }

    public void Registrar(string tipo, Func<IMensagem> criador)
    {
        _catalogo[tipo.ToLower()] = criador;
    }

    public IMensagem Criar(string tipo)
    {
        var chave = (tipo ?? "").ToLower();
        return _catalogo.ContainsKey(chave) ? _catalogo[chave]() : new MsgPadrao();
    }
}