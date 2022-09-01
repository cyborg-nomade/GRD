using CPTM.GRD.Domain.AccessControl;
using CPTM.GRD.Domain.Acoes;
using CPTM.GRD.Domain.Acoes.Children;
using CPTM.GRD.Domain.Proposicoes;
using CPTM.GRD.Domain.Reunioes;

namespace CPTM.GRD.Application.Models;

public static class EmailSubjectsAndMessages
{
    public const string UserCreationSubject = "Concessão de acesso ao sistema GRD";

    public const string ProposicaoCreationSubject = "Criação de Proposição";
    public const string ProposicaoUpdateSubject = "Alteração de Proposição";

    public const string ProposicaoSendToDiretoriaApprovalSubject =
        "Envio de Proposição para Aprovação da Diretoria Responsável";

    public const string ProposicaoDirRespApproveSubject = "Aprovação de Proposição pela Diretoria Responsável";
    public const string ProposicaoDirRespRepproveSubject = "Reprovação de Proposição pela Diretoria Responsável";
    public const string ProposicaoAddToReuniaoSubject = "Inclusão de Proposição em Pauta de Reunião de Diretoria";
    public const string ProposicaoDeliberacaoRdSubject = "Deliberação sobre Proposição em Reunião de Diretoria";
    public const string ProposicaoArquivamentoSubject = "Arquivamento de Proposição";

    public const string AcaoCreationSubject = "Criação de Ação em Reunião de Diretoria";
    public const string AcaoAddAndamentoSubject = "Novo Andamento em Ação";

    public const string UserCreationMessage =
        @"Prezado,

Você recebeu acesso ao sistema GRD. Acesse o sistema com seu login de rede na URL http://grd.cptm.info/.

Atenciosamente, GRG";

    public static string ProposicaoCreationMessage(Proposicao proposicao) =>
        @$"Prezados,

A área {proposicao.Area?.Sigla} criou a Proposição IDPRD {proposicao.IdPrd}, com a seguinte descrição: {proposicao.DescricaoProposicao}.
Para verificar, acesse o sistema GRD com seu login de rede na URL http://grd.cptm.info/. 

Atenciosamente, GRG";

    public static string ProposicaoUpdateMessage(Proposicao proposicao, User responsavel) =>
        @$"Prezados,

A Proposição IDPRD {proposicao.IdPrd} foi alterada por {responsavel.Nome} ({responsavel.Email}), e agora tem seguinte descrição: {proposicao.DescricaoProposicao}.
Para verificar as demais alterações, acesse o sistema GRD com seu login de rede na URL http://grd.cptm.info/. 

Atenciosamente, GRG";

    public static string ProposicaoSendToDiretorialApprovalMessage(Proposicao proposicao, User responsavel) =>
        @$"Prezados,

A Proposição IDPRD {proposicao.IdPrd} foi encaminhada para aprovação da diretoria responsável por {responsavel.Nome} ({responsavel.Email}).
Para verificar, acesse o sistema GRD com seu login de rede na URL http://grd.cptm.info/. 

Atenciosamente, GRG";

    public static string ProposicaoDirRespApproveMessage(Proposicao proposicao, User responsavel) =>
        @$"Prezados,

A Proposição IDPRD {proposicao.IdPrd} foi aprovada por {responsavel.Nome} ({responsavel.Email}), e agora está disponível para inclusão em pauta de Reunião de Diretoria.
Para verificar, acesse o sistema GRD com seu login de rede na URL http://grd.cptm.info/.

Atenciosamente, GRG";

    public static string ProposicaoDirRespRepproveMessage(Proposicao proposicao, User responsavel) =>
        @$"Prezados,

A Proposição IDPRD {proposicao.IdPrd} foi reprovada por {responsavel.Nome} ({responsavel.Email}), pelo seguinte motivo:

{proposicao.MotivoRetornoDiretoriaResp}.

Para verificar, acesse o sistema GRD com seu login de rede na URL http://grd.cptm.info/. 

Atenciosamente, GRG";

    public static string ProposicaoAddToReuniaoMessage(Proposicao proposicao, Reuniao reuniao) =>
        @$"Prezados,

A Proposição IDPRD {proposicao.IdPrd} foi incluída na pauta da Reunião de Diretoria número {reuniao.NumeroReuniao}, a ser realizada em {reuniao.Data}. 
Para verificar, acesse o sistema GRD com seu login de rede na URL http://grd.cptm.info/. 

Atenciosamente, GRG";

    public static string ProposicaoDeliberacaoRdMessage(Proposicao proposicao, Reuniao reuniao) =>
        @$"Prezados,\n\n A Proposição IDPRD {proposicao.IdPrd} recebeu a seguinte deliberação durante a Reunião de Diretoria número {reuniao.NumeroReuniao}, realizada em {reuniao.Data}:

{proposicao.Deliberacao}.

Para verificar, acesse o sistema GRD com seu login de rede na URL http://grd.cptm.info/. 

Atenciosamente, GRG";

    public static string ProposicaoArquivamentoMessage(Proposicao proposicao, User responsavel) =>
        @$"Prezados,

A Proposição IDPRD {proposicao.IdPrd} foi arquivada por {responsavel.Nome} ({responsavel.Email}). Nenhuma nova alteração pode ser realizada nesta Proposição.
Para verificar, acesse o sistema GRD com seu login de rede na URL http://grd.cptm.info/. 

Atenciosamente, GRG";

    public static string AcaoCreationMessage(Acao acao, Reuniao reuniao) =>
        @$"Prezados,

Na Reunião de Diretoria número {reuniao.NumeroReuniao}, realizada em {reuniao.Data}, foi criada a Ação ID {acao.Id}, com a seguinte descrição: 

{acao.Definicao}

O responsável designado para acompanhamento é {acao.Responsavel?.Nome}.
Para verificar, acesse o sistema GRD com seu login de rede na URL http://grd.cptm.info/. 

Atenciosamente, GRG";

    public static string AcaoAddAndamentoMessage(Acao acao, Andamento andamento) =>
        @$"Prezados,

{andamento.User?.Nome} incluiu um novo andamento na Ação ID {acao.Id}, com a seguinte descrição: 

{andamento.Descricao}

Para verificar, acesse o sistema GRD com seu login de rede na URL http://grd.cptm.info/. 

Atenciosamente, GRG";
}