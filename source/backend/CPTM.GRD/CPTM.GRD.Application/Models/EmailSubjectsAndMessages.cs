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
    public const string ProposicaoDirRespApproveSubject = "Aprovação de Proposição pela Diretoria Responsável";
    public const string ProposicaoDirRespRepproveSubject = "Reprovação de Proposição pela Diretoria Responsável";
    public const string ProposicaoAddToReuniaoSubject = "Inclusão de Proposição em Pauta de Reunião de Diretoria";
    public const string ProposicaoDeliberacaoRdSubject = "Deliberação sobre Proposição em Reunião de Diretoria";
    public const string ProposicaoArquivamentoSubject = "Arquivamento de Proposição";

    public const string AcaoCreationSubject = "Criação de Ação em Reunião de Diretoria";
    public const string AcaoAddAndamentoSubject = "Novo Andamento em Ação";

    public const string UserCreationMessage =
        "Prezado,\n\n Você recebeu acesso ao sistema GRD. Acesse o sistema com seu login de rede na URL http://grd.cptm.info/. \n\n Atenciosamente, GRG";

    public static string ProposicaoCreationMessage(Proposicao proposicao) =>
        $"Prezados,\n\n A área {proposicao.AreaSolicitante.Sigla} criou a Proposição IDPRD {proposicao.IdPrd}, com a seguinte descrição: {proposicao.DescricaoProposicao}.\n Para verificar, acesse o sistema GRD com seu login de rede na URL http://grd.cptm.info/. \n\n Atenciosamente, GRG";

    public static string ProposicaoUpdateMessage(Proposicao proposicao, User responsavel) =>
        $"Prezados,\n\n A Proposição IDPRD {proposicao.IdPrd} foi alterada por {responsavel.Nome} ({responsavel.Email}), e agora tem seguinte descrição: {proposicao.DescricaoProposicao}.\n Para verificar as demais alterações, acesse o sistema GRD com seu login de rede na URL http://grd.cptm.info/. \n\n Atenciosamente, GRG";

    public static string ProposicaoDirRespApproveMessage(Proposicao proposicao, User responsavel) =>
        $"Prezados,\n\n A Proposição IDPRD {proposicao.IdPrd} foi aprovada por {responsavel.Nome} ({responsavel.Email}), e agora está disponível para inclusão em pauta de Reunião de Diretoria.\n Para verificar, acesse o sistema GRD com seu login de rede na URL http://grd.cptm.info/. \n\n Atenciosamente, GRG";

    public static string ProposicaoDirRespRepproveMessage(Proposicao proposicao, User responsavel) =>
        $"Prezados,\n\n A Proposição IDPRD {proposicao.IdPrd} foi reprovada por {responsavel.Nome} ({responsavel.Email}), pelo seguinte motivo:\n\n\"{proposicao.MotivoRetornoDiretoriaResp}\".\n\n Para verificar, acesse o sistema GRD com seu login de rede na URL http://grd.cptm.info/. \n\n Atenciosamente, GRG";

    public static string ProposicaoAddToReuniaoMessage(Proposicao proposicao, Reuniao reuniao) =>
        $"Prezados,\n\n A Proposição IDPRD {proposicao.IdPrd} foi incluída na pauta da Reunião de Diretoria número {reuniao.NumeroReuniao}, a ser realizada em {reuniao.Data}. \n Para verificar, acesse o sistema GRD com seu login de rede na URL http://grd.cptm.info/. \n\n Atenciosamente, GRG";

    public static string ProposicaoDeliberacaoRdMessage(Proposicao proposicao, Reuniao reuniao) =>
        $"Prezados,\n\n A Proposição IDPRD {proposicao.IdPrd} recebeu a seguinte deliberação durante a Reunião de Diretoria número {reuniao.NumeroReuniao}, realizada em {reuniao.Data}:\n\n\"{proposicao.Deliberacao}\".\n \n Para verificar, acesse o sistema GRD com seu login de rede na URL http://grd.cptm.info/. \n\n Atenciosamente, GRG";

    public static string ProposicaoArquivamentoMessage(Proposicao proposicao, User responsavel) =>
        $"Prezados,\n\n A Proposição IDPRD {proposicao.IdPrd} foi arquivada por {responsavel.Nome} ({responsavel.Email}). Nenhuma nova alteração pode ser realizada nesta Proposição.\n Para verificar, acesse o sistema GRD com seu login de rede na URL http://grd.cptm.info/. \n\n Atenciosamente, GRG";

    public static string AcaoCreationMessage(Acao acao, Reuniao reuniao) =>
        $"Prezados,\n\n Na Reunião de Diretoria número {reuniao.NumeroReuniao}, realizada em {reuniao.Data}, foi criada a Ação ID {acao.Id}, com a seguinte descrição: \n\n\"{acao.Definicao}\".\n\n O responsável designado para acompanhamento é {acao.Responsavel.Nome}.\n Para verificar, acesse o sistema GRD com seu login de rede na URL http://grd.cptm.info/. \n\n Atenciosamente, GRG";

    public static string AcaoAddAndamentoMessage(Acao acao, Andamento andamento) =>
        $"Prezados,\n\n {andamento.NomeResponsavel} incluiu um novo andamento na Ação ID {acao.Id}, com a seguinte descrição: \n\n\"{andamento.Descricao}\".\n\n Para verificar, acesse o sistema GRD com seu login de rede na URL http://grd.cptm.info/. \n\n Atenciosamente, GRG";
}